namespace Backend;

public static class Enumeradores
{
	public enum tps_usuarios
	{
		Almacenista = 1,
		Estudiante,
		Profesor,
		Coordinador
	}

	public enum est_usuarios
	{
		Activo = 1,
		Inactivo
	}

	public enum tps_mantenimiento
	{
		Preventivo = 1,
		Correctivo,
		Predictivo
	}
	
}
