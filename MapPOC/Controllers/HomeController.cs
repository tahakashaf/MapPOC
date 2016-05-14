using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleMaps.LocationServices;
using MapPOC.Models;



namespace MapPOC.Controllers
{

   
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            var address = "Delhi";
            var locationService = new GoogleLocationService();
             var point = locationService.GetLatLongFromAddress(address); 
  var latitude = point.Latitude; 
  var longitude = point.Longitude;



            return View();
        }

        [HttpGet]
        public JsonResult GetMapData()
        {
            List<GoogleMapViewModel> mapVM= new List<GoogleMapViewModel>();

          GoogleMapViewModel record1= new GoogleMapViewModel();
            record1.City="Delhi";
            record1.Latitude= GetLatitude(record1.City);
            record1.Longitude= GetLongitude(record1.City);

            Webinars webinar= new Webinars();
            webinar.CollegeName="IIT Delhi";
            webinar.WebinarName="Cloud Computing";
            webinar.NumberOfStudents=100;

            Webinars webinar2 = new Webinars();
            webinar.CollegeName = "IIT Delhi";
            webinar.WebinarName = "Biology ";
            webinar.NumberOfStudents = 50;
            List<Webinars> w = new List<Webinars>();
            w.Add(webinar);
            w.Add(webinar2);
            record1.Webinars = w;
         

            GoogleMapViewModel record2= new GoogleMapViewModel();
            record2.City="Mumbai";
            record2.Latitude= GetLatitude(record2.City);
            record2.Longitude= GetLongitude(record2.City);
            
            GoogleMapViewModel record3 = new GoogleMapViewModel();
            record3.City = "Allahabad";
            record3.Latitude = GetLatitude(record3.City);
            record3.Longitude = GetLongitude(record3.City);

            GoogleMapViewModel record4 = new GoogleMapViewModel();
            record4.City = "Shimla";
            record4.Latitude = GetLatitude(record4.City);
            record4.Longitude = GetLongitude(record4.City);
            mapVM.Add(record1);
            mapVM.Add(record2);
            mapVM.Add(record3);
            mapVM.Add(record4);
            return Json(mapVM, JsonRequestBehavior.AllowGet);
        }


        public  double GetLatitude(string cityName)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(cityName);
            var latitude = point.Latitude; 
            return latitude;


        }
        public double GetLongitude(string cityName)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(cityName);
           
             var Longitude = point.Longitude;

             return Longitude;


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}