using UnityEngine;

public class Buttons : MonoBehaviour
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
    public void SceneChange(string SceneName)
    {
        // SceneController.instance
        GameController.GetComponent<SceneController>().LoadScene(SceneName);
    
    }

    public void Quit()
{
    #if UNITY_STANDALONE
    Application.Quit();
     #elif UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
     #endif
}
}
