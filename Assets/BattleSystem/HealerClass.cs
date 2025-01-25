using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "HealerCard", menuName = "HealerCard", order = 0)]
public class HealerClass : BaseCard
{
    // [SerializeField] public string CardName;
    // [SerializeField] public int CardHealth;
    [SerializeField] public List<int> Heals;
    [SerializeField] public List<int> Position;
    
    // [SerializeField] public List<int> AttackPattern;
    // [SerializeField] public List<int> PositionPattern;
    public override void Action(Card target)
    {
        Heal(target, Heals[0]);
        // throw new System.NotImplementedException();
    }
    public void Heal(Card target, int Damage)
    {
        if (target != null)
        {
            target.CardHealth += Damage;
            target.updateCardVisual();
            // target=null;
        }
    }
}
