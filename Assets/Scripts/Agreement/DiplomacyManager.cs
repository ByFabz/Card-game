using System.Collections.Generic;
using UnityEngine;



public class DiplomacyManager : MonoBehaviour
{
    [SerializeField] private List<AgreementData> agreementList;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private AgreementCardUI agreementCardPrefab;
    [SerializeField] private Transform agreementContainer;

    private List<AgreementData> player1Agreements = new List<AgreementData>();
    private List<AgreementData> player2Agreements = new List<AgreementData>();

    private void Start()
    {
        GenerateAgreementsForPlayer(player1, player2, player1Agreements);
        GenerateAgreementsForPlayer(player2, player1, player2Agreements);
        ReadDiplomatStats();
    }

    private void GenerateAgreementsForPlayer(
    Player player,
    Player enemy,
    List<AgreementData> playerAgreements)
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

        AgreementData selectedAgreement =
            matchingAgreements[randomIndex];

        availableAgreements.Remove(selectedAgreement);
        playerAgreements.Add(selectedAgreement);

        int chance = DiplomacyCalculator.GetSuccessChance(
        player,
        enemy,
        selectedAgreement);


        int decisionTime = DiplomacyCalculator.GetDecisionTime(
        player,
        selectedAgreement);


        Debug.Log(              //test için consolea yazdırma amaçlı
        "Player " + player.PlayerID +
        " | " + selectedRarity +
        " | " + selectedAgreement.agreementName +
        " | Success: " + chance + "%" +
        " | Time: " + decisionTime + " sec"
        );
    }
}
    private void ReadDiplomatStats()
{
    Debug.Log("Player 1: " + player1.Diplomat.cardName);
    Debug.Log("Player 2: " + player2.Diplomat.cardName);
}
}

    

