using System;
using UnityEngine;

public class Commander : Administration
{
    public int Strength { get; private set; }
    public bool Used { get; private set; }

    public int WarEffect => 2 * (Charisma + IQ);

    public Commander(int ID, string Name, string AssetPath, int IQ, int Charisma, int Strength) : base(ID, Name, AssetPath, IQ, Charisma)
    {
        this.Strength = Strength;
        this.Used = false;
    }

    public int UseCard(int WarDeckStrength)
    {
        if (this.Used == true)
            throw new InvalidOperationException("This card has already been used.");

        this.Used = true;
        return ((this.Strength + WarDeckStrength) * this.WarEffect);
    }
}