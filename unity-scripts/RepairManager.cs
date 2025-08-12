using UnityEngine;
using UnityEngine.UI;

public class RepairManager : MonoBehaviour
{
    [SerializeField]
    private Slider progressSlider;

    [SerializeField]
    private Text progressText;

    private int totalSlots;
    private int placedCount;

    private void Start()
    {
        var slots = FindObjectsOfType<RepairSlot>();
        totalSlots = slots != null ? slots.Length : 0;
        placedCount = 0;
        UpdateUI();
    }

    public void NotifyPartPlaced()
    {
        placedCount = Mathf.Clamp(placedCount + 1, 0, totalSlots);
        UpdateUI();

        if (totalSlots > 0 && placedCount >= totalSlots)
        {
            OnRepairComplete();
        }
    }

    private void UpdateUI()
    {
        float p = totalSlots > 0 ? (float)placedCount / totalSlots : 0f;

        if (progressSlider != null)
        {
            progressSlider.minValue = 0f;
            progressSlider.maxValue = 1f;
            progressSlider.value = p;
        }

        if (progressText != null)
        {
            progressText.text = $"Repair: {Mathf.RoundToInt(p * 100f)}%";
        }
    }

    private void OnRepairComplete()
    {
        if (progressText != null)
        {
            progressText.text = "Device Repaired! ✔";
        }

        Debug.Log("Repair complete!");
    }
}