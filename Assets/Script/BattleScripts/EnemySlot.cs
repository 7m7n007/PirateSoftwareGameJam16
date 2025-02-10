using UnityEngine;
using System.Collections.Generic;

public class EnemySlot : MonoBehaviour
{
    public List<Card> EnemySlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemySlots = new List<Card>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {

                EnemySlots.Add(transform.GetChild(i).GetChild(0).GetComponent<Card>());
            }
        }
    }
}
