namespace Backend;

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Entidades;

public partial class SQLite : ContextoBD
{

	public string ConnectionString { get; set; }

	public string Excepcion { get; set; }

    public SQLite(DbContextOptions<ContextoBD> options) : base(options) { }

    public SQLite(string connectionString) : base(connectionString) { }

    #region Interfaces
    
    public List<Interfaz> ObtenerTodasLasInterfaces(string sortBy = "")
    {
        List<Interfaz> resultado = new List<Interfaz>();
        Excepcion = string.Empty;

        try
        {
            resultado = Interfaces.ToList();
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
            resultado = new List<Interfaz>();
        }

        return resultado;
    }

	public List<Interfaz> ObtenerInterfacesPorTpoUsuario(int TpoUsuario)
	{
	    List<Interfaz> resultado = new List<Interfaz>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Interfaces.Where(i => i.IdTpoUsrAcceso <= TpoUsuario && i.IdTpoUsrAcceso != 0).ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<Interfaz>();
	    }
	
	    return resultado;
	}

	public bool TieneAccesoAInterfaz(int TpoUsuario, string NombrePagina)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
        	resultado = Interfaces.Any(i => i.IdTpoUsrAcceso <= TpoUsuario && i.Nombre == NombrePagina);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
   	        Console.WriteLine("Error al guardar cambios en la base de datos: " + e.Message);
   	        Console.WriteLine("Stack trace: " + e.StackTrace);
   	        Console.WriteLine("Excepción datos: " + e.Data);
   	        if (e.InnerException != null)
   	        {
   	            Console.WriteLine("Excepción interna: " + e.InnerException.Message);
   	            Console.WriteLine("Excepción interna stack trace: " + e.InnerException.StackTrace);
   	        }
   	        Console.WriteLine("Presiona cualquier tecla para continuar...");
   	        Console.ReadKey();
	    }
	
	    return resultado;
	}
	

    #endregion

    #region Catalogos

	public List<T> ListaCatalogo<T>() where T : class
	{
	    try
	    {
	        return Set<T>().ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        return new List<T>();
	    }
	}
	

    #endregion

    #region General

    public Usuario ObtenerUsuarioPorRegistro(string registro)
    {
    	Usuario resultado = null;
        Excepcion = string.Empty;
        int idUsuario = 0;

        try
        {
            idUsuario = base.ObtenerIdUsuarioPorRegistro(registro);
            if(idUsuario != 0)
            {
            	resultado = ObtenerUsuarioPorId(idUsuario);
            }
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
        }

        return resultado;
    }

    #endregion

    #region Usuarios

    public bool InsertarUsuario(Usuario usuario)
    {
        bool resultado = false;
        Excepcion = string.Empty;

        try
        {
        	usuario.FchCreacion = DateTime.Now;
            Usuarios.Add(usuario);
            SaveChanges();
            resultado = true;
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
	        Console.WriteLine("Error al guardar cambios en la base de datos: " + e.Message);
	        Console.WriteLine("Stack trace: " + e.StackTrace);
	        Console.WriteLine("Excepción datos: " + e.Data);
	        if (e.InnerException != null)
	        {
	            Console.WriteLine("Excepción interna: " + e.InnerException.Message);
	            Console.WriteLine("Excepción interna stack trace: " + e.InnerException.StackTrace);
	        }
        }

        return resultado;
    }

    public bool ActualizarUsuario(Usuario usuario)
    {
        bool resultado = false;
        Excepcion = string.Empty;

        try
        {
        	usuario.FchModificacion = DateTime.Now;
            Usuarios.Update(usuario);
            SaveChanges();
            resultado = true;
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
        }

        return resultado;
    }

    public bool EliminarUsuario(Usuario usuario)
    {
        bool resultado = false;
        Excepcion = string.Empty;

        try
        {
            Usuarios.Remove(usuario);
            SaveChanges();
            resultado = true;
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
        }

        return resultado;
    }

    public Usuario ObtenerUsuarioPorId(long id)
    {
        Usuario resultado = null;
        Excepcion = string.Empty;

        try
        {
            resultado = Usuarios.FirstOrDefault(u => u.Id == id);
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
        }

        return resultado;
    }

    public Usuario ObtenerUsuarioPorContrasena(byte[]? contrasena)
    {
        Usuario resultado = null;
        Excepcion = string.Empty;

        try
        {
            resultado = Usuarios.FirstOrDefault(u => u.Contrasena.SequenceEqual(contrasena));
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
        }

        return resultado;
    }

	// TODO: Implementar logica de ordenamiento
    public List<Usuario> ObtenerTodosLosUsuarios(string sortBy = "")
    {
        List<Usuario> resultado = new List<Usuario>();
        Excepcion = string.Empty;

        try
        {
            resultado = Usuarios.ToList();
        }
        catch (Exception e)
        {
            Excepcion = e.ToString();
            resultado = new List<Usuario>();
        }

        return resultado;
    }

