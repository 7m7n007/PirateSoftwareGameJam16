using System.Collections.Generic;
using UnityEngine;

public class changePhaseImg : MonoBehaviour
{
    [SerializeField] List<GameObject> BattlePhases;
    private int activePhase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject phases in BattlePhases)
        {
            phases.SetActive(false);
        }
        activePhase = 0;
        BattlePhases[activePhase].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NextPhase()
    {
        if (activePhase + 1 < BattlePhases.Count)
        {

            BattlePhases[activePhase].SetActive(false);
            activePhase += 1;
            BattlePhases[activePhase].SetActive(true);
        }
    }
}
