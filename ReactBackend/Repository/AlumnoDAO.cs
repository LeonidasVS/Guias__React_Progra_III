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

        #region Seleccionar
        public List<Alumno> SelectAll()
        {
            var alumno=contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }
        #endregion

        #region Seleccionar por ID
        public Alumno? GetById(int id)
        {
            var alumno=contexto.Alumnos.Where(x=>x.Id==id).FirstOrDefault();    
            return alumno == null ? null : alumno;
        }
        #endregion

        #region InsetarAlumno
        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno {
                Direccion=alumno.Direccion,
                Edad=alumno.Edad,
                Email=alumno.Email,
                Dni=alumno.Dni, 
                Nombre=alumno.Nombre,
                };

                contexto.Alumnos.Add(alum);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }
        #endregion

        #region ActualizarAlumno
        public bool actualizarAlumno(int id, Alumno actualizar)
        {
            try{
                var alumnoActualiza=GetById(id);
                if (alumnoActualiza== null) {

                    Console.WriteLine("Alumno es inexistente");
                    return false;
                }   

                alumnoActualiza.Direccion=actualizar.Direccion;
                alumnoActualiza.Dni=actualizar.Dni;
                alumnoActualiza.Nombre=actualizar.Nombre;
                alumnoActualiza.Email=actualizar.Email;
                alumnoActualiza.Edad=actualizar.Edad;


                contexto.Alumnos.Update(alumnoActualiza);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception ex) { 

                Console.WriteLine(ex.ToString()); return false;
            }
        }
        #endregion

        #region EliminarAlumno
        public bool EliminarAlumno(int id)
        {
            var borrarAlumno = GetById(id);

            try
            {
                if(borrarAlumno== null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(borrarAlumno);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException); return false; 

            }
        }
        #endregion

        #region LeftJoin
        public List<AlumnoAsignatura> SeleccionarAlumnoConAsignatura()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                           select new AlumnoAsignatura
                           {
                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre
                           };

            return consulta.ToList();
        }
        #endregion

        public List<AlumnoProfesor> alumnoProfesores(string nombreProfesor)
        {
            var listadoAlumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Id=a.Id,
                                    Dni=a.Dni,
                                    Nombre=a.Nombre,
                                    Direccion=a.Direccion,
                                    Edad=a.Edad,
                                    Email=a.Email,
                                    asignatura=asig.Nombre
                                };
            return listadoAlumno.ToList();  
        }

        public bool update(int id, Alumno alumno)
        {
            try
            {
                var buscarAlumno=GetById(id);
                if (buscarAlumno == null) {
                    return false;
                }
                else
                {
                    buscarAlumno.Nombre = alumno.Nombre;
                    buscarAlumno.Dni = alumno.Dni;
                    buscarAlumno.Direccion = alumno.Direccion;
                    buscarAlumno.Edad = alumno.Edad;    
                    buscarAlumno.Email = alumno.Email;

                    contexto.Alumnos.Update(buscarAlumno);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { 
                return false;
            }
        }


        public Alumno DNIAlumno(Alumno alumno)
        {
            var alumnos=contexto.Alumnos.Where(a=>a.Dni == alumno.Dni).FirstOrDefault();

            return alumnos == null ? null : alumnos;
        }

        public bool InsertarMatricula(Alumno alumno, int idAsing)
        { 
            try
            {
                var alumnoDNI = DNIAlumno(alumno);
                if (alumnoDNI == null)
                {
                    insertarAlumno(alumno);

                    var alumnoInsertado = DNIAlumno(alumno);

                    var unirAlumnoMatricula = matriculaAsignaturaALumno(alumno, idAsing);

                    if (unirAlumnoMatricula == false)
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    matriculaAsignaturaALumno(alumnoDNI, idAsing);
                    return true;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool matriculaAsignaturaALumno(Alumno alumno, int idAsignatura)
        {
            try
            {
                Matricula matricula= new Matricula();
                matricula.AlumnoId = alumno.Id;
                matricula.AsignaturaId = idAsignatura;

                contexto.Matriculas.Add(matricula);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            } 
        }
    }
}
