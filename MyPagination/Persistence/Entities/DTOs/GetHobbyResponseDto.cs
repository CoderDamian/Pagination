namespace Persistence.Entities.DTOs
{
    public record GetHobbyResponseDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
