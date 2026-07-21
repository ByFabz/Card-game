using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] private Image Art;
    [SerializeField] private TMP_Text Name;

    public void Initialize(CardData CardData)
    {
        Art.sprite = CardData.Art;
        Name.text  = CardData.CardName;
    }
}