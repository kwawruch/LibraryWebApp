﻿using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserCreateDTO dto)
        {
            var id = _userService.Create(dto);

            return Created($"api/users/{id}", null);
        }

        [HttpPut]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateDTO dto)
        {
            var isUpdated = _userService.Update(id, dto);

            if (isUpdated) return Ok();

            return NotFound();
        }

        public ActionResult DeleteUser([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id);

            if (isDeleted) return NoContent();

            return NotFound();
        }
    }
}