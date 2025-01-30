using System.Collections.Generic;
using UnityEngine;

public class changePhaseImg : MonoBehaviour
{
    [SerializeField] List<GameObject> BattlePhasesText;
    // private BattlePhases activePhase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject phases in BattlePhasesText)
        {
            phases.SetActive(false);
        }
        BattlePhasesText[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // public void NextPhase()
    // {
    //     if (activePhase + 1 < BattlePhasesText.Count)
    //     {

    //         BattlePhasesText[activePhase].SetActive(false);
    //         activePhase += 1;
    //         BattlePhasesText[activePhase].SetActive(true);
    //     }
    // }
    public void changePhase(BattlePhases battlePhase){
        switch (battlePhase){
            case BattlePhases.SetUpPhase:
                BattlePhasesText[0].SetActive(true);
                break;
            case BattlePhases.PlayerAttack:
                BattlePhasesText[1].SetActive(true);
                break;
            case BattlePhases.EnemyAttack:
                BattlePhasesText[2].SetActive(true);
                break;
            default:
                BattlePhasesText[0].SetActive(true);
                break;
        }
    }
    public enum BattlePhases{
        SetUpPhase,
        PlayerAttack,
        EnemyAttack,
    }
}
