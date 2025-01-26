using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> PlayerSlots;
    public List<GameObject> EnemySlots;
    public GameObject PlayerUnit;
    public GameObject EnemyUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Card LastSelectedCard;
    public BattleStages battleStages;
    [SerializeField] changePhaseImg changePhaseImg;

    // Functions

    private void OnEnable()
    {
        Card.CardSelected += SelectCard;
    }
    private void OnDisable()
    {
        Card.CardSelected -= SelectCard;
    }
    public void BasicBattle()
    {
        changePhaseImg.NextPhase();
        // Getting Player Cards
        List<Card> PlayerCards = new List<Card>();
        foreach (GameObject card in PlayerSlots)
        {
            PlayerCards.Add(card.GetComponentInChildren<Card>());
        }

        // Getting Enemy Cards
        List<Card> EnemyCards = new List<Card>();
        foreach (GameObject card in EnemySlots)
        {
            EnemyCards.Add(card.GetComponentInChildren<Card>());
        }

        // for(int i=0;i<5;i++){
        // PlayerCards[i].Action(EnemyCards,PlayerCards,i);
        // // Debug.DrawLine(PlayerCards[i].gameObject.transform.position,)
        // EnemyCards[i].Action(PlayerCards,EnemyCards,i);
        // }
        for (int i = 0; i < PlayerCards.Count; i++)
        {
            DeActivateCards(PlayerCards);
        }
        for (int i = 0; i < EnemyCards.Count; i++)
        {
            DeActivateCards(EnemyCards);

        }
        PlayerUnit.GetComponentInChildren<Card>().isActive = false;
        EnemyUnit.GetComponentInChildren<Card>().isActive = false;
        List<Card> targets = new List<Card>();
        // Coroutine ActionCoroutine = StartCoroutine(Action(PlayerCards, EnemyCards));

        if (battleStages == BattleStages.EnemyDecides)
        {

            targets = EnemyAi(EnemyCards, PlayerCards);
            for (int i = 0; i < targets.Count; i++)
            {
                Debug.DrawLine(EnemyCards[i].transform.position, targets[i].transform.position, Color.white, 100f);
            }
            battleStages = BattleStages.PlayerTurn;
        }

        else if (battleStages == BattleStages.PlayerTurn)
        {
            // ActivateCards(PlayerCards);
            // if EnemyBarrier<Threshold add EnemyUnit to EnemyCards
            Coroutine ActionCoroutine = StartCoroutine(Action2(PlayerCards, EnemyCards));
        }
        else if (battleStages == BattleStages.EnemyTurn)
        {
            // if PlayerBarrier<Threshold add PlayerUnit to PlayerCards
            // Coroutine ActionCoroutine = StartCoroutine(Action2(EnemyCards, PlayerCards));
            for (int i = 0; i < EnemyCards.Count; i++)
            {

                // int EnemyCardIndex=FindCards(EnemyCards,EnemyCards[i]);
                // int PlayerCardsIndex=FindCards(PlayerCards,PlayerCards[i]);
                EnemyCards[i].Action();
                EnemyCards[i].target = null;
                // PlayerCards[AttackingCard].Action(EnemyCards, PlayerCards, AttackingCard, TargetCard);
            }

        }
        // print("PlayerAttack DOne");
        // First Player Card Executes
        // First Enemy Card Executes
        // Second Player Card Executes
        // Second Enemy Card Executes


    }
    // IEnumerator Action(List<Card> PlayerCards, List<Card> EnemyCards)
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         PlayerCards[i].Action(EnemyCards, PlayerCards, i);
    //         yield return new WaitForSeconds(2f);
    //         // Debug.DrawLine(PlayerCards[i].gameObject.transform.position,)
    //         EnemyCards[i].Action(PlayerCards, EnemyCards, i);
    //         yield return new WaitForSeconds(2f);
    //     }
    // }
    IEnumerator Action2(List<Card> PlayerCards, List<Card> EnemyCards)
    {
        List<Card> newPlayerCards = PlayerCards;

        List<Card> newEnemyCards = EnemyCards;

        Card AttackingCard = null;
        // int TargetCard = -1;
        AttackStages attackStages = AttackStages.SelectCard;
        int cardleft = 5;

        while (cardleft > 0)
        {

            while (attackStages == AttackStages.SelectCard)
            {
                // newPlayerCards.Add(PlayerUnit.GetComponent<Card>());
                ActivateCards(newPlayerCards);
                LastSelectedCard = null;
                while (LastSelectedCard == null)
                {
                    // print("waiting");
                    yield return null;
                }
                AttackingCard = LastSelectedCard;
                // AttackingCard = FindCards(PlayerCards, LastSelectedCard);
                // print(AttackingCard);
                attackStages = AttackStages.SelectTarget;
                DeActivateCards(newPlayerCards);
            }
            while (attackStages == AttackStages.SelectTarget)
            {
                if (AttackingCard.targetSelf == false)
                {

                    if (EnemyUnit.GetComponent<EnemyUnit>().Barrier < EnemyUnit.GetComponent<EnemyUnit>().BarrierThreshold)
                    {
                        newEnemyCards.Add(EnemyUnit.GetComponentInChildren<Card>());
                        print("Enemy Barrier Low");
                    }
                    ActivateCards(newEnemyCards);
                    LastSelectedCard = null;
                    while (LastSelectedCard == null)
                    {
                        // print("waiting");
                        yield return null;
                    }
                    // TargetCard = FindCards(EnemyCards, LastSelectedCard);
                    // print(TargetCard);
                    AttackingCard.target = LastSelectedCard;

                    attackStages = AttackStages.Attack;
                    DeActivateCards(newEnemyCards);
                }
                else
                {
                    ActivateCards(newPlayerCards);
                    LastSelectedCard = null;
                    while (LastSelectedCard == null)
                    {
                        // print("waiting");
                        yield return null;
                    }
                    AttackingCard.target = LastSelectedCard;
                    // TargetCard = FindCards(PlayerCards, LastSelectedCard);
                    // print(TargetCard);

                    attackStages = AttackStages.Attack;
                    DeActivateCards(newPlayerCards);

                }
            }

            while (attackStages == AttackStages.Attack)
            {
                if (AttackingCard.targetSelf == false)
                {

                    AttackingCard.Action();
                    // AttackingCard.target = null;
                    // AttackingCard.Action(PlayerCards,EnemyCards,AttackingCard,TargetCard);
                    attackStages = AttackStages.SelectCard;
                    cardleft -= 1;

                }
                else
                {
                    AttackingCard.Action();
                    // AttackingCard.Action(PlayerCards,EnemyCards,AttackingCard,TargetCard);
                    attackStages = AttackStages.SelectCard;
                    cardleft -= 1;

                }
            }
        }
        AttackingCard.target = null;
        battleStages += 1;
        // yield return new WaitForSeconds(0);
    }

    public void SelectCard(Card card)
    {
        LastSelectedCard = card;
        // print(LastSelectedCard);
    }
    int FindCards(List<Card> Cards, Card FindCard)
    {
        // List<Card> PlayerCards = new List<Card>();
        int index = -1;
        foreach (Card card in Cards)
        {
            index += 1;
            if (card == FindCard)
            {
                return index;
            }
        }
        return -1;
    }
    public void ActivateCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {

                cards[i].isActive = true;
            }
        }
    }
    public void DeActivateCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {

                cards[i].isActive = false;
            }
        }
    }
    public List<Card> EnemyAi(List<Card> EnemyCards, List<Card> PlayerCards)
    {
        List<Card> playerCardNotNull=PlayerCards;
        playerCardNotNull.RemoveAll(x=>!x);

        List<Card> enemyCardNotNull=EnemyCards;
        enemyCardNotNull.RemoveAll(x=>!x);

        List<Card> targets = new List<Card>();
        foreach (Card enemy in EnemyCards)
        {
            if (enemy != null)
            {
                
                // targets.Add(PlayerCards[UnityEngine.Random.Range(0, PlayerCards.Count)]);
                if (enemy.targetSelf == false)
                {
                    
                    enemy.target = PlayerCards[UnityEngine.Random.Range(0, playerCardNotNull.Count)];
                }
                else
                {
                    enemy.target = EnemyCards[UnityEngine.Random.Range(0, enemyCardNotNull.Count)];

                }
            }
        }
        return targets;
    }

}
public enum AttackStages
{
    SelectCard,
    SelectTarget,
    Attack,
    Idle
}
public enum BattleStages
{
    EnemyDecides,
    PlayerTurn,
    EnemyTurn
}
