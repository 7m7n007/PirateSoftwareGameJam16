using UnityEngine;

public class ShopFunctions : MonoBehaviour
{
    public GameObject card;
    public GameObject Layout;

    public void Start()
    {
       LoadShop(); 
    }
   public void LoadShop()
    
    {
        for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopCards.Count; i++)
        {

            GameObject newCard = Instantiate(card, Layout.transform.GetChild(i).transform);
            newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopCards[i];

        }
    }
}
