using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace hp_api.Controllers
{
    [ApiController]
    [Route("")]
    public class DocsController: ControllerBase
    {
        private readonly IConfiguration configuration;

        public DocsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ContentResult Test()
        {
            // Not working on DOCKER
            /*var path = @"./static/html/home.html";
            var html = System.IO.File.ReadAllText(path);*/
            var html = configuration.GetValue<string>("html:home");

            return Content(html, "text/html", Encoding.UTF8);
        }
    }
}
