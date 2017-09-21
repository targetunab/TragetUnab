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
    public partial class DescargaBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargaSolicitudes();
            EjecutaDescarga();
        }
        protected void cargaSolicitudes()
        {
            string Sp = "SP_SEL_BASE_CLIENTES @FLAG = 2";

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    HtmlTableRow rowNew = new HtmlTableRow();
                    baseClientes.Controls.Add(rowNew);

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
                    lblArea.Text = row["id_area"].ToString();
                    lblFechaIngreso.Text = row["fec_ingreso"].ToString();
                    lblFechaSalida.Text = row["fec_salida"].ToString();
                    lblTipoSolicitud.Text = row["tipo_solicitud"].ToString();
                    lblSolicitante.Text = row["solicitante"].ToString();                 

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
                }
            }
        }
        protected void EjecutaDescarga()
        {
            Response.ContentType = "application/vnd.ms-excel";
            string filename = "Cascada Ampliada Cliente -" + DateTime.Now.ToShortDateString();
            Response.AppendHeader("content-disposition", "attachment; filename=HolaMundo.xls");
        }
    }
}