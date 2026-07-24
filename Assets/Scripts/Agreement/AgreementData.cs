using UnityEngine;

[CreateAssetMenu(
    fileName = "NewAgreement",
    menuName = "Game/Agreement"
)]
public class AgreementData : ScriptableObject
{
    public string agreementName;

    [TextArea]
    public string description;

    public AgreementRarity rarity;

    [Range(0, 100)]
    public int baseSuccessChance;

    public int baseDecisionTime;
}
