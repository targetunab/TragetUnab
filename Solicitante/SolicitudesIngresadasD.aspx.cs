using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Solicitante
{
    public partial class SolicitudesIngresadasD : System.Web.UI.Page
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
        public string idSol
        {
            get { return Convert.ToString(ViewState["idSol"]); }
            set { ViewState.Add("idSol", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            idSol = Request.QueryString["id"].ToString();
            rutUsuario = Request.QueryString["rut"].ToString();
            datosUsuario();
            cargaSolicitudes();
            botoneraVisible();
            cargaDatosSolicitud(idSol);
        }

        protected void datosUsuario()
        {
            string Sp = "SP_SEL_USUARIOS_LOGIN @RUT_USUARIO = " + rutUsuario;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    rutUsuario = row["rut_usuario"].ToString();
                    perfil = row["perfil"].ToString();
                    area = row["id_area"].ToString();
                }
            }
        }

        protected void botoneraVisible()
        {
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnNuevaSol' class='btn btn-nav'><a href='../Solicitante/NuevaSolicitud.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-plus'></span><p>Nueva Solicitud</p></a></button></div><div class='btn-group'><button type='button' id='btnSolIngres' class='btn btn-nav'><a href='../Solicitante/SolicitudesIngresadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-list'></span><p>Solicitudes Ingresadas</p></a></button></div></div></div>");
        }

        protected void cargaDatosSolicitud(string idSol)
        {
            string Sp = "SP_SEL_SOLICITUD @id_solicitud = " + idSol;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    lblSolicitud.InnerText = row["nombre_solicitud"].ToString();
                    lblArea.InnerText = row["nombre_area"].ToString();
                    lblFechaIngreso.InnerText = row["fec_ingreso"].ToString();
                    lblFechaSalida.InnerText = row["fec_ingreso"].ToString();
                    lblSolicitante.InnerText = row["solicitante"].ToString();
                    lblTipoSolicitud.InnerText = row["tipo_solicitud"].ToString();
                }
            }
        }

        protected void cargaSolicitudes()
        {
            string Sp = "SP_SEL_SOLICITUDES @FLAG = 1,@AREA = " + area;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    HtmlTableRow rowNew = new HtmlTableRow();
                    solicitudesIngresadas.Controls.Add(rowNew);

                    HtmlTableCell cell_id_solicitud = new HtmlTableCell("td");
                    HtmlTableCell cell_solicitud = new HtmlTableCell("td");
                    HtmlTableCell cell_area = new HtmlTableCell("td");
                    HtmlTableCell cell_fec_ingreso = new HtmlTableCell("td");
                    HtmlTableCell cell_fec_salida = new HtmlTableCell("td");
                    HtmlTableCell cell_tipo_solicitud = new HtmlTableCell("td");
                    HtmlTableCell cell_solicitante = new HtmlTableCell("td");
                    HtmlTableCell cell_analista_responsable = new HtmlTableCell("td");
                    HtmlTableCell cell_estado = new HtmlTableCell("td");
                    HtmlTableCell cell_accion = new HtmlTableCell("td");

                    Label lblIdSolicitud = new Label();
                    Label lblSolicitud = new Label();
                    Label lblArea = new Label();
                    Label lblFechaIngreso = new Label();
                    Label lblFechaSalida = new Label();
                    Label lblTipoSolicitud = new Label();
                    Label lblSolicitante = new Label();
                    Label lblAnalistaResponsable = new Label();
                    Label lblEstado = new Label();
                    Label lblAccion = new Label();

                    lblIdSolicitud.Text = row["id_solicitud"].ToString();
                    lblSolicitud.Text = row["nombre_solicitud"].ToString();
                    lblArea.Text = row["nombre_area"].ToString();
                    lblFechaIngreso.Text = Convert.ToDateTime(row["fec_ingreso"]).ToString("dd/MM/yyyy");
                    lblFechaSalida.Text = Convert.ToDateTime(row["fec_salida"]).ToString("dd/MM/yyyy");
                    lblTipoSolicitud.Text = row["tipo_solicitud"].ToString();
                    lblSolicitante.Text = row["solicitante"].ToString();
                    lblAnalistaResponsable.Text = row["analista"].ToString();

                    string Estado = row["estado_solicitud"].ToString();
                    switch (Estado)
                    {
                        case "1":
                            lblEstado.Text = "<button type='button' class='btn btn-warning btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Ingresada</button>";
                            break;

                        case "2":
                            lblEstado.Text = "<button type='button' class='btn btn-info2 btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Asignada</button>";
                            break;

                        case "3":
                            lblEstado.Text = "<button type='button'  class='btn btn-info btn-xs'><span class='glyphicon glyphicon-pause' aria-hidden='true'></span> En Proceso</button>";
                            break;

                        case "4":
                            lblEstado.Text = "<button type='button' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-ok' aria-hidden='true'></span> Finalizada</button>";
                            break;
                    }
                    if (Estado == "4")
                    {
                        lblAccion.Text = "<button type='button'  title='Descargar' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span> &nbsp;</button><button type='button' runat='server' onserverclick='devolverSolicitud' title='Devolver' class='btn btn-warning btn-xs'><span class='glyphicon glyphicon-retweet' aria-hidden='true'></span> &nbsp;</button>";
                    }
                    else
                    {
                        lblAccion.Text = "";
                    }

                    cell_id_solicitud.Controls.Add(lblIdSolicitud);
                    cell_solicitud.Controls.Add(lblSolicitud);
                    cell_area.Controls.Add(lblArea);
                    cell_fec_ingreso.Controls.Add(lblFechaIngreso);
                    cell_fec_salida.Controls.Add(lblFechaSalida);
                    cell_tipo_solicitud.Controls.Add(lblTipoSolicitud);
                    cell_solicitante.Controls.Add(lblSolicitante);
                    cell_analista_responsable.Controls.Add(lblAnalistaResponsable);
                    cell_estado.Controls.Add(lblEstado);
                    cell_accion.Controls.Add(lblAccion);

                    cell_solicitud.Attributes.Add("class", "text-left");
                    cell_area.Attributes.Add("class", "text-left");
                    cell_tipo_solicitud.Attributes.Add("class", "text-left");
                    cell_solicitante.Attributes.Add("class", "text-left");
                    cell_analista_responsable.Attributes.Add("class", "text-left");
                    cell_estado.Attributes.Add("class", "text-left");

                    rowNew.Controls.Add(cell_id_solicitud);
                    rowNew.Controls.Add(cell_solicitud);
                    rowNew.Controls.Add(cell_area);
                    rowNew.Controls.Add(cell_fec_ingreso);
                    rowNew.Controls.Add(cell_fec_salida);
                    rowNew.Controls.Add(cell_tipo_solicitud);
                    rowNew.Controls.Add(cell_solicitante);
                    rowNew.Controls.Add(cell_analista_responsable);
                    rowNew.Controls.Add(cell_estado);
                    rowNew.Controls.Add(cell_accion);
                }
            }
        }
        protected void devolverSolicitud(object sender, EventArgs e)
        {
            string observacion = txtObservacion.InnerText;
            SqlCommand cmdExecute = Conexion.GetCommand("SP_PROC_DEVUELVE_SOLICITUD");
            cmdExecute.Parameters.AddWithValue("@id_solicitud", idSol);
            cmdExecute.Parameters.AddWithValue("@observacion", observacion);

            cmdExecute.ExecuteNonQuery();
            cmdExecute.Connection.Close();

            Tools.tools.ClientExecute("solicitudDevuelta(" + rutUsuario + ");");
        }
    }
}