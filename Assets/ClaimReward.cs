using TMPro;
using UnityEngine;

public class ClaimReward : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    [SerializeField] TMP_Text RewardText;
    private int reward;
    [SerializeField] AudioClip coinAudioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reward=battleManager.RewardMoney;
        RewardText.text="+"+reward.ToString();
    }

    public void claimReward(){
        GameObject.FindWithTag("GameController").GetComponent<CardsData>().money+=reward;
        SoundFxManager.Instance.AudioManagerFixedTime(coinAudioClip,transform,1f,0.5f);
        Destroy(gameObject);
    }
}
