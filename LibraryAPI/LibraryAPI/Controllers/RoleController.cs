﻿using LibraryAPI.Entities;
using LibraryAPI.Models.Roles;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetAll()
        {
            var roles = _service.GetAll().Result;

            return Ok(roles);
        }

        [HttpPost]
        public ActionResult Create([FromBody] RoleDTO dto)
        {
            var id = _service.Create(dto).Result;

            return Created($"api/roles/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody] RoleDTO dto)
        {
            var isUpdated = _service.Update(id, dto).Result;
            if (!isUpdated) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id).Result;
            if(!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
