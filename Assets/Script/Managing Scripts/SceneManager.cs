// using UnityEditor.SearchService;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private GameObject transition;
     [SerializeField] AudioClip TransitionSound;

     [SerializeField] private SoundMixerManager SoundManager;
    
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
        SoundManager=GameObject.FindWithTag("MixerManager").GetComponent<SoundMixerManager>();
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
        SoundManager=GameObject.FindWithTag("MixerManager").GetComponent<SoundMixerManager>();
        print("start Pressed");
         SoundFxManager.Instance.AudioManager(TransitionSound, transform, 1f);
         SoundManager.SetMusicVolume(0f);
        transition.GetComponent<Animator>().SetTrigger("Exit");
        yield return new WaitForSeconds(1f);


        SceneManager.LoadSceneAsync(sceneName);
        // LoadScene(sceneName);
    }
    IEnumerator EntryLevel(){
        transition=GameObject.FindWithTag("Transition");
        SoundManager=GameObject.FindWithTag("MixerManager").GetComponent<SoundMixerManager>();
        SoundManager.SetMusicVolume(0f);
        SoundFxManager.Instance.AudioManager(TransitionSound, transform, 1f);
        transition.GetComponent<Animator>().SetTrigger("Entry");
        yield return new WaitForSeconds(.5f);
        SoundManager.SetMusicVolume(0.5f);
        // SceneManager.LoadSceneAsync(sceneName);
        // LoadScene(sceneName);
    }
}
