using UnityEngine;

public class Item
{
    public char Type { get; private set; }
    public double Val { get; private set; }
    public int Amount { get; set; }

    public Item(char ItemType, double ItemVal, int ItemAmount)
    {
        this.Type   = ItemType;
        this.Val    = ItemVal;
        this.Amount = ItemAmount;
    }

    public void IncreaseAmount() { this.Amount++; }
    public void DecreaseAmount() { this.Amount--; }
}