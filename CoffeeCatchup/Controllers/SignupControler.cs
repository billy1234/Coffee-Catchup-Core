using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoffeeCatchup.Models;
using CoffeeCatchup.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoffeeCatchup.Controllers
{
    [Route("api/signup")]
    public class SignupControler : Controller
    {

        UsersDataAPIService usersService;
        public SignupControler(UsersDataAPIService usersService) {
            this.usersService = usersService;
        }

        [HttpPost("store")]
        [Consumes("application/json")]
        public async Task<ActionResult> StoreSignup([FromBody] UserModel data) {
            HttpResponseMessage result = await usersService.postUser(data);


            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return StatusCode(200);
            }
            else
            {
                return new ObjectResult(new { result= await result.Content.ReadAsStringAsync()})
                {
                    StatusCode = 400
                };
            }
        }

    }
}
