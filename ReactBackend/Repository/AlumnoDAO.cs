﻿using System;
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
    }
}
