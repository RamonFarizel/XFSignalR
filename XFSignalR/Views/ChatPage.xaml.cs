using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XFSignalR.ViewModels;

namespace XFSignalR.Views
{
    public partial class ChatPage : ContentPage
    {
        readonly ChatPageViewModel _viewModel;

        public ChatPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ChatPageViewModel(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
