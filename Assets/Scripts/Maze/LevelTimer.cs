using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 60f; // seconds

    private float currentTime;
    private bool timerActive = true;

    private void Start()
    {
        currentTime = levelTime;
    }

    private void Update()
    {
        if (!timerActive) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            TimeUp();
        }
    }

    private void TimeUp()
    {
        timerActive = false;
        SceneManager.LoadScene(0);
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public float GetTimeRemaining()
    {
        return currentTime;
    }
}