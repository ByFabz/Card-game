using UnityEngine;

[CreateAssetMenu(fileName = "New Leader", menuName = "Game/Card/Leader")]
public class LeaderCardData : CardData
{
    [Header("Leader Stats")]
    public int Popularity;
    public int Prestige;
    public int Authority;

    public override string GetStats()
{
    return
        "Popularity: " + Popularity +
        "\nPrestige: " + Prestige +
        "\nAuthority: " + Authority;
}
}
