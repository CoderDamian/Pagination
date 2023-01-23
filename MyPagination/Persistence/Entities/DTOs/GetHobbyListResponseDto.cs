namespace Persistence.Entities.DTOs
{
    public record GetHobbyListResponseDto
    {
        public int CurrentPage { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages { get; init; }
        public List<GetHobbyResponseDto> Items { get; init; }
    }
}
