using System.Collections.Generic;
using UnityEngine;

public class GrettingGenerator : MonoBehaviour
{
    public GreetingSO[] greetings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GenerateGreeting()
    {
        Target target = TargetManager.Instance.currentTarget;
        string greeting = "";

        // get current parameters of the target

        // based on the parameters, put possible greetings into list
        List<string> possibleGreetings = new List<string>();
        for (int i = 0; i < greetings.Length; i++)
        {
            if (greetings[i].targetMood == target.targetMood && greetings[i].progressMeterRequired <= target.progressValue)
            {
                possibleGreetings.Add(greetings[i].greetingText);
            }
        }

        // select a random greeting from the list of possible greetings
        if (possibleGreetings.Count > 0)
        {
            greeting = possibleGreetings[Random.Range(0, possibleGreetings.Count)];
        }

        return greeting;
    }
}
