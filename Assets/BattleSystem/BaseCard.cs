using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "NewCard", menuName = "BaseCard", order = 0)]
public abstract class BaseCard:ScriptableObject
{
    public string CardName="Card";
    public int CardHealth;
    public abstract void Action(List<CardSlot> target, List<CardSlot> user, int CardIndex);
    public virtual void Attack(List<int> damages,List<int> positions){
        
    }
}
