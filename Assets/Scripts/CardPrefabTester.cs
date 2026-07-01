using UnityEngine;

public class CardPrefabTester : MonoBehaviour
{
    [Header("Prefab")]
    public CardUI cardPrefab;

    [Header("Spawn Parent")]
    public Transform spawnParent;

    [Header("Test Card")]
    public CardData testCard;

    void Start()
    {
        CardUI newCard = Instantiate(cardPrefab, spawnParent);

        newCard.SetCard(testCard);
    }
}
