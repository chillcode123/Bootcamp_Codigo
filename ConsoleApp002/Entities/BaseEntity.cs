namespace ConsoleApp002.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime? FechaCreacion { get; set; }
    }
}
