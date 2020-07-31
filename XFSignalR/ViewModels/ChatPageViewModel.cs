using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFSignalR.ViewModels
{
    public class ChatPageViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public ICommand SendCommand { get; set; }

        public ChatPageViewModel()
        {
            Title = "ChatPage";
            SendCommand = new Command(ExecuteSendCommand);
        }

        void ExecuteSendCommand()
        {
        }
    }
}
