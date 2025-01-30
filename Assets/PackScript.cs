using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    [SerializeField] List<BaseCard> cards;
    [SerializeField] List<int> cardsWeights;
    [SerializeField] List<float> cardsIndex;
    [SerializeField]int packSize;
    
    [SerializeField] GameObject OpeningScene;
    [SerializeField] GameObject BlankCard;
    [SerializeField] Transform spawnSlot;
    [SerializeField] TMP_Text cardText;
    [SerializeField] AnimationClip SpawnAnim;

    // [SerializeField] AnimationCurve animationCurve;
    private void Start()
    {
        int total = cardsWeights.Sum();
        float cf = 0;
        for (int i = 0; i < cardsWeights.Count; i++)
        {
            cf += cardsWeights[i];
            cardsIndex.Add(cf * (1f / total));
        }
    }
    public void OpenPack(){
        StartCoroutine(openPack());
    }

    public IEnumerator openPack(){
        OpeningScene.SetActive(true);
        List<BaseCard> newcards=openCards();
        foreach(BaseCard card in newcards){
            GameObject newCard=Instantiate(BlankCard,spawnSlot);
            // GameObject newCard=Instantiate(BlankCard,GameObject.FindWithTag("Canvas").transform);
            newCard.GetComponent<Card>().CardSO=card;
            newCard.GetComponent<Card>().runSpawnAnim=true  ;
            cardText.text=card.CardName;
            // GameObject.FindWithTag("GameController").GetComponent<CardsData>().UnlockedCards.Add(card);
            // newCard.GetComponent<Card>().PlayAnim(SpawnAnim);

            yield return new WaitForSeconds(2f);
            Destroy(newCard);
            cardText.text="";
        }
        OpeningScene.SetActive(false);
    }
    public List<BaseCard> openCards(){
        List<BaseCard> openedCards = new List<BaseCard>();
        for(int i = 0; i < packSize; i++){
            float randNum=Random.value;
            int randCard=checkValue(randNum);
            openedCards.Add(cards[randCard]);
        }
        return openedCards;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int checkValue(float value)
    {
        for (int i=0; i < cardsIndex.Count; i++)
        {
            if (value<cardsIndex[i])
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
