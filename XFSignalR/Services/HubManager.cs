using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;
using XFSignalR.Helpers;
using XFSignalR.Interfaces;

namespace XFSignalR.Services
{
    public abstract class HubManager : IHubManager
    {
        string BaseHost = $"https://{Settings.ServerIP}2994/";//"https://10.0.2.2:2994/" : "https://localhost:2994/";

        protected HubConnection hubConnection;

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
            if(!IsConected)
                await hubConnection.StartAsync();
        }

        public async Task Disconnect() => await hubConnection.StopAsync();

        public abstract Task Send(object[] message);

        public bool IsConected => hubConnection.State == HubConnectionState.Connected;
        
    }
}
