using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public CardScriptableObject cardScriptableObject;
    [SerializeField] TMP_Text cardName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardName=GetComponentInChildren<TMP_Text>();
        cardName.text=cardScriptableObject.CardName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
