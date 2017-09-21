using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Solicitud
{
    public partial class NuevaSolicitud : System.Web.UI.Page
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
            if (rutUsuario == null) { return; }
            botoneraVisible();           
            cargarDatos();
            divError.Visible = false;
            if (!IsPostBack)
            {
                cargaComboTipoSolicitud();
            }
        }

        protected void botoneraVisible()
        {
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngres' class='btn btn-nav'><a href='../Solicitante/SolicitudesIngresadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-list'></span><p>Solicitudes Ingresadas</p></a></button></div><div class='btn-group'><button type='button' id='btnNuevaSol' class='btn btn-nav'><a href='../Solicitante/NuevaSolicitud.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-plus'></span><p>Nueva Solicitud</p></a></button></div></div></div>");
        }
        protected void cargaComboTipoSolicitud()
        {
            comboTipoSol.Items.Insert(0,"Seleccione un Tipo");
            string Sp = "SP_SEL_TIPO_SOLICITUD @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    comboTipoSol.Items.Insert(Int32.Parse(row["id_tipo_solicitud"].ToString()), row["tipo_solicitud"].ToString());
                }
            }            
        }
        protected void cargarDatos()
        {
            string Sp = "SP_SEL_SOLICITANTE @RUT_USUARIO = " + rutUsuario;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    lblSolicitante.InnerText = row["nombre_usuario"].ToString();
                    lblAreaSolicitante.InnerHtml = row["nombre_area"].ToString();
                    lblFechaIngreso.InnerText = DateTime.Today.ToString("d");
                    area = row["id_area"].ToString();
                }
            }
        }
        protected void validarIngreso(object sender, EventArgs e)
        {
            string exito = ""; 
            if (txtNombreSolicitud.Text == "" || txtFechaSalida.Text == "" || comboTipoSol.Text == "Seleccione un Tipo" || archivoFicha.FileName == "")
            {
                divError.InnerText = "Debe ingresar todos los campos obligatorios";
                divError.Visible = true;
            }
            else
            {
                SqlCommand cmdExecute = Conexion.GetCommand("SP_VALIDA_FECHA_SALIDA");
                cmdExecute.Parameters.AddWithValue("@fecha_salida", txtFechaSalida.Text);
                SqlParameter difDias = new SqlParameter("@exito", 0);
                difDias.Direction = ParameterDirection.Output;
                cmdExecute.Parameters.Add(difDias);

                cmdExecute.ExecuteNonQuery();
                exito = cmdExecute.Parameters["@exito"].Value.ToString();
                cmdExecute.Connection.Close();

                if (exito == "0")
                {
                    divError.InnerText = "Fecha de Salida no cumple con el parametro mínimo de días";
                    divError.Visible = true;
                }
                else
                {
                    Tools.tools.ClientAlert("OK");
                    //ingresarOperacion();
                }
            }
        }
        protected void ingresarOperacion()
        {        
            SqlCommand cmdExecute = Conexion.GetCommand("SP_INS_SOLICITUD");
            int tipo = 0;

            if (comboTipoSol.SelectedValue == "Informativo")
            {
                tipo = 1;
            }
            if (comboTipoSol.SelectedValue == "Informativo Legal")
            {
                tipo = 2;
            }
            if (comboTipoSol.SelectedValue == "Campaña")
            {
                tipo = 3;
            }           

            cmdExecute.Parameters.AddWithValue("@nombreSolicitud", txtNombreSolicitud.Text);
            cmdExecute.Parameters.AddWithValue("@idArea", area);
            cmdExecute.Parameters.AddWithValue("@fecSalida", txtFechaSalida.Text);
            cmdExecute.Parameters.AddWithValue("@tipoSolicitud", tipo);
            cmdExecute.Parameters.AddWithValue("@observacion", txtObservacion.InnerText);
            cmdExecute.Parameters.AddWithValue("@solicitante", rutUsuario);
            SqlParameter idSolicitud = new SqlParameter("@ID_SOL", 0);
            idSolicitud.Direction = ParameterDirection.Output;
            cmdExecute.Parameters.Add(idSolicitud);

            cmdExecute.ExecuteNonQuery();
            int idSol = Int32.Parse(cmdExecute.Parameters["@ID_SOL"].Value.ToString());         
            cmdExecute.Connection.Close();

            archivoFicha.SaveAs("c:\\TargetApp\\Fichas\\Ficha_Solicitud_"+idSol+".xlsx");

            limpiaFormulario();

            Tools.tools.ClientAlert("Solicitud Ingresada Exitosamente");
        }
        protected void limpiaFormulario()
        {
            txtNombreSolicitud.Text = "";
            txtFechaSalida.Text = "";
            txtObservacion.InnerText = "";
        }
    }
}