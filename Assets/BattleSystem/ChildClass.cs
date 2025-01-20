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
    public override void Action(List<CardSlot> target, List<CardSlot> user, int CardIndex)
    {
        Attack(Damage,Position,target,user,CardIndex);
        // throw new System.NotImplementedException();
    }
    public void Attack(List<int> damage, List<int> Position, List<CardSlot> target, List<CardSlot> user, int CardIndex)
    {
        for (int i = 0; i < damage.Count; i++)
        {
            target[CardIndex + Position[i]].CardHealth -= damage[i];
            target[CardIndex + Position[i]].updateCardVisual();
            Debug.DrawLine(user[CardIndex].transform.position, target[CardIndex + Position[i]].transform.position, new Color(UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, 1), 1f);
            // target.IndexOf(this);
        }
        // ActionDone.Invoke();

    }
}
