using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//for testing purposes only
namespace Tindyr.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatTest()
        {
            return View();
        }
    }
}