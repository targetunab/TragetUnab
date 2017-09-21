using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Funciones
/// </summary>
public class Funciones
{

    public static string PrimeraLetraMayusculaDeCadaPalabra(string texto)
    {
        texto = texto.ToLower();

        char[] array = texto.ToCharArray();
        //Primera letra de la cadena
        if (array.Length >= 1)
        {
            if (char.IsLower(array[0]))
            {
                array[0] = char.ToUpper(array[0]);
            }
        }

        //Buscar la primera letra de cada palabra
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ')
            {
                if (char.IsLower(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
        }
        return new string(array);
    }

}