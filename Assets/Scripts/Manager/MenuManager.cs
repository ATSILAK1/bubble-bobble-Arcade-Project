﻿
namespace STUDENT_NAME
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using SDD.Events;

	public class MenuManager : Manager<MenuManager>
	{

		[Header("MenuManager")]

		#region Panels
		[Header("Panels")]
		[SerializeField] GameObject m_PanelMainMenu;
		[SerializeField] GameObject m_PanelInGameMenu;
		[SerializeField] GameObject m_PanelGameOver;
		[SerializeField] GameObject m_PanelNextLevel;

        List<GameObject> m_AllPanels;
		#endregion

		#region Events' subscription
		public override void SubscribeEvents()
		{
			base.SubscribeEvents();
		}

		public override void UnsubscribeEvents()
		{
			base.UnsubscribeEvents();
		}
		#endregion

		#region Manager implementation
		protected override IEnumerator InitCoroutine()
		{
			yield break;
		}
		#endregion

		#region Monobehaviour lifecycle
		protected override void Awake()
		{
			base.Awake();
			RegisterPanels();
		}

		private void Update()
		{
			if (Input.GetButtonDown("Cancel"))
			{
				Debug.Log("Escape Button Has Been Clicked ");
                EscapeButtonHasBeenClicked();
			}
		}
		#endregion

		#region Panel Methods
		void RegisterPanels()
		{
			m_AllPanels = new List<GameObject>();
			m_AllPanels.Add(m_PanelMainMenu);
			m_AllPanels.Add(m_PanelInGameMenu);
			m_AllPanels.Add(m_PanelGameOver);
			m_AllPanels.Add(m_PanelNextLevel);
        }

		void OpenPanel(GameObject panel)
		{
			foreach (var item in m_AllPanels)
				if (item) item.SetActive(item == panel);
		}
		#endregion

		#region UI OnClick Events
		public void EscapeButtonHasBeenClicked()
		{
			EventManager.Instance.Raise(new EscapeButtonClickedEvent());
		}

		public void PlayButtonHasBeenClicked()
		{
			EventManager.Instance.Raise(new PlayButtonClickedEvent());
			Debug.Log("Play Button Has Been Clicked ");
		}

		public void ResumeButtonHasBeenClicked()
		{
			EventManager.Instance.Raise(new ResumeButtonClickedEvent());
		}

		public void MainMenuButtonHasBeenClicked()
		{
			EventManager.Instance.Raise(new MainMenuButtonClickedEvent());
		}

		public void QuitButtonHasBeenClicked()
		{
			EventManager.Instance.Raise(new QuitButtonClickedEvent());
		}
		public void NextLevelButtonHasBeenClicked()
		{
			Debug.Log("Next Level Button Has Been Clicked ");
            EventManager.Instance.Raise(new NextLevelButtonClickedEvent());
        }
		#endregion

		#region Callbacks to GameManager events
		protected override void GameMenu(GameMenuEvent e)
		{
			OpenPanel(m_PanelMainMenu);
		}

		protected override void GamePlay(GamePlayEvent e)
		{
			OpenPanel(null);
		}

		protected override void GamePause(GamePauseEvent e)
		{
			OpenPanel(m_PanelInGameMenu);
		}

		protected override void GameResume(GameResumeEvent e)
		{
			OpenPanel(null);
		}

		protected override void GameOver(GameOverEvent e)
		{
			OpenPanel(m_PanelGameOver);
		}

        protected override void GameVictory(GameVictoryEvent e)
        {
            OpenPanel(m_PanelNextLevel);
        }
        #endregion
    }

}
