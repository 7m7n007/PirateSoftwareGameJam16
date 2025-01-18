using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 0)]
public class CardScriptableObject : ScriptableObject {
    [SerializeField] public string CardName;
    [SerializeField] public int CardHealth;
    [SerializeField] public int CardAttack;
    [SerializeField] public int CardDefense;

}