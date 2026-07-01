using UnityEngine;

[CreateAssetMenu(fileName = "New Security", menuName = "Game/Card/Security")]
public class SecurityCardData : CardData
{
    [Header("Security Stats")]
    public int ProtectionPower;
    public int Awareness;

    public override string GetStats()
{
    return
        "Protection: " + ProtectionPower +
        "\nAwareness: " + Awareness;
}
}