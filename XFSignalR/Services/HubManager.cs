using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace XFSignalR.Services
{
    public class HubManager
    {
        const string BaseHost = "https://localhost:2994/api/";

        public delegate void MessageReceived(string name, string message);
        public event MessageReceived OnMessageReceived;

        HubConnection hubConnection;

        public HubManager()
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{BaseHost}chatHub")
                                                      .Build();


            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });
        }

        public async Task Connect() => await hubConnection.StartAsync();

        public async Task Disconnect() => await hubConnection.StopAsync();

        public async Task SendMessage(string username,string message) => await hubConnection.InvokeAsync("SendMessage", username, message);

        public bool IsConected => hubConnection.State == HubConnectionState.Connected;
        
    }
}
