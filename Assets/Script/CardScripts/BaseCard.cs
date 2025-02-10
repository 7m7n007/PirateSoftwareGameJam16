using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "NewCard", menuName = "BaseCard", order = 0)]
public abstract class BaseCard:ScriptableObject
{
    public string CardName="Card";
    public int CardHealth;
    public int CardPower;
    public Sprite CardSprite;
    public string CardDescription;
    
    public bool selfTargeting;
    public abstract void Action(Card user,Card target,List<GameObject> targetSlots,int Bonus);
    public virtual void Attack(int damage){
        
    }
}
