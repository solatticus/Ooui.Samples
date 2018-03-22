using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xamarin.Forms; //needed for ContentPage.GetOouiElement() extension method
using Ooui.Samples.Forms;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ooui.AspNetCore.SignalR.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            ViewData["Title"] = "AspNetCore Ooui SignalR - Chat Sample";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public ElementResult SignalRDemo()
        {
            var oe = new ChatSamplePage().GetOouiElement();
            var er = new ElementResult(oe, "SignalR Sample");
            return er;
        }
    }
}
