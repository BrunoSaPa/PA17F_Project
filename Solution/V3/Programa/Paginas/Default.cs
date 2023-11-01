namespace Programa.Paginas;

using Backend;
using Entidades;

using Microsoft.Extensions.Configuration;
using System;

public class Default : PaginaBase
{
	public int IdUsuarioActual { get; set; }

	public int IdTpoUsuarioActual { get; set; }

	public Usuario UsuarioActual { get; set; }
	
    public Default(IConfiguration configuracion) : base("Default", configuracion)
    {
        IdUsuarioActual = -1;
        if(IdTpoUsuarioActual != null && IdTpoUsuarioActual != 0)
        {
        	base.IdTpoUsuarioActual = this.IdTpoUsuarioActual;
        }
    }

	/*
	TODO: Completar funcion
	? Metodo encargado de mostrar la pagina
	*/
    public void MostrarDefault()
    {
    	/*
    	base.IdTpoUsuarioActual = this.IdTpoUsuarioActual;
    	if(!base.TieneAccesoAInterfazActual)
    	{
    		return;
    	}
    	*/
    	MostrarMenu();
    }

    /*
    TODO: Realizar la validacion de las interfaces en base al tipo de usuario actual
    ? Metodo encargado de mostrar las pantallas disponibles para el usuario en base a su tipo
	*/
    public void MostrarMenu()
    {
    	Console.Clear();
    	if(!ObtenerUsuarioActual())
    	{
    		return;
    	}
    	Console.WriteLine($"Holiwis {UsuarioActual.Nombre}");
    	Console.ReadKey();
    	
    }

    public bool ObtenerUsuarioActual()
    {
    	bool resultado = false;

		try
		{
			UsuarioActual = SQLite.ObtenerUsuarioPorId(IdUsuarioActual);
			resultado = true;
		}
		catch(Exception e)
		{
			Console.WriteLine("Ocurrio un error al consultar el usuario actual, porfavor intentalo mas tarde");
			Console.WriteLine($"Mensaje de error: {e.Message}");
			Console.WriteLine("\nPresiona cualquier tecla para continuar");
			Console.ReadKey();
		}

    	return resultado;
    }
}
