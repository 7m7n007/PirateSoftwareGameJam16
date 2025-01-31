using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Packs", menuName = "Pack", order = 0)]
public class Pack : ScriptableObject
{
    public List<BaseCard> cards;
    public List<int> cardsWeights;
    public int packSize;
    public Sprite packSprite;
    public AnimationClip packAnim;
}
