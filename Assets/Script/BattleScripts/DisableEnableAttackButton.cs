using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class DisableEnableAttackButton : MonoBehaviour
{private GameObject GameController;
    private int Threshold;
    [SerializeField] Button StartButton;
    [SerializeField] GameObject minCardText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController=GameObject.FindWithTag("GameController");
        Threshold = 5; // change this value to the desired threshold
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameController.GetComponent<CardsData>().Deck.Count >=Threshold ){
            StartButton.interactable=true;
            minCardText.SetActive(false);
        }
        else{
            StartButton.interactable=(false);
            minCardText.SetActive(true);
        }
    }
}
