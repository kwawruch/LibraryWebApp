﻿using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Models.Users;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsersDTO>> GetAll([FromQuery]LibraryQuery query)
        {
            var users = _userService.GetAll(query).Result;

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get([FromRoute] int id)
        {
            var user = _userService.GetById(id).Result;

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserCreateDTO dto)
        {
            var id = _userService.Create(dto).Result;

            return Created($"api/users/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateDTO dto)
        {
            var isUpdated = _userService.Update(id, dto).Result;

            if (isUpdated) return Ok();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id).Result;

            if (isDeleted) return NoContent();

            return NotFound();
        }

        [HttpPut("{id}/role/{roleId}")]
        public ActionResult UserUpdateRole([FromRoute] int id, [FromRoute] int roleId)
        {
            var isUpdated = _userService.RoleUpdate(id, roleId).Result;

            if (isUpdated) return Ok();

            return NotFound();
        }
    }
}
