using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Analista
{
    public partial class EnProceso : System.Web.UI.Page
    {
        public string rutUsuario
        {
            get { return Convert.ToString(ViewState["rutUsuario"]); }
            set { ViewState.Add("rutUsuario", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rutUsuario = Request.QueryString["rut"].ToString();
            botoneraVisible();
            cargaSolicitudes();
        }
        protected void botoneraVisible()
        {
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngresadas' class='btn btn-nav'><a href='../Analista/SolicitudesAsignadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-list'></span><p>Solicitudes Asignadas</p></a></button></div><div class='btn-group'><button type='button' id='btnGeneracion' class='btn btn-nav'><a href='../Analista/EnProceso.aspx'><span class='glyphicon glyphicon-wrench'></span><p>Generacion</p></a></button></div></div></div>");
        }
        protected void cargaSolicitudes()
        {
            string Sp = "SP_SEL_SOLICITUDES_GENERACION @ANALISTA = " + rutUsuario;

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
                    HtmlTableCell cell_inicio = new HtmlTableCell("td");
                    HtmlTableCell cell_fin = new HtmlTableCell("td");
                    HtmlTableCell cell_estado = new HtmlTableCell("td");
                    HtmlTableCell cell_progreso = new HtmlTableCell("td");

                    Label lblIdSolicitud = new Label();
                    Label lblSolicitud = new Label();
                    Label lblArea = new Label();
                    Label lblFechaIngreso = new Label();
                    Label lblFechaSalida = new Label();
                    Label lblTipoSolicitud = new Label();
                    Label lblSolicitante = new Label();
                    Label lblInicio = new Label();
                    Label lblFin = new Label();
                    Label lblEstado = new Label();
                    Label lblProgreso = new Label();

                    lblIdSolicitud.Text = row["id_solicitud"].ToString();
                    lblSolicitud.Text = row["nombre_solicitud"].ToString();
                    lblArea.Text = row["nombre_area"].ToString();
                    lblFechaIngreso.Text = row["fec_ingreso"].ToString();
                    lblFechaSalida.Text = row["fec_salida"].ToString();
                    lblTipoSolicitud.Text = row["tipo_solicitud"].ToString();
                    lblSolicitante.Text = row["solicitante"].ToString();
                    lblInicio.Text = row["fec_inicio"].ToString();
                    lblFin.Text = row["fec_termino"].ToString();
                    lblEstado.Text = "<button type='button' class='btn btn-warning btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> En Proceso</button>";
                    if (row["id_solicitud"].ToString() == "6")
                    {
                        lblProgreso.Text = "<span class='btn btn-xs btn-success barra-progreso2' data-toggle='tooltip' data-placement='top' title=''>100%</span>";
                    }
                    else
                    {
                        lblProgreso.Text = "<div class='progress'><div class='progress-bar' role='progressbar' aria-valuenow='20' aria-valuemin='0' aria-valuemax='100' style='width: 20%;'>20%</div></div>";
                    }
                    cell_id_solicitud.Controls.Add(lblIdSolicitud);
                    cell_solicitud.Controls.Add(lblSolicitud);
                    cell_area.Controls.Add(lblArea);
                    cell_fec_ingreso.Controls.Add(lblFechaIngreso);
                    cell_fec_salida.Controls.Add(lblFechaSalida);
                    cell_tipo_solicitud.Controls.Add(lblTipoSolicitud);
                    cell_solicitante.Controls.Add(lblSolicitante);
                    cell_inicio.Controls.Add(lblInicio);
                    cell_fin.Controls.Add(lblFin);
                    cell_estado.Controls.Add(lblEstado);
                    cell_progreso.Controls.Add(lblProgreso);

                    cell_solicitud.Attributes.Add("class", "text-left");
                    cell_area.Attributes.Add("class", "text-left");
                    cell_tipo_solicitud.Attributes.Add("class", "text-left");
                    cell_solicitante.Attributes.Add("class", "text-left");
                    cell_estado.Attributes.Add("class", "text-left");

                    rowNew.Controls.Add(cell_id_solicitud);
                    rowNew.Controls.Add(cell_solicitud);
                    rowNew.Controls.Add(cell_area);
                    rowNew.Controls.Add(cell_fec_ingreso);
                    rowNew.Controls.Add(cell_fec_salida);
                    rowNew.Controls.Add(cell_tipo_solicitud);
                    rowNew.Controls.Add(cell_solicitante);
                    rowNew.Controls.Add(cell_inicio);
                    rowNew.Controls.Add(cell_fin);
                    rowNew.Controls.Add(cell_estado);
                    rowNew.Controls.Add(cell_progreso);
                }
            }
        }
    }
}