using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeckRecord : MonoBehaviour
{
    // [SerializeField] List<BaseCard> DeckCard;
    public GameObject card;
    private void Awake() {
        // DeckCard=GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck;
    }

    public void SaveDeck()
    { 
        GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck=new List<BaseCard>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount !=0)
            {
                GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck.Add(transform.GetChild(i).GetChild(0).GetComponent<Card>().CardSO);

            }

        }
    }
    public void LoadDeck()
    {
        for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck.Count; i++)
        {
            // transform.GetChild(i);

            GameObject newCard = Instantiate(card, transform.GetChild(i).transform);
            newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck[i];
            // newCard.transform.SetParent(Layout.transform);

        }
    }
    public void ClearDeck()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount != 0)
            {

                Destroy(transform.GetChild(i).GetChild(0).gameObject);
            }
        }
    }
}
