using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "item1", menuName = "Scriptable Objects/item1")]
public class item1 : Item
{
    public override void UseItem()
    {
        // Implementation for using the item

    }

    public override void TrainingOverEffect()
    {
        // Implementation for the effect when training ends
        return;
    }

    public override void OnGetEvent()
    {
        // Implementation for when the item is obtained
        Debug.Log("Item obtained: " + itemName);
        return;
    }
}
