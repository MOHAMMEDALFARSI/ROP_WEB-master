using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROP_WEB.Models;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace ROP_WEB.Controllers
{
    public class HomeController : Controller
    {
    //   ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        // GET: Home
        public ActionResult Index()
        {

            //slider id 1 will be active one other normal
            List<Slider> slides = new List<Slider>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/Res/Slider.xml"));
            var slidslist = xelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in slidslist)
            {
                slides.Add(new Slider
                {
                    SlideId = (int)xEle.Element("SlideId"),
                    SlideImg = xEle.Element("SlideImg").Value,
                    SlideUrl = xEle.Element("SlideUrl").Value,
                    SlideAlt = xEle.Element("SlideAlt").Value,
                    SlideLang = xEle.Element("SlideLang").Value
                   



                });



            }

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                slides = slides.Where(x => x.SlideLang == "AR").ToList();
            }
            else
            {
                slides = slides.Where(x => x.SlideLang == "EN").ToList();
            }




            return View(slides);
        }
        public ActionResult terms()
        {

            return View();
        }
        public ActionResult copyright()
        {

            return View();
        }
        public ActionResult polices()
        {

            return View();
        }
        public ActionResult disclaimer()
        {

            return View();
        }
        public ActionResult Sitemap()
        {

            return View();
        }

        public ActionResult Search()
        {

            
            //GET SEARCH THEN OPEN THIS PAGE THEN CLICL ON BUTTON AUTOMATICLAY
            return View();
        }



        // lang Fun
        public ActionResult GetLang(string lang, string view, string cont)
        {
            if (lang != null)
            {
                HttpCookie ck = new HttpCookie("fav");
                ck.Value = lang;
                ck.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Add(ck);

            }


            return RedirectToAction(view, cont);

        }
    }
}