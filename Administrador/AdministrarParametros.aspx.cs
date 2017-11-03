using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Target.Administrador
{
    public partial class AdministrarParametros : System.Web.UI.Page
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
            rutUsuario = Request.QueryString["rut"].ToString();
            if(rutUsuario == null){rutUsuario = 1}
            botoneraVisible();
            cargaUsuario();
        }
        protected void cargaUsuario()
        {
            string Sp = "SP_SEL_USUARIOS_LOGIN @RUT_USUARIO = " + rutUsuario;
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    Master.usuario = row["nombre_usuario"].ToString();
                    Master.perfil = row["nombre_perfil"].ToString();
                }
            }
        }
        protected void botoneraVisible()
        {
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngres' class='btn btn-nav'><a href='../Administrador/SolicitudesIngresadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-plus'></span><p>Solicitudes Ingresdas</p></a></button></div><div class='btn-group'><button type='button' id='btnUsuarios' class='btn btn-nav'><a href='../Administrador/AdministrarUsuarios.aspx?rut=" + rutUsuario + "''><span class='glyphicon glyphicon-user'></span><p>Usuarios</p></a></button></div><div class='btn-group'><button type='button' id='btnParametros' class='btn btn-nav'><a href='../Administrador/AdministrarParametros.aspx?rut=" + rutUsuario + "''><span class='glyphicon glyphicon-cog'></span><p>Parametros de Negocio</p></a></button></div></div></div>");
        }
    }
}
