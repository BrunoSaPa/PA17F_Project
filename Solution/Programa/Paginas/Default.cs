namespace Programa.Paginas;

using Backend;
using Entidades;

using Microsoft.Extensions.Configuration;
using Spectre.Console;
using System;

public class Default : PaginaBase
{
	public int IdUsuarioActual { get; set; }

	public int IdTpoUsuarioActual { get; set; }

	public Usuario UsuarioActual { get; set; }

	public Default(IConfiguration configuracion) : base("Default", configuracion)
	{
		IdUsuarioActual = -1;
		if (IdTpoUsuarioActual != null && IdTpoUsuarioActual != 0)
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
		MostrarMenu();
	}

	/*
    TODO: Realizar la validacion de las interfaces en base al tipo de usuario actual
    ? Metodo encargado de mostrar las pantallas disponibles para el usuario en base a su tipo
	*/
	public void MostrarMenu()
	{
		Console.Clear();

		
		if (!ObtenerUsuarioActual())
		{
			return;
		}
		Console.WriteLine($"Holiwis {UsuarioActual.Nombre}");
		




		//Se obtiene en una lista todos los tipos de interfaces que tiene un determinado usuario por su ID de Tipo de Usuario.
		List<Interfaz> interfaces = SQLite.ObtenerInterfacesPorTpoUsuario(IdTpoUsuarioActual);


		AnsiConsole.MarkupLine("[bold yellow]Por favor selecciona una opción[/]");
		List<string> opciones = new();
		//muestra las interfaces que tiene el usuario
		if (interfaces.Count > 0 && interfaces is not null)
		{
			foreach (var inter in interfaces)  //iterar para mostrar en un menu
			{
				if (inter.Nombre!.Equals( "MantenimientoUsuarios")) //MantenimientoUsuarios no se muestra en el menu.
				{
					continue;
				}
				opciones.Add(inter.Nombre!);

			}
		}
		else
		{
			//Si no tiene interfaces, no se le muestra nada.

			AnsiConsole.WriteLine("Lo sentimos, pero por el momento no tienes el permiso de accesar a ninguna interfaz");
		}
		opciones.Add("Cerrar sesión"); //Todos tienen la oportunidad de cerrar sesión.

		var seleccionPrompt = new SelectionPrompt<string>()

			//.Title("Opciones")
			.AddChoices(opciones);

		var opcionSeleccionada = AnsiConsole.Prompt(seleccionPrompt);


		//cada una de las opciones del menu.
		switch (opcionSeleccionada)
		{
			case "MantenimientoEstudiantes":

				MantenimientoEstudiantes mantenimientoEstudiantes = new(base.configuracion);
				mantenimientoEstudiantes.IdUsuarioActual = IdUsuarioActual;
				mantenimientoEstudiantes.MostrarMantenimientoEstudiantes();

				break;
			case "MantenimientoCoordinadores":
				MantenimientoCoordinadores mantenimientoCoordinadores = new(base.configuracion);
				mantenimientoCoordinadores.IdUsuarioActual = IdUsuarioActual; //ID usuario a modificar.	
				mantenimientoCoordinadores.MostrarMantenimientoCoordinadores();

				break;
			case "MantenimientoProfesores":
				MantenimientoProfesores mantenimientoProfesores = new(base.configuracion);
				mantenimientoProfesores.IdUsuarioActual = IdUsuarioActual;
				
				mantenimientoProfesores.MostrarMantenimientoProfesores();

				break;

			case "MantenimientoAlmacenistas":
				MantenimientoAlmacenistas mantenimientoAlmacenistas = new(base.configuracion);		
				mantenimientoAlmacenistas.IdUsuarioActual = IdUsuarioActual;
				mantenimientoAlmacenistas.MostrarMantenimientoAlmacenistas();

				break;
			case "Cerrar sesión":
				Console.WriteLine("Saliendo del sistema... haga clic en una tecla");


				break;
			default:
				AnsiConsole.MarkupLine("[red]Opción no válida.[/]");
				break;
		}


	}
	//Verifica si el usuario existe
	public bool ObtenerUsuarioActual()
	{
		bool resultado = false;

		try
		{
			UsuarioActual = SQLite.ObtenerUsuarioPorId(IdUsuarioActual);
			resultado = true;
		}
		catch (Exception e)
		{
			Console.WriteLine("Ocurrio un error al consultar el usuario actual, porfavor intentalo mas tarde");
			Console.WriteLine($"Mensaje de error: {e.Message}");
			Console.WriteLine("\nPresiona cualquier tecla para continuar");
			Console.ReadKey();
		}

		return resultado;
	}
}
