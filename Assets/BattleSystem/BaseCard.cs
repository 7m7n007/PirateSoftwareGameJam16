using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "NewCard", menuName = "BaseCard", order = 0)]
public abstract class BaseCard:ScriptableObject
{
    
    public abstract void Action();
    public virtual void Attack(List<int> damages,List<int> positions){
        for(int i=0;i<damages.Count;i++){

        }
    }
}
