namespace STUDENT_NAME
{
    using System.Collections;
    using SDD.Events;
    using UnityEngine;

    public enum GameState { gameMenu, gamePlay, gameNextLevel, gamePause, gameOver, gameVictory }
	

	public class GameManager : Manager<GameManager>
	{
		#region Game State
		private GameState m_GameState;
		public bool IsPlaying { get { return m_GameState == GameState.gamePlay; } }
        #endregion

        #region Mode
		
		private GlobalEnum.TypeOfElement currentModeState = GlobalEnum.TypeOfElement.Dark;
		public GlobalEnum.TypeOfElement CurrentModeState { get { return currentModeState; } }

		void SwapModeState()
		{
			Debug.Log("Mode  Current state "+ currentModeState );
			// better to Call the camera one time than Find it 2 time 
			var camera = GameObject.Find("Main Camera");


            if (currentModeState == GlobalEnum.TypeOfElement.Dark)
			{
				currentModeState = GlobalEnum.TypeOfElement.Light;
                
                camera.GetComponent<Camera>().backgroundColor = Color.gray;
			}
			
			else
			{
				currentModeState = GlobalEnum.TypeOfElement.Dark;
                camera.GetComponent<Camera>().backgroundColor = Color.black;
            }
			Debug.Log("Mode After Swap " + currentModeState);
			

        }


        #endregion

        //LIVES
        #region Lives
        [Header("GameManager")]
		[SerializeField]
		private int m_NStartLives;

		private int m_NLives;
		public int NLives { get { return m_NLives; } }

		private int m_NEnemy; 
		public int NEnemy {  get { return m_NEnemy; } set { m_NEnemy = value; } }
		void DecrementNLives(int decrement)
		{
			SetNLives(m_NLives - decrement);
		}

