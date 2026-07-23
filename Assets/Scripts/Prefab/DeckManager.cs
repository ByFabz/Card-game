using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private Transform Container;

    [SerializeField] private List<CardDataMain> CardList;

    private void Start()
    {
        CreateDeck(CardList);
    }

    public void CreateDeck(List<CardDataMain> Cards)
    {
        foreach (CardDataMain Card in Cards)
        {
            GameObject obj  = Instantiate(CardPrefab, Container);
            CardPrefab view = obj.GetComponent<CardPrefab>();

            view.Initialize(Card);
        }
    }
}