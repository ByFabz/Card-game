using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Faction : Card
{
    public Card Card { get; set; }
    public Item Item { get; set; }
    public int ProductionSpeed { get; private set; }
    public int ReturnTime { get; private set; }

    public Faction (int ID, string Name, string AssetPath, int ProductionSpeed, Item Item) : base(ID, Name, AssetPath)
    {
        this.ProductionSpeed = ProductionSpeed;
        this.ReturnTime = ProductionSpeed;
        this.Item = Item;
    }

    public void BoostProduction(int Amount)
    {
        this.ProductionSpeed = this.ProductionSpeed * Amount;
    }
    public void PassiveProduction() { this.Item.IncreaseAmount(); }
    public void UseCard(Deck OrdnanceDeck, Kingdom Kingdom) {
        Kingdom.Items.Add(this.Item);
        OrdnanceDeck.OnDeck.Add(this.Card);
    }
}