﻿using CoolCat.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CoolCat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISystemManager _systemManager = null;

        public HomeController(ISystemManager systemManager)
        {
            _systemManager = systemManager;
        }

        public IActionResult Index()
        {
            if (_systemManager.CheckInstall())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Setup", "System", new { Area = "Admin" });
            }
        }
    }
}
