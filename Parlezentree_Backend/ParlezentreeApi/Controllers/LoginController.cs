using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParlezentreeDl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParlezentreeApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allowedOrigins")]
    public class LoginController : Controller
    {
        readonly IUserRepository userRepo;
        public LoginController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        /// <summary>
        /// this methos is used to check login credentials
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>retun if sucessfully login or login fail</returns>
        [HttpGet]
        public ActionResult Get(string email, string password)
        {
            if (email == null || password == null)
            {
                return BadRequest("EmailId or Password cannot be empty.");
            }
            var userresult = userRepo.getAllUser();
            foreach (var user in userresult)
            {
                if (user.EmailId == email && user.UserPassword == password)
                {

                    return Ok(user);
                }
                else
                {
                    if (user.EmailId != email)
                    {
                        return Ok("Don't have an account with this emailId.");
                    }
                    else
                    {
                        return Ok("Invalid emailid or password.");
                    }

                }
            }
            return Ok("login");
        }

    }
}

