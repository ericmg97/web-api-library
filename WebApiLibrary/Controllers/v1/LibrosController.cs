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

        [HttpPost("{id:int}/reviews/from/users/{userId:int}")]
        public async Task<ActionResult> PostReview(int id, int userId, ReviewCreacionDTO reviewdto)
        {
            var user = await context.Usuarios
                .FirstOrDefaultAsync(x => x.Id == userId);

            var book = await context.Libros
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null || book == null)
            {
                return NotFound();
            }

            var prevreview = await context.Calificaciones.AnyAsync(x => x.UsuarioId == userId && x.LibroId == id);
            if (prevreview)
            {
                return BadRequest();
            }

            var review = mapper.Map<Review>(reviewdto);
            review.LibroId = id;
            review.UsuarioId = userId;
            review.Fecha = DateTime.Now;
            context.Add(review);

            book.PromedioCalificacion = (book.PromedioCalificacion * book.CantidadCalificacion  + (int)review.Calificacion) / (book.CantidadCalificacion + 1);
            book.CantidadCalificacion++;

            context.Entry(book).State = EntityState.Modified;

            await context.SaveChangesAsync();

            var comentariordto = mapper.Map<ReviewDTO>(review);

            return CreatedAtRoute("getReviews", new {id}, comentariordto);
        }

        [HttpGet("{id:int}/reviews", Name = "getReviews")]
        public async Task<ActionResult<List<ReviewDTO>>> GetReview(int id)
        {
            var entities = await context.Calificaciones.Where(x => x.LibroId == id).ToListAsync();
            return mapper.Map<List<ReviewDTO>>(entities);
        }
    }
}
