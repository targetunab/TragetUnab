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
        public string rutUsuario
        {
            get { return Convert.ToString(ViewState["rutUsuario"]); }
            set { ViewState.Add("rutUsuario", value); }
        }
        public string idSol
        {
            get { return Convert.ToString(ViewState["idSol"]); }
            set { ViewState.Add("idSol", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            idSol = Request.QueryString["id"].ToString();
            if(idSol == null){idSol = 1}
            rutUsuario = Request.QueryString["rut"].ToString();
            if(rutUsuario == null){rutUsuario = 1}
            cargaSolicitudes();
            EjecutaDescarga();
        }
        protected void cargaSolicitudes()
        {
            string Sp = "SP_SEL_BASE_CLIENTES @id_solicitud = "+idSol;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    HtmlTableRow rowNew = new HtmlTableRow();
                    baseClientes.Controls.Add(rowNew);

                    HtmlTableCell cell_rut = new HtmlTableCell("td");
                    HtmlTableCell cell_nombres = new HtmlTableCell("td");
                    HtmlTableCell cell_appaterno = new HtmlTableCell("td");
                    HtmlTableCell cell_apmaterno = new HtmlTableCell("td");
                    HtmlTableCell cell_direccion = new HtmlTableCell("td");
                    HtmlTableCell cell_comuna = new HtmlTableCell("td");
                    HtmlTableCell cell_region = new HtmlTableCell("td");
                    HtmlTableCell cell_fono = new HtmlTableCell("td");
                    HtmlTableCell cell_mail = new HtmlTableCell("td");

                    Label lblRut = new Label();
                    Label lblNombres = new Label();
                    Label lblApPaterno = new Label();
                    Label LblApMaterno = new Label();
                    Label lblDireccion = new Label();
                    Label lblComuna = new Label();
                    Label lblRegion = new Label();
                    Label LblFono = new Label();
                    Label LblMail = new Label();

                    lblRut.Text = row["rut_cliente"].ToString();
                    lblNombres.Text = row["nombre_cliente"].ToString();
                    lblApPaterno.Text = row["ap_paterno"].ToString();
                    LblApMaterno.Text = row["ap_materno"].ToString();
                    lblDireccion.Text = row["direccion_particular"].ToString();
                    lblComuna.Text = row["comuna"].ToString();
                    lblRegion.Text = row["region"].ToString();
                    LblFono.Text = row["fono"].ToString();
                    LblMail.Text = row["mail"].ToString();

                    cell_rut.Controls.Add(lblRut);
                    cell_nombres.Controls.Add(lblNombres);
                    cell_appaterno.Controls.Add(lblApPaterno);
                    cell_apmaterno.Controls.Add(LblApMaterno);
                    cell_direccion.Controls.Add(lblDireccion);
                    cell_comuna.Controls.Add(lblComuna);
                    cell_region.Controls.Add(lblRegion);
                    cell_fono.Controls.Add(LblFono);
                    cell_mail.Controls.Add(LblMail);


                    cell_rut.Attributes.Add("class", "text-left");
                    cell_nombres.Attributes.Add("class", "text-left");
                    cell_appaterno.Attributes.Add("class", "text-left");
                    cell_apmaterno.Attributes.Add("class", "text-left");
                    cell_direccion.Attributes.Add("class", "text-left");
                    cell_comuna.Attributes.Add("class", "text-left");
                    cell_region.Attributes.Add("class", "text-left");
                    cell_fono.Attributes.Add("class", "text-left");
                    cell_mail.Attributes.Add("class", "text-left");

                    rowNew.Controls.Add(cell_rut);
                    rowNew.Controls.Add(cell_nombres);
                    rowNew.Controls.Add(cell_appaterno);
                    rowNew.Controls.Add(cell_apmaterno);
                    rowNew.Controls.Add(cell_direccion);
                    rowNew.Controls.Add(cell_comuna);
                    rowNew.Controls.Add(cell_region);
                    rowNew.Controls.Add(cell_fono);
                    rowNew.Controls.Add(cell_mail);
                }
            }
        }
        protected void EjecutaDescarga()
        {
            Response.ContentType = "application/vnd.ms-excel";
            string filename = "Base_Clientes_" + idSol;
            Response.AppendHeader("content-disposition", "attachment; filename="+filename+".xls");
        }
    }
}
