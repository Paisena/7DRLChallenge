using UnityEngine;
using System;

public struct LocationInfo
{
    public Location location;
    public string statIndex;
}
public class LocationButton : MonoBehaviour
{
    public static event Action<Location> onTrainingSelected;
    public void StartTraining()
    {
        // This function will be called when the player clicks on a location button, it will start the training for that location.
        // You can add any additional functionality you want here, such as loading a new scene or displaying a new UI panel.
        onTrainingSelected?.Invoke(GetComponentInParent<Location>());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
