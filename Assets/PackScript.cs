using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    [SerializeField] Pack packSO;
    [SerializeField] List<BaseCard> cards;
    [SerializeField] List<int> cardsWeights;
    [SerializeField] int packSize;


    [SerializeField] List<float> cardsIndex;

    // [SerializeField] GameObject OpeningScene;
    [SerializeField] GameObject BlankCard;
    // [SerializeField] Transform spawnSlot;
    // [SerializeField] TMP_Text cardText;
    [SerializeField] AnimationClip SpawnAnim;
    [SerializeField] AudioClip OpeningClip;

    // [SerializeField] AnimationCurve animationCurve;
    private void Start()
    {
        cards=packSO.cards;
        cardsWeights=packSO.cardsWeights;
        packSize=packSO.packSize;

        int total = cardsWeights.Sum();
        float cf = 0;
        for (int i = 0; i < cardsWeights.Count; i++)
        {
            cf += cardsWeights[i];
            cardsIndex.Add(cf * (1f / total));
        }
    }
    public void OpenPack(GameObject openingScene, Transform spawnSlot, TMP_Text cardText)
    {
        StartCoroutine(openPack(openingScene, spawnSlot, cardText));
    }

    private IEnumerator openPack(GameObject openingScene, Transform spawnSlot, TMP_Text cardText)
    {
        transform.GetComponentInChildren<Animator>().SetTrigger("Open");
        SoundFxManager.Instance.AudioManager(OpeningClip,transform,1f);
        yield return new WaitForSeconds(2f);
        openingScene.SetActive(true);
        List<BaseCard> newcards = openCards();
        foreach (BaseCard card in newcards)
        {
            GameObject newCard = Instantiate(BlankCard, spawnSlot);
            // GameObject newCard=Instantiate(BlankCard,GameObject.FindWithTag("Canvas").transform);
            newCard.GetComponent<Card>().CardSO = card;
            newCard.GetComponent<Card>().runSpawnAnim = true;
            cardText.text = card.CardName;
            GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Add(card);
            // newCard.GetComponent<Card>().PlayAnim(SpawnAnim);

            yield return new WaitForSeconds(1f);
            Destroy(newCard);
            cardText.text = "";
        }
        openingScene.SetActive(false);
        Destroy(gameObject);
    }
    private List<BaseCard> openCards()
    {
        List<BaseCard> openedCards = new List<BaseCard>();
        for (int i = 0; i < packSize; i++)
        {
            float randNum = Random.value;
            int randCard = checkValue(randNum);
            openedCards.Add(cards[randCard]);
        }
        return openedCards;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int checkValue(float value)
    {
        for (int i = 0; i < cardsIndex.Count; i++)
        {
            if (value < cardsIndex[i])
            {
                // print(i);
                // break;
                return i;
            }
        }
        // print("no");
        return -1;
    }

}
