using System;
using Xamarin.Forms;

namespace Ooui.WebAssembly
{
    /// <summary>
    /// Class that uses Ooui to load up the Xamarin Forms framework. 
    /// 
    /// The chat sample is within the Ooui.Samples.Forms project. 
    /// 
    /// This way any other Xamarin Targets (iOS, Droid etc.) would reference 
    /// that project the same way they always do. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // configure the route for the sample and point it to the main page of the xamarin forms app
            UI.Publish("/signalr-chat", new Ooui.Samples.Forms.App().MainPage.GetOouiElement());

            // present the 'published' main page
            UI.Present("/signalr-chat");

            // don't quit right away
            Console.ReadLine();
        }
    }
}
