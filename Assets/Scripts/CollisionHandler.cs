using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip levelSuccess;
    [SerializeField] AudioClip levelFailure;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                FinishedLevelSequence(); 
                break;

            case "Friendly":  
                break;

            default:
                StartCrashSequence();
                break;
        }

    }

    void FinishedLevelSequence()
    {
        audioSource.PlayOneShot(levelSuccess);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(levelFailure);
        // todo: add particle effect
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay); //Invoke delays calling a method by the number specified
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // first level has build index of 0
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }





}
