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
            ROP_WEBEntities db = new ROP_WEBEntities();
            ViewModel mymodel = new ViewModel();
            //slider id 1 will be active one,, other normal
            List<Slider> slides = new List<Slider>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/Slider.xml"));
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
                mymodel.Sliders = slides.Where(x => x.SlideLang == "ar").ToList();
            }
            else
            {
                mymodel.Sliders = slides.Where(x => x.SlideLang == "en").ToList();
            }
            //get last 3 ads/*******************************/
           
          
            //slider id 1 will be active one,, other normal
            List<Ad> ad = new List<Ad>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement adsxelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/Ads.xml"));
            var adslist = adsxelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in adslist)
            {
                ad.Add(new Ad
                {
                    AdId = (int)xEle.Element("AdId"),
                    AdTitle = xEle.Element("AdTitle").Value,
                    Adtxt = xEle.Element("Adtxt").Value,
                    Adimg = xEle.Element("Adimg").Value,
                    Adfile = xEle.Element("Adfile").Value,
                    AdLang = xEle.Element("AdLang").Value,
                    AdEndDate = (DateTime)xEle.Element("AdEndDate")




                }); ;



            }

          
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                mymodel.Ads = ad.Where(x => x.AdLang == "ar").ToList();
            }
            else
            {
                mymodel.Ads = ad.Where(x => x.AdLang == "en").ToList();
            }


            //get last 4 news/***************************/


            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                mymodel.News = db.NewsMains.Where(x => x.Show == true && x.Archive == false && x.Language == "ar").Take(4).ToList();

            }
            else
            {
                mymodel.News = db.NewsMains.Where(x => x.Show == true && x.Archive == false && x.Language == "en").Take(4).ToList();

            }


            return View(mymodel);
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
        public ActionResult privacy()
        {


           
            return View();
        }
        public ActionResult SMSServices()
        {



            return View();
        }
        public ActionResult MolileAppService()
        {



            return View();
        }
        public ActionResult KOISService()
        {



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