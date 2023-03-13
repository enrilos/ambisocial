namespace AmbiSocial.Web;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected const string Id = "{id:int}";
    protected const string PathSeparator = "/";
}