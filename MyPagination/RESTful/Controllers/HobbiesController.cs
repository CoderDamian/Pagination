using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities.DTOs;
using Persistence.Entities.Hateoas;
using RESTful.Contracts;

namespace RESTful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbyService _service;

        public HobbiesController(IHobbyService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetHobbyListAsync))]
        public async Task<IActionResult> GetHobbyListAsync([FromQuery] UrlQueryParameters urlQueryParameters, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hobbies = await _service.GetByPageAsync(
                                    urlQueryParameters.Limit,
                                    urlQueryParameters.Page,
                                    cancellationToken);

            GeneratePageLinks(urlQueryParameters, hobbies);

            return Ok(hobbies);
        }


        public record UrlQueryParameters(int Limit = 50, int Page = 1);

        private GetHobbyListResponseDto GeneratePageLinks(UrlQueryParameters queryParameters, GetHobbyListResponseDto response)
        {
            if (response.CurrentPage > 1)
            {
                var prevRoute = Url.RouteUrl(nameof(GetHobbyListAsync), new { limit = queryParameters.Limit, page = response.CurrentPage - 1 });

                response.AddResourceLink(LinkedResourceType.Next, prevRoute); // using extension method AddResourceLink
            }

            if (response.CurrentPage < response.TotalPages)
            {
                var nextRoute = Url.RouteUrl(nameof(GetHobbyListAsync), new { limit = queryParameters.Limit, page = response.CurrentPage + 1 });

                response.AddResourceLink(LinkedResourceType.Next, nextRoute);
            }

            return response;
        }
    }
}
