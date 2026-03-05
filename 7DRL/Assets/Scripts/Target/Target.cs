using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action<int> onProgressValueChanged;
    public string TargetName;
    public string TargetDescription;
    public enum Mood
    {
        Happy,
        Sad,
        Angry
        
    }    
    public Mood targetMood;
    private int _progressValue;
    public int progressValue
    {
        get => _progressValue;
        set
        {
            int oldValue = _progressValue;
            _progressValue = value;

            int delta = progressValue - oldValue;

            onProgressValueChanged?.Invoke(delta);

        }
    }
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
