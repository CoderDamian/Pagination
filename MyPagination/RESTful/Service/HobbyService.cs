using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using Persistence.Entities.DTOs;
using Persistence.Entities.Extensions;
using RESTful.Contracts;

namespace RESTful.Service
{
    public class HobbyService : IHobbyService
    {
        private readonly HobbyDbContext _dbContext;
        public HobbyService(HobbyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetHobbyListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
        {
            Page<Hobby> hobbies = await _dbContext.Hobbies
                .AsNoTracking()
                .OrderBy(h => h.CreatedAt)
                .PaginateAsync(page, limit, cancellationToken); // extensions method that return PAGE

            GetHobbyListResponseDto responseDto = new()
            {
                CurrentPage = hobbies.CurrentPage,
                TotalItems = hobbies.TotalItems,
                TotalPages = hobbies.TotalPages,
                Items = hobbies.Items.Select(h => new GetHobbyResponseDto() // items is a property of PAGE
                {
                    Id = h.ID,
                    Name = h.Name,
                    CreatedAt = h.CreatedAt
                }).ToList()
            };

            return responseDto;
        }
    }
}
