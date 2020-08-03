using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFSignalR.Services;

namespace XFSignalR.ViewModels
{
    public class ChatPageViewModel
    {
        public string Title { get; set; }
        string UserName = "Ramon";
        public string Message { get; set; }

        public ICommand SendCommand { get; set; }

        HubManager _hubManager;

        public ChatPageViewModel()
        {
            Title = "ChatPage";

            _hubManager = new HubManager();
            Task.Run(() => _hubManager.Connect());

            _hubManager.OnMessageReceived += (username,message) => MessageReceived(username,message);

            SendCommand = new Command(async () => await ExecuteSendCommand());
        }

        private void MessageReceived(string username, string message)
        {
            UserName = username;
            Message = message;
        }

        async Task ExecuteSendCommand()
        {
            await _hubManager.SendMessage(UserName, Message);
        }
    }
}
