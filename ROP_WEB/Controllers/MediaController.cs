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
            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar"))) {
                News = db.NewsMains.Where(x => x.Show == true && x.Archive == false && x.Language=="ar").ToList();

            }
            else
            {
                News = db.NewsMains.Where(x => x.Show == true && x.Archive == false && x.Language == "en").ToList();

            }
            int pageSize = 6;
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
        public ActionResult Articles(string sortOrder, string CurrentSort, int? page)
        {
            List<Article> articles = new List<Article>();
            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                articles = db.Articles.Where(x => x.Status == true && x.Language == "ar").ToList();

            }
            else
            {
                articles = db.Articles.Where(x => x.Status == true && x.Language == "en").ToList();
            }
            


            int pageSize = 6;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "ArticleID" : sortOrder;
            IPagedList<Article> artlist = null;
            switch (sortOrder)
            {
                case "ArticleID":
                    artlist = articles.OrderByDescending
                            (m => m.ArticleID).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    artlist = articles.OrderByDescending
                           (m => m.ArticleID).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(artlist);
        }
        public ActionResult ArticleDetails(int id)
        {

            return View(db.Articles.FirstOrDefault(x => x.ArticleID == id));
        }
        public ActionResult Ads()
        {


            List<Ad> Ads = new List<Ad>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/Ads.xml"));
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
                Ads = Ads.Where(x => x.AdLang == "ar").ToList();
            }
            else
            {
                Ads = Ads.Where(x => x.AdLang == "en").ToList();
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
            List<Magazin> magazins = new List<Magazin>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/Ropmagazine.xml"));
            var magazinslst = xelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in magazinslst)
            {
                magazins.Add(new Magazin
                {
                    count = (int)xEle.Element("count"),
                    publishdate = (DateTime)xEle.Element("publishdate"),
                    filename = xEle.Element("filename").Value,
                    magaimg = xEle.Element("magaimg").Value,
                    filesize = (int)xEle.Element("filesize"),
                    magalang = xEle.Element("magalang").Value,
                    status = (int)xEle.Element("status")




                });



            }

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                magazins = magazins.Where(x => x.magalang == "ar").ToList();
            }
            else
            {
                magazins = magazins.Where(x => x.magalang == "en").ToList();
            }
            return View(magazins);
        }
        public ActionResult KidsMagazin()
        {
            List<Magazin> magazins = new List<Magazin>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/kidsmagazin.xml"));
            var magazinslst = xelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in magazinslst)
            {
                magazins.Add(new Magazin
                {
                    count = (int)xEle.Element("count"),
                    publishdate = (DateTime)xEle.Element("publishdate"),
                    filename = xEle.Element("filename").Value,
                    magaimg = xEle.Element("magaimg").Value,
                    filesize = (int)xEle.Element("filesize"),
                    magalang = xEle.Element("magalang").Value,
                    status = (int)xEle.Element("status")




                });



            }

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                magazins = magazins.Where(x => x.magalang == "ar").ToList();
            }
            else
            {
                magazins = magazins.Where(x => x.magalang == "en").ToList();
            }
            return View(magazins);
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