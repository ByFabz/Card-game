using UnityEngine;

[CreateAssetMenu(fileName = "New Diplomat", menuName = "Game/Card/Diplomat")]
public class DiplomatCardData : CardData
{
    [Header("Diplomat Stats")]
    public int Intelligence;
    public int Persuasion;
    public int Negotiation;
    public int Resistance;

    public override string GetStats()
{
    return
        "Intelligence: " + Intelligence +
        "\nPersuasion: " + Persuasion +
        "\nAgreement Skill: " + Negotiation +
        "\nResistance: " + Resistance;
}
}