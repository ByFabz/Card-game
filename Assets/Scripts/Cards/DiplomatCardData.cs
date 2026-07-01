using UnityEngine;

[CreateAssetMenu(fileName = "New Diplomat", menuName = "Game/Card/Diplomat")]
public class DiplomatCardData : CardData
{
    [Header("Diplomat Stats")]
    public int İntelligence;
    public int Persuasion;
    public int AgreementSkill;
    public int Resistance;

    public override string GetStats()
{
    return
        "Intelligence: " + İntelligence +
        "\nPersuasion: " + Persuasion +
        "\nAgreement Skill: " + AgreementSkill +
        "\nResistance: " + Resistance;
}
}