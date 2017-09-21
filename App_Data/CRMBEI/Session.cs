using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net;
using System.Net.Sockets;


namespace CRMBEI
{
    public class Session
    {
        public Session()
        {

        }

        private static HttpSessionState Session1
        {
            get { return HttpContext.Current.Session; }
        }

        public static string UsuarioId()
        {
            if (Session1 != null && Session1["usu_id"] != null)
            {
                return HttpContext.Current.Session["usu_id"].ToString();
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }
        }

        public static string UsuarioCuenta()
        {
            if (Session1 != null && Session1["usu_cuenta"] != null)
            {
                return HttpContext.Current.Session["usu_cuenta"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static string UsuarioNombre()
        {
            if (Session1 != null && Session1["usu_nombre"] != null)
            {
                return HttpContext.Current.Session["usu_nombre"].ToString();
            }
            else
            {
                return "";
            }
        }

       
        public static string UsuarioPerfil() 
        {
            if (Session1 != null && Session1["usu_perfil"] != null)
            {
                return HttpContext.Current.Session["usu_perfil"].ToString();
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }
        }
        
        public static string RemoteHost()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return "";
            }
        }

        

    }
}