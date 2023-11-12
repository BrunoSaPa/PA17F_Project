using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Spectre.Console;
using Backend;
using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

using Programa.Paginas;


public class PrestamosEstudiantes : PaginaBase
{
    public Estudiante EstudianteActual { get; set; }
    public Usuario UsuarioActual { get; set; }

    public int IdUsuarioActual { get; set; }
    public bool UsuarioNuevo { get; set; }

    public PrestamosEstudiantes(IConfiguration configuracion) : base("MantenimientoEstudiantes", configuracion)
    {
        IdUsuarioActual = -1;
        UsuarioNuevo = true;
        EstudianteActual = null;
        UsuarioActual = null;
    }  //Constructor

    public void MostrarPrestamosEstudiantes()
    {
       

        UsuarioNuevo = IdUsuarioActual ==  -1;
        if (!UsuarioNuevo)
        {
            Consultar();
            base.IdTpoUsuarioActual = (int)UsuarioActual.IdTpoUsuario; //Cambiar esto.
        }

        //Comprobar que efectivamente sea un estudiante.

        if (UsuarioActual.IdTpoUsuario != 1)
        {
            AnsiConsole.MarkupLine("[bold red]No tienes permisos para acceder a esta interfaz.[/]");
        }
        else
        {
            AgregarPrestamos();
        }
    }

    public void AgregarPrestamos()
    {

        List<Equipo> equiposPrestados = new();
        Equipo equipo = new();
        Salon salon = new();
        int cantidad = 0;
        long idEquipo = 0;
        int repetir = 0;
        string opcionSeleccionada = string.Empty;
        long idSalon = 0;
        ListarEquipos();
        do
        {
            AnsiConsole.MarkupLine("\n\n[bold green]Por favor ingrese el ID y la cantidad de equipos[/]");
            do
            {
                Console.WriteLine("ID: ");
                idEquipo = Convert.ToInt32(Console.ReadLine());
                //Realizar una verificación de que el ID ingresado sea válido
                equipo = SQLite.ObtenerEquipoPorId(idEquipo);

            } while (equipo is null);

            //La cantidad de equipos que se van a prestar. Esta cantidad no puede ser mayor a la cantidad disponible.
            do
            {
                Console.WriteLine("Cantidad:");
                cantidad = Convert.ToInt32(Console.ReadLine());

            } while (cantidad > equipo.CntDisponible);

            AnsiConsole.MarkupLine("\n\n[bold blue]¿Desea ingresar más? [/]");
            List<string> opciones = new();
            opciones.Add("Si");
            opciones.Add("No");

            equiposPrestados.Add(equipo);

            var seleccionPrompt = new SelectionPrompt<string>()
                                        .AddChoices(opciones);

            opcionSeleccionada = AnsiConsole.Prompt(seleccionPrompt);

        } while(opcionSeleccionada == "Si");

        //Agregar el salon donde se dará el  prestamo
        AnsiConsole.MarkupLine("\n\n[bold green]Ahora seleccione el salón del prestamo[/]");

        AnsiConsole.WriteLine($"{"ID",-10}|{"Nombre",20}|");

        foreach(var salones in SQLite.ObtenerTodosLosSalones())
        {
            //Mostrando salones disponibles
            AnsiConsole.WriteLine($"{salones.Id,-10}|{salones.NmrSalon,20}|");
        }

        do
        {
            Console.WriteLine("ID: ");
            idSalon = Convert.ToInt32(Console.ReadLine());

            salon = SQLite.ObtenerSalonPorId(idSalon);

        } while (salon is null);

        Console.ReadKey();
    }

    public void ListarEquipos()
    {
        List<Equipo> inventario = SQLite.ObtenerTodosLosEquipos();
        //Se obtiene la lista de todos los equipos existentes 

        if (inventario is not null)
        {
            //Se muestra la lista de equipos disponibles

            AnsiConsole.WriteLine($"{"ID",-10}|{"Nombre",20}|{"Descripcion",20}|{"Cantidad Disponible",20}|");
            foreach (var equipos in inventario)
            {
                AnsiConsole.WriteLine($"{equipos.Id,-10}|{equipos.Nombre,20}|{equipos.Descripcion,20}|{equipos.CntDisponible,20}|");
            }
        }
    }

    public void Consultar()
	{

        /*
        
		UsuarioActual = null;
		EstudianteActual = null;

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
			EstudianteActual = SQLite.ObtenerAlmacenistaPorIdUsuario(UsuarioActual.Id);
		}
		catch (Exception e)
		{
			Console.WriteLine("Ocurrio un error al consultar el almacenista, por favor intentalo mas tarde");
			Console.WriteLine($"Mensaje de error: {e.Message}");
			Console.WriteLine("\nPresiona cualquier tecla para continuar...");
			Console.ReadKey();
		}

        */

    

	}
}