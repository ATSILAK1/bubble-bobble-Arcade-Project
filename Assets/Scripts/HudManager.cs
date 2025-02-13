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
        }

        public override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChanged);
        }

        #endregion

        #region Callbacks to GameManager events
        protected override void GameStatisticsChanged(GameStatisticsChangedEvent e)
		{
			lScore.text = "Score : "+e.eScore.ToString();
		}
		#endregion

	}
}