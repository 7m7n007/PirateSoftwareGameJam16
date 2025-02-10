using UnityEngine;


public class buyCard : MonoBehaviour
{
    [SerializeField] int cost;
    public void BuyCard()
    {
        if (GameObject.FindWithTag("GameController").GetComponent<CardsData>().money - cost >= 0)
        {
            GameObject.FindWithTag("GameController").GetComponent<CardsData>().money -= cost;
            GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Add(transform.GetChild(0).GetComponent<Card>().CardSO);
            Destroy(transform.GetChild(0).gameObject);
        }
    }


}
