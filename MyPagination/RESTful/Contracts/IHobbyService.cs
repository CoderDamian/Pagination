using Persistence.Entities.DTOs;

namespace RESTful.Contracts
{
    public interface IHobbyService
    {
        Task<GetHobbyListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    }
}