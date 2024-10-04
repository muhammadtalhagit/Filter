namespace ShowroomApi.Models.DTOs
{
    public class CarsDTO
    {
        public string Name { get; set; } = null!;

        public int ManufactureId { get; set; }

        public string Color { get; set; } = null!;

        public string Power { get; set; } = null!;

        public long Price { get; set; }
    }
}
