namespace Programa.Paginas;

using Backend;
using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;


public class MantenimientoEstudiantes : PaginaBase
{
    // Bandera que determina si solo se cambia la contrasena del estudiante o todos sus atributos
    // - True: Solo cambia la contrasena
    // - False: Cambiar todos los atributos
    public bool _RecuperarContrasena { get; set; }
    
    public Estudiante EstudianteActual { get; set; }
    public Usuario UsuarioActual { get; set; }
    
    public int IdUsuarioActual { get; set; }
    public bool UsuarioNuevo { get; set; }

    public MantenimientoEstudiantes(IConfiguration configuracion) : base("MantenimientoEstudiantes", configuracion)
    {
        IdUsuarioActual = -1;
        UsuarioNuevo = true;
        _RecuperarContrasena = false;
        EstudianteActual = null;
        UsuarioActual = null;
    }

    public void MostrarMantenimientoEstudiantes()
    {
        UsuarioNuevo = IdUsuarioActual == -1;
        if (UsuarioNuevo)
        {
            Agregar();
        }
        else
        {
            Consultar();
            if (EstudianteActual == null)
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

    // Metodo que te permite cambiar la contrasena del estudiante
    public void RecuperarContrasena()
    {
        Console.Clear();
        Mostrar();

        Console.WriteLine("\nIngresa la nueva contrasena: ");
        string nuevaContrasena = Console.ReadLine();

        if (UsuarioActual != null)
        {
            string nuevaContrasenaEncriptada = Utilidades.EncriptarContrasenaSHA256(nuevaContrasena);
            UsuarioActual.Contrasena = Encoding.UTF8.GetBytes(nuevaContrasenaEncriptada);
        }

        bool usuarioActualizado = SQLite.ActualizarUsuario(UsuarioActual);
        bool estudianteActualizado = SQLite.ActualizarEstudiante(EstudianteActual);

        if (!usuarioActualizado || !estudianteActualizado)
        {
            Console.WriteLine("Error al actualizar la contrasena del estudiante. Verifica los datos y vuelve a intentarlo.");
            return;
        }

        Console.WriteLine("Contrasena actualizada con exito.");
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodo que consulta al estudiante y su usuario relacionado
    public void Consultar()
    {
        UsuarioActual = null;
        EstudianteActual = null;

        try
        {
            UsuarioActual = SQLite.ObtenerUsuarioPorId(IdUsuarioActual);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar el usuario, por favor intentalo mas tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        try
        {
            EstudianteActual = SQLite.ObtenerEstudiantePorIdUsuario(UsuarioActual.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar el estudiante, por favor intentalo mas tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    // Método para agregar un nuevo estudiante
    public void Agregar()
    {
        bool usuarioAgregado = false;
        bool estudianteAgregado = false;
        
        Console.Clear();
        Console.WriteLine("Agregando un nuevo Estudiante");
        
        // Solicitar los datos
        
        Console.Write("Ingresa el nombre del usuario: ");
        string nuevoNombre = Console.ReadLine();
        
        Console.Write("Ingresa el apellido paterno del usuario: ");
        string nuevoAplPaterno = Console.ReadLine();
        
        Console.Write("Ingresa el apellido materno del usuario: ");
        string nuevoAplMaterno = Console.ReadLine();
        
        Console.Write("Ingresa el registro del estudiante: ");
        long nuevoRegistro = long.Parse(Console.ReadLine());
        
        Console.Write("Ingresa la contraseña del usuario: ");
        string nuevaContrasena = Console.ReadLine();
        
        string contrasenaEncriptada = Utilidades.EncriptarContrasenaSHA256(nuevaContrasena);
        
        try
        {
            // Crear una nueva instancia de Usuario
            UsuarioActual = new Usuario
            {
                IdTpoUsuario = (long)Enumeradores.tps_usuarios.Estudiante, // Estudiante
                IdEstUsuario = (long)Enumeradores.est_usuarios.Activo, // Activo
                //IdGrupo = 1, //Prueba
                Nombre = nuevoNombre,
                AplPaterno = nuevoAplPaterno,
                AplMaterno = nuevoAplMaterno,
                Contrasena = Encoding.UTF8.GetBytes(contrasenaEncriptada),
                FchCreacion = Utilidades.ObtenerFechaActualEnBytes()
            };

            usuarioAgregado = SQLite.InsertarUsuario(UsuarioActual);

            if (usuarioAgregado)
  	        {
        		Console.WriteLine("asjhskaj");
        		Console.ReadKey();
	            // Crear una nueva instancia de Estudiante
	            EstudianteActual = new Estudiante
	            {
	                IdUsuario = UsuarioActual.Id,
	                Registro = nuevoRegistro,
	                FchCreacion = Utilidades.ObtenerFechaActualEnBytes()
	            };

	            
	            // Guardar el nuevo usuario y estudiante en la base de datos
	            
	            estudianteAgregado = SQLite.InsertarEstudiante(EstudianteActual);
	            Console.WriteLine(estudianteAgregado);
           		Console.ReadKey();
			}
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al agregar el nuevo estudiante, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        if (!usuarioAgregado)
        {
            Console.WriteLine("Error al agregar el usuario. Verifica los datos y vuelve a intentarlo.");
            return;
        }

        if (!estudianteAgregado)
         {
             Console.WriteLine("Error al agregar el estudiante. Verifica los datos y vuelve a intentarlo.");
             return;
         }
        
        Console.WriteLine("Estudiante agregado exitosamente.");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    // Método para actualizar un estudiante
    public void Actualizar()
    {
        Mostrar(); // Muestra los datos actuales
        
        // Solicitar los nuevos valores del estudiante
        Console.Write("Ingresa el nuevo registro del estudiante: ");
        long nuevoRegistro = long.Parse(Console.ReadLine());
        
        Console.Write("Ingresa el nuevo nombre del usuario: ");
        string nuevoNombre = Console.ReadLine();
        
        Console.Write("Ingresa el nuevo apellido paterno del usuario: ");
        string nuevoAplPaterno = Console.ReadLine();
        
        Console.Write("Ingresa el nuevo apellido materno del usuario: ");
        string nuevoAplMaterno = Console.ReadLine();
        
        try
        {
            // Actualizar el estudiante
            EstudianteActual.Registro = nuevoRegistro;
            UsuarioActual.Nombre = nuevoNombre;
            UsuarioActual.AplPaterno = nuevoAplPaterno;
            UsuarioActual.AplMaterno = nuevoAplMaterno;
            UsuarioActual.FchModificacion = Utilidades.ObtenerFechaActualEnBytes();
            EstudianteActual.FchModificacion = Utilidades.ObtenerFechaActualEnBytes();
        
            // Guardar los cambios en la base de datos
            SQLite.SaveChanges();
        
            Console.WriteLine("Cambios guardados exitosamente.");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error al actualizar el estudiante, por favor inténtalo más tarde");
            Console.WriteLine($"Mensaje de error: {e.Message}");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
    
    // Método para mostrar la información del estudiante y su usuario relacionado
    public void Mostrar()
    {
        Console.Clear();
        Console.WriteLine("Datos del Estudiante");
        Console.WriteLine($"Nombre completo: {UsuarioActual.Nombre} {UsuarioActual.AplPaterno} {UsuarioActual.AplMaterno}");
        Console.WriteLine($"Registro: {EstudianteActual.Registro}");
        Console.WriteLine($"Fecha de creación: {Utilidades.ObtenerFechaDesdeBytes(EstudianteActual.FchCreacion)}");
    
        if (EstudianteActual.FchModificacion != null)
   	    {
   	        Console.WriteLine($"Ultima fecha de modificación: {Utilidades.ObtenerFechaDesdeBytes(EstudianteActual.FchModificacion)}");
   	    }
   	    else
   	    {
   	        Console.WriteLine("Ultima fecha de modificación: No disponible");
   	    }
    }
    
}
