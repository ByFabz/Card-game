using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerID;
    [SerializeField] private DiplomatCardData diplomat;

    public int PlayerID => playerID;
    public DiplomatCardData Diplomat => diplomat;

    public void SelectDiplomat(DiplomatCardData selectedDiplomat)
    {
        diplomat = selectedDiplomat;
    }
}