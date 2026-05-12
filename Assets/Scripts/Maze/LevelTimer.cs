using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 75f; // seconds

    public Text timerText;

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

    // Display the time as a whole number
    if (timerText != null)
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();

    if (currentTime <= 0f) TimeUp();
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