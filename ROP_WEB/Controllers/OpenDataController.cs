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
        public ActionResult TrafficFines(string sortOrder, string CurrentSort, int? page)
        {
            List<Offense> offense = new List<Offense>();
            //use try andcatch for erorr control + id showd come from user request 
            XElement xelement = XElement.Load(HttpContext.Server.MapPath("~/Res/OffenseClass.xml"));
            var OffenseClass = xelement.Elements();
         //   var element = (from Offense in OffenseClass where (int)Offense.Element("OffenseId") == 1 select Offense).ToList();

            foreach (XElement xEle in OffenseClass)
            {
                offense.Add(new Offense
                {
                    OffenseId = (int)xEle.Element("OffenseId"),
                    OffenseClassAr = xEle.Element("OffenseClassAr").Value,
                    OffenseClassEn= xEle.Element("OffenseClassEn").Value,
                    OffenseDescAr= xEle.Element("OffenseDescAr").Value,
                    OffenseDescEn= xEle.Element("OffenseDescEn").Value,
                    OffensePoints = (int)xEle.Element("OffensePoints"),
                    OffenseAmount = (float)xEle.Element("OffenseAmount")


                });
            }



            int pageSize = 1;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "OffenseId" : sortOrder;
            IPagedList<Offense> off = null;
            switch (sortOrder)
            {
                case "OffenseId":
                    if (sortOrder.Equals(CurrentSort))
                        off = offense.OrderByDescending
                                (m => m.OffenseId).ToPagedList(pageIndex, pageSize);
                    else
                        off = offense.OrderBy
                                (m => m.OffenseId).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    off = offense.OrderByDescending
                           (m => m.OffenseId).ToPagedList(pageIndex, pageSize);
                    break;
            }



            //List<Offense> offense = new List<Offense>();

            ////Load the XML file in XmlDocument.
            //XmlDocument doc = new XmlDocument();
            //doc.Load(Server.MapPath("~/Res/OffenseClass.xml"));

            ////Loop through the selected Nodes.
            //foreach (XmlNode node in doc.SelectNodes("/Offenses/Offense"))
            //{
            //    //Fetch the Node values and assign it to Model.
            //    offense.Add(new Offense
            //    {
            //        OffenseId = int.Parse(node["OffenseId"].InnerText),
            //        OffenseClassAr = node["OffenseClassAr"].InnerText,
            //        OffenseClassEn = node["OffenseClassEn"].InnerText,
            //        OffenseDescAr = node["OffenseDescAr"].InnerText,
            //        OffensePoints = int.Parse(node["OffenseId"].InnerText),
            //        OffenseAmount = float.Parse(node["OffenseId"].InnerText)
            //    });
            //}
            //var test = offense;
            return View(off);
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