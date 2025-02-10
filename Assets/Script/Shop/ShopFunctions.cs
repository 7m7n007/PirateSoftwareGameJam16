using UnityEngine;

public class ShopFunctions : MonoBehaviour
{
    public GameObject card;
    public GameObject pack;
    public GameObject CardLayout;
    public GameObject PackLayout;

    public void Start()
    {
       LoadShop(); 
    }
   public void LoadShop()
    
    {
        for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopCards.Count; i++)
        {

            GameObject newCard = Instantiate(card, CardLayout.transform.GetChild(i).transform);
            newCard.GetComponent<Card>().CardSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopCards[i];

        }
        for (int i = 0; i < GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopPacks.Count; i++)
        {

            GameObject newCard = Instantiate(pack, PackLayout.transform.GetChild(i).transform);
            newCard.GetComponent<PackScript>().packSO = GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopPacks[i];

        }

    }
}
