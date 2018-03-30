using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace Ooui.Samples.Forms
{
    public class ChatSampleViewModel : ViewModel
    {
        private HubConnection _Connection;

        public ObservableCollection<string> ChatMessages { get; set; } = new ObservableCollection<string>();

        public Command SendMessageCommand { get; set; }

        private string _InputMessage;
        public string InputMessage
        {
            get { return _InputMessage; }
            set { _InputMessage = value; SetProperty(ref _InputMessage, value); }
        }

        public ChatSampleViewModel()
        {
            SendMessageCommand = new Command(async ()=> await ExecuteSendMessageCommand());

            InitializeSignalR();
        }

        private void InitializeSignalR()
        {
            _Connection = new HubConnectionBuilder()
                    .WithConsoleLogger() //log messages to the console
                    .WithUrl("http://localhost:5000/chat") //web port
                    .Build(); //grab the connection object

            // handle a "UserJoined" call from the server
            // username is a string
            _Connection.On<string>("UserJoined", (username) => {
                Console.WriteLine($@"Client| On.UserJoined {username}");
                AddChatMessage($@"{username} has joined");
            });

            // handle a "Send" call from the server
            // user and message are both strings
            _Connection.On<string, string>("Send", (user, message) => {
                Console.WriteLine($@"Client| On.Send {user}, {message}");
                AddChatMessage($@"{user}: {message}");
            });

            // single threaded, so... no point in awaiting
            // if it's built for another platform it would matter
            _Connection.StartAsync().GetAwaiter().GetResult();
        }

        private void AddChatMessage(string fullMessage)
            => ChatMessages.Add(fullMessage); // add the message to the observable collection of messages

        private async Task ExecuteSendMessageCommand()
        {
            // call the send method on the server's ChatHub
            await _Connection.SendAsync("Send", InputMessage);

            // reset the textbox's text so it's blank
            //TODO: This isn't refreshing for some reason
            InputMessage = string.Empty;
        }
    }
}
