using JetBrains.Annotations;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager Instance { get; private set; }
    public GameTime gameTime;
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
        gameTime = GetComponent<GameTime>();
    }

    void OnEnable()
    {
        //LocationButton.onTrainingSelected += ProgressTime;
        LocationManager.onTrainingEnded += ProgressTime;
    }

    void OnDisable()
    {
        //LocationButton.onTrainingSelected -= ProgressTime;
        LocationManager.onTrainingEnded -= ProgressTime;
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ProgressTime()
    {
        print("Progressing time");
        gameTime.CurrentTime++; // just update it for now, will probably have to add more stuff later
    }

    public void StartTime()
    {
        gameTime.CurrentTime = 0;
    }
}
