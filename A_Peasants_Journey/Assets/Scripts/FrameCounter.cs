using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameCounter : MonoBehaviour
{
    public int avgFrameRate;
    public TextMeshProUGUI DisplayText;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        DisplayText.text = avgFrameRate.ToString() + " FPS";
    }
}