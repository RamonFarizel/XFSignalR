using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace XFSignalR.Services
{
    public class ChatHub : HubManager
    {
        public delegate void MessageReceived(string name, string message);

        public event MessageReceived OnMessageReceived;

        public ChatHub()
        {
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });
        }

        public override async Task Send(object[] message)
        {
            await hubConnection.InvokeAsync("SendMessage", message[0],message[1]);
        }
    }
}
