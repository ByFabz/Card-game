using UnityEngine;

public class TestCardSpawner : MonoBehaviour
{
    [Header("UI")]
    public CardUI cardUI;

    [Header("Test Card")]
    public CardData testCard;

    void Start()
    {
        cardUI.SetCard(testCard);
    }
}