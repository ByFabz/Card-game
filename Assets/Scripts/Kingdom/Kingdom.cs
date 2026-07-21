using UnityEditor.Search;
using UnityEngine;
using System.Collections.Generic;

public class Kingdom
{
    public string KingdomName { get; private set; }
    public double Treasure { get; set; }
    public List<Item> Items = new List<Item>();

    public Kingdom(string KingdomName, double Treasure) {
        this.KingdomName = KingdomName;
        this.Treasure    = Treasure;
    }
}