namespace Programa.Paginas;

using Backend;
using Entidades;

using Microsoft.Extensions.Configuration;
using System;
using System.Text;

public class MantenimientoPrestamos : PaginaBase
{
	// ? Bandera que determina si solo se cambia la contrasena del almacenista o todos sus atributos
	// ? True: Solo cambia la contrasena
	// ? False : Cambiar todos los atributos
	public bool _ActualizarPermiso { get; set; }

	public PrmPrestamo PrestamoActual { get; set; }

	public Usuario UsuarioActual { get; set; }

	public int IdUsuarioActual { get; set; }

	public bool UsuarioNuevo { get; set; }

	public MantenimientoPrestamos(IConfiguration configuracion) : base("MantenimientoPrestamos", configuracion)
    {
    	IdUsuarioActual = -1;
    	UsuarioNuevo = true;
    	PrestamoActual = null;
    	UsuarioActual = null;
    }

	public void MostrarMantenimientoPrestamo()
	{
    	if(!base.TieneAccesoAInterfazActual)
    	{
    		return;
    	}
		UsuarioNuevo = IdUsuarioActual == -1;
		if(UsuarioNuevo)
		{
			Agregar();
		}
		else
		{
			// Consultar al almacenista
			Consultar();

			if(PrestamoActual == null)
			{
				return;
			}
			
			if(_ActualizarPermiso)
			{
            Actualizar();
		    }
        }
	}

	/*
	? Metodo que te permite cambiar la contrasena del almacenista
	*/
	

