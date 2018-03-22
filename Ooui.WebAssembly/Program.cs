using System;
using Xamarin.Forms;

namespace Ooui.WebAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            // startup xamarin forms
            Xamarin.Forms.Forms.Init();

            // create the sample page and get the ooui element
            UI.Publish("/signalr-chat", new ChatSamplePage().GetOouiElement());

            // present that 'published' chat page
            UI.Present("/signalr-chat");

            // don't quit right away
            Console.ReadLine();
        }
    }
}
