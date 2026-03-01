using UnityEngine;
// This scripts holds the information and functions for time and it's progress duringthe training stage
public class GameTime : MonoBehaviour
{
    public enum StageOneTimeUnits
    {
        Semester,
        Year,
        Summer,
    }
    // Not a set unit of time because it will change over the stages, will have to make a function which translates this number to the correct unit base on the stage
    private int currentTurn = 0;
    public int CurrentTurn
    {
        get { return currentTurn; }
        set
        {
            currentTurn = value;
            CheckStageEnd();
        }
    } 
    public int TotalTurnsPerStage = 14;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckStageEnd()
    {
        if (CurrentTurn > 0 && CurrentTurn % TotalTurnsPerStage == 0)
        {
            // trigger stage end event
            Debug.Log("Stage ended!");
            print(CurrentTurn);
            print(CurrentTurn % TotalTurnsPerStage);
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
            // probably just throw player into conffesion scenario
        }
    }

    public string TranslateToTimeUnit()
    {
        string semester = "";
        switch (CurrentTurn % 4)
        {
            case 0: semester += "Semester 1,";
            break;
            case 1: semester += "Semester 2,";
            break;
            case 2: semester += "Semester 3,";
            break;
            case 3: semester += "Summer,";
            break;
        }
        return $"{semester} Year {(CurrentTurn / 4) + 1}";

    }
}
