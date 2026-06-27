using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image artworkImage;

    public void SetCard(CardData card)
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
    }
}