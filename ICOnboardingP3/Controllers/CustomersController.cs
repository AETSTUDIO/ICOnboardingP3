﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICOnboardingP3.Models;

namespace ICOnboardingP3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly OnboardingP3Entities db;

        public CustomersController() {
            db = new OnboardingP3Entities();
        }
        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }
    }
}