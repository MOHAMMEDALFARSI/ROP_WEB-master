using ROP_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace ROP_WEB.Controllers
{
    public class MediaController : Controller
    {
        ROP_WEBEntities db = new ROP_WEBEntities();
        // GET: Media
        public ActionResult News(string sortOrder, string CurrentSort, int? page)
        {

            List<NewsMain> News = new List<NewsMain>();

            News = db.NewsMains.Where(x => x.Show == true && x.Archive == false).ToList();
            int pageSize = 1;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "NewsID" : sortOrder;
            IPagedList<NewsMain> Newslst = null;
            switch (sortOrder)
            {
                case "NewsID":
                        Newslst = News.OrderByDescending
                                (m => m.NewsID).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    Newslst = News.OrderByDescending
                           (m => m.NewsID).ToPagedList(pageIndex, pageSize);
                    break;
            }

            return View(Newslst);
        }
        public ActionResult NewsDetails(int id)
        {

            return View(db.NewsMains.FirstOrDefault(x => x.NewsID == id));
        }
        public ActionResult Articles()
        {

            return View();
        }
        public ActionResult Ads()
        {


            List<Ad> Ads = new List<Ad>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/Res/Ads.xml"));
            var Adslst = xelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in Adslst)
            {
                Ads.Add(new Ad  
                {
                    AdId = (int)xEle.Element("AdId"),
                    AdTitle = xEle.Element("AdTitle").Value,
                    Adtxt = xEle.Element("Adtxt").Value,
                    Adfile = xEle.Element("Adfile").Value,
                    AdLang = xEle.Element("AdLang").Value,
                    AdEndDate = (DateTime)xEle.Element("AdEndDate")
                   


                });



            }

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                Ads = Ads.Where(x => x.AdLang == "AR").ToList();
            }
            else
            {
                Ads = Ads.Where(x => x.AdLang == "EN").ToList();
            }
            return View(Ads);
        }
        public ActionResult Events()
        {

            return View();
        }
        public ActionResult PhotosAlbum()
        {

            return View();
        }
        public ActionResult Ropmagazine()
        {

            return View();
        }
        public ActionResult KidsMagazin()
        {

            return View();
        }
        public ActionResult AlainaAssahira()
        {

            return View();
        }
        public ActionResult EmploymentAds()
        {

            return View();
        }
    }
}