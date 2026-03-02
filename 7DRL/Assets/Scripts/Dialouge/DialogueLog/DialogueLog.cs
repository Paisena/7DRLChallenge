using System;
using UnityEngine;

public class DialogueLog : MonoBehaviour
{
    public string LogText;
    public static DialogueLog Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddToLog(string newEntry, bool isPlayer = false)
    {
        LogText += (isPlayer ? "[Player] " : $"[{DialogueTextManager.Instance.currentDialouge.CharacterName}] ") + newEntry + "\n";
    }

    internal void AddToLog(string text, object value)
    {
        throw new NotImplementedException();
    }
}
