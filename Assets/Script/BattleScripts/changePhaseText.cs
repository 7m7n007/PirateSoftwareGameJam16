using TMPro;
using UnityEngine;

public class changePhaseText : MonoBehaviour
{
    [SerializeField] GameObject selectUser;
    [SerializeField] GameObject selectTarget;
    // private Phases currentPhase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // currentPhase=Phases.None;
    }

    public void changePhase(Phases changePhase){
        if(changePhase==Phases.None){
            selectUser.SetActive(false);
            selectTarget.SetActive(false);
        }
        else if(changePhase==Phases.selectTarget){
            selectUser.SetActive(false);
            selectTarget.SetActive(true);
        }
        else if(changePhase==Phases.selectUser){
            selectUser.SetActive(true);
            selectTarget.SetActive(false);
        }
    }
    public enum Phases{
        selectUser,
        selectTarget,
        None
    }
}
