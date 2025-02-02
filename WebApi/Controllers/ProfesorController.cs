using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactBackend.Models;
using ReactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDAO _proDAO=new ProfesorDAO();

        [HttpPost("autenticacion")]

        public string loginProfesor([FromBody] Profesor profesor)
        {
            var prof=_proDAO.login(profesor.Usuario,profesor.Pass);
            if (prof!=null)
            {
                return prof.Usuario+"|"+prof.Email;
            }
            return "Elemento no encontrado";
        }
    }
}
