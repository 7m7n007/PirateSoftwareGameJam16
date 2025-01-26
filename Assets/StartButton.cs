using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private GameObject GameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController=GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(string SceneName){
        // SceneController.instance
        GameController.GetComponent<SceneController>().LoadScene(SceneName);
    }
}
