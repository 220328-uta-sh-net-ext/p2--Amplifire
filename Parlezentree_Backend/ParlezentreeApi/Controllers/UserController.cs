using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParlezentreeDl;

namespace ParlezentreeApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly IUserRepository userRepo;
        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
      
         
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest("Id cannot be empty.");
            }
            var userresult = userRepo.getAllUser();
            foreach (var user in userresult)
            {
                if (user.UserId == id)
                {
                    return Ok(user);
                }
            }
            return Ok("Invalid Id");
        }

        /// <summary>
        /// This methos creats the api for adding users into the database 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>if user is added or not</returns>
      
        [HttpPost]
        public ActionResult Post([FromBody] ParlezentreeDl.Entities.User user)
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

                var result = userRepo.addUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "An error occurred while saving the entity changes. See the inner exception for details.")
                {
                    return Ok("Emaild is already used.");
                }
                else
                {

                    return BadRequest(ex.Message);
                }
            }

        }

        /// <summary>
        /// This methods create the Api to update user by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>return the wether user is updated or not</returns>
       
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
                return Ok(user);
            }
            catch (Exception ex)
            {
                 
                return BadRequest("Something went wrong!!" + ex.Message);
            }
        }

    }

}

