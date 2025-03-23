using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class ShopTutorial : MonoBehaviour
{
    public ShopTutorialState shopTutorialState;
    public bool tutorialComplete;
    public void nextState()
    {
        if ((int)shopTutorialState + 1 < System.Enum.GetValues(typeof(ShopTutorialState)).Length)
        {
            shopTutorialState = shopTutorialState + 1;
            if(shopTutorialState==ShopTutorialState.Completed){
                tutorialComplete=true;
            }
        }
    }
    public void prevState()
    {
        // if(shopTutorialState+1)
        if ((int)shopTutorialState - 1 >= 0)
        {

            shopTutorialState = shopTutorialState - 1;
        }
    }
    public void stateHandler(ShopTutorialState state)
    {
        if(shopTutorialState == state){
            nextState();
            
        }
    }
}
public enum ShopTutorialState
{
    OpenShop,
    BuyCards,
    ExitShop,
    OpenDeck,
    AddCard,
    ExitDeck,
    SelectMission,
    Completed
}
