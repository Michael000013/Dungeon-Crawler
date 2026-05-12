using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // This will load the scene at Index 1 (Level 1)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
