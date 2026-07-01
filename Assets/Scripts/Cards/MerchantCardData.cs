using UnityEngine;

[CreateAssetMenu(fileName = "New Merchant", menuName = "Game/Card/Merchant")]
public class MerchantCardData : CardData
{
    [Header("Merchant Stats")]
    public int TradePowerBonus;
    public int GoldBonus;
    public int İnternationalInfluence;
    public int BargainingSkill;

    public override string GetStats()
{
    return
        "Trade Bonus: " + TradePowerBonus +
        "\nGold Bonus: " + GoldBonus +
        "\nInternational Influence: " + İnternationalInfluence +
        "\nBargaining: " + BargainingSkill;
}
}