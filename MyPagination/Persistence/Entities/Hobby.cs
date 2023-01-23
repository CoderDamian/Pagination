namespace Persistence.Entities
{
    public class Hobby
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
