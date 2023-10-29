namespace Programa.Paginas;

using Backend;
using Microsoft.Extensions.Configuration;

public class PaginaBase
{
    public string NombrePagina { get; }
    public IConfiguration configuracion;
    protected SQLite SQLite { get; }

    public PaginaBase(string nombrePagina, IConfiguration _configuracion)
    {
        NombrePagina = nombrePagina;
        configuracion = _configuracion;
        SQLite = new SQLite(_configuracion.GetConnectionString("ConexionSQLite"));
    }
}
