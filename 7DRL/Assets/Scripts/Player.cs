using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public float[] stats;
    // not one hundred percent sure the names of the stats so probably change later
    public string statOneName;
    public string statTwoName;
    public string statThreeName;
    public string statFourName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = new float[4]; // initialize the stats array with 4 elements
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = 0; // set each stat to 0 at the start of the game
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
