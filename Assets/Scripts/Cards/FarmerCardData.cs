using UnityEngine;

[CreateAssetMenu(fileName = "New Farmer", menuName = "Game/Card/Farmer")]
public class FarmerCardData : CardData
{
    [Header("Farmer Stats")]
    public int FoodProductionBonus;
    public int HarvestEfficiency;
    public int HarvestSpeedBonus;
    public int LandManagement;

    public override string GetStats()
{
    return
        "Food Bonus: " + FoodProductionBonus +
        "\nHarvest Efficiency: " + HarvestEfficiency +
        "\nHarvest Speed: " + HarvestSpeedBonus +
        "\nLand Management: " + LandManagement;
}
}