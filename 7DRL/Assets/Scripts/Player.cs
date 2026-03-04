using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public float[] Stats;
    // not one hundred percent sure the names of the stats so probably change later
    public string[] items;
    public enum StatIndex
    {
        Strength,
        Intelligence,
        Charisma,
        Style
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Stats = new float[4]; // initialize the stats array with 4 elements
        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i] = 10; 
        }
        UpdateStatText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStatText()
    {
        GameObject statTextObject = GameObject.Find("Stats"); // find the stat text object based on the index
        
        print($"{statTextObject.transform.childCount} children in stat text object");
        for (int i = 0; i < statTextObject.transform.childCount; i++)
        {
            Transform child = statTextObject.transform.GetChild(i);
            GameObject childGO = child.gameObject;

            if (childGO != null)
            {
                StatText statText = childGO.GetComponent<StatText>();
                if (statText != null)
                {
                    StatIndex statEnum = (StatIndex)i;
                    string statTitle = statEnum.ToString();
                    statText.UpdateStatText(statTitle, Stats[i]);
                }
            }
            else
            {
                print("could not find stat text for " + "Stat" + (i + 1));
            }
        }
    }
}
