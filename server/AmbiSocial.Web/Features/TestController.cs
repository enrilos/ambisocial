namespace AmbiSocial.Web;

using Microsoft.AspNetCore.Mvc;

public class TestController : ApiController
{
    [HttpGet]
    public ActionResult<IEnumerable<object>> GetAll()
    {
        var objects = new List<object>()
        {
            new
            {
                Adjective = "Smithsonian",
                Noun = "Institute"
            },
            new
            {
                Adjective = "Norwegian",
                Noun = "Glacier"
            }
        };

        return objects;
    }

    [HttpGet]
    [Route(Id)]
    public ActionResult Get([FromRoute] int id)
    {
        var obj = new
        {
            Adjective = id,
            Noun = "Unit"
        };

        return Ok(obj);
    }
}