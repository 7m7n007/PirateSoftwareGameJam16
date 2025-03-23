using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleMaskManager : MonoBehaviour
{
    [SerializeField]GameObject cutscene;
    [SerializeField] List<GameObject> Masks;
    public BattleTutorial battleTutorial;
    void Start()
    {
        battleTutorial=GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleTutorial>();
        foreach(GameObject mak in Masks){
            mak.SetActive(true);
        }
    }
    void Update()
    {
        if(battleTutorial.tutorialComplete){
            gameObject.SetActive(false);
        }
        print((int)battleTutorial.battleTutorialState);
        ActivateMask((int)battleTutorial.battleTutorialState);
    }

    public void ActivateMask(int mask){
        foreach(GameObject mak in Masks){
            mak.SetActive(false);
        }
        Masks[mask].SetActive(true);
    }
    public void SkipTutorial(){
        battleTutorial.tutorialComplete=true;
    }
}
