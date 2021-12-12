using System;
using CoffeeCatchup.Databases;
using CoffeeCatchup.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCatchup.Controllers
{
    [Route("api/signup")]
    public class SignupControler : Controller
    {
        private UserDBContext context { get; }

        [HttpPost("store")]
        public JsonResult StoreSignup(DayPrefrences data)
        {
            //context.Add(data);
            System.Diagnostics.Debug.WriteLine(data.monday);
            return Json(new { success=true });
        }

        public class DayPrefrences
        {
            public bool monday { get; set; }
            public bool tuesday { get; set; }
            public bool wednesday { get; set; }

            public bool thursday { get; set; }
            public bool friday { get; set; }
        }

    }
}
