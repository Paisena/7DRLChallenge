using UnityEngine;

[CreateAssetMenu(fileName = "LocationSO", menuName = "Scriptable Objects/LocationSO")]
public class LocationSO : ScriptableObject
{
    public string LocationName;
    public DialougeSO[] LocationEvents; // make this in order
    public int LocationEventIndex; // this is for the current event in the location, will be used to determine which event to trigger next
    public float baseStatIncrease;
    public int statIndex;
    public LocationManager.LocationIndex locationIndex;
}
