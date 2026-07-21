using System;
using System.Linq;
using UnityEngine;

public abstract class Card
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string AssetPath { get; private set; }

    public Card(int ID, string Name, string AssetPath)
    {
        this.ID        = ID;
        this.Name      = Name;
        this.AssetPath = AssetPath;
    }
}
