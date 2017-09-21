using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Globalization;
using System.Net;

/// <summary>
/// Descripción breve de FuncionesTexto
/// </summary>
namespace FuncionesTexto
{
    public class FuncionesTexto
    {
        public static string obtenerNombreMesNumero(int numeroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                int largo = nombreMes.Length;

                nombreMes = nombreMes.Substring(0, 1).ToUpper() + nombreMes.Substring(1, largo - 1);
                nombreMes = nombreMes.Substring(0, 3);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }

        public static string obtenerNombreMes(int numeroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                return nombreMes.ToUpper();
            }
            catch
            {
                return "Desconocido";
            }
        } 

        public static string obtenerRutHexadecimal(string rut)
        {
            try 
            {
                string str = rut;
                string salida = "";

                char[] ca = str.ToCharArray();

                foreach (char c in ca)
                {
                    
                    switch (c.ToString())
                    {
                        case "0":
                            salida += "0035";                          
                            break;

                        case "1":
                             salida += "0036";                          
                            break;

                        case "2":
                            salida += "0037";
                            break;

                        case "3":
                            salida += "0038";
                            break;

                        case "4":
                            salida += "0039";
                            break;

                        case "5":
                            salida += "003A";
                            break;

                        case "6":
                            salida += "003B";
                            break;
                            
                        case "7":
                            salida += "003C";
                            break;

                        case "8":
                            salida += "003D";
                            break;

                        case "9":
                            salida += "003E";
                            break;

                        case "-":
                            salida += "0032";
                            break;


                        case "K":
                            salida += "0050";
                            break;

                    }
                }
             
                salida += "%u00feM";
                return salida;

            }
            catch
            {
                return "Rut invalido";
            }
        }  

        public static string obtenerIp()
        {
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }

                return localIP;
            }
            catch
            {
                return "";
            }
        }
    }
    

    


}