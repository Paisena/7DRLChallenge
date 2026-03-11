using UnityEngine;

[CreateAssetMenu(fileName = "ItemReward", menuName = "Scriptable Objects/ItemReward")]
public class ItemReward : Reward
{
    [SerializeField] private Item item;

    public override void GiveReward(Player player)
    {
        player.inventory.AddItemToInventory(item);
    }
}
