using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROP_WEB.Controllers
{
    public class HomeController : Controller
    {
    //   ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        // GET: Home
        public ActionResult Index()
        {

        // var xx=   ur.GetData(222);

           //List<Models.Slider> sliderlist = new List<Models.Slider>();

           //var lst = service.GetSliders();

           // foreach (var item in lst)
           // {
           //     Models.Slider sldr = new Models.Slider();
           //     int x = (int)item.SlideId;
           //     sldr.sliderid = x;
           //     sldr.sliderurl = item.slideUrl;
           //     //sldr.sliderimg = item.SlideImg;

           //     sliderlist.Add(sldr);

             

           // }

           // //foreach (var aPart in lst)
           // //{
           // //    Console.WriteLine(aPart);
           // //}

           // ViewBag.sld = sliderlist;



            return View();
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