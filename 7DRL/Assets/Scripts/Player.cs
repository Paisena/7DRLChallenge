using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public float[] _stats;
    public float[] Stats;
    // not one hundred percent sure the names of the stats so probably change later
    public string[] statNames;
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
        for (int i = 0; i < Stats.Length; i++)
        {
            GameObject statTextObject = GameObject.Find("Stat" + (i + 1)); // find the stat text object based on the index

            if (statTextObject != null)
            {
                StatText statText = statTextObject.GetComponent<StatText>();
                if (statText != null)
                {
                    statText.UpdateStatText(statNames[i], Stats[i]);
                }
            }
        }
    }
}
