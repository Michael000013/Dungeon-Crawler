using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image foreground;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // This is the function the EnemyAI is looking for
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (foreground != null)
        {
            foreground.fillAmount = currentHealth / maxHealth;
        }
    }

    private void LateUpdate()
    {
        // Keeps the health bar facing the camera
        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                             mainCamera.transform.rotation * Vector3.up);
        }
    }
}