using UnityEngine;

[CreateAssetMenu(fileName = "New Soldier", menuName = "Game/Card/Soldier")]
public class SoldierCardData : CardData
{
    public override string GetStats()
    {
        return "Special Passive Move";
    }
}