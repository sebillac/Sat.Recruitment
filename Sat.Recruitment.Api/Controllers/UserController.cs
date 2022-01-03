using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Services;
using Sat.Recruitment.Entities;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/GetUserById")]
        public async Task<User> GetUserById(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpPost]
        [Route("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                user.Validate();
                user = await _userService.CreateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }
    }
}