using Persistence.Entities.Hateoas;

namespace Persistence.Entities.DTOs
{
    public record GetHobbyListResponseDto : ILinkedResource
    {
        public int CurrentPage { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages { get; init; }
        public List<GetHobbyResponseDto> Items { get; init; }
        public IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }
    }
}
