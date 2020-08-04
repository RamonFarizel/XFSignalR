using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace XFSignalR.Services
{
    public class HubManager
    {
        string BaseHost = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:2994/" : "https://localhost:2994/";

        public delegate void MessageReceived(string name, string message);
        public event MessageReceived OnMessageReceived;

        HubConnection hubConnection;

        public HubManager()
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{BaseHost}chathub", (opts) =>
            {
                opts.HttpMessageHandlerFactory = (message) =>
                {
                    if (message is HttpClientHandler clientHandler)
                        // bypass SSL certificate
                        clientHandler.ServerCertificateCustomValidationCallback +=
                            (sender, certificate, chain, sslPolicyErrors) => { return true; };
                    return message;
                };
            }).Build();
        }

        public async Task Connect()
        {
            ConnectToHubs();

            await hubConnection.StartAsync();
        }

        public async Task Disconnect() => await hubConnection.StopAsync();

        public async Task SendMessage(string username,string message)
        {
            await hubConnection.InvokeAsync("SendMessage", username, message);
        }

        public bool IsConected => hubConnection.State == HubConnectionState.Connected;

        void ConnectToHubs()
        {
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });
        }
        
    }
}
