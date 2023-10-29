namespace Programa.Paginas;

using Backend;
using Entidades;

using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System;

public class Inicio : PaginaBase
{
	// Variable encargada de manejar el ciclo del sistema
	public bool Ciclo { get; set; }

	public Inicio(IConfiguration configuracion) : base("Inicio", configuracion)
    {
    	Ciclo = true;
    }

	/*
	? Metodo encargado de mostrar la pagina
	*/
    public void MostrarInicio()
    {
    	MostrarOpciones();
    }

    public void MostrarOpciones()
    {
        int opcionSeleccionada = 0;
        bool opcionValida = false;
    
        Console.Clear();
        Console.WriteLine("Bienvenido al sistema de administración del CETI");
        
        do
        {
            Console.WriteLine("Por favor selecciona una opción");
            Console.WriteLine("1 - Iniciar Sesión");
            Console.WriteLine("2 - Crear Cuenta");
            Console.WriteLine("3 - Recuperar Contraseña");
            Console.WriteLine("4 - Salir");
            Console.Write("Opción: ");
    
            string entradaUsuario = Console.ReadLine();
    
            if (int.TryParse(entradaUsuario, out opcionSeleccionada))
            {
                if (opcionSeleccionada >= 1 && opcionSeleccionada <= 4)
                {
                    opcionValida = true;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Ingresa un número entre 1 y 3.");
                    //Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingresa un número válido.");
                //Console.Clear();
            }
        } while (!opcionValida);

        // Utilizamos un switch para determinar la acción basada en la opción seleccionada.
        switch (opcionSeleccionada)
        {
            case 1:
                MostrarPantallaLogin();
                break;
            case 2:
                MostrarPantallaCrearCuenta();
                break;
            case 3:
                MostrarPantallaRecuperarContrasena();
                break;
            case 4:
            	Ciclo = false;
            	break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    public int PedirTipoUsuario(bool usuarioExistente = false)
    {
    	int resultado = 0;
		int opcionSeleccionada = 0;
		bool opcionValida = true;
		string pregunta = string.Empty;

		Console.Clear();

		if(usuarioExistente)
		{
			pregunta = "Que tipo de usuario eres?";
		}
		else
		{
			pregunta = "Que tipo de usuario quieres crear?";
		}

		do
		{
		    Console.WriteLine(pregunta);
		    Console.WriteLine("1 - Almacenista");
		    Console.WriteLine("2 - Estudiante");
		    Console.WriteLine("3 - Profesor");
		    Console.WriteLine("4 - Coordinador");
		    Console.Write("Opción: ");

		    string entradaUsuario = Console.ReadLine();

		    if (int.TryParse(entradaUsuario, out opcionSeleccionada))
		    {
		        if (opcionSeleccionada >= 1 && opcionSeleccionada <= 4)
		        {
		            opcionValida = true;
		        }
		        else
		        {
		            Console.WriteLine("Opción no válida. Ingresa un número entre 1 y 3.");
		            //Console.Clear();
		        }
		    }
		    else
		    {
		        Console.WriteLine("Opción no válida. Por favor, ingresa un número válido.");
		        //Console.Clear();
		    }
		} while (!opcionValida);

		resultado = opcionSeleccionada;
    	
    	return resultado;
    }

    public string PedirRegistro()
    {
    	string registro = string.Empty;
        Regex regex = new Regex("^[0-9]{8}");
    
        Console.Clear();
        Console.WriteLine("Bienvenido al sistema de administración del CETI");
        Console.WriteLine("Por favor ingresa tus datos a continuación");
        Console.Write("\nRegistro/Nómina: ");
        registro = Console.ReadLine();
    
        while (!regex.IsMatch(registro))
        {
            Console.Clear();
            Console.WriteLine("Registro/Nómina no válidos, inténtalo de nuevo");
            Console.Write("\nRegistro/Nómina: ");
            registro = Console.ReadLine();
        };

		return registro;
        
    }

    public int BuscarUsuario(string registro)
  	{
  	    int resultado = 0;
  	    Usuario usuarioActual = null;
  	
  	    try
  	    {
  	        usuarioActual = SQLite.ObtenerUsuarioPorRegistro(registro);
  	    }
  	    catch (Exception e)
  	    {
  	        Console.WriteLine("Ocurrió un error al consultar el usuario, por favor inténtalo más tarde");
  	        Console.WriteLine($"Mensaje de error: {e.Message}");
  	        Console.WriteLine("\nPresiona cualquier tecla para continuar");
  	        Console.ReadKey();
  	    }

  	    if(!((int)usuarioActual.IdTpoUsuario == (int)Enumeradores.tps_usuarios.Coordinador))
  	    {
  	    	resultado = (int)usuarioActual.Id;
  	    }
  	
  	    return resultado;
  	}

    public void MostrarPantallaLogin()
    {
    	Login login = new Login(base.configuracion);
       	login.MostrarLogin();
    }

    public void MostrarPantallaRecuperarContrasena()
	{
		bool usuarioExistente = true;
		int tpoUsuario = PedirTipoUsuario(usuarioExistente);
		string registro = PedirRegistro();
		int IdUsuarioActual = BuscarUsuario(registro);

		if(IdUsuarioActual == 0)
		{
			return;
		}

		switch (tpoUsuario)
		{
			case 1:
				MantenimientoAlmacenistas mntAlmacenista = new MantenimientoAlmacenistas(base.configuracion);
				mntAlmacenista.IdUsuarioActual = IdUsuarioActual;
				mntAlmacenista._RecuperarContrasena = true;
				mntAlmacenista.MostrarMantenimientoAlmacenistas();
				break;
			case 2:
				MantenimientoEstudiantes mntEstudiante = new MantenimientoEstudiantes(base.configuracion);
				mntEstudiante.IdUsuarioActual = IdUsuarioActual;
				mntEstudiante._RecuperarContrasena = true;
				mntEstudiante.MostrarMantenimientoEstudiantes();
				break;
			case 3:
				MantenimientoProfesores mntProfesor = new MantenimientoProfesores(base.configuracion);
				mntProfesor.IdUsuarioActual = IdUsuarioActual;
				mntProfesor._RecuperarContrasena = true;
				mntProfesor.MostrarMantenimientoProfesores();
				break;
			/*case 4:
				MantenimientoCoordinadores mntCoordinador = new MantenimientoCoordinadores(base.configuracion);
				mntCoordinador.MostrarMantenimientoCoordinadores();
				break;*/
			default:
				break;
		}
	}

	public void MostrarPantallaCrearCuenta()
	{
		bool usuarioExistente = false;
		int tpoUsuario = PedirTipoUsuario(usuarioExistente);
		switch (tpoUsuario)
		{
			case 1:
				MantenimientoAlmacenistas mntAlmacenista = new MantenimientoAlmacenistas(base.configuracion);
				mntAlmacenista.MostrarMantenimientoAlmacenistas();
				break;
			case 2:
				MantenimientoEstudiantes mntEstudiante = new MantenimientoEstudiantes(base.configuracion);
				mntEstudiante.MostrarMantenimientoEstudiantes();
				break;
			case 3:
				MantenimientoProfesores mntProfesor = new MantenimientoProfesores(base.configuracion);
				mntProfesor.MostrarMantenimientoProfesores();
				break;
			/*case 4:
				MantenimientoCoordinadores mntCoordinador = new MantenimientoCoordinadores(base.configuracion);
				mntCoordinador.MostrarMantenimientoCoordinadores();
				break;*/
			default:
				break;
		}
	}

}
