using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public float[] Stats;
    public float[] statMultipler = new float[4];
    // not one hundred percent sure the names of the stats so probably change later
    public Inventory inventory;
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

        for (int i = 0; i < statMultipler.Length; i++)
        {
            statMultipler[i] = 1; 
        }
        UpdateStatText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Inventory.OnItemGet += UpdateStatMultipler;
    }

    private void OnDisable()
    {
        Inventory.OnItemGet -= UpdateStatMultipler;
    }


    public void UpdateStatText()
    {
        GameObject statTextObject = GameObject.Find("Stats"); // find the stat text object based on the index
        
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
    public void AddFlatStat(int statIndex, float amount)
    {
        Stats[statIndex] += amount;
        UpdateStatText();
    }
    public void ChangeStat(int statIndex, float amount)
    {
        Stats[statIndex] += amount * statMultipler[statIndex];
        UpdateStatText();
    }

    public void UpdateStatMultipler(Item item)
    {
        for (int i = 0; i < statMultipler.Length; i++)
        {
            statMultipler[i] += item.statMultipler[i];
        }
    }
}
