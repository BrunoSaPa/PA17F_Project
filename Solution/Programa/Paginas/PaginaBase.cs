namespace Programa.Paginas;

using Backend;
using Microsoft.Extensions.Configuration;

public class PaginaBase
{
    public string NombrePagina { get; }
    public IConfiguration configuracion;
    protected SQLite SQLite { get; }
    protected bool Debug;
    protected int IdTpoUsuarioActual { get; set; }
    public bool TieneAccesoAInterfazActual
    {
        get
        {
            return ValidarAccesoAInterfazActual();
        }
    }

    protected PaginaBase(string nombrePagina, IConfiguration _configuracion)
    {
    	Debug = true;
    	// Si el programa esta en modo debug los permisos default son los maximos, de lo contrario son los minimos
    	IdTpoUsuarioActual = Debug ? (int)Enumeradores.tps_usuarios.Coordinador : (int)Enumeradores.tps_usuarios.Estudiante;
        NombrePagina = nombrePagina;
        configuracion = _configuracion;
        SQLite = new SQLite(_configuracion.GetConnectionString("ConexionSQLite"));
    }

    private bool ValidarAccesoAInterfazActual()
    {
    	bool resultado = false;
    	
    	try
        {
            resultado = SQLite.TieneAccesoAInterfaz(this.IdTpoUsuarioActual, this.NombrePagina);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar los permisos para la interfaz actual. Vuelve a intentarlo mas tarde");
            if (e.InnerException != null)
            {
                Console.WriteLine("Excepción interna: " + e.InnerException.Message);
            }
            resultado = false;
        }

        return resultado;
    }
}
