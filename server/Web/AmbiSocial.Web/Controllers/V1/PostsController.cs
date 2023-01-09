namespace AmbiSocial.Web.Controllers.V1
{
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : ApiController
    {
        private readonly ILogger<PostsController> logger;

        public PostsController(ILogger<PostsController> logger)
            => this.logger = logger;


        [HttpGet]
        public IEnumerable<object> Get()
        {
            var objects = new List<object>()
            {
                new
                {
                    Origin = "Smithsonian",
                    Value = "Considerably high"
                },
                new
                {
                    Name = "Norwegian",
                    Value = "High"
                }
            };

            return objects;
        }
    }
}
