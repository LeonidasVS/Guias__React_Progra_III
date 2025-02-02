using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaControllers : ControllerBase
    {
        [HttpGet("prueba")]

        public string Get() {
            return "Hola mundo";        
        }
    }
}
