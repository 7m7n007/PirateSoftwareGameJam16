using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class allcards:MonoBehaviour
{
    [SerializeField] List<BaseCard> Allcards;
    public GameObject Layout;
    public GameObject card;
    private void Awake() {
        Allcards=GameObject.FindWithTag("GameController").GetComponent<CardsData>().AllCards;
    }
    public void Start()
    {
       for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().AllCards.Count; i++){
        // transform.GetChild(i);

        GameObject newCard = Instantiate(card, Layout.transform.GetChild(i).transform);
        newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().AllCards[i];
        // newCard.transform.SetParent(Layout.transform);

       }
    }

}
