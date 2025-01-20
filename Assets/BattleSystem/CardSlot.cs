using System;
using System.Collections.Generic;
using TMPro;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CardSlot : MonoBehaviour
{
    [SerializeField] public BaseCard CardSO;
    // [SerializeField] TMP_Text cardName;
    [SerializeField] private string CardName;
    [SerializeField] public int CardHealth;
    [SerializeField] private int CardAttack;
    [SerializeField] private int CardDefense;
    public static event Action ActionDone;


    // Reference To Visual Fields
    [SerializeField] TMP_Text cardNameVisual;
    [SerializeField] TMP_Text cardAttackVisual;
    [SerializeField] TMP_Text cardHealthVisual;
    // public UnityEvent unityEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        ActionDone += updateCardVisual;
    }
    private void OnDisable()
    {
        ActionDone -= updateCardVisual;
    }

    void Start()
    {
        CardName = CardSO.CardName;
        CardHealth = CardSO.CardHealth;
        // CardAttack = CardSO.CardAttack;
        // CardDefense = CardSO.CardDefense;

        // cardName = GetComponentInChildren<TMP_Text>();
        // cardName.text = cardScriptableObject.CardName;
        updateCardVisual();
        // print(ScriptableObject.CreateInstance(cardScriptableObject.GetType()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(List<CardSlot> target, List<CardSlot> user, int CardIndex)
    {
        print("Doing Attack");
        CardSO.Action(target,user,CardIndex);
        // Attack(CardSO.AttackPattern, CardSO.PositionPattern, target, user, CardIndex);
    }
    public void Attack(List<int> damage, List<int> Position, List<CardSlot> target, List<CardSlot> user, int CardIndex)
    {
        for (int i = 0; i < damage.Count; i++)
        {
            target[CardIndex + Position[i]].CardHealth -= damage[i];
            target[CardIndex + Position[i]].updateCardVisual();
            Debug.DrawLine(user[CardIndex].transform.position, target[CardIndex + Position[i]].transform.position, new Color(UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, 1), 1f);
            // target.IndexOf(this);
        }
        // ActionDone.Invoke();

    }
    public void updateCardVisual()
    {
        // Update Visual
        print("Updating Visuals");
        cardNameVisual.text = CardName.ToString();
        cardAttackVisual.text = CardAttack.ToString();
        cardHealthVisual.text = CardHealth.ToString();

    }

}
