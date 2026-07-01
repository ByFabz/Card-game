using UnityEngine;

[CreateAssetMenu(fileName = "New Blacksmith", menuName = "Game/Card/Blacksmith")]
public class BlacksmithCardData : CardData
{
    [Header("Blacksmith Stats")]
    public int ProductionSpeedBonus;
    public int WeaponQuality;
    public int ArmorQuality;
    public int Efficiency;

    public override string GetStats()
{
    return
        "Production Speed: " + ProductionSpeedBonus +
        "\nWeapon Quality: " + WeaponQuality +
        "\nArmor Quality: " + ArmorQuality +
        "\nEfficiency: " + Efficiency;
}
}