using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;



public class DiplomacyManager : MonoBehaviour
{
    [SerializeField] private List<AgreementData> agreementList;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private AgreementCardUI agreementCardPrefab;
    [SerializeField] private Transform player1AgreementContainer;
    [SerializeField] private Transform player2AgreementContainer;
    [SerializeField] private TMP_Text negotiationTimerText;
    [SerializeField] private TMP_Text cooldownTimerText;
    [SerializeField] private TMP_Text successOrFailText;
    [SerializeField] private GameObject rollAgainButton;
    private List<AgreementCardUI> activeCards = new List<AgreementCardUI>();
    private List<AgreementData> player1Agreements = new List<AgreementData>();
    private List<AgreementData> player2Agreements = new List<AgreementData>();
    private AgreementData selectedAgreement;
    private float remainingTime;
    private float selectedSuccessChance;
    private void Start()
    {
        GenerateAgreementsForPlayer(
        player1,
        player2,
        player1Agreements,
        player1AgreementContainer);

        GenerateAgreementsForPlayer(
        player2,
        player1,
        player2Agreements,
        player2AgreementContainer);
            
    }

    private void GenerateAgreementsForPlayer(
    Player player,
    Player enemy,
    List<AgreementData> playerAgreements,
    Transform agreementContainer)
    {
    playerAgreements.Clear();

    List<AgreementData> availableAgreements =
        new List<AgreementData>(agreementList);

    for (int i = 0; i < 3; i++)
    {
        AgreementRarity selectedRarity =
            DiplomacyCalculator.GetRandomRarity(player.Diplomat.Intelligence);

        List<AgreementData> matchingAgreements =
            new List<AgreementData>();

        foreach (AgreementData agreement in availableAgreements)
        {
            if (agreement.rarity == selectedRarity)
            {
                matchingAgreements.Add(agreement);
            }
        }

        if (matchingAgreements.Count == 0) //bunun sayesinde yeterince agreement yoksa olan bir agreement seçene kadar devam etmesini sağlar önemli bir kısım bu
        {
            i--;
            continue;
        }

        int randomIndex =
            Random.Range(0, matchingAgreements.Count);

        AgreementData generatedAgreement =
            matchingAgreements[randomIndex];

        availableAgreements.Remove(generatedAgreement);
        playerAgreements.Add(generatedAgreement);

        int chance = DiplomacyCalculator.GetSuccessChance(
        player,
        enemy,
        generatedAgreement);


        int decisionTime = DiplomacyCalculator.GetDecisionTime(
        player,
        generatedAgreement);

        AgreementCardUI card =
        Instantiate(
        agreementCardPrefab,
        agreementContainer);

        card.Initialize(
        generatedAgreement,
        chance,
        decisionTime,
        this);

        activeCards.Add(card);

        Debug.Log(              //test için consolea yazdırma amaçlı
        "Player " + player.PlayerID +
        " | " + selectedRarity +
        " | " + generatedAgreement.agreementName +
        " | Success: " + chance + "%" +
        " | Time: " + decisionTime + " sec"
        );
    }
    }
    public void SelectAgreement(AgreementCardUI selectedCard)
    {
    selectedAgreement = selectedCard.AgreementData;

    remainingTime = selectedCard.DecisionTime;
    selectedSuccessChance = selectedCard.SuccessChance;

    foreach (AgreementCardUI card in activeCards)
    {
        if (card != selectedCard)
        {
            Destroy(card.gameObject);
        }
    }

    StartCoroutine(NegotiationTimer());
    
    }

    private IEnumerator NegotiationTimer()
    {

    negotiationTimerText.gameObject.SetActive(true);

    while(remainingTime >= -1)
        {
        negotiationTimerText.text = "The agreement will be announced in " + 
        Mathf.CeilToInt(remainingTime).ToString() + " seconds";

        remainingTime -= Time.deltaTime;

        yield return null;
        }
    
    negotiationTimerText.gameObject.SetActive(false);

    if (Random.Range(0f, 100f) <= selectedSuccessChance)

    {
    successOrFailText.gameObject.SetActive(true);
    successOrFailText.text = "The agreement was a SUCCESS";
    StartCoroutine(CooldownTimer());
    }

    else

    {
    successOrFailText.gameObject.SetActive(true);    
    successOrFailText.text = "The agreement was a FAILURE";
    rollAgainButton.SetActive(true);
    }
    }

    private IEnumerator CooldownTimer()
    {
    float cooldown = 60f;

    cooldownTimerText.gameObject.SetActive(true);
    
        while (cooldown >= -1)
        {
            cooldownTimerText.text =
                "New agreements available in " +
                Mathf.CeilToInt(cooldown) + " seconds";

            cooldown -= Time.deltaTime;

            yield return null;
        }

    cooldownTimerText.gameObject.SetActive(false);
    rollAgainButton.SetActive(true);
    }

    public void RollAgain()
    {
    successOrFailText.gameObject.SetActive(false);

    rollAgainButton.SetActive(false);

    foreach (AgreementCardUI card in activeCards)
    
    if (card != null)
    {
        Destroy(card.gameObject);
    }

    activeCards.Clear();

    GenerateAgreementsForPlayer(
        player1,
        player2,
        player1Agreements,
        player1AgreementContainer);

    GenerateAgreementsForPlayer(
        player2,
        player1,
        player2Agreements,
        player2AgreementContainer);
    }
}

    

