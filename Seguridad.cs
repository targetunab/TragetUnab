using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Seguridad
/// </summary>
public static class Seguridad
{

    /// Encripta una cadena
    public static string Encriptar(this string cadenaAencriptar)
    {
        string result = string.Empty;
        byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
        result = Convert.ToBase64String(encryted);
        return result;
    }

    /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
    public static string DesEncriptar(this string cadenaAdesencriptar)
    {
        try
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        catch
        {
            string result = "";
            return result;
        }
    }
}