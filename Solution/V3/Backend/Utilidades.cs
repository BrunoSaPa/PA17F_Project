namespace Backend;

using System;
using System.Text;
using System.Security.Cryptography;

public static class Utilidades
{



#region Contrasena
	// Función para comparación en tiempo constante
	public static bool ComparacionEnTiempoConstante(byte[] a, byte[] b)
	{
	    if (a.Length != b.Length)
	        return false;
	
	    int result = 0;
	    for (int i = 0; i < a.Length; i++)
	    {
	        result |= a[i] ^ b[i];
	    }
	    return result == 0;
	}

	public static string EncriptarContrasenaSHA256(string contrasena)
	{
	    using (SHA256 sha256 = SHA256.Create())
	    {
	        byte[] contrasenaBytes = Encoding.UTF8.GetBytes(contrasena);
	        byte[] hashBytes = sha256.ComputeHash(contrasenaBytes);
	
	        StringBuilder sb = new StringBuilder();
	        for (int i = 0; i < hashBytes.Length; i++)
	        {
	            sb.Append(hashBytes[i].ToString("x2")); // Convierte los bytes en formato hexadecimal
	        }
	
	        return sb.ToString();
	    }
	}
		
	public static bool VerificarContrasenaSHA256(string contrasena, string hashAlmacenado)
	{
	    string hashEntrante = EncriptarContrasenaSHA256(contrasena);
	    return string.Equals(hashAlmacenado, hashEntrante, StringComparison.OrdinalIgnoreCase);
	}
	
	public static bool VerificarContrasenaSHA256(byte[] contrasena, string hashAlmacenado)
	{
	    string contrasenaHash = Encoding.UTF8.GetString(contrasena);
	    string hashEntrante = EncriptarContrasenaSHA256(contrasenaHash);
	    return string.Equals(hashAlmacenado, hashEntrante, StringComparison.OrdinalIgnoreCase);
	}

	public static bool VerificarContrasenaSHA256(string contrasena, byte[] hashAlmacenado)
	{
	    string hashEntrante = EncriptarContrasenaSHA256(contrasena);
	    byte[] hashEntranteBytes = Encoding.UTF8.GetBytes(hashEntrante);
	    
	    return VerificarContrasenaSHA256(hashAlmacenado, hashEntranteBytes);
	}

	public static bool VerificarContrasenaSHA256(byte[] contrasena, byte[] hashAlmacenado)
	{
		return ComparacionEnTiempoConstante(contrasena, hashAlmacenado);
	}
#endregion

}
