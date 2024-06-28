using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using creating_a_form_backend.Models;
using creating_a_form_backend.Models.DTO;
using creating_a_form_backend.Services;

namespace creating_a_form_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Form_UserController : ControllerBase
    {
        private readonly Form_UserService _userData;

        public Form_UserController(Form_UserService userData)
        {
            _userData = userData;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Form_LoginDTO User)
        {
            return _userData.Login(User);
        }

        [HttpPost]
        [Route("NewUser")]
        public bool AddUser(Form_CreateAccountDTO UserToAdd)
        {
            return _userData.AddUser(UserToAdd);
        }

        [HttpPut]
        [Route("UpdateUserPassword/{username}/{newPassword}")]
        public bool UpdateUserPassword(string username, string newPassword)
        {
            return _userData.UpdateUserPassword(username, newPassword);
        }

        [HttpGet]
        [Route("GetUserByUserName/{username}")]
        public Form_UserModels GetUserByUsername(string username)
        {
            return _userData.GetUserByUsername(username);
        }
    }
}