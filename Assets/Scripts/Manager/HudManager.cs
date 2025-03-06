namespace STUDENT_NAME
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using SDD.Events;
    using TMPro;
    using System.Diagnostics.Contracts;

    public class HudManager : Manager<HudManager>
	{

		//[Header("HudManager")]
		#region Labels & Values
		[SerializeField]
		private TMP_Text lScore;
		[SerializeField]
		private Image hearthSprite; 
		[SerializeField]
		private GameObject hearthHudHolderGameObject;


		// TO DO
		#endregion
		


		#region Manager implementation
		protected override IEnumerator InitCoroutine()
		{
			yield break;
		}
        public override void SubscribeEvents()
        {
            base.SubscribeEvents();
			EventManager.Instance.AddListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
			EventManager.Instance.AddListener<HealtUpdateHudEvent>(HealthBarChangeCallBack);
        }

        public override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
            EventManager.Instance.RemoveListener<HealtUpdateHudEvent>(HealthBarChangeCallBack);
        }

        #endregion

        #region Callbacks to GameManager events
        protected override void GameStatisticsChanged(GameStatisticsChangedEvent e)
		{
			lScore.text = "Score : "+e.eScore.ToString();



			

		}

		private void HealthBarChangeCallBack(HealtUpdateHudEvent e)
		{
            for (int i = 0; i < hearthHudHolderGameObject.transform.childCount; i++)
            {
                hearthHudHolderGameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < e.eHealth; i++)
            {
				if (e.eHealth == i)
					break;
              hearthHudHolderGameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
		#endregion

	}
}