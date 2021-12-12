using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApi.DAO;
using DataApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        UsersDAO dao;
        public UsersController(UsersDAO dao) {
            this.dao = dao;
        }

        [HttpPost]
        [Consumes("application/json")]
        public ActionResult Post([FromBody] UserModel value){
            string result = dao.storeUser(value);

            if (result == "Success") {
                return Json(new { result });
            }
            else {
                return new ObjectResult(new { result }) {
                    StatusCode = 400
                };
            }
            
        }


    }
}
