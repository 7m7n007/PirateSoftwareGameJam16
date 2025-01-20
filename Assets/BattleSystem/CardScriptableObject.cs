using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 0)]
public  class CardScriptableObject : ScriptableObject {
    [SerializeField] public string CardName;
    [SerializeField] public int CardHealth;
    [SerializeField] public int CardAttack;
    [SerializeField] public int CardDefense;
    
    [SerializeField] public List<int>AttackPattern;
    [SerializeField] public List<int>PositionPattern;
    
}