using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject PlayerHand;
    [SerializeField] List<BaseCard> PlayerDeck;
    [SerializeField] GameObject BlankCard;
    [SerializeField] AudioClip DrawCardAudioClip;
    // [SerializeField] GameObject EmptySlot;
    private void Awake()
    {
        PlayerDeck = GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerDeck.Count > 0)
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
            GameObject newSlot = PlayerHand.GetComponent<HandScript>().createSlot();
            DrawCard(newSlot.transform);

        }

        else
        {
            gameObject.SetActive(false);
        }

    }
    private void DrawCard(Transform Slot)
    {
        GameObject newCard = Instantiate(BlankCard, Slot);
        int randCardIndex = Random.Range(0, PlayerDeck.Count);
        newCard.GetComponent<Card>().CardSO = PlayerDeck[randCardIndex];
        PlayerDeck.RemoveAt(randCardIndex);
        
        SoundFxManager.Instance.AudioManager(DrawCardAudioClip, transform,1f);

    }
}
