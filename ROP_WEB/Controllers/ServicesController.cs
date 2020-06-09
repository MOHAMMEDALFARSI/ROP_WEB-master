using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROP_WEB.Models;
using System.Globalization;
using System.Threading;
using System.Xml.Linq;
namespace ROP_WEB.Controllers
{
    public class ServicesController : Controller
    {
        ROP_WEBEntities db = new ROP_WEBEntities();
        // GET: Services
        public ActionResult PersonalServices()
        {


            var personalServices = db.SERVICEs.Where(x => x.Service_Cat_Id == 1 && x.services_Status_Id == 2).ToList();
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 1 && x.services_Status_Id == 2).Select(m => m.Service_Provider_Id).Distinct();
                var spname = db.SERVICE_PROVIDER.Where(x => ServiceProviders.Contains(x.Service_Provider_Id));
                ViewBag.ServiceProviders = spname;
           

            return View(personalServices);
        }
        public ActionResult GovServices()
        {



            var puplicSecServices = db.SERVICEs.Where(x => x.Service_Cat_Id == 2 && x.services_Status_Id == 2).ToList();
            var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 2 && x.services_Status_Id == 2).Select(m => m.Service_Provider_Id).Distinct();
            var spname = db.SERVICE_PROVIDER.Where(x => ServiceProviders.Contains(x.Service_Provider_Id));
            ViewBag.ServiceProviders = spname;







            return View(puplicSecServices);

           
        }
        public ActionResult CompaniesServices()
        {

            var ComServices = db.SERVICEs.Where(x => x.Service_Cat_Id == 3 && x.services_Status_Id == 2).ToList();
            var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 3 && x.services_Status_Id == 2).Select(m => m.Service_Provider_Id).Distinct();
            var spname = db.SERVICE_PROVIDER.Where(x => ServiceProviders.Contains(x.Service_Provider_Id));
            ViewBag.ServiceProviders = spname;









            return View(ComServices);


        }

        public ActionResult ServicesDetails(int id)
        {

            ROP_WEBEntities db = new ROP_WEBEntities();
       
                return View(db.SERVICEs.FirstOrDefault(x => x.Service_Id == id));
        }

        public ActionResult smsservice()
        {
            return View();
        }
        public ActionResult RopMobileApp()
        {
            return View();
        }
        public ActionResult Kiosks()
        {

            //slider id 1 will be active one,, other normal
            List<Kiosk> kiosks = new List<Kiosk>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement Kiosxelement = XElement.Load(HttpContext.Server.MapPath("~/ROP-Content/Xmls/Kiosk.xml"));
            var adslist = Kiosxelement.Elements();
            //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in adslist)
            {
                kiosks.Add(new Kiosk
                {
                   
                    kioskLocationAr = xEle.Element("kioskLocationAr").Value,
                    kioskLocationEn = xEle.Element("kioskLocationEn").Value,
                    kioskLocationUrl = xEle.Element("kioskLocationUrl").Value,
                    region = xEle.Element("region").Value
                  
                




                }); ;



            }



           // kiosks = kiosks.Where(x => x.AdLang == "ar").ToList();
           
            return View(kiosks);
        }
    }
}