using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;

    bool isTransitioning = false;

    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip levelSuccess;
    [SerializeField] AudioClip levelFailure;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return; 
        }
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
        isTransitioning = true;
        audioSource.PlayOneShot(levelSuccess);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); //stop all other sound effects
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
