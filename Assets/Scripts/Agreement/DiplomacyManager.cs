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
        int randomIndex = Random.Range(0, availableAgreements.Count);

        AgreementData selectedAgreement =
            availableAgreements[randomIndex];

        playerAgreements.Add(selectedAgreement);
        availableAgreements.RemoveAt(randomIndex);

        Debug.Log(
            "Player " + player.PlayerID +
            " Agreement: " + selectedAgreement.agreementName
        );
    }
}

    private void ReadDiplomatStats()
{
    Debug.Log("Player 1: " + player1.Diplomat.cardName);
    Debug.Log("Player 2: " + player2.Diplomat.cardName);
}
}

