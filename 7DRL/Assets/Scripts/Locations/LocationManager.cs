using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public static LocationManager Instance;
    // These are arrays with each index being for the stage
    public Location[] LocationOneInfo;
    public Location[] LocationTwoInfo;
    public Location[] LocationThreeInfo;
    public Location[] LocationFourInfo;
    public Location[] CurrentLocations;
    public TrainingEventSO[] TrainingEvents;
    public Player player;
    private int currentStageIndex =  1;
    public GameObject EventIconPrefab;
    public GameObject currentEventIcon;
    public Transform CanvasParent;
    public enum LocationIndex
    {
        LocationOne,
        LocationTwo,
        LocationThree,
        LocationFour
    }

    public static event Action onTrainingEnded;
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

    void OnEnable()
    {
        LocationButton.onTrainingSelected += startTraining;
    }

    void OnDisable()
    {
        LocationButton.onTrainingSelected -= startTraining;
    }
    
    private void startTraining(Location location)
    {
        // This function will be called when the player clicks on a location button, it will start the training for that location.
        // You can add any additional functionality you want here, such as loading a new scene or displaying a new UI panel.
        Debug.Log("Starting training for " + location.LocationName);

        if (location.currentTrainingEvent != null)
        {
            Debug.Log("Current training event: " + location.currentTrainingEvent.EventName);
            // trigger the event's dialouge
            //DialougeManager.Instance.StartDialouge(location.currentTrainingEvent.dialouge);
            // update the player's stats based on the event's stat change amount and stat affected
            player.stats[location.currentTrainingEvent.statAffected] += location.currentTrainingEvent.statChangeAmount;
            location.currentTrainingEvent = null;
            location.LocationEventIndex++; 
            endTraining();
            return;
        }
        else
        {
            print("no event");
        }
        // update stats based on the location's base stat increase and the player's current stats
        location.baseStatIncrease += player.stats[location.statIndex];
        
        // after everything is done end training
        endTraining();
        return;
    }

    private void endTraining()
    {
        Destroy(currentEventIcon);
        onTrainingEnded?.Invoke();
    }

    public void UpdateNextStageLocation()
    {
        currentStageIndex++;
        // get locations in scene and then update them to have the info for the next stage.
        Location location = GameObject.Find("Location 1").GetComponent<Location>();
        location.UpdateLocationInfo(LocationOneInfo[currentStageIndex]);

        location = GameObject.Find("Location 2").GetComponent<Location>();
        location.UpdateLocationInfo(LocationTwoInfo[currentStageIndex]);

        location = GameObject.Find("Location 3").GetComponent<Location>();
        location.UpdateLocationInfo(LocationThreeInfo[currentStageIndex]);

        location = GameObject.Find("Location 4").GetComponent<Location>();
        location.UpdateLocationInfo(LocationFourInfo[currentStageIndex]);

        return;
    }

    public void GiveLocationEvent(TrainingEventSO trainingEvent)
    {
        // this function will be called by the TrainingEventManager when a training event is triggered, it will give the player the event for the current location.
        Debug.Log("Giving player " + trainingEvent.EventName + " event for " + CurrentLocations[(int)trainingEvent.locationRequirement].LocationName);

        currentEventIcon = Instantiate(EventIconPrefab);
        currentEventIcon.transform.SetParent(GameObject.Find($"Location{(int)trainingEvent.locationRequirement + 1}").transform, false);

        currentEventIcon.transform.localRotation = Quaternion.identity;
        RectTransform rectTransform = currentEventIcon.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = CurrentLocations[(int)trainingEvent.locationRequirement].GetComponentInChildren<RectTransform>().anchoredPosition + rectTransform.rect.height * Vector2.up;
        
        CurrentLocations[(int)trainingEvent.locationRequirement].currentTrainingEvent = trainingEvent;
        return;
    }
}
