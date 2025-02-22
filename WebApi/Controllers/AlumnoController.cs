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

        [HttpGet("alumno")]
        public Alumno? selectById(int id)
        {
            var estudiante=alumno.GetById(id);
            return estudiante;
        }

        [HttpPut("actualizar")]
        public bool actualizarAlumno([FromBody] Alumno alum) {

            return alumno.update(alum.Id, alum);
        }

        [HttpPost("alumno")]

        public bool insertarMatricula([FromBody] Alumno alumnom, int idAsignatura)
        {
            return alumno.InsertarMatricula(alumnom, idAsignatura);
        }
    }
}
