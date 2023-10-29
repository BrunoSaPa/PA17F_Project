using System;
using System.Text;
using Backend;
using Entidades;
using Microsoft.Extensions.Configuration;

namespace Programa.Paginas;

public class MantenimientoProfesores : PaginaBase
{
    public bool _RecuperarContrasena { get; set; }
    public Profesor ProfesorActual { get; set; }
    public Usuario UsuarioActual { get; set; }
    public int IdUsuarioActual { get; set; }
    public bool UsuarioNuevo { get; set; }

    public MantenimientoProfesores(IConfiguration configuracion) : base("MantenimientoProfesores", configuracion)
    {
        IdUsuarioActual = -1;
        UsuarioNuevo = true;
        _RecuperarContrasena = false;
        ProfesorActual = null;
        UsuarioActual = null;
    }

    public void MostrarMantenimientoProfesores()
    {
        UsuarioNuevo = IdUsuarioActual == -1;
        if (UsuarioNuevo)
        {
            Agregar();
        }
        else
        {
            Consultar();
            if (ProfesorActual == null)
            {
                return;
            }

            if (_RecuperarContrasena)
            {
                RecuperarContrasena();
            }
            else
            {
                Actualizar();
            }
        }
    }

    public void RecuperarContrasena()
    {
        bool usuarioActualizado = false;
        bool profesorActualizado = false;
        Mostrar();
        Console.WriteLine("\nIngresa la nueva contraseña: ");
        string nuevaContrasena = Console.ReadLine();

        if (UsuarioActual != null)
        {
            string nuevaContrasenaEncriptada = Utilidades.EncriptarContrasenaSHA256(nuevaContrasena);
            UsuarioActual.Contrasena = Encoding.UTF8.GetBytes(nuevaContrasenaEncriptada);
        }

        try
        {
            SQLite.ActualizarUsuario(UsuarioActual);
            SQLite.ActualizarProfesor(ProfesorActual);
            usuarioActualizado = true;
            profesorActualizado = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al actualizar la contraseña del profesor, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        if (!usuarioActualizado)
        {
            Console.WriteLine("Error al actualizar la contraseña del usuario. Verifica los datos y vuelve a intentarlo.");
            return;
        }

        if (!profesorActualizado)
        {
            Console.WriteLine("Error al actualizar la contraseña del usuario. Verifica los datos y vuelve a intentarlo.");
            return;
        }

        Console.WriteLine("Contraseña actualizada con éxito.");
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    public void Consultar()
    {
        UsuarioActual = null;
        ProfesorActual = null;

        try
        {
            UsuarioActual = SQLite.ObtenerUsuarioPorId(IdUsuarioActual);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al consultar el usuario, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        try
        {
            ProfesorActual = SQLite.ObtenerProfesorPorIdUsuario(UsuarioActual.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al consultar el profesor, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public void Agregar()
    {
        bool usuarioAgregado = false;
        bool profesorAgregado = false;
    
        Console.Clear();
        Console.WriteLine("Agregando un nuevo Profesor");
    
        Console.Write("Ingresa el nombre del usuario: ");
        string nombre = Console.ReadLine();
    
        Console.Write("Ingresa la nomina: ");
        string nomina = Console.ReadLine();
    
        Console.Write("Ingresa la contraseña del usuario: ");
        string contrasena = Console.ReadLine();
        string contrasenaEncriptada = Utilidades.EncriptarContrasenaSHA256(contrasena);
    
        try
        {
            UsuarioActual = new Usuario
            {
                IdTpoUsuario = (int)Enumeradores.tps_usuarios.Profesor, // Profesor
                IdEstUsuario = (int)Enumeradores.est_usuarios.Activo, // Activo
                Nombre = nombre,
                Contrasena = Encoding.UTF8.GetBytes(contrasenaEncriptada),
                FchCreacion = Utilidades.ObtenerFechaActualEnBytes()
            };
    
            if (!string.IsNullOrWhiteSpace(nomina))
            {
                ProfesorActual = new Profesor
                {
                    Nomina = long.Parse(nomina),
                    IdUsuario = UsuarioActual.Id,
                    FchCreacion = Utilidades.ObtenerFechaActualEnBytes()
                };
            }
    
            usuarioAgregado = SQLite.InsertarUsuario(UsuarioActual);
    
            if (usuarioAgregado && ProfesorActual != null)
            {
                profesorAgregado = SQLite.InsertarProfesor(ProfesorActual);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al agregar el nuevo profesor, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    
        if (!usuarioAgregado)
        {
            Console.WriteLine("Error al agregar el profesor. Verifica los datos y vuelve a intentarlo.");
            return;
        }
    
        if (!profesorAgregado)
        {
            Console.WriteLine("Error al agregar el profesor. Verifica los datos y vuelve a intentarlo.");
            return;
        }
    
        Console.WriteLine("Profesor agregado exitosamente.");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    public void Actualizar()
    {
        Mostrar();
    
        Console.Write("Ingresa el nuevo nombre del usuario: ");
        string nuevoNombre = Console.ReadLine();
    
        Console.Write("Ingresa la nueva nomina: ");
        string nuevaNomina = Console.ReadLine();
    
        try
        {
            if (ProfesorActual.IdUsuarioNavigation != null)
            {
                ProfesorActual.IdUsuarioNavigation.FchModificacion = Utilidades.ObtenerFechaActualEnBytes();
                ProfesorActual.IdUsuarioNavigation.Nombre = nuevoNombre;
            }
    
            if (ProfesorActual != null && !string.IsNullOrWhiteSpace(nuevaNomina))
            {
                ProfesorActual.Nomina = long.Parse(nuevaNomina);
                ProfesorActual.FchModificacion = Utilidades.ObtenerFechaActualEnBytes();
            }
    
            SQLite.SaveChanges();
    
            Console.WriteLine("Cambios guardados exitosamente.");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al actualizar el profesor, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
    
    public void Mostrar()
    {
        Console.Clear();
        Console.WriteLine("Datos del Profesor");
        Console.WriteLine($"Nombre completo: {UsuarioActual.Nombre}");
        Console.WriteLine($"Nomina: {ProfesorActual.Nomina}");
        Console.WriteLine($"Fecha de creación: {Utilidades.ObtenerFechaDesdeBytes(UsuarioActual.FchCreacion)}");
    
        if (ProfesorActual.FchModificacion != null)
        {
            Console.WriteLine($"Última fecha de modificación: {Utilidades.ObtenerFechaDesdeBytes(ProfesorActual.FchModificacion)}");
        }
    }
}
