using TMPro;
using UnityEngine;

public class BuyPack : MonoBehaviour
{
    [SerializeField] GameObject OpeningScene;
    [SerializeField] Transform spawnSlot;
    [SerializeField] TMP_Text cardTxt;
    [SerializeField] int cost;
    public void OpenPack()
    {
        if (GameObject.FindWithTag("GameController").GetComponent<CardsData>().money - cost >= 0)
        {
            GameObject.FindWithTag("GameController").GetComponent<CardsData>().money -= cost;
            if (transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<PackScript>().OpenPack(OpeningScene, spawnSlot, cardTxt);
            }
        }
    }
}
