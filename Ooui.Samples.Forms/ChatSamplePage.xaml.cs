using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace Ooui.Samples.Forms
{
    public partial class ChatSamplePage : ContentPage
    {
        private HubConnection connection;

        public ChatSamplePage()
        {
            InitializeComponent();
            InitializeSignalR();
        }

        private void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                    .WithConsoleLogger()
                    .WithUrl("http://localhost:5000/chat")
                    .Build();

            connection.StartAsync().GetAwaiter().GetResult();

            Debugger.Break();
        }
    }
}
