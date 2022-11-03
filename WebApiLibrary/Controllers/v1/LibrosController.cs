using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers.v1
{
    [ApiController]
    [Route("api/v1.0/library/books")]
    [Produces("application/json")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name = "getBook")]
        public async Task<ActionResult<List<LibroDTO>>> Get()
        {
            var entities = await context.Libros.Include(librodb => librodb.Autor).ToListAsync();
            return mapper.Map<List<LibroDTO>>(entities);
        }
    }
}
