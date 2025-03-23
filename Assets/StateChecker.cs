using UnityEngine;

public class StateChecker : MonoBehaviour
{
    public ShopTutorial shopTutorial;
    public BattleTutorial battleTutorial;
    public ShopTutorialState shopTutorialState;
    public BattleTutorialState battleTutorialState;
    public bool isBattleTut;
    void Start()
    {
        shopTutorial = GameObject.FindGameObjectWithTag("GameController").GetComponent<ShopTutorial>();
        battleTutorial = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleTutorial>();
    }
    public void changeState()
    {
        if (!isBattleTut)
        {

            if (shopTutorial.tutorialComplete == false)
            {

                shopTutorial.stateHandler(shopTutorialState);
            }
        }
        else
        {
            if (battleTutorial.tutorialComplete == false)
            {

                battleTutorial.stateHandler(battleTutorialState);
            }

        }
    }
}
