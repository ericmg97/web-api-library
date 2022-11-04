namespace WebApiLibrary.DTOs
{
    public class PaginacionDTO
    {
        public int offset { get; set; } = 0;
        private int _limit = 50;
        private readonly int maxLimit = 100;
        public int limit 
        { 
            get => _limit;
            set
            {
                _limit = (value > maxLimit) ? maxLimit : value;
            }
        }
    }
}
