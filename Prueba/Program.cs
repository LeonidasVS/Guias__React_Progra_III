// See https://aka.ms/new-console-template for more information

using ReactBackend.Repository;



AlumnoDAO alumnoDao = new AlumnoDAO(); // abstracion del objeto DAO

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