using UnityEngine;

[CreateAssetMenu(fileName = "MoodEvent", menuName = "Scriptable Objects/MoodEvent")]
public class MoodEvent : ScriptableObject
{
    public string EventName;
    public DialougeSO dialouge;
    public int WhatStage;
    public Target.Mood MoodChangeTo;
    public Target.Mood MoodChangeFrom;
}
