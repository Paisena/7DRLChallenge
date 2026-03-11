using UnityEngine;

[CreateAssetMenu(fileName = "StatReward", menuName = "Scriptable Objects/StatReward")]
public class StatReward : Reward
{
    [SerializeField] private Player.StatIndex statIndex;
    [SerializeField] private float statIncreaseAmount;

    public override void GiveReward(Player player)
    {
        player.AddFlatStat((int)statIndex, statIncreaseAmount);
    }
}