#endregion

#region Estudiantes

	public bool InsertarEstudiante(Estudiante estudiante)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	estudiante.FchCreacion = DateTime.Now;
	        Estudiantes.Add(estudiante);
	        SaveChanges();
	        resultado = true;
	    }
        catch (Exception e)
        {
            Excepcion = e.ToString();
            Console.WriteLine("Error al guardar cambios en la base de datos: " + e.Message);
            if (e.InnerException != null)
            {
                Console.WriteLine("Excepción interna: " + e.InnerException.Message);
            }
        }
	
	    return resultado;
	}
	
	public bool ActualizarEstudiante(Estudiante estudiante)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	estudiante.FchModificacion = DateTime.Now;
	        Estudiantes.Update(estudiante);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool EliminarEstudiante(Estudiante estudiante)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	        Estudiantes.Remove(estudiante);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public Estudiante ObtenerEstudiantePorId(long id)
	{
	    Estudiante resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Estudiantes.FirstOrDefault(e => e.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public List<Estudiante> ObtenerTodosLosEstudiantes()
	{
	    List<Estudiante> resultado = new List<Estudiante>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Estudiantes.ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<Estudiante>();
	    }
	
	    return resultado;
	}

	public Estudiante ObtenerEstudiantePorIdUsuario(long idUsuario)
	{
	    Estudiante estudiante = null;
	    try
	    {
	        estudiante = Estudiantes.FirstOrDefault(e => e.IdUsuario == idUsuario);
	    }
	    catch (Exception e)
	    {
	        // TODO: Manejar la excepcion
	    }
	    return estudiante;
	}
	
#endregion
#region Prestamos

public bool InsertarPrestamo(PrmPrestamo _PrmPrestamo)
	{
 		bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	_PrmPrestamo.FchCreacion = DateTime.Now;
			_PrmPrestamo.FchInicio = DateTime.Now;
	        PrmPrestamos.Add(_PrmPrestamo);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
            Excepcion = e.ToString();
	        Console.WriteLine("Error al guardar cambios en la base de datos: " + e.Message);
	        Console.WriteLine("Stack trace: " + e.StackTrace);
	        Console.WriteLine("Excepción datos: " + e.Data);
	        if (e.InnerException != null)
	        {
	            Console.WriteLine("Excepción interna: " + e.InnerException.Message);
	            Console.WriteLine("Excepción interna stack trace: " + e.InnerException.StackTrace);
	        }
	    }
	
	    return resultado;

	}

	public PrmPrestamo ObtenerPrestamoPorId(long id)
	{
	    PrmPrestamo resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = PrmPrestamos.FirstOrDefault(a => a.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	public PrmPrestamo ObtenerPrestamoPorEstadoDePrestamo(int id)
	{
	    PrmPrestamo resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = PrmPrestamos.FirstOrDefault(a => a.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool ActualizarPrestamo(PrmPrestamo _PrmPrestamo)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	_PrmPrestamo.FchModificacion = DateTime.Now;
	        PrmPrestamos.Update(_PrmPrestamo);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool EliminarPrestamo(PrmPrestamo _PrmPrestamo)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	        PrmPrestamos.Remove(_PrmPrestamo);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}

	public List<PrmPrestamo> ObtenerTodosLosPrestamos()
	{
	    List<PrmPrestamo> resultado = new List<PrmPrestamo>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = PrmPrestamos.ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<PrmPrestamo>();
	    }
	
	    return resultado;
	}

	public PrmPrestamo ObtenerPrestamoPorIdUsuario(long idUsuario)
	{
	    PrmPrestamo _PrmPrestamo = null;
	    try
	    {
	        _PrmPrestamo = PrmPrestamos.FirstOrDefault(a => a.IdUsuario == idUsuario);
	    }
	    catch (Exception e)
	    {
	        // TODO: Manejar la excepcion
	    }
	    return _PrmPrestamo;
	}
	
#endregion

#region Almacenistas

	public bool InsertarAlmacenista(Almacenista almacenista)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	almacenista.FchCreacion = DateTime.Now;
	        Almacenistas.Add(almacenista);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
            Excepcion = e.ToString();
	        Console.WriteLine("Error al guardar cambios en la base de datos: " + e.Message);
	        Console.WriteLine("Stack trace: " + e.StackTrace);
	        Console.WriteLine("Excepción datos: " + e.Data);
	        if (e.InnerException != null)
	        {
	            Console.WriteLine("Excepción interna: " + e.InnerException.Message);
	            Console.WriteLine("Excepción interna stack trace: " + e.InnerException.StackTrace);
	        }
	    }
	
	    return resultado;
	}
	
	public Almacenista ObtenerAlmacenistaPorId(long id)
	{
	    Almacenista resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Almacenistas.FirstOrDefault(a => a.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool ActualizarAlmacenista(Almacenista almacenista)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	almacenista.FchModificacion = DateTime.Now;
	        Almacenistas.Update(almacenista);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool EliminarAlmacenista(Almacenista almacenista)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	        Almacenistas.Remove(almacenista);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}

	public List<Almacenista> ObtenerTodosLosAlmacenistas()
	{
	    List<Almacenista> resultado = new List<Almacenista>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Almacenistas.ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<Almacenista>();
	    }
	
	    return resultado;
	}

	public Almacenista ObtenerAlmacenistaPorIdUsuario(long idUsuario)
	{
	    Almacenista almacenista = null;
	    try
	    {
	        almacenista = Almacenistas.FirstOrDefault(a => a.IdUsuario == idUsuario);
	    }
	    catch (Exception e)
	    {
	        // TODO: Manejar la excepcion
	    }
	    return almacenista;
	}
	
