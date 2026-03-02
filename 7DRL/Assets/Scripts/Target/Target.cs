using UnityEngine;

public class Target : MonoBehaviour
{
    public string TargetName;
    public string TargetDescription;
    public enum Mood
    {
        Happy,
        Sad,
        Angry
        
    }    
    public Mood targetMood;
    public int progressValue = 0;
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
