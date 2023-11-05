using Entidades;
using Programa.Paginas;
using Microsoft.Extensions.Configuration;
namespace Programa;


public class MantenimientoCoordinadores : PaginaBase
{
    public bool _RecuperarContrasena { get; set; }

    public Coordinador CoordinadorActual { get; set; }

    public Usuario UsuarioActual { get; set; }

    public int IdUsuarioActual { get; set; }

    public bool UsuarioNuevo { get; set; }

    public MantenimientoCoordinadores(IConfiguration configuracion) : base("MantenimientoCoordinadores", configuracion)
    {
        IdUsuarioActual = -1;
        UsuarioNuevo = true;
        _RecuperarContrasena = false;
        CoordinadorActual = null;
        UsuarioActual = null;
    }

//Acceso a la página de coordinador.
   public void MostrarMantenimientoCoordinadores()
   {
     Console.WriteLine("Página de coordinador"); 
		UsuarioNuevo = IdUsuarioActual == -1;
    	if(!UsuarioNuevo)
    	{
    		Consultar();
			base.IdTpoUsuarioActual = (int)UsuarioActual.IdTpoUsuario; //Cambiar esto.
    	}
		
		if(!base.TieneAccesoAInterfazActual)
		{
			return;
		}

	Console.ReadKey();
       
   }



   
	/*
	? Metodo que consulta al almacenista y su usuario relacionado
	*/
	public void Consultar()
	{
	    UsuarioActual = null;
		CoordinadorActual = null;

		// Consulta del usuario
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

		// Consulta del almacenista
		try
		{
			CoordinadorActual = SQLite.ObtenerCoordinadorPorId(UsuarioActual.Id);
		}
		catch (Exception e)
	    {
	        Console.WriteLine("Ocurrio un error al consultar el almacenista, por favor intentalo mas tarde");
	        Console.WriteLine($"Mensaje de error: {e.Message}");
	        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
	        Console.ReadKey();
	    }
		
	}


}
