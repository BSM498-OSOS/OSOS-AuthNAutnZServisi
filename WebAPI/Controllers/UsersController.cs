﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService) { 
            _userService = userService;
        }

        [HttpGet("getUserByID")]
        public IActionResult getUserByID(Guid id) { 
            return Ok(_userService.GetById(id));
        }
    }
}
