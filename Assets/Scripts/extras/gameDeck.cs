using UnityEngine;

public class gameDeck : MonoBehaviour
{
    // I'm going to access userId etc. later on so this is an automated script.
    private int userId;
    private int matchId;
    
    // Cards should be a parent class containing other card types as its children.
    [SerializeField] private ArmyCardData[] playerDeck;

    public void Start() {
        createPlayerDeck();
    }

    public void createPlayerDeck()
    {
        playerDeck = new ArmyCardData[10];

        for (int i=0; i<playerDeck.Length; i++)
        {
            playerDeck[i] = ScriptableObject.CreateInstance<ArmyCardData>();

            playerDeck[i].cardName    = "Yeniceri";
            playerDeck[i].description = "Lorem ipsum dolor sit amet.";

            playerDeck[i].AttackPower = 7;
            playerDeck[i].Durability  = 3;
            playerDeck[i].Speed       = 10;
        }

        Debug.Log($"Successfully created {playerDeck[0].cardName}");
    }
}