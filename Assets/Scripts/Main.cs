using UnityEngine;

public class Main : MonoBehaviour
{
    private gameClient gameClient = new gameClient();

    private async void startWebSockets() { await gameClient.ConnectAsync("ws://localhost:5000/match"); _ = gameClient.RecieveLoop(); }
}