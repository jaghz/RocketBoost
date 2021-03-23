using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Finished level");
                break;

            case "Friendly":
                Debug.Log("Found friendly");
                break;

            case "Fuel":
                Debug.Log("Found fuel");
                break;

            default:
                ReloadLevel();
                break;
        }

    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }





}
