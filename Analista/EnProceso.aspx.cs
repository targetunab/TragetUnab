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
            if (rutUsuario == null) { return; }
            botoneraVisible();
            cargaSolicitudes();
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
            Master.visibleBotonera("<div class='row'><div class='btn-group btn-group-justified'><div class='btn-group'><button type='button' id='btnSolIngresadas' class='btn btn-nav'><a href='../Analista/SolicitudesAsignadas.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-list'></span><p>Solicitudes Asignadas</p></a></button></div><div class='btn-group'><button type='button' id='btnGeneracion' class='btn btn-nav'><a href='../Analista/EnProceso.aspx?rut=" + rutUsuario + "'><span class='glyphicon glyphicon-wrench'></span><p>Generacion</p></a></button></div></div></div>");
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
                    HtmlTableCell cell_solicitante = new HtmlTableCell("td");
                    HtmlTableCell cell_area = new HtmlTableCell("td");
                    HtmlTableCell cell_fec_ingreso = new HtmlTableCell("td");
                    HtmlTableCell cell_fec_salida = new HtmlTableCell("td");                  
                    HtmlTableCell cell_inicio = new HtmlTableCell("td");
                    HtmlTableCell cell_fin = new HtmlTableCell("td");
                    HtmlTableCell cell_estado = new HtmlTableCell("td");
                    HtmlTableCell cell_clientes = new HtmlTableCell("td");

                    Label lblIdSolicitud = new Label();
                    Label lblSolicitud = new Label();
                    Label lblSolicitante = new Label();
                    Label lblArea = new Label();
                    Label lblFechaIngreso = new Label();
                    Label lblFechaSalida = new Label();                
                    Label lblInicio = new Label();
                    Label lblFin = new Label();
                    Label lblEstado = new Label();
                    Label lblClientes = new Label();

                    lblIdSolicitud.Text = row["id_solicitud"].ToString();
                    lblSolicitud.Text = row["nombre_solicitud"].ToString();
                    lblSolicitante.Text = row["solicitante"].ToString();
                    lblArea.Text = row["nombre_area"].ToString();
                    lblFechaIngreso.Text = Convert.ToDateTime(row["fec_ingreso"]).ToString("dd/MM/yyyy");
                    lblFechaSalida.Text = Convert.ToDateTime(row["fec_salida"]).ToString("dd/MM/yyyy");
                    lblInicio.Text = row["fec_inicio"].ToString();
                    lblFin.Text = row["fec_termino"].ToString();
                    string estado = "";
                    estado = row["estado_generacion"].ToString();
                    if (estado == "En Espera")
                    {
                        lblEstado.Text = "<button type='button' class='btn btn-warning btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> En Espera</button>";
                    }
                    if (estado == "En Proceso")
                    {
                        lblEstado.Text = "<button type='button' class='btn btn-info btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> En Proceso</button>";
                    }
                    if (estado == "Finalizada")
                    {
                        lblEstado.Text = "<button type='button' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Finalizada</button>";
                    }
                    lblClientes.Text = row["cant_clientes"].ToString(); 

                    cell_id_solicitud.Controls.Add(lblIdSolicitud);
                    cell_solicitud.Controls.Add(lblSolicitud);
                    cell_solicitante.Controls.Add(lblSolicitante);
                    cell_area.Controls.Add(lblArea);
                    cell_fec_ingreso.Controls.Add(lblFechaIngreso);
                    cell_fec_salida.Controls.Add(lblFechaSalida); 
                    cell_inicio.Controls.Add(lblInicio);
                    cell_fin.Controls.Add(lblFin);
                    cell_estado.Controls.Add(lblEstado);
                    cell_clientes.Controls.Add(lblClientes);

                    cell_solicitud.Attributes.Add("class", "text-left");
                    cell_area.Attributes.Add("class", "text-left");
                    cell_solicitante.Attributes.Add("class", "text-left");
                    cell_estado.Attributes.Add("class", "text-left");

                    rowNew.Controls.Add(cell_id_solicitud);
                    rowNew.Controls.Add(cell_solicitud);
                    rowNew.Controls.Add(cell_solicitante);
                    rowNew.Controls.Add(cell_area);
                    rowNew.Controls.Add(cell_fec_ingreso);
                    rowNew.Controls.Add(cell_fec_salida);                 
                    rowNew.Controls.Add(cell_inicio);
                    rowNew.Controls.Add(cell_fin);
                    rowNew.Controls.Add(cell_clientes);
                    rowNew.Controls.Add(cell_estado);                  
                }
            }
        }
    }
}
