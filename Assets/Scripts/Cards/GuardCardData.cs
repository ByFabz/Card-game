using UnityEngine;

[CreateAssetMenu(fileName = "New Guard", menuName = "Game/Card/Guard")]
public class SecurityCardData : CardData
{
    [Header("Guard Stats")]
    public int ProtectionPower;
    public int Awareness;

    public override string GetStats()
{
    return
        "Protection: " + ProtectionPower +
        "\nAwareness: " + Awareness;
}
}