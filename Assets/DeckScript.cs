using System;
using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject PlayerHand;
    [SerializeField] List<BaseCard> PlayerDeck;
    [SerializeField] GameObject BlankCard;
    [SerializeField] AudioClip DrawCardSingleAudioClip;
    [SerializeField] AudioClip DrawCardMultipleAudioClip;
    [SerializeField] AnimationClip SpawnAnim;
    [SerializeField] int StartingCards;
    // [SerializeField] GameObject EmptySlot;
    private void Awake()
    {
        PlayerDeck = GameObject.FindWithTag("GameController").GetComponent<CardsData>().Deck;
    }
    private void Start()
    {
        // DrawFirstHand();
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
    private void DrawCard(Transform Slot,bool isSingle=true)
    {
        GameObject newCard = Instantiate(BlankCard, Slot);
        int randCardIndex = UnityEngine.Random.Range(0, PlayerDeck.Count);
        newCard.GetComponent<Card>().CardSO = PlayerDeck[randCardIndex];
        newCard.GetComponent<Card>().runSpawnAnim = true;
        newCard.GetComponent<Card>().SpawnAnim = SpawnAnim;
        PlayerDeck.RemoveAt(randCardIndex);

        if(isSingle){

        SoundFxManager.Instance.AudioManager(DrawCardSingleAudioClip, transform, 1f);
        }

    }
    public void DrawFirstHand(){
        StartCoroutine(FirstHand(1f));
    }
    public IEnumerator FirstHand(float time)
    {
        SoundFxManager.Instance.AudioManagerFixedTime(DrawCardMultipleAudioClip, transform, 1f,time);

        for (int i = 0; i < StartingCards; i++)
        {
            DrawCard(PlayerHand.transform.GetChild(i).transform,false);
            yield return new WaitForSeconds(0.2f);
        }
        // print("stop");
        // SoundFxManager.Instance.StopMusicFx();
    }
}
