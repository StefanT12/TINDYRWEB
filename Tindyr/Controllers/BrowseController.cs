using System;
using Microsoft.AspNetCore.Mvc;

namespace Tindyr.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Browsing()
        {
            return View();
        }
    }
}