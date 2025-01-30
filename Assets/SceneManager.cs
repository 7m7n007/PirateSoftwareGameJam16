// using UnityEditor.SearchService;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private GameObject transition;
    
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Start() {
        transition=GameObject.FindWithTag("Transition");
        StartCoroutine(EntryLevel());
    }
    public void NextLevel(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadScene(string sceneName){
        StartCoroutine(ExitLevel(sceneName));
    }
    IEnumerator ExitLevel(string sceneName){
        transition=GameObject.FindWithTag("Transition");
        print("start Pressed");
        transition.GetComponent<Animator>().SetTrigger("Exit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneName);
        // LoadScene(sceneName);
    }
    IEnumerator EntryLevel(){
        transition.GetComponent<Animator>().SetTrigger("Entry");
        yield return new WaitForSeconds(.5f);
        // SceneManager.LoadSceneAsync(sceneName);
        // LoadScene(sceneName);
    }
}
