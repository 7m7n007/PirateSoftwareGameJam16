using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class allcards:MonoBehaviour
{
    public List<BaseCard> Allcards;
    public GameObject Layout;
    public GameObject card;
    public void Start()
    {
       for (int i = 0; i < Layout.transform.childCount; i++){
        // transform.GetChild(i);

        GameObject newCard = Instantiate(card, Layout.transform.GetChild(i).transform);
        newCard.GetComponent<CardSlot>().CardSO = Allcards[i];
        // newCard.transform.SetParent(Layout.transform);

       }
    }

}
