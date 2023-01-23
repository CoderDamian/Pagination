using Microsoft.AspNetCore.Mvc;
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

            return Ok(hobbies);
        }

    }

    public record UrlQueryParameters(int Limit = 50, int Page = 1);
}
