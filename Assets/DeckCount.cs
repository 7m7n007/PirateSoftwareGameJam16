using UnityEngine;

public class DeckCount : MonoBehaviour
{
    [SerializeField] StateChecker stateChecker;
    [SerializeField] GameObject GameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController = GameObject.FindWithTag("GameController");

    }

    // Update is called once per frame
    void Update()
    {
        // print("hi");
        // print(GameController.GetComponent<CardsData>().UnlockedCards.Count);
        if (GameController.GetComponent<CardsData>().UnlockedCards.Count >= 5)
        {
            stateChecker.changeState();
        }
    }
}
