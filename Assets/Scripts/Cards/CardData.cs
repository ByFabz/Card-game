using UnityEngine;


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

    public CardRarity rarity;

    public Kingdoms kingdom;
    public virtual string GetStats()
    {
        return "";
    }
}