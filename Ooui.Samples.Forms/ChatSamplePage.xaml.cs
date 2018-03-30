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

            //setting this here due to a bug with XAML parsing apparently
            BindingContext = new ChatSampleViewModel();
        }
    }
}
