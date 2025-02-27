using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactBackend.Models;
using ReactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDAO _cdao=new CalificacionDAO();

        [HttpGet("calificaciones")]

        public List<Calificacion>get(int idMatricula)
        {
            return _cdao.seleccion(idMatricula);
        }

        [HttpPost("calificacion")]
        public bool insertar([FromBody] Calificacion calificacion)
        {
            return _cdao.insertar(calificacion);    
        }
    }
}
