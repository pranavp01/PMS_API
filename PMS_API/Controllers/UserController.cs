using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Business.Interfaces;
using PMS_Models;

namespace PMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
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
    }
}
