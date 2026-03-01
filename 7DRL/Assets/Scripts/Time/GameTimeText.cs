using TMPro;
using UnityEngine;

public class GameTimeText : MonoBehaviour
{
   public TextMeshProUGUI timeText;

   public void UpdateTimeText(string text)
   {
       timeText.text = text;
   }
}
