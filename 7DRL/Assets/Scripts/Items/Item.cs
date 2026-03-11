using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public float[] statMultipler = new float[4];

    public abstract void UseItem();
    public abstract void TrainingOverEffect();
    public abstract void OnGetEvent();
    public void OnEnable()
    {
        LocationManager.onTurnOver += TrainingOverEffect;
    }

    public void OnDisable()
    {
        LocationManager.onTurnOver -= TrainingOverEffect;
    }
}
