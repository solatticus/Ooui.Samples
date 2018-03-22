using System;
namespace Ooui.Samples.Forms
{
    public class App : Xamarin.Forms.Application
    {
        static App()
        {
            // Initializing prior to the constructor
            Xamarin.Forms.Forms.Init();
        }

        public App()
        {
            // set the main page of the application to the chat sample page
            MainPage = new ChatSamplePage();
        }
	}
}
