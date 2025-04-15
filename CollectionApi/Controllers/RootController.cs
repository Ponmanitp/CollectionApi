using Microsoft.AspNetCore.Mvc;

namespace CollectionApi.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class RootController : ControllerBase
{
    public const string PathVersion = "/api/v1";
    public const string PathController = $"{PathVersion}/[Controller]";
}
