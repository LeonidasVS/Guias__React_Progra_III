using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactBackend.Context;
using ReactBackend.Models;

namespace ReactBackend.Repository
{
    public class AlumnoDAO
    {
        public RegistroAlumnoContext contexto= new RegistroAlumnoContext(); 


        public List<Alumno> SelectAll()
        {
            var alumno=contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }

        public Alumno? GetById(int id)
        {
            var alumno=contexto.Alumnos.Where(x=>x.Id==id).FirstOrDefault();    
            return alumno == null ? null : alumno;
        }
    }
}
