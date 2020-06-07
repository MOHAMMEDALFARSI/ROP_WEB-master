using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using ROP_WEB.Models;
using PagedList;
namespace ROP_WEB.Controllers
{
    public class OpenDataController : Controller
    {
        // GET: OpenData
        public ActionResult Roplaws()
        {

            return View();
        }
        public ActionResult TrafficFines()
        {
           
            return View();
        }
        public ActionResult ServicesFees()
        {

            return View();
        }
        public ActionResult Statistics()
        {

            return View();
        }
        public ActionResult Saftytips()
        {

            return View();
        }

       
    }
}