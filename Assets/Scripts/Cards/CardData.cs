using UnityEngine;

public enum CardType //this will be to choose the card type which you will write different scripts     to add special stats for the card types
{
    Leader,
    Commander,
    Soldier,
    Army,
    Diplomat,
    Security,
    Merchant,
    Blacksmith,
    Farmer
}

[CreateAssetMenu(fileName = "New Card", menuName = "Game/Card/Base Card")]
public class CardData : ScriptableObject
{
    [Header("Base Info")]
    public string cardName;

    [TextArea]
    public string description;

    [TextArea]
    public string passiveDescription;

    public Sprite artwork;



    public virtual string GetStats()
    {
        return "";
    }
}