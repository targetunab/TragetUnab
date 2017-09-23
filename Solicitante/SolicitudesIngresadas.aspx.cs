using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Solicitud
{
    public partial class SolicitudesIngresadas : System.Web.UI.Page
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
            datosUsuario();
            cargaSolicitudes();
            botoneraVisible();     
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
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngres' class='btn btn-nav'><a href='../Solicitante/SolicitudesIngresadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-list'></span><p>Solicitudes Ingresadas</p></a></button></div><div class='btn-group'><button type='button' id='btnNuevaSol' class='btn btn-nav'><a href='../Solicitante/NuevaSolicitud.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-plus'></span><p>Nueva Solicitud</p></a></button></div></div></div>");
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
                    HtmlTableCell cell_solicitante= new HtmlTableCell("td");
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
                        lblAccion.Text = "<button type='button'  title='Descargar' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span> &nbsp;</button><a href='SolicitudesIngresadasD.aspx?rut=" + rutUsuario + "&id=" + row["id_solicitud"].ToString() + "' class='btn btn-info btn-xs'><span class='glyphicon glyphicon-retweet' aria-hidden='true'></span> &nbsp;</a>";
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
            Tools.tools.ClientAlert("Solicitud Devuelta Exitosamente");
        }
        protected void descargaExcel(object sender, EventArgs e)
        {
            
        }
    }
}
