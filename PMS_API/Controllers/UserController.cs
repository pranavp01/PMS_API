using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Business.Interfaces;
using PMS_Models;
using PMS_API.Model;
using PMS_API.Services;
using Microsoft.AspNetCore.Authorization;


namespace PMS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IUserService _userService;
        public UserController(IUserBusiness userBusiness, IUserService userService)
        {
            _userBusiness = userBusiness;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles =RoleConstants.Admin)]
        [Route("getallusers")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            try
            {
                var patients = await _userBusiness.GetUsers();
                return Ok(patients);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
           
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<ActionResult<bool>> AddUser(UserModel userModel)
        {
            try
            {
                var result = await _userBusiness.AddUser(userModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserApiModel>> Login([FromBody] AuthenticateModel authenticateModel)
        {
            try
            {
                var user = await _userService.Authenticate(authenticateModel.Username, authenticateModel.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
