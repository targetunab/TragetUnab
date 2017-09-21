using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Administrador
{
    public partial class SolicitudesIngresadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botoneraVisible();
            cargaSolicitudes();
        }
         protected void botoneraVisible()
        {
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngres' class='btn btn-nav'><a href='../Supervisor/SolicitudesIngresadas.aspx'><span class='glyphicon glyphicon-plus'></span><p>Solicitudes Ingresdas</p></a></button></div><div class='btn-group'><button type='button' id='btnSeguimiento' class='btn btn-nav'><a href='../Reportes/Reportes.aspx'><span class='glyphicon glyphicon-user'></span><p>Usuarios</p></a></button></div><div class='btn-group'><button type='button' id='btnSeguimiento' class='btn btn-nav'><a href='../Reportes/Reportes.aspx'><span class='glyphicon glyphicon-cog'></span><p>Parametros de Negocio</p></a></button></div></div></div>");
        }

        protected void cargaSolicitudes()
        {
            string Sp = "SP_SEL_SOLICITUDES @FLAG = 3";

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

                    Label lblIdSolicitud = new Label();
                    Label lblSolicitud = new Label();
                    Label lblArea = new Label();
                    Label lblFechaIngreso = new Label();
                    Label lblFechaSalida = new Label();
                    Label lblTipoSolicitud = new Label();
                    Label lblSolicitante = new Label();
                    Label lblAnalistaResponsable = new Label();
                    Label lblEstado = new Label();

                    lblIdSolicitud.Text = row["id_solicitud"].ToString();
                    lblSolicitud.Text = row["nombre_solicitud"].ToString();
                    lblArea.Text = row["nombre_area"].ToString();
                    lblFechaIngreso.Text = row["fec_ingreso"].ToString();
                    lblFechaSalida.Text = row["fec_salida"].ToString();
                    lblTipoSolicitud.Text = row["tipo_solicitud"].ToString();
                    lblSolicitante.Text = row["solicitante"].ToString();
                    
                    string analista = row["analista"].ToString();
                    if (analista != "No Asignada")
                    {
                        lblAnalistaResponsable.Text = row["analista"].ToString();
                    }
                    else
                    {
                        lblAnalistaResponsable.Text = "<button type='button' data-toggle='modal' data-target='#myModal' class='btn btn-info btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Asignar</button>";
                    }
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

                    cell_id_solicitud.Controls.Add(lblIdSolicitud);
                    cell_solicitud.Controls.Add(lblSolicitud);
                    cell_area.Controls.Add(lblArea);
                    cell_fec_ingreso.Controls.Add(lblFechaIngreso);
                    cell_fec_salida.Controls.Add(lblFechaSalida);
                    cell_tipo_solicitud.Controls.Add(lblTipoSolicitud);
                    cell_solicitante.Controls.Add(lblSolicitante);
                    cell_analista_responsable.Controls.Add(lblAnalistaResponsable);
                    cell_estado.Controls.Add(lblEstado);

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
                }
            }
        }
    }
}