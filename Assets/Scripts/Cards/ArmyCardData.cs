using UnityEngine;

[CreateAssetMenu(fileName = "New Army", menuName = "Game/Card/Army")]
public class ArmyCardData : CardData
{
    [Header("Army Stats")]

    public int AttackPower;
    public int Durability;
    public int Speed;
    

    public override string GetStats()
{
    return
        "Attack: " + AttackPower +
        "\nDurability: " + Durability +
        "\nSpeed: " + Speed;
}
}