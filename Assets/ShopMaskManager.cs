using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopMaskManager : MonoBehaviour
{
    [SerializeField]GameObject cutscene;
    [SerializeField] List<GameObject> Masks;
    public ShopTutorial shopTutorial;
    void Start()
    {
        shopTutorial=GameObject.FindGameObjectWithTag("GameController").GetComponent<ShopTutorial>();
    }
    void Update()
    {
        if(shopTutorial.tutorialComplete){
            gameObject.SetActive(false);
        }
        // print((int)shopTutorial.shopTutorialState);
        ActivateMask((int)shopTutorial.shopTutorialState);
    }

    public void ActivateMask(int mask){
        foreach(GameObject mak in Masks){
            mak.SetActive(false);
        }
        Masks[mask].SetActive(true);
    }
    public void SkipTutorial(){
        shopTutorial.tutorialComplete=true;
    }
}
