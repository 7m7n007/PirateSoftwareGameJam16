using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "ChildCard", menuName = "ChildCard", order = 0)]
public class ChildCard : BaseCard
{
    // [SerializeField] public string CardName;
    // [SerializeField] public int CardHealth;
    [SerializeField] public List<int> Damage;
    [SerializeField] public List<int> Position;
    [SerializeField] public AnimationClip AttackingClip;
    [SerializeField] public AnimationClip TargetHitClip;
    [SerializeField] public AudioClip AttackingSFX;

    public override void Action(Card user, Card target, List<GameObject> targetSlots,int Bonus)
    {
        if (target.isUnit)
        {
            Attack(target, Damage[Damage.Count/2]+Bonus);
            target.PlayAnim(TargetHitClip);
        }
        else
        {

            int targetIndex = FindCardinSlot(target, targetSlots);
            Debug.Log(targetIndex);
            for (int i = 0; i < Position.Count; i++)
            {
                if (targetIndex + Position[i] < targetSlots.Count && targetIndex + Position[i] >= 0)
                {

                    Card temp = GetCardinSlot(targetIndex + Position[i], targetSlots);
                    if (temp != null)
                    {

                        Attack(temp, Damage[i]+Bonus);
                        temp.PlayAnim(TargetHitClip);
                    }
                }
            }
        }
        // Attack(target, Damage[0]);

        SoundFxManager.Instance.AudioManager(AttackingSFX, GameObject.FindWithTag("Canvas").transform, 1f);
        user.PlayAnim(AttackingClip);
        // target.PlayAnim(TargetHitClip);

        // throw new System.NotImplementedException();
    }

    public void Attack(Card target, int Damage)
    {
        if (target != null)
        {
            target.CardHealth -= Damage;
            target.updateCardVisual();
            // target=null;
        }
    }
    private int FindCardinSlot(Card card, List<GameObject> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                if (slots[i].transform.GetChild(0).GetComponent<Card>() == card)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    private Card GetCardinSlot(int index, List<GameObject> slots)
    {
        if (slots[index].transform.childCount > 0)
        {
            return slots[index].transform.GetChild(0).GetComponent<Card>();
        }
        else
        {
            return null;
        }
    }
}
