using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
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
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void StartCrashSequence()
    {
        // todo: add SFX upon crash
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
