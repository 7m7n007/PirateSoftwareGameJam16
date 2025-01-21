using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject PlayerHand;
    [SerializeField] List<BaseCard> PlayerDeck;
    [SerializeField] GameObject BlankCard;
    // [SerializeField] GameObject EmptySlot;
    public void OnPointerClick(PointerEventData eventData)
    {
        int totalSlots = PlayerHand.transform.childCount;
        for (int i = 0; i < totalSlots; i++)
        {
            if (PlayerHand.transform.GetChild(i).childCount == 0)
            {
                DrawCard(PlayerHand.transform.GetChild(i).transform);
                return;
            }
        }
        GameObject newSlot=PlayerHand.GetComponent<HandScript>().createSlot();
        DrawCard(newSlot.transform);
        
    }
    private void DrawCard(Transform Slot){
        GameObject newCard = Instantiate(BlankCard, Slot);
        newCard.GetComponent<CardSlot>().CardSO = PlayerDeck[Random.Range(0, PlayerDeck.Count)];

    }
}
