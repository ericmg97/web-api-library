namespace WebApiLibrary.DTOs
{
    public class PaginacionDTO
    {
        public int Offset { get; set; } = 0;
        private int limit = 50;
        private readonly int maxLimit = 100;
        public int Limit 
        { 
            get => limit;
            set
            {
                limit = (value > maxLimit) ? maxLimit : value;
            }
        }
    }
}
