using UnityEngine;

public enum CardType //this will be to choose the card type which you will write different scripts     to add special stats for the card types
{
    Soldier,
    Diplomat,
    Assassin,
    Leader,
    Building
}

[CreateAssetMenu(fileName = "New Card", menuName = "Game/Card/Base Card")]
public class CardData : ScriptableObject
{
    [Header("Base Info")]
    public int cardId;
    public string cardName;
    public string description;
    public Sprite artwork;

    public CardType cardType;
}