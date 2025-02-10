using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class allcards:MonoBehaviour
{
    [SerializeField] List<BaseCard> UnlockedCards;
    public GameObject Layout;
    public GameObject card;
    private void Awake() {
        UnlockedCards=GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards;
    }
    public void SaveAllCards()
    { 
        GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards=new List<BaseCard>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount !=0)
            {
                GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Add(transform.GetChild(i).GetChild(0).GetComponent<Card>().CardSO);

            }

        }
    }
    public void LoadAllCards()
    {
        for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Count; i++)
        {
            // transform.GetChild(i);

            GameObject newCard = Instantiate(card, transform.GetChild(i).transform);
            newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards[i];
            // newCard.transform.SetParent(Layout.transform);

        }
    }
    public void ClearAllCards()
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
