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
    public int BonusAttack;
    // Reference To Visual Fields
    [SerializeField] GameObject diableImg;
    [SerializeField] TMP_Text cardNameVisual;
    [SerializeField] TMP_Text cardAttackVisual;
    [SerializeField] TMP_Text cardHealthVisual;
    [SerializeField] TMP_Text cardDescription;

    [SerializeField] Image cardImg;
    [SerializeField] LineRenderer lineRenderer;
    public bool isActive;
    public bool isSelectable;
    public bool targetSelf;
    public Card target;
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;
    public bool runSpawnAnim;
    public bool isUnit;
    public bool isEnemy;
    public AnimationClip SpawnAnim;
    [SerializeField] AnimationClip animationClip;
    [SerializeField] GameObject Border;
    public static event Action<bool> CardDestroyed;
    // public UnityEvent unityEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        isActive = true;
        CardName = CardSO.CardName;
        CardHealth = CardSO.CardHealth;
        CardSprite = CardSO.CardSprite;
        targetSelf = CardSO.selfTargeting;
        target = null;
        animator = GetComponentInChildren<Animator>();
        BonusAttack=0;
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        // CardAttack = CardSO.CardAttack;
        // CardDefense = CardSO.CardDefense;

        // cardName = GetComponentInChildren<TMP_Text>();
        // cardName.text = cardScriptableObject.CardName;
        updateCardVisual();
        if (runSpawnAnim)
        {
            PlayAnim(SpawnAnim);
        }
        // print(ScriptableObject.CreateInstance(cardScriptableObject.GetType()));
    }
    private void OnDestroy()
    {
        if (target != null)
        {

            target.setBorder(false);
        }
        if(isUnit){
            CardDestroyed.Invoke(isEnemy);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // add -1 to the z axis
            lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
            lineRenderer.SetPosition(1, new Vector3(target.transform.position.x, target.transform.position.y, 0));
            // Debug.DrawLine(transform.position, target.transform.position);
        }
        else
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
        if (isActive)
        {
            diableImg.SetActive(false);
        }
        else
        {
            diableImg.SetActive(true);
        }
        // if(isSelectable){
        //     Border.GetComponent<RawImage>().color=Color.green;
        //     Border.SetActive(true);
        // }
        // else{
            
        //     Border.GetComponent<RawImage>().color=Color.red;
        //     Border.SetActive(false);
        // }
        if (CardHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Action(List<GameObject> targetSlots)
    {
        CardSO.Action(this, target, targetSlots,BonusAttack);

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
        cardDescription.text = CardSO.CardDescription;
        cardImg.sprite = CardSprite;
        // cardImg=CardSprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            CardSelected?.Invoke(this);
            // animatorOverrideController
        }
        // PlayAnim(animationClip);
        // print("Click Invoked");
    }
    public void PlayAnim(AnimationClip animationClip)
    {

        animatorOverrideController["BasicAttackAnim"] = animationClip;
        animator.SetTrigger("Attack");
    }
    public void setBorder(bool setBorder)
    {
        Border.SetActive(setBorder);
    }
}
