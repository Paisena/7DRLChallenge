using TMPro;
using UnityEngine;

public class StatText : MonoBehaviour
{
    public TextMeshProUGUI statValueText;
    public TextMeshProUGUI statTitleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateStatText(string statTitle, float statValue)
    {
        statTitleText.text = statTitle;
        statValueText.text = statValue.ToString();
        print("updated stat text");
    }
}
