using LMS_App.Interface;
using LMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserInfo iuserServiceInfo;

        public UserController(IUserInfo _iuserServiceInfo)
        {
            iuserServiceInfo = _iuserServiceInfo;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {

                var users = await iuserServiceInfo.GetAllUsers();
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("GetUserByEmailAddress/{emailid}")]
        public async Task<IActionResult> GetUserByEmailAddress(string emailid)
        {
            try
            {

                var users = await iuserServiceInfo.GetUserByEmailAddress(emailid);
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User userInfo)
        {
            try
            {
                var user = await iuserServiceInfo.RegisterUser(userInfo);
                return new OkObjectResult(user);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var result = await iuserServiceInfo.LoginUser(login);
                if (result != null)
                {
                    return new OkObjectResult(result);
                }
                else
                    return new BadRequestObjectResult("Incorrect username/password");

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // POST api/<UserController>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword resetPassword)
        {
            try
            {
                var result = await iuserServiceInfo.ResetPassword(resetPassword);
                if (result)
                {
                    return new OkObjectResult("User password has been changed successfully");
                }
                else
                    return new BadRequestObjectResult("Incorrect old password");

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


    }
}
