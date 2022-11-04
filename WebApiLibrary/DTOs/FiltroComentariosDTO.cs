using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class FiltroComentariosDTO : PaginacionDTO
    {
        public EnumCalificacion? reviewType { get; set; } = null;

        public bool? order { get; set; } = null;
    }
}
