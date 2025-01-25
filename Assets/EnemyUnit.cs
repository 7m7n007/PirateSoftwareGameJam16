using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyUnit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] EnemySlot enemySlot;
    public int Barrier;
    public int BarrierThreshold;
    [SerializeField] TMP_Text BarrierText;
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
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
