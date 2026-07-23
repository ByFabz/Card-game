using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Merchant : Card
{
    public int TradeSkill { get; private set; }
    public bool IsActive { get; private set; }


    public Merchant(int ID, string Name, string AssetPath, int TradeSkill) : base (ID, Name, AssetPath)
    {
        this.TradeSkill = TradeSkill;
        this.IsActive = false;
    }

    public void UseCard()
    {
        this.IsActive = true;
    }

    // Return to this function later on
    public void TradeFromOuterLands(Item Item, Kingdom Kingdom, int Amount, double Treasury)
    {
        if (Kingdom.Treasure < (Amount * Item.Val) || (Amount * Item.Val) == 0)
        {

        } else {
            Kingdom.Treasure -= (Amount * Item.Val);
        }
        
    }
    // This will run in a loop, merchant cards are passive cards
    public double PassiveMethod(Item Item, Kingdom Kingdom)
    {
        if (Item.Amount > 0)
        {
            Item.Amount -= (this.TradeSkill)/2;
            Kingdom.Treasure += (Item.Val * this.TradeSkill/2);
        }
        return 0;
    }
}