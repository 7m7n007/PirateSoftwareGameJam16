using UnityEngine;


public class buyCard : MonoBehaviour 
{
    public void BuyCard()
    {
        // TODO: Implement buying a card functionality
        GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Add(transform.GetChild(0).GetComponent<Card>().CardSO);
        Destroy(transform.GetChild(0).gameObject);
    }

 
}
