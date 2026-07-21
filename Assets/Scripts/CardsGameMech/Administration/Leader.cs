public class Leader : Administration
{
    public int RoundsTillAvailable { get; private set; }
    public int Rounds { get; private set; }

    private int WarEffect => 2 * (Charisma + IQ);
    private int OrdnanceEffect => 2 * Charisma + IQ;

    public Leader(int ID, string Name, string AssetPath, int Available, int IQ, int Charisma) : base(ID, Name, AssetPath, IQ, Charisma)
    {
        this.Rounds = Available;
    }

    // Returns multipliers
    public int UseCardOrdnance() { this.RoundsTillAvailable = this.Rounds; return (this.OrdnanceEffect); }
    public int UseCardWar() { this.RoundsTillAvailable = this.Rounds; return (this.WarEffect); }
}