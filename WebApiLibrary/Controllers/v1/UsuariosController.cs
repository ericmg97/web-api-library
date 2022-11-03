﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;
using WebApiLibrary.Services;

namespace WebApiLibrary.Controllers.v1
{
    [ApiController]
    [Route("api/v1.0/library/users")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name = "getUsers")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            var entities = await context.Usuarios
                .Include(userdb => userdb.Suscripciones)
                .ToListAsync();
            return mapper.Map<List<UsuarioDTO>>(entities);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO userDTO)
        {
            var user = mapper.Map<Usuario>(userDTO);
            user.FechaRegistro = DateTime.Now;
            context.Add(user);
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getUsers", new { id = user.Id }, userDTO);
        }

        [HttpPut("{id:int}", Name = "updateUser")]
        public async Task<ActionResult> Put(int id, [FromForm] UsuarioEdicionDTO userDTO)
        {
            var userdb = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (userdb == null)
            {
                return NotFound();
            }

            var user = mapper.Map<Usuario>(userDTO);
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "delUser")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Usuario() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id:int}/subscribe-to-author/{authorid:int}")]
        public async Task<ActionResult> SuscribeToAuthor(int id, int authorid)
        {
            var user = await context.Usuarios
                .Include(userDB => userDB.Suscripciones)
                .FirstOrDefaultAsync(x => x.Id == id);

            var author = await context.Autores
                .FirstOrDefaultAsync(x => x.Id == authorid);

            if (user == null || author == null)
            {
                return NotFound();
            }

            var suscription = user.Suscripciones.FirstOrDefault(x => x.Id == authorid);

            if (suscription != null) 
            {
                return BadRequest();        
            }

            user.Suscripciones.Add(author);
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}/subscribe-to-author/{authorid:int}")]
        public async Task<ActionResult> UnsuscribeToAuthor(int id, int authorid)
        {
            var user = await context.Usuarios
                .Include(userDB => userDB.Suscripciones)
                .FirstOrDefaultAsync(x => x.Id == id);

            var author = await context.Autores
                .FirstOrDefaultAsync(x => x.Id == authorid);

            if (user == null || author == null)
            {
                return NotFound();
            }

            var suscription = user.Suscripciones.FirstOrDefault(x => x.Id == authorid);

            if (suscription == null)
            {
                return BadRequest();
            }

            user.Suscripciones.Remove(author);
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}