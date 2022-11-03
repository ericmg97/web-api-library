using AutoMapper;
using WebApiLibrary.DTOs;
using WebApiLibrary.Models;

namespace WebApiLibrary.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(
                    autorDTO => autorDTO.Libros,
                    opciones => opciones.MapFrom(MapLibroAutorDTO));

            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Libro, LibroCreacionDTO>().ReverseMap();
            CreateMap<Libro, LibroDTO>()
                .ForMember(
                    libroDTO => libroDTO.NombreAutor,
                    opciones => opciones.MapFrom(MapNombreAutorLibro)); ;
        }

        private List<LibroAutorDTO> MapLibroAutorDTO(Autor autor, AutorDTO autordto)
        {
            var resultado = new List<LibroAutorDTO>();

            if (autor.Libros == null) { return resultado; }

            foreach (var libro in autor.Libros)
            {
                resultado.Add(new LibroAutorDTO
                {
                    ISBN = libro.ISBN,
                    Titulo = libro.Titulo,
                    FechaPublicacion = libro.FechaDePublicacion
                });
            }

            return resultado;
        }

        private string MapNombreAutorLibro(Libro libro, LibroDTO librodto)
        {
            return libro.Autor.Nombre;
        }
    }
}
