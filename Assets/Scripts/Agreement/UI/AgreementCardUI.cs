using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgreementCardUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text agreementNameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text rarityText;
    [SerializeField] private TMP_Text successChanceText;
    [SerializeField] private TMP_Text decisionTimeText;

    [Header("Button")]
    [SerializeField] private Button selectButton;

    public void Initialize(
    AgreementData agreement,
    float successChance,
    float decisionTime)
{
    agreementNameText.text = agreement.agreementName;

    descriptionText.text = agreement.description;

    rarityText.text = agreement.rarity.ToString();

    successChanceText.text =
        "Success Chance: " + successChance.ToString("F0") + "%";

    decisionTimeText.text =
        "Decision Time: " + decisionTime.ToString("F0") + " sec";
}
}

