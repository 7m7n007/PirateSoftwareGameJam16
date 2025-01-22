using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "NewCard", menuName = "BaseCard", order = 0)]
public abstract class BaseCard:ScriptableObject
{
    public string CardName="Card";
    public int CardHealth;
    public abstract void Action(List<Card> target, List<Card> user, int userIndex,int targetIndex);
    public virtual void Attack(List<int> damages,List<int> positions){
        
    }
}
