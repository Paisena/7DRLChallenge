using TMPro;
using UnityEngine;

public class GameTimeText : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void OnEnable()
    {
        GameTimeManager.Instance.UpdateTimeText(GameTimeManager.Instance.gameTime.TranslateToTimeUnit());
    }

    public void UpdateTimeText(string text)
    {
        timeText.text = text;
    }
}
