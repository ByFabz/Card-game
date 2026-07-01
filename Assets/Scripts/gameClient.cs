using System.Net.WebSockets;
using System.Net.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

public class gameClient
{
    private readonly ClientWebSocket _socket = new();

    // WebSocket Conn
    public async Task ConnectAsync(string uri) { await _socket.ConnectAsync(new Uri(uri), CancellationToken.None); }

    // Send Data
    public async Task SendAsync(string message) {
        byte[] bytes = Encoding.UTF8.GetBytes(message);

        await _socket.SendAsync(
            bytes,
            WebSocketMessageType.Text,
            true,
            CancellationToken.None
        );
    }

    // Recieve Data
    public async Task RecieveLoop() {
        byte[] buffer = new byte[4096];

        while (_socket.State == WebSocketState.Open) {
            var result     = await _socket.ReceiveAsync(buffer, CancellationToken.None);
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);

            Console.WriteLine(message);
        }
    }
}