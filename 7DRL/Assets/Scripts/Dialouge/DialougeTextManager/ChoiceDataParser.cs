using System;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDataParser : MonoBehaviour
{
    public static Dictionary<DialogueTextManager.ChoiceReuirementTypes, string> ParseChoiceData(string choiceText)
    {
        Dictionary<DialogueTextManager.ChoiceReuirementTypes, string> requirements = new Dictionary<DialogueTextManager.ChoiceReuirementTypes, string>();

        string[] parts = choiceText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            string[] pair = part.Split(':', StringSplitOptions.RemoveEmptyEntries);

            if (pair.Length != 2)
                continue;
            
            string enumPart = pair[0];
            string valuePart = pair[1];

            if (Enum.TryParse(enumPart, true, out DialogueTextManager.ChoiceReuirementTypes enumResult))
            {
                requirements[enumResult] = valuePart;
            }
        }
        return requirements;
    }

    public static float GetProgressValue(string choiceText)
    {
        ParseChoiceData(choiceText).TryGetValue(DialogueTextManager.ChoiceReuirementTypes.progress, out string progressValue);
        if (float.TryParse(progressValue, out float result))
        {
            return result;
        }
        return 0;
    }
}
