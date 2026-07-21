using NUnit.Framework;
using System.Collections.Generic;
using Unity;

public class Deck
{
    public Kingdom Kingdom;
    public List<Card> Cards  = new List<Card>();
    public List<Card> OnDeck = new List<Card>();

    public Deck(Kingdom Kingdom, List<Card> Cards, List<Card> OnDeck)
    {
        this.Kingdom = Kingdom;
        this.Cards   = Cards;
        this.OnDeck  = OnDeck;
    }
}