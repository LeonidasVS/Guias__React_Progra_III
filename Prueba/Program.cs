// See https://aka.ms/new-console-template for more information

using ReactBackend.Models;
using ReactBackend.Repository;



AlumnoDAO alumnoDao = new AlumnoDAO(); // abstracion del objeto DAO
/*
#region Select All
var alumno =alumnoDao.SelectAll(); // Llamamos al metodo creado

foreach (var item in alumno) //Recorremos la lista de alumnos
{
    Console.WriteLine(item.Nombre+" - Edad: "+item.Edad);
}
#endregion


#region SelectById
Console.WriteLine(" ");
var selectById = alumnoDao.GetById(10);
Console.WriteLine(selectById?.Nombre);
#endregion


#region InsertarAlumno

var insertarAlumno = new Alumno {
    Direccion="Nueva Concepcion, Chalatenango",
    Dni="12345",
    Edad=30,
    Email="12344321@gmail",
    Nombre="iAMJL Milos"
};

var resultado=alumnoDao.insertarAlumno(insertarAlumno);
Console.WriteLine(resultado);
#endregion


#region AxtualizarAlumno
var actualizarAlumno = new Alumno
{
    Direccion = "San salvador, reubicacion II",
    Dni = "72192",
    Edad = 45,
    Email = "72192@gmail.com",
    Nombre = "Mario gonzales"
};

var resultado=alumnoDao.actualizarAlumno(2,actualizarAlumno);
Console.WriteLine(resultado);
#endregion


#region Eliminar



var resultado = alumnoDao.EliminarAlumno(12);
Console.WriteLine("Se elimino"+resultado);
#endregion
*/

#region AlumnoAsignatura desde un Join
var alumnoAsig = alumnoDao.SeleccionarAlumnoConAsignatura();

foreach (AlumnoAsignatura item in alumnoAsig)
{
    Console.WriteLine(item.nombreAlumno+ " | Cursa: "+item.nombreAsignatura);
}
#endregion

