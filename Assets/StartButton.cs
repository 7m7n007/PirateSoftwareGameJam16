using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private GameObject GameController;
    private int Threshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController=GameObject.FindWithTag("GameController");
        Threshold = 5; // change this value to the desired threshold
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(string SceneName){
        // SceneController.instance
        if ( GameController.GetComponent<CardsData>().Deck.Count >=Threshold )
        {  
        GameController.GetComponent<SceneController>().LoadScene(SceneName);
    }
    }
}
