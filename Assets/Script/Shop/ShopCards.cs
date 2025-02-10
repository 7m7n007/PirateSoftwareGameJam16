using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopCards:MonoBehaviour
{
    [SerializeField] List<BaseCard> shopCards;
    public GameObject Layout;
    public GameObject card;
    private void Awake() {
        shopCards=GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards;
    }
    public void Start()
    {
       for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Count; i++){
        // transform.GetChild(i);

        GameObject newCard = Instantiate(card, Layout.transform.GetChild(i).transform);
        newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards[i];
        // newCard.transform.SetParent(Layout.transform);

       }
    }

}