		void SetNLives(int nLives)
		{
			m_NLives = nLives;
			EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eBestScore = BestScore, eScore = m_Score, eNLives = m_NLives});
		}
		 void DecrementNEnemy()
		{
			NEnemy--;
		}
				
		#endregion

		#region Score
		private float m_Score;
		public float Score
		{
			get { return m_Score; }
			set
			{
				m_Score = value;
				BestScore = Mathf.Max(BestScore, value);
			}
		}

		public float BestScore
		{
			get { return PlayerPrefs.GetFloat("BEST_SCORE", 0); }
			set { PlayerPrefs.SetFloat("BEST_SCORE", value); }
		}

		void IncrementScore(float increment)
		{
			SetScore(m_Score + increment);
		}

		void SetScore(float score, bool raiseEvent = true)
		{
			Score = score;

			if (raiseEvent)
				EventManager.Instance.Raise(new GameStatisticsChangedEvent() { eBestScore = BestScore, eScore = m_Score, eNLives = m_NLives });
		}
		#endregion

		#region Time
		void SetTimeScale(float newTimeScale)
		{
			Time.timeScale = newTimeScale;
		}
		#endregion

		#region Events' subscription
		public override void SubscribeEvents()
		{
			base.SubscribeEvents();
			
			// MainMenuManager
			EventManager.Instance.AddListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
			EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClicked);
			EventManager.Instance.AddListener<ResumeButtonClickedEvent>(ResumeButtonClicked);
			EventManager.Instance.AddListener<EscapeButtonClickedEvent>(EscapeButtonClicked);
			EventManager.Instance.AddListener<QuitButtonClickedEvent>(QuitButtonClicked);

			// Score Item
			EventManager.Instance.AddListener<ScoreItemEvent>(ScoreHasBeenGained);

			// Enemy 
			EventManager.Instance.AddListener<EnemyHasBeenHitEvent>(EnemyKilled);

			// Player
			EventManager.Instance.AddListener<PlayerHasBeenHitEvent>(PlayerHit);

			// Mode Swap 
			EventManager.Instance.AddListener<ModeHasBeenChangedEvent>(ModeChange);
			
		}

		public override void UnsubscribeEvents()
		{
			base.UnsubscribeEvents();

			//MainMenuManager
			EventManager.Instance.RemoveListener<MainMenuButtonClickedEvent>(MainMenuButtonClicked);
			EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClicked);
			EventManager.Instance.RemoveListener<ResumeButtonClickedEvent>(ResumeButtonClicked);
			EventManager.Instance.RemoveListener<EscapeButtonClickedEvent>(EscapeButtonClicked);
			EventManager.Instance.RemoveListener<QuitButtonClickedEvent>(QuitButtonClicked);

			//Score Item
			EventManager.Instance.RemoveListener<ScoreItemEvent>(ScoreHasBeenGained);

			// Enemy 
			EventManager.Instance.RemoveListener<EnemyHasBeenHitEvent> (EnemyKilled);

			//Player 
			EventManager.Instance.RemoveListener<PlayerHasBeenHitEvent>(PlayerHit);
			
			//Mode Swap 
            EventManager.Instance.RemoveListener<ModeHasBeenChangedEvent>(ModeChange);
        }
		#endregion

		#region Manager implementation
		protected override IEnumerator InitCoroutine()
		{
			Menu();
			
			InitNewGame(); // essentiellement pour que les statistiques du jeu soient mise à jour en HUD
            SwapModeState();
            yield break;
		}
		#endregion

		#region Game flow & Gameplay
		//Game initialization
		void InitNewGame(bool raiseStatsEvent = true)
		{
			SetScore(0);
			SetNLives(m_NStartLives);
		}
		#endregion

		#region Callbacks to events issued by Score items
		private void ScoreHasBeenGained(ScoreItemEvent e)
		{
			if (IsPlaying)
				IncrementScore(e.eScore);
		}
		#endregion

		#region Callbacks to Events issued by MenuManager
		private void MainMenuButtonClicked(MainMenuButtonClickedEvent e)
		{
			Menu();
		}

		private void PlayButtonClicked(PlayButtonClickedEvent e)
		{
			Play();
		}

		private void ResumeButtonClicked(ResumeButtonClickedEvent e)
		{
			Resume();
		}

		private void EscapeButtonClicked(EscapeButtonClickedEvent e)
		{
			if (IsPlaying) Pause();
		}

		private void QuitButtonClicked(QuitButtonClickedEvent e)
		{
			Application.Quit();
		}
        #endregion

        #region GameState methods
        private void Menu()
		{
			SetTimeScale(0);
			m_GameState = GameState.gameMenu;
			if(MusicLoopsManager.Instance)MusicLoopsManager.Instance.PlayMusic(Constants.MENU_MUSIC);
			EventManager.Instance.Raise(new GameMenuEvent());
		}

		private void Play()
		{
			InitNewGame();
			SetTimeScale(1);
			m_GameState = GameState.gamePlay;

			if (MusicLoopsManager.Instance) MusicLoopsManager.Instance.PlayMusic(Constants.GAMEPLAY_MUSIC);
			EventManager.Instance.Raise(new GamePlayEvent());
		}

		private void Pause()
		{
			if (!IsPlaying) return;

			SetTimeScale(0);
			m_GameState = GameState.gamePause;
			EventManager.Instance.Raise(new GamePauseEvent());
		}

		private void Resume()
		{
			if (IsPlaying) return;

			SetTimeScale(1);
			m_GameState = GameState.gamePlay;
			EventManager.Instance.Raise(new GameResumeEvent());
		}

		private void Over()
		{
			SetTimeScale(0);
			m_GameState = GameState.gameOver;
			EventManager.Instance.Raise(new GameOverEvent());
			if(SfxManager.Instance) SfxManager.Instance.PlaySfx2D(Constants.GAMEOVER_SFX);
		}
        #endregion

        #region CallBacks To Events issued by Ennemy 

        private void EnemyKilled(EnemyHasBeenHitEvent e)
        {
			IncrementScore(100);
        }

        #endregion

        #region CallBacks To Events issued By Player
        private void PlayerHit(PlayerHasBeenHitEvent e)
		{
		 DecrementNLives(1);
			
		}
        #endregion

        #region CallBacks To Events Issued by Mode Changing 
		private void ModeChange(ModeHasBeenChangedEvent e)
		{
			SwapModeState();
		}
        #endregion
    }
}

