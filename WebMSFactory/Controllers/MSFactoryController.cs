﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMSFactory
{
    public class MSFactoryController : Controller
    {
        // GET: Home


        public ActionResult Index()
        {
            Response.Redirect("/AllProducts/Search");
            return View();
        }
        public ActionResult Login()
        {
            return View(new UserInfo());
        }
        
    }
}