using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image foreground;

    public void SetHealth(float current, float max)
    {
        foreground.fillAmount = current / max;
    }
}
