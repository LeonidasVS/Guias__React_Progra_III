using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactBackend.Context;
using ReactBackend.Models;

namespace ReactBackend.Repository
{
    public class ProfesorDAO
    {
        public RegistroAlumnoContext context=new RegistroAlumnoContext();

        public Profesor login(string usuario, string password)
        {
            var profesor = context.Profesors.Where(p => p.Usuario == usuario && p.Pass == password).FirstOrDefault();

            return profesor;
        }
    }
}
