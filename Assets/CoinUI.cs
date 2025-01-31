using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TMP_Text CoinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinText=GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text=GameObject.FindWithTag("GameController").GetComponent<CardsData>().money.ToString();
    }
}
