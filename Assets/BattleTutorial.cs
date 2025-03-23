using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class BattleTutorial : MonoBehaviour
{
    public BattleTutorialState battleTutorialState;
    public bool tutorialComplete;
    public void nextState()
    {
        if ((int)battleTutorialState + 1 < System.Enum.GetValues(typeof(BattleTutorialState)).Length)
        {
            battleTutorialState = battleTutorialState + 1;
            if(battleTutorialState==BattleTutorialState.Completed){
                tutorialComplete=true;
            }
        }
    }
    public void prevState()
    {
        // if(shopTutorialState+1)
        if ((int)battleTutorialState - 1 >= 0)
        {

            battleTutorialState = battleTutorialState - 1;
        }
    }
    public void stateHandler(BattleTutorialState state)
    {
        if(battleTutorialState == state){
            nextState();
        }
    }
}

public enum BattleTutorialState
{
    StartBattle,
    DrawCards,
    PlaceCard,
    PressReady,
    EnemyDecides,
    PlayerAttacks,
    EnemyAttacks,
    RoundRestart,
    Completed
}
