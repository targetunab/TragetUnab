using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Target.Analista
{
    public partial class Generacion : System.Web.UI.Page
    {
        public string id_solicitud
        {
            get { return Convert.ToString(ViewState["id_solicitud"]); }
            set { ViewState.Add("id_solicitud", value); }
        }
        public string rutUsuario
        {
            get { return Convert.ToString(ViewState["rutUsuario"]); }
            set { ViewState.Add("rutUsuario", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            id_solicitud = Request.QueryString["id"].ToString();
            if (id_solicitud == null) { id_solicitud = "0"; }
            rutUsuario = Request.QueryString["rut"].ToString();
            if (rutUsuario == null) { rutUsuario = "0"; }
            botoneraVisible();
            if (!IsPostBack)
            {
                cargaComboRubroComercial1();
                cargaComboRubroComercial2();
                cargaComboRubroComercial3();
                cargaComboRubroComercial4();
                cargaFechaCompras();
                cargaDatosSolicitud();
            }
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

        protected void cargaComboRubroComercial1()
        {
            cboRubroComercial1.Items.Insert(0, "Seleccione un Rubro");
            string Sp = "SP_SEL_RUBROS_COMERCIALES @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboRubroComercial1.Items.Add(row["nombre_rubro"].ToString());
                }
            }
        }
        protected void cargaComboRubroComercial2()
        {
            cboRubroComercial2.Items.Insert(0, "Seleccione un Rubro");
            string Sp = "SP_SEL_RUBROS_COMERCIALES @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboRubroComercial2.Items.Add(row["nombre_rubro"].ToString());
                }
            }
        }
        protected void cargaComboRubroComercial3()
        {
            cboRubroComercial3.Items.Insert(0, "Seleccione un Rubro");
            string Sp = "SP_SEL_RUBROS_COMERCIALES @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboRubroComercial3.Items.Add(row["nombre_rubro"].ToString());
                }
            }
        }
        protected void cargaComboRubroComercial4()
        {
            cboRubroComercial4.Items.Insert(0, "Seleccione un Rubro");
            string Sp = "SP_SEL_RUBROS_COMERCIALES @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboRubroComercial4.Items.Add(row["nombre_rubro"].ToString());
                }
            }
        }

        protected void cargaFechaCompras()
        {
            cboFechaCompras.Items.Insert(0, "Seleccione Rango de Fechas");
            cboFechaCompras.Items.Insert(1, "Ultimo mes");
            cboFechaCompras.Items.Insert(2, "Ultimos 3 meses");
            cboFechaCompras.Items.Insert(3, "Ultimos 6 meses");
            cboFechaCompras.Items.Insert(4, "Ultimo año");
        }

        protected void cargaDatosSolicitud()
        {
            string Sp = "SP_SEL_SOLICITUD @id_solicitud = " + id_solicitud;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    lblSolicitud.InnerText = row["nombre_solicitud"].ToString();
                    lblArea.InnerText = row["nombre_area"].ToString();
                    lblFechaIngreso.InnerText = Convert.ToDateTime(row["fec_ingreso"]).ToString("dd/MM/yyyy");
                    lblFechaSalida.InnerText = Convert.ToDateTime(row["fec_salida"]).ToString("dd/MM/yyyy");
                    lblSolicitante.InnerText = row["solicitante"].ToString();
                    lblTipoSolicitud.InnerText = row["tipo_solicitud"].ToString();
                    lblObservacion.InnerText = row["observacion"].ToString();
                    lblDescargar.InnerHtml = "<a href='../Fichas/Ficha_Solicitud_" + row["id_solicitud"].ToString() + ".xlsx' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span> Descargar</a>";
                }
            }
        }

        protected void validaDatos(object sender, EventArgs e)
        {
            // DECLARA VARIABLES 
            string cta_cte = "0";
            string seg_masiva = "0";
            string seg_medio = "0";
            string seg_alto = "0";
            string seg_pyme = "0";
            string seg_empresa = "0";
            string digital = "0";
            string activo = "0";
            string vinculado = "0";
            string premium = "0";
            string tc_cualquiera = "0";
            string tc_mastercard = "0";
            string tc_amex = "0";
            string tc_visa = "0";
            string tc_gold = "0";
            string tc_platinum = "0";
            string tc_wordlmember = "0";
            string tc_cupo_total = "0";
            string tc_cupo_disponible = "0";
            string prod_ffmm = "0";
            string prod_dap = "0";
            string prod_hipotecario = "0";
            string prod_comercial = "0";
            string prod_consumo = "0";
            string region = "0";
            string renta = "0";
            string edad_min = "0";
            string edad_max = "0";
            string sexo = "0";
            string estado_civil = "0";
            string vehiculo = "0";
            string compras_comercios = "0";
            string rubro1 = "0";
            string rubro2 = "0";
            string rubro3 = "0";
            string rubro4 = "0";
            string morosos = "0";
            string molestos = "0";
            string fallecidos = "0";
            string mail_no_valido = "0";

            if (cboxCtaCte.Checked)
            {
                cta_cte = "1";
            }
            if (cboxSegMasiva.Checked)
            {
                seg_masiva = "1";
            }
            if (cboxSegMedia.Checked)
            {
                seg_medio = "1";
            }
            if (cboxSegAlta.Checked)
            {
                seg_alto = "1";
            }
            if (cboxSegPyme.Checked)
            {
                seg_pyme = "1";
            }
            if (cboxSegEmpresa.Checked)
            {
                seg_empresa = "1";
            }
            if (cboxDigital.Checked)
            {
                digital = "1";
            }
            if (cboxActivo.Checked)
            {
                activo = "1";
            }
            if (cboxVinculado.Checked)
            {
                vinculado = "1";
            }
            if (cboxTcCualquiera.Checked)
            {
                tc_cualquiera = "1";
            }
            if (cboxTcMastercard.Checked)
            {
                tc_mastercard = "1";
            }
            if (cboxTcAmex.Checked)
            {
                tc_amex = "1";
            }
            if (cboxTcVisa.Checked)
            {
                tc_visa = "1";
            }
            if (cboxTcGold.Checked)
            {
                tc_gold = "1";
            }
            if (cboxTcPlatinum.Checked)
            {
                tc_platinum = "1";
            }
            if (cboxTcWorldMember.Checked)
            {
                tc_wordlmember = "1";
            }
            if (txtTcCupoTotal.Text != "")
            {
                tc_cupo_total = txtTcCupoTotal.Text;
            }
            if (txtTcCupoDisponible.Text != "")
            {
                tc_cupo_disponible = txtTcCupoDisponible.Text;
            }
            if (cboxFFMM.Checked)
            {
                prod_ffmm = "1";
            }
            if (cboxDAP.Checked)
            {
                prod_dap = "1";
            }
            if (cboxHipotecario.Checked)
            {
                prod_hipotecario = "1";
            }
            if (cboxConsumo.Checked)
            {
                prod_consumo = "1";
            }
            if (cboxComercial.Checked)
            {
                prod_comercial = "1";
            }
            if (cboRegion.Value == "Cualquiera")
            {
                region = "0";
            }
            if (cboRegion.Value == "Metropolitana")
            {
                region = "1";
            }
            if (cboRegion.Value == "Regiones")
            {
                region = "2";
            }
            if (txtRenta.Value != "")
            {
                renta = txtRenta.Value;
            }
            if (txtEdadDesde.Value != "")
            {
                edad_min = txtEdadDesde.Value;
            }
            if (txtEdadHasta.Value != "")
            {
                edad_max = txtEdadHasta.Value;
            }
            if (cboSexo.Value == "Cuaquiera")
            {
                sexo = "0";
            }
            if (cboSexo.Value == "Masculino")
            {
                sexo = "1";
            }
            if (cboSexo.Value == "Femenino")
            {
                sexo = "2";
            }
            if (cboEstadoCivil.Value == "Cualquiera")
            {
                estado_civil = "0";
            }
            if (cboEstadoCivil.Value == "Soltero")
            {
                estado_civil = "1";
            }
            if (cboEstadoCivil.Value == "Casado")
            {
                estado_civil = "2";
            }
            if (cboEstadoCivil.Value == "Unión Civil")
            {
                estado_civil = "3";
            }
            if (cboEstadoCivil.Value == "Divorciado")
            {
                estado_civil = "4";
            }
            if (cboxVehiculo.Checked)
            {
                vehiculo = "1";
            }
            if (cboxPremium.Checked)
            {
                premium = "1";
            }

            cboFechaCompras.Items.Insert(0, "Seleccione Rango de Fechas");
            cboFechaCompras.Items.Insert(1, "Ultimo mes");
            cboFechaCompras.Items.Insert(2, "Ultimos 3 meses");
            cboFechaCompras.Items.Insert(3, "Ultimos 6 meses");
            cboFechaCompras.Items.Insert(4, "Ultimo año");

            if (cboFechaCompras.SelectedValue == "Ultimo mes")
            {
                compras_comercios = "1";
            }
            if (cboFechaCompras.SelectedValue == "Ultimos 3 meses")
            {
                compras_comercios = "2";
            }
            if (cboFechaCompras.SelectedValue == "Ultimos 6 meses")
            {
                compras_comercios = "3";
            }
            if (cboFechaCompras.SelectedValue == "Ultimo año")
            {
                compras_comercios = "4";
            }
            
            if (cboRubroComercial1.SelectedValue != "Seleccione un Rubro")
            {
                rubro1 = cboRubroComercial1.SelectedValue;
            }
            if (cboRubroComercial2.SelectedValue != "Seleccione un Rubro")
            {
                rubro2 = cboRubroComercial2.SelectedValue;
            }
            if (cboRubroComercial3.SelectedValue != "Seleccione un Rubro")
            {
                rubro3 = cboRubroComercial3.SelectedValue;
            }
            if (cboRubroComercial4.SelectedValue != "Seleccione un Rubro")
            {
                rubro4 = cboRubroComercial4.SelectedValue;
            }
            if (cboxMorosos.Checked)
            {
                morosos = "1";
            }
            if (cboxMolestos.Checked)
            {
                molestos = "1";
            }
            if (cboxFallecidos.Checked)
            {
                fallecidos = "1";
            }
            if (cboxMailNoValido.Checked)
            {
                mail_no_valido = "1";
            }

            SqlCommand cmdExecute = Conexion.GetCommand("SP_INS_FILTROS_SOLICITUD");
            cmdExecute.Parameters.AddWithValue("@id_solicitud", id_solicitud);
            cmdExecute.Parameters.AddWithValue("@cta_cte", cta_cte);
            cmdExecute.Parameters.AddWithValue("@seg_masiva", seg_masiva);
            cmdExecute.Parameters.AddWithValue("@seg_medio", seg_medio);
            cmdExecute.Parameters.AddWithValue("@seg_alto", seg_alto);
            cmdExecute.Parameters.AddWithValue("@seg_pyme", seg_pyme);
            cmdExecute.Parameters.AddWithValue("@seg_empresa", seg_empresa);
            cmdExecute.Parameters.AddWithValue("@digital", digital);
            cmdExecute.Parameters.AddWithValue("@activo", activo);
            cmdExecute.Parameters.AddWithValue("@vinculado", vinculado);
            cmdExecute.Parameters.AddWithValue("@premium", premium);
            cmdExecute.Parameters.AddWithValue("@tc_cualquiera", tc_cualquiera);
            cmdExecute.Parameters.AddWithValue("@tc_mastercard", tc_mastercard);
            cmdExecute.Parameters.AddWithValue("@tc_amex", tc_amex);
            cmdExecute.Parameters.AddWithValue("@tc_visa", tc_visa);
            cmdExecute.Parameters.AddWithValue("@tc_gold", tc_gold);
            cmdExecute.Parameters.AddWithValue("@tc_platinum", tc_platinum);
            cmdExecute.Parameters.AddWithValue("@tc_wordlmember", tc_wordlmember);
            cmdExecute.Parameters.AddWithValue("@tc_cupo_total", tc_cupo_total);
            cmdExecute.Parameters.AddWithValue("@tc_cupo_disponible", tc_cupo_disponible);
            cmdExecute.Parameters.AddWithValue("@prod_ffmm", prod_ffmm);
            cmdExecute.Parameters.AddWithValue("@prod_dap", prod_dap);
            cmdExecute.Parameters.AddWithValue("@prod_hipotecario", prod_hipotecario);
            cmdExecute.Parameters.AddWithValue("@prod_comercial", prod_comercial);
            cmdExecute.Parameters.AddWithValue("@prod_consumo", prod_consumo);
            cmdExecute.Parameters.AddWithValue("@region", region);
            cmdExecute.Parameters.AddWithValue("@renta", renta);
            cmdExecute.Parameters.AddWithValue("@edad_min", edad_min);
            cmdExecute.Parameters.AddWithValue("@edad_max", edad_max);
            cmdExecute.Parameters.AddWithValue("@sexo", sexo);
            cmdExecute.Parameters.AddWithValue("@estado_civil", estado_civil);
            cmdExecute.Parameters.AddWithValue("@vehiculo", vehiculo);
            cmdExecute.Parameters.AddWithValue("@compras_comercios", compras_comercios);
            cmdExecute.Parameters.AddWithValue("@rubro1", rubro1);
            cmdExecute.Parameters.AddWithValue("@rubro2", rubro2);
            cmdExecute.Parameters.AddWithValue("@rubro3", rubro3);
            cmdExecute.Parameters.AddWithValue("@rubro4", rubro4);
            cmdExecute.Parameters.AddWithValue("@morosos", morosos);
            cmdExecute.Parameters.AddWithValue("@molestos", molestos);
            cmdExecute.Parameters.AddWithValue("@fallecidos", fallecidos);
            cmdExecute.Parameters.AddWithValue("@mail_no_valido", mail_no_valido);

            cmdExecute.ExecuteNonQuery();
            cmdExecute.Connection.Close();

            SqlCommand cmdExecute2 = Conexion.GetCommand("SP_INS_SOLICITUD_GENERACION");
            cmdExecute2.Parameters.AddWithValue("@id_solicitud", id_solicitud);

            cmdExecute2.ExecuteNonQuery();
            cmdExecute2.Connection.Close();

            Tools.tools.ClientAlert("La generación de la solicitud ha comenzado");
	
        }
    }
}