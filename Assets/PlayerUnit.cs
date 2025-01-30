using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUnit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PlayerSlot playerSlot;
    public int Barrier;
    public int BarrierThreshold;
    [SerializeField] TMP_Text BarrierText;
    [SerializeField] TMP_Text ThresholdText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int barrier = 0;
        foreach (Card card in playerSlot.PlayerCards)
        {
            barrier += card.CardHealth;
        }
        Barrier = barrier;
        BarrierText.text = barrier.ToString();
        ThresholdText.text = BarrierThreshold.ToString();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
