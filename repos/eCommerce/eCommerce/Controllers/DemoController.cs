using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eCommerce.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
      
        public ActionResult DtLocation()
        {
            // return 1/1/0001 12:00:00 AM  
            DateTime defaultDate = default(DateTime);
            // return 08/05/2016 12:56 PM  
            var shortDT = defaultDate.ToString().Replace("12:00:00 AM", "");
            // return 08/05/2016 12:56 PM     
            var userDt = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            // return 08/05/2016 12:56 PM  
            var nwDt = DateTime.Now.ToShortDateString();
            // return 12:24 PM  
            var nwTm = DateTime.Now.ToShortTimeString();
            // return 8/5/2016 12:00:00 AM  
            //DateTime dtByUser = DateTime.Parse(userDt).Date;
            //// return Friday, August 05, 2016  
            //var longDt = dtByUser.ToLongDateString();
            //// return 12:00:00 AM  
            //var shortTm = dtByUser.ToLongTimeString();
            //// return 2016-08-05  
            //var formattedDt = dtByUser.ToString("yyyy-MM-dd");
            // return Friday, 05 August 2016    
            var fDt = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            ViewData["removeTm"] = shortDT;
            ViewData["nowDt"] = nwDt;
            ViewData["nowTm"] = nwTm;
            //ViewData["userDt"] = dtByUser;
            //ViewData["longDt"] = longDt;
            //ViewData["shortTm"] = shortTm;
            //ViewData["formattedDt"] = formattedDt;
            ViewData["fDt"] = fDt;
            TimeZone zone = TimeZone.CurrentTimeZone;
            ViewData["CurrentTimeZone"] = zone.StandardName;
            // return 05:30:00  
            TimeSpan UTCOffset = zone.GetUtcOffset(DateTime.Now);
            ViewData["UTCOffset"] = UTCOffset;
            //System.Globalization.DaylightTime dayLightTm = zone.GetDaylightChanges(dtByUser.Year);
            //ViewData["dayLightStartTm"] = dayLightTm.Start.ToString("hh:mm:ss tt");
            // return 8/5/2016 12:56:18 PM  
            var s = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, zone.StandardName);
            ViewData["ConvertedTZone"] = s;
            return View();
        }
    }
}