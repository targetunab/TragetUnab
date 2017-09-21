using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Target
{
    public partial class Login : System.Web.UI.Page
    {
        public string rutUsuario
        {
            get { return Convert.ToString(ViewState["rutUsuario"]); }
            set { ViewState.Add("rutUsuario", value); }
        }
        public string perfil
        {
            get { return Convert.ToString(ViewState["perfil"]); }
            set { ViewState.Add("perfil", value); }
        }
        public string area
        {
            get { return Convert.ToString(ViewState["area"]); }
            set { ViewState.Add("area", value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Sp = "SP_SEL_USUARIOS_LOGIN @RUT_USUARIO = "+txtUsuario.Text;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    rutUsuario = row["rut_usuario"].ToString();
                    perfil = row["perfil"].ToString();
                    area = row["nombre_area"].ToString();
                }
            }

            if (perfil == "2")
            {
                Response.Redirect("Supervisor/SolicitudesIngresadas.aspx?rut=" + rutUsuario);
            }
            if (perfil == "3")
            {
                Response.Redirect("Analista/SolicitudesAsignadas.aspx?rut=" + rutUsuario);
            }
            if (perfil == "4")
            {
                Response.Redirect("Solicitante/SolicitudesIngresadas.aspx?rut=" + rutUsuario);
            }
        }
    }
}