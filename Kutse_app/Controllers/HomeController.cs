﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Kutse_app.Models;

namespace Kutse_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int month = DateTime.Now.Month;
            if (month==03)
            {
                ViewBag.Message = "Ootan 8. märtsi peole!";
            }
            else if (month == 04)
            {
                ViewBag.Message = "Ootan 1 aprilli peole!";
            }
            else if (month == 05)
            {
                ViewBag.Message = "Ootan sind minu sünnipäeval peole!";
            }
            else if (month == 06)
            {
                ViewBag.Message = "Ootan Ivanovi päeva peole!";
            }
            
            int hour = DateTime.Now.Hour;
            if (hour < 12 && hour >= 5)
            {
                ViewData["greeting"] = "Tere hommikust!";
            }
                
            else if (hour>=12 && hour <= 19)
            {
                ViewData["greeting"] = "Tere päevast!";
            }
                
            else if (hour>19 && hour < 23)
            {
                ViewData["greeting"] = "Tere õhtust!";
            }
                
            else
            {
                ViewData["greeting"] = "Miks sa öösel ei maga?";
            }
                
            return View();
        }
        [HttpGet]
        public ActionResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ankeet(Guest guest)
        {

            E_mail(guest);
            if (ModelState.IsValid)
            {

                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "alisa.krupenko18@gmail.com";
                WebMail.Password = " ";
                WebMail.From = "alisa.krupenko18@gmail.com";
                WebMail.Send("alisa.krupenko18@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }
        }

    }
}