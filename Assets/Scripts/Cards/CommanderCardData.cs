using UnityEngine;

[CreateAssetMenu(fileName = "New Commander", menuName = "Game/Card/Commander")]
public class CommanderCardData : CardData
{
    [Header("Commander Stats")]
    public int CommandCapacity;
    public int Courage;
    public int Strategy;

    public override string GetStats()
{
    return
        "Command Capacity: " + CommandCapacity +
        "\nCourage: " + Courage +
        "\nStrategy: " + Strategy;
}
}