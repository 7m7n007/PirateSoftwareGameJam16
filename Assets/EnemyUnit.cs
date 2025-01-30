using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] EnemySlot enemySlot;
    public int Barrier;
    public int BarrierThreshold;
    [SerializeField] TMP_Text BarrierText;
    [SerializeField] TMP_Text ThreshHoldText;
    [SerializeField] public List<BaseCard> EnemyDeck;
    [SerializeField] GameObject BlankCard;
    [SerializeField] AnimationClip SpawnAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int barrier = 0;
        foreach (Card card in enemySlot.EnemySlots)
        {
            barrier += card.CardHealth;
        }
        Barrier = barrier;
        BarrierText.text = barrier.ToString();
        ThreshHoldText.text = BarrierThreshold.ToString();

        // if(EnemyDeck.Count<=0 && enemySlot.EnemySlots.Count<=0){
        //     print("enemyLoses");
        // }
        // if(gameObject.GetComponentInChildren<Card>().CardHealth<=0){
        //     print("enemyLost");
        // }
    }
    public void EnemyPlaceCardOne(Transform Slot)
    {
        GameObject newCard = Instantiate(BlankCard, Slot);
        int randCardIndex = UnityEngine.Random.Range(0, EnemyDeck.Count);
        newCard.GetComponent<Card>().CardSO = EnemyDeck[randCardIndex];
        newCard.GetComponent<Card>().runSpawnAnim = true;
        newCard.GetComponent<Card>().SpawnAnim = SpawnAnim;
        newCard.GetComponent<drag>().enabled=false;

        EnemyDeck.RemoveAt(randCardIndex);

    }
}
