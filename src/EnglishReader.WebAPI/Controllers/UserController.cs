using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishReader.Business.Abstract;
using EnglishReader.Business.Constants;
using EnglishReader.Entities.CustomEntity.Request.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishReader.WebAPI.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserManager userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// User register operation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult InsertUser(UserRegisterRequest request)
        {
            var response = _userService.Register(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Message);
        }
    }
}
