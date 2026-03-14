using TMPro;
using UnityEngine;

public class ProgressionBarText : MonoBehaviour
{
    public TextMeshProUGUI progressionText;
    public Target target;

    void OnEnable()
    {
        target.onProgressValueChanged += UpdateProgressText;     
    }

    void OnDisable()
    {
        target.onProgressValueChanged -= UpdateProgressText;     
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateProgressText(float newValue)
    {
        progressionText.text = $"Progress: {Mathf.RoundToInt(newValue * 100)}%";
    }
}
