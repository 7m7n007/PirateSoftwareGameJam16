using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEditor;
using JetBrains.Annotations;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> PlayerSlots;
    public List<GameObject> EnemySlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Card LastSelectedCard;
    public BattleStages battleStages;
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

        // Coroutine ActionCoroutine = StartCoroutine(Action(PlayerCards, EnemyCards));
        if (battleStages == BattleStages.PlayerTurn)
        {

            Coroutine ActionCoroutine = StartCoroutine(Action2(PlayerCards, EnemyCards));
        }
        else if (battleStages == BattleStages.EnemyTurn)
        {
            Coroutine ActionCoroutine = StartCoroutine(Action2(EnemyCards, PlayerCards));

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
        int AttackingCard = -1;
        int TargetCard = -1;
        AttackStages attackStages = AttackStages.SelectCard;
        int cardleft = 5;

        while (cardleft > 0)
        {

            while (attackStages == AttackStages.SelectCard)
            {
                LastSelectedCard = null;
                while (LastSelectedCard == null)
                {
                    // print("waiting");
                    yield return null;
                }
                AttackingCard = FindCards(PlayerCards, LastSelectedCard);
                print(AttackingCard);
                attackStages = AttackStages.SelectTarget;
            }
            while (attackStages == AttackStages.SelectTarget)
            {
                LastSelectedCard = null;
                while (LastSelectedCard == null)
                {
                    // print("waiting");
                    yield return null;
                }
                TargetCard = FindCards(EnemyCards, LastSelectedCard);
                print(TargetCard);

                attackStages = AttackStages.Attack;
            }

            while (attackStages == AttackStages.Attack)
            {
                PlayerCards[AttackingCard].Action(EnemyCards, PlayerCards, AttackingCard, TargetCard);
                // AttackingCard.Action(PlayerCards,EnemyCards,AttackingCard,TargetCard);
                attackStages = AttackStages.SelectCard;
                cardleft -= 1;
            }
        }
        battleStages+=1;
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
    int FindInEnemyCards(Card FindCard)
    {
        // List<Card> PlayerCards = new List<Card>();
        int index = -1;
        foreach (GameObject card in EnemySlots)
        {
            index += 1;
            if (card.GetComponentInChildren<Card>() == FindCard)
            {
                return index;
            }
        }
        return -1;
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
    PlayerTurn,
    EnemyTurn
}
