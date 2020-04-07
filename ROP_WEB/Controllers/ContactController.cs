using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROP_WEB.Models;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Threading;

namespace ROP_WEB.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ropphones()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult workTimes()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            ROP_WEBEntities db = new ROP_WEBEntities();
            
            return View(db.FAQMains.ToList());
        }
        public ActionResult Survey()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetStations(string Region)
        {

            List<Station> stationLIST = new List<Station>();
          
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/Res/ROP_Phones/"+Region+".xml"));
            var Stations = xelement.Elements();
            // lstWilaya = (db.Wilayas.Where(x => x.Region_Id == Region_Idd)).ToList<Wilaya>();
            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;
            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
          foreach (XElement xEle in Stations)
            {

                    stationLIST.Add(new Station
                {
                    StationId = (int)xEle.Element("StationId"),
                    //StationEn = xEle.Element("StationEn").Value,
                    StationAr = xEle.Element("StationAr").Value,
                    StationPhone = xEle.Element("StationPhone").Value
           


                });
                }

            }
            else
            {
                foreach (XElement xEle in Stations)
                {

                    stationLIST.Add(new Station
                    {
                        StationId = (int)xEle.Element("StationId"),
                        //StationEn = xEle.Element("StationEn").Value,
                        StationAr = xEle.Element("StationEn").Value,
                        StationPhone = xEle.Element("StationPhone").Value



                    });
                }

            }


      

            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(stationLIST);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}