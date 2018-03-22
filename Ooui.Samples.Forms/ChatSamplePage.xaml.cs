using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace Ooui.Samples.Forms
{
    public partial class ChatSamplePage : ContentPage
    {
        private HubConnection connection;

        public ObservableCollection<string> ChatMessages { get; set; } = new ObservableCollection<string>();

        public ChatSamplePage()
        {
            InitializeComponent();
            InitializeSignalR();
        }

        private void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                    .WithConsoleLogger() //log messages to the console
                    .WithUrl("http://localhost:5000/chat") //hit the WEB PORT!
                    .Build(); //grab the connection object

            // handle a "UserJoined" call from the server
            // username is a string
            connection.On<string>("UserJoined", (username) => {
                Console.WriteLine($@"Client| On.UserJoined {username}");
                AddChatMessage($@"{username} has joined");
            });

            // handle a "Send" call from the server
            // user and message are both strings
            connection.On<string, string>("Send", (user, message) => {
                Console.WriteLine($@"Client| On.Send {user}, {message}");
                AddChatMessage($@"{user}: {message}");
            });

            // bind the messages
            MessageListView.ItemsSource = ChatMessages;

            // single threaded, so... no point in awaiting
            // if it's built for another platform it would matter
            connection.StartAsync().GetAwaiter().GetResult();
        }

        private void AddChatMessage(string fullMessage)
        {
            // add the message to the observable collection of messages
            ChatMessages.Add(fullMessage);
        }

        private async void SendMessage_Click(object sender, System.EventArgs e)
        {
            var message = InputMessage.Text;

            // reset the textbox so it's blank
            InputMessage.Text = string.Empty;

            // call the send method on the server's ChatHub
            await connection.SendAsync("Send", message);
        }
    }
}
