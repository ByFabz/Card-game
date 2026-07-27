using System.Collections.Generic;
using UnityEngine;



public class DiplomacyManager : MonoBehaviour
{
    [SerializeField] private List<AgreementData> agreementList;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    private List<AgreementData> player1Agreements = new List<AgreementData>();
    private List<AgreementData> player2Agreements = new List<AgreementData>();

    private void Start()
    {
        GenerateAgreementsForPlayer(player1, player1Agreements);
        GenerateAgreementsForPlayer(player2, player2Agreements);
        ReadDiplomatStats();
    }

    private void GenerateAgreementsForPlayer(
    Player player,
    List<AgreementData> playerAgreements)
{
    playerAgreements.Clear();

    List<AgreementData> availableAgreements =
        new List<AgreementData>(agreementList);

    for (int i = 0; i < 3; i++)
    {
        AgreementRarity selectedRarity =
            GetRandomRarity(player.Diplomat.Intelligence);

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

        playerAgreements.Add(selectedAgreement);

        availableAgreements.Remove(selectedAgreement);
        Debug.Log(
            "Player " + player.PlayerID +
            " | " + selectedRarity +
            " | " + selectedAgreement.agreementName
        );
    }
}

    private AgreementRarity GetRandomRarity(int intelligence)
    {
        int roll = Random.Range(1, 101);

        if (intelligence < 25)
        {
            if (roll <= 60) return AgreementRarity.Common;
            if (roll <= 85) return AgreementRarity.Uncommon;
            if (roll <= 95) return AgreementRarity.Rare;
            if (roll <= 99) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 50)
        {
            if (roll <= 45) return AgreementRarity.Common;
            if (roll <= 75) return AgreementRarity.Uncommon;
            if (roll <= 91) return AgreementRarity.Rare;
            if (roll <= 98) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 75)
        {
            if (roll <= 30) return AgreementRarity.Common;
            if (roll <= 60) return AgreementRarity.Uncommon;
            if (roll <= 83) return AgreementRarity.Rare;
            if (roll <= 96) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 100)
        {
            if (roll <= 18) return AgreementRarity.Common;
            if (roll <= 43) return AgreementRarity.Uncommon;
            if (roll <= 71) return AgreementRarity.Rare;
            if (roll <= 92) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (roll <= 10) return AgreementRarity.Common;
        if (roll <= 28) return AgreementRarity.Uncommon;
        if (roll <= 55) return AgreementRarity.Rare;
        if (roll <= 85) return AgreementRarity.Epic;

        return AgreementRarity.Legendary;
    }
    private void ReadDiplomatStats()
{
    Debug.Log("Player 1: " + player1.Diplomat.cardName);
    Debug.Log("Player 2: " + player2.Diplomat.cardName);
}
}

    

