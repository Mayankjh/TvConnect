﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tv_Connect_App.Entities;
using Tv_Connect_App.Helpers;
using Tv_Connect_App.Models.Users;
using Tv_Connect_App.Services;

namespace Tv_Connect_App.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
        public class UsersController : ControllerBase
        {
            private IUserService _userService;
            private IMapper _mapper;
            private readonly AppSettings _appSettings;

            public UsersController(
                IUserService userService,
                IMapper mapper,
                IOptions<AppSettings> appSettings)
            {
                _userService = userService;
                _mapper = mapper;
                _appSettings = appSettings.Value;
            }
        [Authorize]
        [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody]AuthenticateModel model)
            {
                var user = _userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
               
                // return basic user info and authentication token
                return Ok(new
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                    Token = tokenString
                });
            }

           
            [HttpPost("register")]
            public IActionResult Register([FromBody]RegisterModel model)
            {
                // map model to entity
                var user = _mapper.Map<User>(model);

                try
                {
                    // create user
                    _userService.Create(user, model.Password);
                    
                    return Ok();
                }
                catch (AppException ex)
                {
                    // return error message if there was an exception
                    return BadRequest(new { message = ex.Message });
                }
            }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
            public IActionResult GetAll()
            {
                var users = _userService.GetAll();
                var model = _mapper.Map<IList<UserModel>>(users);
                return Ok(model);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var user = _userService.GetById(id);
                var model = _mapper.Map<UserModel>(user);
                return Ok(model);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody]UpdateModel model)
            {
                // map model to entity and set id
                var user = _mapper.Map<User>(model);
                user.Id = id;

                try
                {
                    // update user 
                    _userService.Update(user, model.Password);
                    return Ok();
                }
                catch (AppException ex)
                {
                    // return error message if there was an exception
                    return BadRequest(new { message = ex.Message });
                }
            }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _userService.Delete(id);
                return Ok();
            }
        }
    }