using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "ChildCard", menuName = "ChildCard", order = 0)]
public class ChildClass : BaseCard
{
    // [SerializeField] public string CardName;
    // [SerializeField] public int CardHealth;
    [SerializeField] public List<int> Damage;
    [SerializeField] public List<int> Position;
    
    // [SerializeField] public List<int> AttackPattern;
    // [SerializeField] public List<int> PositionPattern;
    public override void Action(List<Card> target, List<Card> user, int userIndex,int targetIndex)
    {
        Attack(Damage,Position,target,user,userIndex,targetIndex);
        // throw new System.NotImplementedException();
    }
    public void Attack(List<int> damage, List<int> Position, List<Card> target, List<Card> user, int userIndex,int targetIndex)
    {
        for (int i = 0; i < damage.Count; i++)
        {
            target[targetIndex + Position[i]].CardHealth -= damage[i];
            target[targetIndex + Position[i]].updateCardVisual();
            Debug.DrawLine(user[userIndex].transform.position, target[targetIndex + Position[i]].transform.position, new Color(UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, 1), 1f);
            // target.IndexOf(this);
        }
        // ActionDone.Invoke();

    }
}