#endregion

#region Profesores

	public bool InsertarProfesor(Profesor profesor)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	profesor.FchCreacion = DateTime.Now;
	        Profesores.Add(profesor);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool ActualizarProfesor(Profesor profesor)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	profesor.FchModificacion = DateTime.Now;
	        Profesores.Update(profesor);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool EliminarProfesor(Profesor profesor)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	        Profesores.Remove(profesor);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public Profesor ObtenerProfesorPorId(long id)
	{
	    Profesor resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Profesores.FirstOrDefault(p => p.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public List<Profesor> ObtenerTodosLosProfesores()
	{
	    List<Profesor> resultado = new List<Profesor>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Profesores.ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<Profesor>();
	    }
	
	    return resultado;
	}

	public Profesor ObtenerProfesorPorIdUsuario(long idUsuario)
	{
	    Profesor profesor = null;
	    try
	    {
	        profesor = Profesores.FirstOrDefault(p => p.IdUsuario == idUsuario);
	    }
	    catch (Exception e)
	    {
	        // TODO: Manejar la excepcion
	    }
	    return profesor;
	}
	
#endregion

#region  Coordinadores

	public bool InsertarCoordinador(Coordinador coordinador)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	coordinador.FchCreacion = DateTime.Now;
	        Coordinadores.Add(coordinador);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool ActualizarCoordinador(Coordinador coordinador)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	    	coordinador.FchModificacion = DateTime.Now;
	        Coordinadores.Update(coordinador);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public bool EliminarCoordinador(Coordinador coordinador)
	{
	    bool resultado = false;
	    Excepcion = string.Empty;
	
	    try
	    {
	        Coordinadores.Remove(coordinador);
	        SaveChanges();
	        resultado = true;
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public Coordinador ObtenerCoordinadorPorId(long id)
	{
	    Coordinador resultado = null;
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Coordinadores.FirstOrDefault(c => c.Id == id);
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	    }
	
	    return resultado;
	}
	
	public List<Coordinador> ObtenerTodosLosCoordinadores()
	{
	    List<Coordinador> resultado = new List<Coordinador>();
	    Excepcion = string.Empty;
	
	    try
	    {
	        resultado = Coordinadores.ToList();
	    }
	    catch (Exception e)
	    {
	        Excepcion = e.ToString();
	        resultado = new List<Coordinador>();
	    }
	
	    return resultado;
	}

	public Coordinador ObtenerCoordinadorPorIdUsuario(long idUsuario)
	{
	    Coordinador coordinador = null;
	    try
	    {
	        coordinador = Coordinadores.FirstOrDefault(c => c.IdUsuario == idUsuario);
	    }
	    catch (Exception e)
	    {
	        // TODO: Manejar la excepcion
	    }
	    return coordinador;
	}
	
#endregion
    
}
