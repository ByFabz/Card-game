using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private Transform Container;

    [SerializeField] private List<CardData> CardList;

    private void Start()
    {
        CreateDeck(CardList);
    }

    public void CreateDeck(List<CardData> Cards)
    {
        foreach (CardData Card in Cards)
        {
            GameObject obj  = Instantiate(CardPrefab, Container);
            CardPrefab view = obj.GetComponent<CardPrefab>();

            view.Initialize(Card);
        }
    }
}