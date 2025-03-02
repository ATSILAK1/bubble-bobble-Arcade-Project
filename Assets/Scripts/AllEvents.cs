using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

#region GameManager Events
public class GameMenuEvent : SDD.Events.Event
{
}
public class GamePlayEvent : SDD.Events.Event
{
}
public class GamePauseEvent : SDD.Events.Event
{
}
public class GameResumeEvent : SDD.Events.Event
{
}
public class GameOverEvent : SDD.Events.Event
{
}
public class GameVictoryEvent : SDD.Events.Event
{
}

public class GameStatisticsChangedEvent : SDD.Events.Event
{
	public float eBestScore { get; set; }
	public float eScore { get; set; }
	public int eNLives { get; set; }
}
#endregion

#region MenuManager Events
public class EscapeButtonClickedEvent : SDD.Events.Event
{
}
public class PlayButtonClickedEvent : SDD.Events.Event
{
}
public class ResumeButtonClickedEvent : SDD.Events.Event
{
}
public class MainMenuButtonClickedEvent : SDD.Events.Event
{
}

public class QuitButtonClickedEvent : SDD.Events.Event
{ }
#endregion

#region Score Event
public class ScoreItemEvent : SDD.Events.Event
{
	public float eScore;
}
#endregion

#region Enemy Events 

public class EnemyHasBeenHitEvent : SDD.Events.Event { }
#endregion

#region Player Events 

public class PlayerHasBeenHitEvent : SDD.Events.Event { }
#endregion

#region Mode Events  
public class ModeHasBeenChangedEvent : SDD.Events.Event 
{
	public GlobalEnum.TypeOfElement typeOfElement ; 
}
#endregion

public class GoToNextLevelEvent : SDD.Events.Event
{

}

public class LevelHasBeenInstantiatedEvent : SDD.Events.Event
{
	public Level eLevel;
}