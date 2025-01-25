using System;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public BaseCard CardSO;
    // [SerializeField] TMP_Text cardName;
    [SerializeField] private string CardName;
    [SerializeField] public int CardHealth;
    [SerializeField] private int CardAttack;
    [SerializeField] private int CardDefense;
    [SerializeField] private Sprite CardSprite;
    public static event Action<Card> CardSelected;
    // Reference To Visual Fields
    [SerializeField] GameObject diableImg;
    [SerializeField] TMP_Text cardNameVisual;
    [SerializeField] TMP_Text cardAttackVisual;
    [SerializeField] TMP_Text cardHealthVisual;
    [SerializeField] Image cardImg;
    [SerializeField] LineRenderer lineRenderer;
    public bool isActive;
    public bool targetSelf;
    public Card target;
    [SerializeField] AnimatorOverrideController animatorOverrideController;
    [SerializeField] AnimationClip animationClip;
    // public UnityEvent unityEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        isActive = true;
        CardName = CardSO.CardName;
        CardHealth = CardSO.CardHealth;
        CardSprite = CardSO.CardSprite;
        targetSelf = CardSO.selfTargeting;
        target=null;
        // CardAttack = CardSO.CardAttack;
        // CardDefense = CardSO.CardDefense;

        // cardName = GetComponentInChildren<TMP_Text>();
        // cardName.text = cardScriptableObject.CardName;
        updateCardVisual();
        // print(ScriptableObject.CreateInstance(cardScriptableObject.GetType()));
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null){
            // add -1 to the z axis
            lineRenderer.SetPosition(0,new Vector3(transform.position.x,transform.position.y,-1));
            lineRenderer.SetPosition(1,new Vector3(target.transform.position.x,target.transform.position.y,-1));
            // Debug.DrawLine(transform.position, target.transform.position);
        }
        if (isActive)
        {
            diableImg.SetActive(false);
        }
        else
        {
            diableImg.SetActive(true);
        }
        if (CardHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

public void Action(){
   CardSO.Action(target); 
}
// public void Attack(int damage){
//     target.CardHealth-=damage;
// }
    // public void Action(List<Card> target, List<Card> user, int userIndex, int targetIndex)
    // {
    //     // print("Doing Attack");
    //     CardSO.Action(target, user, userIndex, targetIndex);
    //     // Attack(CardSO.AttackPattern, CardSO.PositionPattern, target, user, CardIndex);
    // }
    // public void Attack(List<int> damage, List<int> Position, List<Card> target, List<Card> user, int CardIndex)
    // {
    //     for (int i = 0; i < damage.Count; i++)
    //     {
    //         target[CardIndex + Position[i]].CardHealth -= damage[i];
    //         target[CardIndex + Position[i]].updateCardVisual();
    //         Debug.DrawLine(user[CardIndex].transform.position, target[CardIndex + Position[i]].transform.position, new Color(UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, UnityEngine.Random.Range(0, 255) / 255, 1), 1f);
    //         // target.IndexOf(this);
    //     }
    //     // ActionDone.Invoke();

    // }
    public void updateCardVisual()
    {
        // Update Visual
        // print("Updating Visuals");
        cardNameVisual.text = CardName.ToString();
        cardAttackVisual.text = CardAttack.ToString();
        cardHealthVisual.text = CardHealth.ToString();
        cardImg.sprite=CardSprite;
        // cardImg=CardSprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            CardSelected?.Invoke(this);
            // animatorOverrideController
        }
            changeAnimation(animationClip);
        // print("Click Invoked");
    }
    public void changeAnimation(AnimationClip animationClip){

            // print(animatorOverrideController.ApplyOverrides()));
    }
}
