﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventarios.Controllers
{
    public class HelpDeskController : Controller
    {
        // GET: HelpDesk
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tickets");
        }
    }
}