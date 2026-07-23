using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card Data")]
public class CardDataMain : ScriptableObject
{
    [Header("Card Info")]
    public int CardId;
    public string CardName;
    public string Description;
    public Sprite Art;
}