	/*
	? Metodo que consulta al almacenista y su usuario relacionado
	*/
	public void Consultar()
	{
	    UsuarioActual = null;
		PrestamoActual = null;

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
			PrestamoActual = SQLite.ObtenerPrestamoPorIdUsuario(UsuarioActual.Id);
		}
		catch (Exception e)
	    {
	        Console.WriteLine("Ocurrio un error al consultar el almacenista, por favor intentalo mas tarde");
	        Console.WriteLine($"Mensaje de error: {e.Message}");
	        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
	        Console.ReadKey();
	    }
		
	}

	/*
	? Metodo permite actualizar al almacenista
	*/



    /*INSERT INTO prm_prestamos (
    id_tpo_prm_prestamo,
    id_usuario,
    fch_fin,
    id_est_prm_prestamos
)*/
	public void Actualizar()
	{
	    //Mostrar(); // Muestra los datos actuales
	
	    // Solicitar los nuevos valores de usuario
	    Console.Write("Ingresa el nuevo tipo de Prestamo:\n1-Generado por un estudiante\n2-Generado por un profesor ");
	    string nuevoNombre = Console.ReadLine();
	
		while(!Utilidades.VerificarTipoDePrestamo(nuevoNombre)){
            Console.Clear();
            Console.WriteLine("Opcion no válida, inténtalo de nuevo");
            Console.Write("\nIngresa el nuevo tipo de Prestamo:\n1-Generado por un estudiante\n2-Generado por un profesor ");
            nuevoNombre = Console.ReadLine();
		};
        
	    Console.Write("Ingresa la nueva nomina del usuario: ");
	    string nuevoIdUser = Console.ReadLine();

		while(!Utilidades.VerificarRegistroNomina(nuevoIdUser)){
            Console.Clear();
            Console.WriteLine("nomina no existente, inténtalo de nuevo");
            Console.Write("\nIngresa la nueva nomina del usuario: ");
            nuevoIdUser = Console.ReadLine();
		};
    
        Usuario registronuevo = SQLite.ObtenerUsuarioPorRegistro(nuevoIdUser);
    
	    Console.Write("Ingresa la nueva fecha de finalizacion: ");
	    string nuevofchfin = Console.ReadLine();

		while(!Utilidades.Verificarfecha(nuevofchfin)){
            Console.Clear();
            Console.WriteLine("Informacion Invalida, inténtalo de nuevo");
            Console.Write("\nIngresa la nueva fecha de finalizacion: ");
            nuevofchfin = Console.ReadLine();
		};
         Console.Write("Ingresa el nuevo estado de Prestamo:\n1-Aprobado\n2-Por Aprobar\n3-Rechazado ");
	    string nuevoEstado = Console.ReadLine();
	
		while(!Utilidades.VerificarEstadoDePrestamo(nuevoNombre)){
            Console.Clear();
            Console.WriteLine("Opcion no válida, inténtalo de nuevo");
            Console.Write("\nIngresa el nuevo estado de Prestamo:\n1-Aprobado\n2-Por Aprobar\n3-Rechazado ");
            nuevoEstado = Console.ReadLine();
		}; 
        string formato = "yyyy-MM-dd HH:mm:ss";
        DateTime fechaHora = DateTime.MinValue;
        try
        {
          fechaHora = DateTime.ParseExact(nuevofchfin, formato, System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
        // La cadena no tiene el formato esperado
        Console.WriteLine("La cadena no es una fecha y hora válida.");
        }       

	    try
	    {
	    	// Solicitar los nuevos valores de almacenista
   		    if (PrestamoActual.IdUsuarioNavigation != null)
   		    {
   		        // Actualizar el usuario
                PrestamoActual.IdUsuario = registronuevo.Id;
   		        PrestamoActual.FchModificacion = DateTime.Now;
                if (long.TryParse(nuevoNombre, out long nuevoNombrelong))
	            PrestamoActual.IdTpoPrmPrestamo = nuevoNombrelong;
           	    PrestamoActual.FchFin = fechaHora;
                 if (long.TryParse(nuevoEstado, out long nuevoEstadolong))
           	    PrestamoActual.IdEstPrmPrestamosNavigation.Id = nuevoEstadolong;
   		    }
   		
   		    // Guardar los cambios en la base de datos
   		    SQLite.SaveChanges();
   		
   		    Console.WriteLine("Cambios guardados exitosamente.");
   		    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
   		    Console.ReadKey();
	    }
	    catch (Exception e)
   	    {
   	        Console.WriteLine("Ocurrio un error al actualizar el almacenista, por favor intentalo mas tarde");
   	        Console.WriteLine($"Mensaje de error: {e.Message}");
   	        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
   	        Console.ReadKey();
   	    }
	}
	

	/*
	? Metodo para pedir la info del almacenista, incluyendo la de su usuario relacionado
	*/

    
	public void Agregar()
	{
	    bool prestamoAgregado = false;
	    bool usuarioAgregado = false;
	    Console.Clear();
	    Console.WriteLine("Agregando un nuevo Permiso");
	
	      Console.Write("Ingresa el tipo de Prestamo:\n1-Generado por un estudiante\n2-Generado por un profesor ");
	    string nuevoNombre = Console.ReadLine();
	
		while(!Utilidades.VerificarTipoDePrestamo(nuevoNombre)){
            Console.Clear();
            Console.WriteLine("Opcion no válida, inténtalo de nuevo");
            Console.Write("\nIngresa el tipo de Prestamo:\n1-Generado por un estudiante\n2-Generado por un profesor ");
            nuevoNombre = Console.ReadLine();
		};
        
	    Console.Write("Ingresa la nomina del usuario: ");
	    string nuevoIdUser = Console.ReadLine();

		while(!Utilidades.VerificarRegistroNomina(nuevoIdUser)){
            Console.Clear();
            Console.WriteLine("nomina no existente, inténtalo de nuevo");
            Console.Write("\nIngresa la  nomina del usuario: ");
            nuevoIdUser = Console.ReadLine();
		};
    
        Usuario registronuevo = SQLite.ObtenerUsuarioPorRegistro(nuevoIdUser);
    
	    Console.Write("Ingresa la  fecha de finalizacion: ");
	    string nuevofchfin = Console.ReadLine();

		while(!Utilidades.Verificarfecha(nuevofchfin)){
            Console.Clear();
            Console.WriteLine("Informacion Invalida, inténtalo de nuevo");
            Console.Write("\nIngresa la  fecha de finalizacion: ");
            nuevofchfin = Console.ReadLine();
		};
         Console.Write("Ingresa el estado de Prestamo:\n1-Aprobado\n2-Por Aprobar\n3-Rechazado ");
	    string nuevoEstado = Console.ReadLine();
	
		while(!Utilidades.VerificarEstadoDePrestamo(nuevoNombre)){
            Console.Clear();
            Console.WriteLine("Opcion no válida, inténtalo de nuevo");
            Console.Write("\nIngresa el estado de Prestamo:\n1-Aprobado\n2-Por Aprobar\n3-Rechazado ");
            nuevoEstado = Console.ReadLine();
		}; 
        string formato = "yyyy-MM-dd HH:mm:ss";
        DateTime fechaHora = DateTime.MinValue;
        try
        {
          fechaHora = DateTime.ParseExact(nuevofchfin, formato, System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
        // La cadena no tiene el formato esperado
        Console.WriteLine("La cadena no es una fecha y hora válida.");
        }       
        
      
	    try
	    { 
	    
	       
	
	        
	            // Crear una nueva instancia de Almacenista y asignar el ID del usuario
	            PrestamoActual = new PrmPrestamo
	            {
	                 
	                
	                FchCreacion = DateTime.Now,
                    FchInicio = DateTime.Now,
                     
	                IdTpoPrmPrestamo = long.Parse(nuevoNombre),
                    IdEstPrmPrestamo = 2,

                    IdUsuario = registronuevo.Id,
           	        FchFin = fechaHora,
                    
                    
	            };
	
	            // Insertar el almacenista en la base de datos
	            prestamoAgregado = SQLite.InsertarPrestamo(PrestamoActual);
	        
	    }
	    catch (Exception e)
	    {
	        Console.WriteLine("Ocurrió un error al agregar el nuevo almacenista, por favor inténtalo más tarde");
	        Console.WriteLine($"Mensaje de error: {e.Message}");
	        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
	        Console.ReadKey();
	    }
	
	    if (!prestamoAgregado)
	    {
	        Console.WriteLine("Error al agregar el almacenista. Verifica los datos y vuelve a intentarlo.");
	        Console.WriteLine("Presiona cualquier tecla para continuar...");
	        Console.ReadKey();
	        return;
	    }
	
	    Console.WriteLine("Almacenista agregado exitosamente.");
	    Console.WriteLine("Presiona cualquier tecla para continuar...");
	    Console.ReadKey();
	}
	
	

	 

    public void Mostrar()
    {
    if (PrestamoActual != null)
    {
        Console.Clear();
        Console.WriteLine("Información del Prestamo:");
        Console.WriteLine($"ID: {PrestamoActual.Id}");
        Console.WriteLine($"Tipo de Prestamo: {PrestamoActual.IdTpoPrmPrestamo}");
        Console.WriteLine($"ID de Usuario: {PrestamoActual.IdUsuario}");
        Console.WriteLine($"Fecha de Inicio: {PrestamoActual.FchInicio}");
        Console.WriteLine($"Fecha de Fin: {PrestamoActual.FchFin}");
        Console.WriteLine($"Fecha de Creación: {PrestamoActual.FchCreacion}");
        Console.WriteLine($"Fecha de Modificación: {PrestamoActual.FchModificacion}");
        Console.WriteLine($"Fecha de Eliminación: {PrestamoActual.FchEliminacion}");
        Console.WriteLine($"Estado de Prestamo: {PrestamoActual.IdEstPrmPrestamosNavigation.Id}");
    }
    else
    {
        Console.WriteLine("No se encontró información del Prestamo.");
    }
}

    
    
}
