using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class DarknessController : MonoBehaviour
{
    public Image darknessOverlay;
    public int memorabiliaCount = 0;
    public int maxMemorabilia = 8;
    public float maxAlpha = 1f; // 100% opacity when memorabiliaCount is 0
    public float minAlpha = 0.2f; // Adjust as needed

    void Start()
    {
        UpdateDarkness();
    }

    void Update()
    {
        // For testing purposes, you can increase memorabiliaCount over time (replace this with your actual logic)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            memorabiliaCount = Mathf.Min(memorabiliaCount + 1, maxMemorabilia);
            UpdateDarkness();
        }
    }

    void UpdateDarkness()
    {
        // Calculate darkness level based on memorabilia count
        float darknessLevel = Mathf.Lerp(maxAlpha, minAlpha, (float)memorabiliaCount / maxMemorabilia);

        // Set the alpha value of the darkness overlay
        Color overlayColor = darknessOverlay.color;
        overlayColor.a = darknessLevel;
        darknessOverlay.color = overlayColor;
    }
}
