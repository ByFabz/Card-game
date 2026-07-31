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
    private AgreementData selectedAgreement;
    private List<AgreementCardUI> activeCards = new List<AgreementCardUI>();
    private List<AgreementData> player1Agreements = new List<AgreementData>();
    private List<AgreementData> player2Agreements = new List<AgreementData>();
    private float remainingTime;

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

    Debug.Log(remainingTime);
    Debug.Log("Selected Agreement: " + selectedAgreement.agreementName);

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
    while(remainingTime > 0)
        {
        negotiationTimerText.text =
        remainingTime.ToString("F0") + " seconds";

        remainingTime -= Time.deltaTime;

        yield return null;
        }
    }
}

    

