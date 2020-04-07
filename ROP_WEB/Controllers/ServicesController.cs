using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROP_WEB.Models;
using System.Globalization;
using System.Threading;

namespace ROP_WEB.Controllers
{
    public class ServicesController : Controller
    {
        ROP_WEBEntities db = new ROP_WEBEntities();
        // GET: Services
        public ActionResult PersonalServices()
        {
            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;

            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 1).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_Ar).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;

            }
            else
            {
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 1).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_En).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;
            }


            var personalServices = db.SERVICEs.Where(x=>x.Service_Cat_Id==1).ToList();

            return View(personalServices);
        }
        public ActionResult GovServices()
        {

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;

            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 2).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_Ar).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;

            }
            else
            {
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 2).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_En).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;
            }



            var puplicSecServices = db.SERVICEs.Where(x => x.Service_Cat_Id == 2).ToList();

            return View(puplicSecServices);

           
        }
        public ActionResult CompaniesServices()
        {

            CultureInfo currentInfo = Thread.CurrentThread.CurrentCulture;

            if (currentInfo.IetfLanguageTag.ToString().Equals("ar-OM") || (currentInfo.IetfLanguageTag.ToString().Equals("ar")))
            {
                var ServiceProviders = db.SERVICEs.Where(x=>x.Service_Cat_Id==3).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_Ar).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;

            }
            else
            {
                var ServiceProviders = db.SERVICEs.Where(x => x.Service_Cat_Id == 3).Select(m => m.SERVICE_PROVIDER.Service_Provider_Name_En).Distinct();
                ViewBag.ServiceProviders = ServiceProviders;
            }



            var ComServices = db.SERVICEs.Where(x => x.Service_Cat_Id == 3).ToList();

            return View(ComServices);


        }

        public ActionResult ServicesDetails(int id)
        {

            ROP_WEBEntities db = new ROP_WEBEntities();
           
            return View(db.SERVICEs.FirstOrDefault(x => x.Service_Id == id));
        }
    }
}