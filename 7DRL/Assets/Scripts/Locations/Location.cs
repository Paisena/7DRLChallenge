using TMPro;
using UnityEditor;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string LocationName;
    public DialougeSO[] LocationEvents; // make this in order
    public int LocationEventIndex; // this is for the current event in the location, will be used to determine which event to trigger next
    public float baseStatIncrease;
    public int statIndex;
    public LocationManager.LocationIndex locationIndex;
    public TrainingEventSO currentTrainingEvent; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLocationButtonName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLocationInfo(Location location)
    {
        LocationName = location.LocationName;
        LocationEvents = location.LocationEvents;
        baseStatIncrease = location.baseStatIncrease;
        statIndex = location.statIndex;
        UpdateLocationButtonName();
    }

    public void UpdateLocationButtonName()
    {
        TextMeshProUGUI buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = LocationName;
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(Location))]
public class LocationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Location location = (Location)target;

        if (GUILayout.Button("Update Location Button Name"))
        {
            location.UpdateLocationButtonName();
        }
    }
}
#endif