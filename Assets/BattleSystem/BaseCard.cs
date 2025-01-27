using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "NewCard", menuName = "BaseCard", order = 0)]
public abstract class BaseCard:ScriptableObject
{
    public string CardName="Card";
    public int CardHealth;
    // public Card target;
    public Sprite CardSprite;
    
    public bool selfTargeting;
    public abstract void Action(Card user,Card target);
    public virtual void Attack(int damage){
        
    }
}
