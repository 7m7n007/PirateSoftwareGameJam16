using System.Collections.Generic;
using UnityEngine;

public class PlayerSlot : MonoBehaviour
{
    public List<Card> PlayerCards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerCards = new List<Card>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {

                PlayerCards.Add(transform.GetChild(i).GetChild(0).GetComponent<Card>());
            }
        }
    }
}
