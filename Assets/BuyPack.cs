using TMPro;
using UnityEngine;

public class BuyPack : MonoBehaviour
{
    [SerializeField] GameObject OpeningScene;
    [SerializeField] Transform spawnSlot;
    [SerializeField] TMP_Text cardTxt;
    public void OpenPack(){
        if(transform.childCount>0){
            transform.GetChild(0).GetComponent<PackScript>().OpenPack(OpeningScene,spawnSlot,cardTxt);
        }
    }
}
