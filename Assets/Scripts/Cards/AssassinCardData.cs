using UnityEngine;

[CreateAssetMenu(fileName = "New Assassin", menuName = "Game/Card/Assassin")]
public class AssassinCardData : CardData
{
    [Header("Assassin Stats")]
    public int AssassinationPower;
    public int EspionagePower;
    public int OrganizationPower;
    public int Speed;

    public override string GetStats()
{
    return
        "Assassination: " + AssassinationPower +
        "\nEspionage: " + EspionagePower +
        "\nOrganization: " + OrganizationPower +
        "\nSpeed: " + Speed;
}
}