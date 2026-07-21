using System;
using UnityEngine;

public class Diplomat : Administration
{
    public int DiplomatPersuasion => (IQ + Charisma) / 2;
    public int DiplomatTreatySpeed { get; private set; } // Number of rounds to make treaty
    public bool IsPreparing { get; private set; }

    public Diplomat(int ID, string Name, string AssetPath, int IQ, int Charisma, int Rounds) : base(ID, Name, AssetPath, IQ, Charisma)
    {
        this.DiplomatTreatySpeed = Rounds;
        this.IsPreparing = false;
    }

    public int FinishTreaty(int ThisRound)
    {
        if (ThisRound == 0)
        {
            return ((this.DiplomatPersuasion * this.DiplomatTreatySpeed)/2);
        }
        return 0;
    }
    public int CancelTreaty(int EnemyPersuasion)
    {
        return (EnemyPersuasion - this.DiplomatPersuasion);
    }
    public int PrepareTreaty() {
        if (this.IsPreparing == true)
            throw new InvalidOperationException("This card is already preparing a treaty.");

        this.IsPreparing = true;
        return DiplomatTreatySpeed;
    }
}