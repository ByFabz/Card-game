using UnityEngine;

public class Administration : Card
{
    public int IQ { get; private set; }
    public int Charisma { get; private set; }
    public Administration(int ID, string Name, string AssetPath, int IQ, int Charisma) : base(ID, Name, AssetPath)
    {
        this.IQ = IQ;
        this.Charisma = Charisma;
    }
}