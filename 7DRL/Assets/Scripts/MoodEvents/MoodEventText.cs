using TMPro;
using UnityEngine;

public class MoodEventText : MonoBehaviour
{
    public TextMeshProUGUI MoodTitleText;
    public TextMeshProUGUI MoodDescriptionText;

    public void SetMoodEventText(string title, string description)
    {
        MoodTitleText.text = title;
        MoodDescriptionText.text = description;
    }
    
    public void SetMoodEventText(string description)
    {
        MoodDescriptionText.text = description;
    }
}
