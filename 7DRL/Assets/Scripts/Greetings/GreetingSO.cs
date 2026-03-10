using UnityEngine;

[CreateAssetMenu(fileName = "GreetingSO", menuName = "Scriptable Objects/GreetingSO")]
public class GreetingSO : ScriptableObject
{
    public Target.Mood targetMood;
    public float minProgressMeter;
    public float maxProgressMeter;
    public string greetingText;
}
