using System.Collections;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
    public Target currentTarget;
    public MoodEvent[] moodEvents;
    public int MoodEventChance = 30; 
    public MoodEventText moodEventText;
    public static event System.Action onMoodEventOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        LocationManager.onTrainingEnded += MoodEventCheck;
    }

    void OnDisable()
    {
        LocationManager.onTrainingEnded -= MoodEventCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoodEventCheck()
    {
        StartCoroutine(DecideTargetMood());
    }

    public IEnumerator DecideTargetMood()
    {
        print("mood event triggered");
        // Roll to see if a mood event happens
        int roll = Random.Range(0, 100);
        if (roll < MoodEventChance) // 30% chance for a mood event to occur
        {
            int moodEventIndex = Random.Range(0, moodEvents.Length);
            currentTarget.targetMood = moodEvents[moodEventIndex].MoodChangeTo;

            // Trigger the dialogue for the mood event
            DialogueTextManager.Instance.StartDialouge(moodEvents[moodEventIndex].dialouge);
            moodEventText.SetMoodEventText(currentTarget.targetMood.ToString());
            yield return new WaitUntil(() => DialogueTextManager.Instance.isInDialouge == false);
            LocationManager.Instance.EnableTrainingHUD();
        }
        onMoodEventOver?.Invoke();
    }
}
