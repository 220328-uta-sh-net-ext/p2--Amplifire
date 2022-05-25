﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParlezentreeDl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParlezentreeApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository user;
        public UserController(IUserRepository user)
        {
            this.user = user;
        }
     
        [HttpGet]
        public ActionResult Get(string email, string password)
        {
            var userresult = user.getAllUser();
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

    }

}

