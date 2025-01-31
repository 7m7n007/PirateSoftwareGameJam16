using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    // --------------------Decleration--------------------
    public List<GameObject> PlayerSlots;
    public List<GameObject> EnemySlots;
    public GameObject PlayerUnit;
    public GameObject EnemyUnit;
    public Card LastSelectedCard;
    public BattleStages battleStages;
    [SerializeField] changePhaseImg changePhaseImg;
    [SerializeField] changePhaseText changePhaseText;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;

    [SerializeField] DeckScript Deck;
    [SerializeField] bool isReady;
    [SerializeField] bool gameRunning;

    [SerializeField] AudioClip SelectAudioClip;
    [SerializeField] AudioClip WinSFX;
    [SerializeField] AudioClip LoseSFX;

    [SerializeField] List<BaseCard> RewardCards;
    public int RewardMoney;

    // -------------------Functions-----------------------
    private void OnEnable()
    {
        Card.CardSelected += SelectCard;
        Card.CardDestroyed += GameFinish;

        changePhaseText.changePhase(changePhaseText.Phases.None);
    }
    private void OnDisable()
    {
        Card.CardSelected -= SelectCard;
        Card.CardDestroyed -= GameFinish;
    }
    private void Update()
    {
        if (!gameRunning)
        {
            StopAllCoroutines();
            GameFinish(true);
            gameRunning = true;
            // SceneController.instance.LoadScene("DeckMenu");
        }
    }
    public void GameFinish(bool isPlayerEnemy)
    {
        StopAllCoroutines();

        if (isPlayerEnemy)
        {

            WinScreen.SetActive(true);
            GiveReward(RewardCards, RewardMoney);
            SoundFxManager.Instance.AudioManager(WinSFX, transform, 1f);
        }
        else
        {
            LoseScreen.SetActive(true);
            SoundFxManager.Instance.AudioManager(LoseSFX, transform, 1f);
        }
    }
    public void startBattle()
    {
        Coroutine c = StartCoroutine(RewampedBattle());
    }
    public IEnumerator RewampedBattle()
    {
        // -------StartingLevel--------
        // SetUp Stage
        // Player Draw Cards
        yield return StartCoroutine(Deck.FirstHand(1f));
        // Enemy Places Card
        yield return StartCoroutine(EnemyPlacesCard());

        // ---------Round Loop--------
        while (gameRunning)
        {
            // // Player Places Cards
            yield return StartCoroutine(PlacingCards());

            // Round begins
            yield return StartCoroutine(BattleRound());
            yield return NextRound();
        }
    }

    public IEnumerator NextRound()
    {
        changePhaseImg.changePhase(changePhaseImg.BattlePhases.SetUpPhase);
        Deck.DrawOneCard();
        yield return StartCoroutine(EnemyPlacesCard());
    }
    public IEnumerator BattleRound()
    {
        // Round 1 

        List<Card> PlayerCards = new List<Card>();
        foreach (GameObject card in PlayerSlots)
        {
            if (card.GetComponentInChildren<Card>() != null)
            {
                PlayerCards.Add(card.GetComponentInChildren<Card>());
            }
        }

        // Getting Enemy Cards
        List<Card> EnemyCards = new List<Card>();
        foreach (GameObject card in EnemySlots)
        {
            if (card.GetComponentInChildren<Card>() != null)
            {
                EnemyCards.Add(card.GetComponentInChildren<Card>());
            }
        }

        // Disable Drag of Cards
        foreach (Card card in PlayerCards)
        {
            card.GetComponent<drag>().enabled = false;
        }
        foreach (Card card in EnemyCards)
        {
            card.GetComponent<drag>().enabled = false;
        }


        // Enemy DEcides Attack
        yield return StartCoroutine(EnemyAi(EnemyCards, PlayerCards));
        changePhaseImg.changePhase(changePhaseImg.BattlePhases.PlayerAttack);

        // Player Attacks One by One
        yield return StartCoroutine(Action2(PlayerCards, EnemyCards));

        changePhaseImg.changePhase(changePhaseImg.BattlePhases.EnemyAttack);
        print("Enemies Turn");
        yield return new WaitForSeconds(2f);


        ActivateCards(PlayerCards);
        ActivateCards(EnemyCards);

        EnemyCards = new List<Card>();
        foreach (GameObject card in EnemySlots)
        {
            if (card.transform.childCount>0)
            {
                EnemyCards.Add(card.GetComponentInChildren<Card>());
            }
        }

        // Enemy attack
        yield return StartCoroutine(EnemyAttack(EnemyCards, PlayerCards));
        PlayerReady(false);
        // Restart


        // Disable Drag of Cards
        foreach (Card card in PlayerCards)
        {
            card.GetComponent<drag>().enabled = true;
        }
        // foreach (Card card in EnemyCards)
        // {
        //     card.GetComponent<drag>().enabled = true;
        // }
        // yield return null;
        // StartCoroutine(RewampedBattle());

        // }
    }

    public void PlayerReady(bool Ready)
    {
        isReady = Ready;
    }
    IEnumerator PlacingCards()
    {
        while (!isReady)
        {
            yield return null;
        }

    }
    IEnumerator EnemyAttack(List<Card> EnemyCards, List<Card> PlayerCards)
    {
        for (int i = 0; i < EnemyCards.Count; i++)
        {
            if (EnemyCards[i].target != null)
            {
                if (EnemyCards[i].targetSelf)
                {

                    EnemyCards[i].Action(EnemySlots);
                    EnemyCards[i].target.setBorder(false,Color.clear);
                    EnemyCards[i].target = null;
                }
                else
                {
                    EnemyCards[i].Action(PlayerSlots);
                    EnemyCards[i].target.setBorder(false,Color.clear);
                    EnemyCards[i].target = null;

                }
                yield return new WaitForSeconds(1f);
            }
        }

    }
    IEnumerator EnemyPlacesCard()
    {
        foreach (GameObject Slot in EnemySlots)
        {
            if (Slot.transform.childCount <= 0)
            {
                if (EnemyUnit.GetComponent<EnemyUnit>().EnemyDeck.Count > 0)
                {

                    EnemyUnit.GetComponent<EnemyUnit>().EnemyPlaceCardOne(Slot.transform);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
        // print("EnemyCardPlaced");

    }
    // public void BasicBattle()
    // {
    //     changePhaseImg.NextPhase();
    //     // Getting Player Cards
    //     List<Card> PlayerCards = new List<Card>();
    //     foreach (GameObject card in PlayerSlots)
    //     {
    //         PlayerCards.Add(card.GetComponentInChildren<Card>());
    //     }

    //     // Getting Enemy Cards
    //     List<Card> EnemyCards = new List<Card>();
    //     foreach (GameObject card in EnemySlots)
    //     {
    //         EnemyCards.Add(card.GetComponentInChildren<Card>());
    //     }


    //     for (int i = 0; i < PlayerCards.Count; i++)
    //     {
    //         DeActivateCards(PlayerCards);
    //     }
    //     for (int i = 0; i < EnemyCards.Count; i++)
    //     {
    //         DeActivateCards(EnemyCards);

    //     }
    //     PlayerUnit.GetComponentInChildren<Card>().isActive = false;
    //     EnemyUnit.GetComponentInChildren<Card>().isActive = false;
    //     List<Card> targets = new List<Card>();

    //     if (battleStages == BattleStages.EnemyDecides)
    //     {

    //         targets = EnemyAi(EnemyCards, PlayerCards);
    //         for (int i = 0; i < targets.Count; i++)
    //         {
    //             Debug.DrawLine(EnemyCards[i].transform.position, targets[i].transform.position, Color.white, 100f);
    //         }
    //         battleStages = BattleStages.PlayerTurn;
    //     }

    //     else if (battleStages == BattleStages.PlayerTurn)
    //     {

    //         Coroutine ActionCoroutine = StartCoroutine(Action2(PlayerCards, EnemyCards));
    //     }
    //     else if (battleStages == BattleStages.EnemyTurn)
    //     {
    //         for (int i = 0; i < EnemyCards.Count; i++)
    //         {

    //             EnemyCards[i].Action();
    //             EnemyCards[i].target = null;
    //         }

    //     }
    //     // print("PlayerAttack DOne");
    //     // First Player Card Executes
    //     // First Enemy Card Executes
    //     // Second Player Card Executes
    //     // Second Enemy Card Executes


    // }
    IEnumerator Action2(List<Card> PlayerCards, List<Card> EnemyCards)
    {

        Card AttackingCard = null;
        // int TargetCard = -1;
        AttackStages attackStages = AttackStages.SelectCard;
        int cardleft = PlayerCards.Count;

        // List<Card> availableCards=newPlayerCards;

        while (cardleft > 0)
        {
            List<Card> newPlayerCards = PlayerCards;

            List<Card> newEnemyCards = EnemyCards;

            while (attackStages == AttackStages.SelectCard)
            {
                changePhaseText.changePhase(changePhaseText.Phases.selectUser);
                ActivateCards(newPlayerCards);
                LastSelectedCard = null;
                while (LastSelectedCard == null)
                {
                    yield return null;
                }
                AttackingCard = LastSelectedCard;
                attackStages = AttackStages.SelectTarget;
                DeActivateCards(newPlayerCards);
                // yield return new WaitForSeconds(1f);
            }
            while (attackStages == AttackStages.SelectTarget)
            {

                changePhaseText.changePhase(changePhaseText.Phases.selectTarget);
                if (AttackingCard.targetSelf == false)
                {

                    if (EnemyUnit.GetComponent<EnemyUnit>().Barrier < EnemyUnit.GetComponent<EnemyUnit>().BarrierThreshold)
                    {
                        newEnemyCards.Add(EnemyUnit.GetComponentInChildren<Card>());
                        // print("Enemy Barrier Low");
                    }
                    ActivateCards(newEnemyCards);
                    SelectableCards(EnemyCards);
                    LastSelectedCard = null;
                    while (LastSelectedCard == null)
                    {
                        yield return null;
                    }
                    AttackingCard.target = LastSelectedCard;

                    attackStages = AttackStages.Attack;
                    DeSelectableCards(EnemyCards);
                    DeActivateCards(newEnemyCards);
                }
                else
                {
                    ActivateCards(newPlayerCards);
                    SelectableCards(PlayerCards);
                    LastSelectedCard = null;
                    while (LastSelectedCard == null)
                    {
                        yield return null;
                    }
                    AttackingCard.target = LastSelectedCard;
                    DeSelectableCards(PlayerCards);
                    attackStages = AttackStages.Attack;
                    DeActivateCards(newPlayerCards);

                }
            }
            // yield return new WaitForSeconds(1f);
            while (attackStages == AttackStages.Attack)
            {

                changePhaseText.changePhase(changePhaseText.Phases.None);
                if (AttackingCard.targetSelf == false)
                {

                    AttackingCard.Action(EnemySlots);
                    AttackingCard.target = null;
                    AttackingCard.isActive = false;
                    newPlayerCards.Remove(AttackingCard);
                    // DeActivateCards(new List<Card>{AttackingCard});
                    attackStages = AttackStages.SelectCard;
                    cardleft -= 1;

                }
                else
                {
                    AttackingCard.Action(PlayerSlots);
                    AttackingCard.target = null;
                    AttackingCard.isActive = false;
                    newPlayerCards.Remove(AttackingCard);
                    // DeActivateCards(new List<Card>{AttackingCard});
                    attackStages = AttackStages.SelectCard;
                    cardleft -= 1;

                }
                yield return new WaitForSeconds(1f);
            }
        }
        AttackingCard.target = null;
        battleStages += 1;

    }

    public void SelectCard(Card card)
    {
        LastSelectedCard = card;
    }
    int FindCards(List<Card> Cards, Card FindCard)
    {
        int index = -1;
        foreach (Card card in Cards)
        {
            index += 1;
            if (card == FindCard)
            {
                return index;
            }
        }
        return -1;
    }
    public void ActivateCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {

                cards[i].isActive = true;
            }
        }
    }
    public void SelectableCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {
                
                cards[i].setBorder(true,new Color(207/255f,36/255f,211/255f));
            }
        }
    }
    public void DeSelectableCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {

                cards[i].setBorder(false,Color.clear);
            }
        }
    }
    public void DeActivateCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {

                cards[i].isActive = false;
            }
        }
    }
    public IEnumerator EnemyAi(List<Card> EnemyCards, List<Card> PlayerCards)
    {
        List<Card> playerCardNotNull = PlayerCards;
        playerCardNotNull.RemoveAll(x => !x);

        List<Card> enemyCardNotNull = EnemyCards;
        enemyCardNotNull.RemoveAll(x => !x);

        if (PlayerUnit.GetComponent<PlayerUnit>().Barrier < PlayerUnit.GetComponent<PlayerUnit>().BarrierThreshold)
        {
            playerCardNotNull.Add(PlayerUnit.GetComponentInChildren<Card>());
        }

        List<Card> targets = new List<Card>();
        if (EnemyCards.Count > 0)
        {

            foreach (Card enemy in EnemyCards)
            {
                if (enemy != null)
                {

                    if (enemy.targetSelf == false)
                    {

                        enemy.target = PlayerCards[UnityEngine.Random.Range(0, playerCardNotNull.Count)];

                    }
                    else
                    {
                        enemy.target = EnemyCards[UnityEngine.Random.Range(0, enemyCardNotNull.Count)];

                    }
                    enemy.target.setBorder(true,Color.red);
                    SoundFxManager.Instance.AudioManagerFixedTime(SelectAudioClip, transform, 1f, 0.3f);
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
        // return targets;
    }
    public void GiveReward(List<BaseCard> RewardCards, int coins)
    {
        foreach (BaseCard card in RewardCards)
        {
            GameObject.FindWithTag("GameController").GetComponent<CardsData>().ShopCards.Add(card);

        }
        GameObject.FindWithTag("GameController").GetComponent<CardsData>().money += coins;
    }

}
public enum AttackStages
{
    SelectCard,
    SelectTarget,
    Attack,
    Idle
}
public enum BattleStages
{
    PlayerDrawCards,
    EnemyPlacesCards,
    EnemyDecides,
    PlayerAttacks,
    EnemyAttacks
}
