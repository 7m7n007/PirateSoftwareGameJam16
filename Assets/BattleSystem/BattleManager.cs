using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> PlayerSlots;
    public List<GameObject> EnemySlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicBattle(){
        // Getting Player Cards
        List<CardScriptableObject> PlayerCards= new List<CardScriptableObject>();
        foreach(GameObject card in PlayerSlots){
            PlayerCards.Add(card.GetComponent<Card>().cardScriptableObject);
        }
        
        // Getting Enemy Cards
        List<CardScriptableObject> EnemyCards= new List<CardScriptableObject>();
        foreach(GameObject card in EnemySlots){
            EnemyCards.Add(card.GetComponent<Card>().cardScriptableObject);
        }

        // First Player Card Executes
        // First Enemy Card Executes
        // Second Player Card Executes
        // Second Enemy Card Executes


    }
}
