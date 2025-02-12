using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactBackend.Models;
using ReactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumno=new AlumnoDAO();

        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor>GetAlumnoProfesor(string usuario)
        {
            return alumno.alumnoProfesores(usuario);
        }
    }
}
