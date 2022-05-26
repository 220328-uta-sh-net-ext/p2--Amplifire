using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParlezentreeDl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParlezentreeApi.Controllers
{
    [Route("api/")]
    public class UserController : Controller
    {
        private IUserRepository userRepo;
        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        [Route("login")]
        [HttpGet]
        public ActionResult Get(string email, string password)
        {
            if(email==null || password == null)
            {
                return BadRequest("EmailId or Password cannot be empty.");
            }
            var userresult = userRepo.getAllUser();
            foreach (var user in userresult)
            {
                if (user.EmailId == email && user.UserPassword == password)
                {

                    return Ok("Login Sucessfull.");
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

        [Route("User")]
        [HttpPost]
        public ActionResult Post([FromBody] ParlezentreeDl.Entities.User user)
        {
            if(user == null)
            {
                return BadRequest("User can not be null");
            }
            else if(user.ContactNo.ToString().Length != 10)
            {
                return BadRequest("Contact number can not be less than 10 digit");
            }
            else if (user.FirstName == null || user.FirstName == "")
            {
                return BadRequest("Invalid First Name,please enter valid First Name.");
            }
            else if (user.UserPassword.Length < 6)
            {
                return BadRequest("Password must be more than 6 character.");
            }
            else if (user.EmailId.ToString() == "")
            {
                return BadRequest("Invalid Email address,Please enter valid email address!!");

            }
            try
            {

            var result = userRepo.addUser(user);
                return Ok(result);
            }
            catch(Exception ex)
            {
                if(ex.Message.ToString() == "An error occurred while saving the entity changes. See the inner exception for details.")
                {
                    return Ok("Emaild is already used.");
                }
                else
                {

                return BadRequest(ex.Message);
                }
            }

        }


        [Route("User")]
        // PUT api/values/5
        [HttpPut]
        public ActionResult Put(int id, [FromBody] ParlezentreeDl.Entities.User user)
        {
            if (user == null)
            {
                return BadRequest("User can not be null");
            }
            else if (user.ContactNo.ToString().Length != 10)
            {
                return BadRequest("Contact number can not be less than 10 digit");
            }
            else if (user.FirstName == null || user.FirstName == "")
            {
                return BadRequest("Invalid First Name,please enter valid First Name.");
            }
            else if (user.UserPassword.Length < 6)
            {
                return BadRequest("Password must be more than 6 character.");
            }
            else if (user.EmailId.ToString() == "")
            {
                return BadRequest("Invalid Email address,Please enter valid email address!!");

            }
            try
            {
                var result = userRepo.updateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong!!");
            }
        }

    }

}

