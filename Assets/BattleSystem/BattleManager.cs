using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> PlayerSlots;
    public List<GameObject> EnemySlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void BasicBattle()
    {
        // Getting Player Cards
        List<CardSlot> PlayerCards = new List<CardSlot>();
        foreach (GameObject card in PlayerSlots)
        {
            PlayerCards.Add(card.GetComponent<CardSlot>());
        }

        // Getting Enemy Cards
        List<CardSlot> EnemyCards = new List<CardSlot>();
        foreach (GameObject card in EnemySlots)
        {
            EnemyCards.Add(card.GetComponent<CardSlot>());
        }

        // for(int i=0;i<5;i++){
        // PlayerCards[i].Action(EnemyCards,PlayerCards,i);
        // // Debug.DrawLine(PlayerCards[i].gameObject.transform.position,)
        // EnemyCards[i].Action(PlayerCards,EnemyCards,i);
        // }

        Coroutine ActionCoroutine = StartCoroutine(Action(PlayerCards, EnemyCards));
        // First Player Card Executes
        // First Enemy Card Executes
        // Second Player Card Executes
        // Second Enemy Card Executes


    }
    IEnumerator Action(List<CardSlot> PlayerCards, List<CardSlot> EnemyCards)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerCards[i].Action(EnemyCards, PlayerCards, i);
            yield return new WaitForSeconds(2f);
            // Debug.DrawLine(PlayerCards[i].gameObject.transform.position,)
            EnemyCards[i].Action(PlayerCards, EnemyCards, i);
            yield return new WaitForSeconds(2f);
        }
    }
}
