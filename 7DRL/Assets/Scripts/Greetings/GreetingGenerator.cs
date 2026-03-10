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
        string greeting = "";

        // get current parameters of the target

        // based on the parameters, put possible greetings into list
        List<string> possibleGreetings = new List<string>();
        for (int i = 0; i < greetings.Length; i++)
        {
            if (CanSayGreeting(greetings[i]))
            {
                possibleGreetings.Add(greetings[i].greetingText);
            }
        }

        // select a random greeting from the list of possible greetings
        if (possibleGreetings.Count > 0)
        {
            greeting = possibleGreetings[Random.Range(0, possibleGreetings.Count)];
        }
        else
        {
            print("No possible greetings found for current target parameters.");
             greeting = "Hello."; // default greeting if no other greetings are possible
        }

        return greeting;
    }

    public bool CanSayGreeting(GreetingSO greeting)
    {
        Target target = TargetManager.Instance.currentTarget;
        if (greeting.targetMood == target.targetMood && greeting.minProgressMeter < target.progressValue && greeting.maxProgressMeter >= target.progressValue)
        {
            return true;
        }
        return false;
    }
}
