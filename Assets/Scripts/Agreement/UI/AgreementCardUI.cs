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
    private AgreementData agreementData;
    public AgreementData AgreementData => agreementData;
    private DiplomacyManager diplomacyManager;
    private float successChance;
    private float decisionTime;
    public float SuccessChance => successChance;
    public float DecisionTime => decisionTime;



    [Header("Button")]
    [SerializeField] private Button selectButton;

    public void Initialize(
    AgreementData agreement,
    float chance,
    float time,
    DiplomacyManager manager)
{
    agreementData = agreement;
    diplomacyManager = manager;
    successChance = chance;
    decisionTime = time;

    agreementNameText.text = agreement.agreementName;

    descriptionText.text = agreement.description;

    rarityText.text = agreement.rarity.ToString();

    successChanceText.text =
        chance.ToString("F0") + "%";

    decisionTimeText.text =
        time.ToString("F0") + " seconds";
}

private void Awake()
{
    selectButton.onClick.AddListener(OnSelectButtonPressed);
}

private void OnSelectButtonPressed()
{
    diplomacyManager.SelectAgreement(this);
}
}

