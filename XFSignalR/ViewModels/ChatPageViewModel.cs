using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using XFSignalR.Models;
using XFSignalR.Services;

namespace XFSignalR.ViewModels
{
    public class ChatPageViewModel : BaseViewModel
    {
        ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        string _textMessage = string.Empty;
        public string TextMessage
        {
            get => _textMessage;
            set => SetProperty(ref _textMessage,value);
        }

        public ICommand SendCommand { get; set; }

        HubManager _hubManager;

        public ChatPageViewModel()
        {
            Title = "ChatPage";

            Messages = new ObservableCollection<Message>();
            _hubManager = new HubManager();

            _hubManager.OnMessageReceived += (username,message) => MessageReceived(username,message);

            SendCommand = new AsyncCommand(ExecuteSendCommand);
        }

        private void MessageReceived(string username, string message)
        {
            Messages.Add(new Message { Text = message, Autor = username });
        }

        async Task ExecuteSendCommand()
        {
            await SendMessage();
            TextMessage = string.Empty;
        }

        async Task SendMessage()
        {
            if (!_hubManager.IsConected)
                await _hubManager.Connect();

            await _hubManager.SendMessage(TextMessage, "Ramon");
        }
    }
}
