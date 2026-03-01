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
    public TrainingEventSO currentEvent;
    public Transform CanvasParent;
    public GameObject[] StatObjects;
    public GameObject TimeObject;
    public GameObject MoodObject;
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
        LocationButton.onTrainingSelected += StartTraining;
    }

    void OnDisable()
    {
        LocationButton.onTrainingSelected -= StartTraining;
    }
    
    private void StartTraining(Location location)
    {
        // This function will be called when the player clicks on a location button, it will start the training for that location.
        // You can add any additional functionality you want here, such as loading a new scene or displaying a new UI panel.
        Debug.Log("Starting training for " + location.LocationName);

        if (location.currentTrainingEvent != null)
        {
            Debug.Log("Current training event: " + location.currentTrainingEvent.EventName);
            player.Stats[location.currentTrainingEvent.statAffected] += location.currentTrainingEvent.statChangeAmount;
            // start dialogue 
            StartTrainingDialogue(location.currentTrainingEvent);

            return;
        }
        // update stats based on the location's base stat increase and the player's current stats
        player.Stats[location.statIndex] += location.baseStatIncrease;
        player.UpdateStatText();
        
        // after everything is done end training
        endTraining();
        return;
    }

    private void endTraining()
    {
        EnableTrainingHUD();
        Destroy(currentEventIcon);
        onTrainingEnded?.Invoke();
    }
    public void EndTraining()
    {
        CurrentLocations[(int)currentEvent.locationRequirement].currentTrainingEvent = null;
        CurrentLocations[(int)currentEvent.locationRequirement].LocationEventIndex++;
        currentEvent = null;
        endTraining();
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
        currentEventIcon = Instantiate(EventIconPrefab);
        currentEventIcon.transform.SetParent(GameObject.Find($"Location{(int)trainingEvent.locationRequirement + 1}").transform, false);

        currentEventIcon.transform.localRotation = Quaternion.identity;
        RectTransform rectTransform = currentEventIcon.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = CurrentLocations[(int)trainingEvent.locationRequirement].GetComponentInChildren<RectTransform>().anchoredPosition + rectTransform.rect.height * Vector2.up;
        
        CurrentLocations[(int)trainingEvent.locationRequirement].currentTrainingEvent = trainingEvent;
        currentEvent = trainingEvent;
        return;
    }

    public void StartTrainingDialogue(TrainingEventSO trainingEvent)
    {
        // this function will be called to start the training dialogue for the current event, it will check if there is an event for the current location and if there is it will start the dialogue for that event.
        if (trainingEvent != null)
        {
            DialogueTextManager.Instance.currentDialouge = trainingEvent.dialouge;
            DialogueTextManager.Instance.StartDialouge();
        }
        DisableTrainingHUD();

        return;
    }

    public void DisableTrainingHUD()
    {
        DisableTrainingButtons();
        DisableTrainingStats();
        DisableTrainingYear();
        DisableTrainingMood();
    }

    public void DisableTrainingMood()
    {
        if (MoodObject != null)
        {
            MoodObject.SetActive(false);
        }
    }
    public void DisableTrainingYear()
    {
        if (TimeObject != null)
        {
            TimeObject.SetActive(false);
        }
    }

    public void DisableTrainingStats()
    {
        foreach (GameObject statObject in StatObjects)
        {
            statObject.SetActive(false);
        }
    }

    public void DisableTrainingButtons()
    {
        foreach (Location location in CurrentLocations)
        {
            location.gameObject.SetActive(false);
        }
    }
    
    public void EnableTrainingHUD()
    {
        EnableTrainingButtons();
        EnableTrainingStats();
        EnableTrainingYear();
        EnableTrainingMood();
    }

    public void EnableTrainingMood()
    {
        if (MoodObject != null)
        {
            MoodObject.SetActive(true);
        }
    }

    public void EnableTrainingButtons()
    {
        foreach (Location location in CurrentLocations)
        {
            location.gameObject.SetActive(true);
        }
    }

    public void EnableTrainingStats()
    {
        foreach (GameObject statObject in StatObjects)
        {
            statObject.SetActive(true);
        }
    }

    public void EnableTrainingYear()
    {
        TimeObject.SetActive(true);
    }
}
