using UnityEngine;

[CreateAssetMenu(fileName = "ChildCard", menuName = "ChildCard", order = 0)]
public class ChildClass : BaseCard
{
    [SerializeField] public string CardName;
    [SerializeField] public int CardHealth;
    [SerializeField] public int CardAttack;
    [SerializeField] public int CardDefense;
    public override void Action()
    {
        throw new System.NotImplementedException();
    }
}
