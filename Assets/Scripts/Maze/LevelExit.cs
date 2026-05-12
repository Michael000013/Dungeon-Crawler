using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Get the current scene's index and add 1 to it
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there is actually a next scene to load
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // If there are no more levels, go back to the Main Menu
            SceneManager.LoadScene(0);
        }
    }
}

}