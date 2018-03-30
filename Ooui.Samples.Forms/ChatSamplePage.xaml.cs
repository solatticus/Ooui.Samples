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
       public ChatSamplePage()
        {
            InitializeComponent();

            //BindingContext = new ChatSampleViewModel();
        }
    }
}
