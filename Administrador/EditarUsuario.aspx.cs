using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Target.Administrador
{
    public partial class EditarUsuario : System.Web.UI.Page
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
        public string usuarioEditar
        {
            get { return Convert.ToString(ViewState["usuarioEditar"]); }
            set { ViewState.Add("usuarioEditar", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rutUsuario = Request.QueryString["rut"].ToString();
            usuarioEditar = Request.QueryString["usuario"].ToString();
            if (rutUsuario == null) { return; }
            botoneraVisible();
            divError.Visible = false;
            if (!IsPostBack)
            {
                cargaComboArea();
                cargaComboPerfil();
                cargaEstado();
                cargaDatosUsuario();

            }
            cargaUsuario();
            cargaUsuarios();       
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
        protected void cargaComboArea()
        {
            cboArea.Items.Insert(0, "Seleccione un Tipo");
            string Sp = "SP_SEL_AREA @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboArea.Items.Add(row["id_area"].ToString() + " - " + row["nombre_area"].ToString());
                }
            }
        }
        protected void cargaComboPerfil()
        {
            cboPerfil.Items.Insert(0, "Seleccione un Tipo");
            string Sp = "SP_SEL_PERFIL @ACTIVO = 1";
            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    cboPerfil.Items.Insert(Int32.Parse(row["id_perfil"].ToString()), row["perfil"].ToString());
                }
            }
        }
        protected void cargaEstado()
        {
            cboEstado.Items.Insert(0, "Activo");
            cboEstado.Items.Insert(0, "Inactivo");
        }

        protected void editarUsuario(object sender, EventArgs e)
        {
            if (txtRutUsuario.Text == "" || txtNombreUsuario.Text == "" || txtCargo.Text == "" || cboArea.Text == "Seleccione un Tipo" || cboPerfil.Text == "Seleccione un Tipo" || txtEmail.Text == "")
            {
                divError.InnerText = "Debe ingresar todos los campos obligatorios";
                divError.Visible = true;
            }
            else
            {
                SqlCommand cmdExecute = Conexion.GetCommand("SP_UPD_USUARIO");
                int perfil = 0;

                if (cboPerfil.SelectedValue == "Administrador")
                {
                    perfil = 1;
                }
                if (cboPerfil.SelectedValue == "Supervisor")
                {
                    perfil = 2;
                }
                if (cboPerfil.SelectedValue == "Analista")
                {
                    perfil = 3;
                }
                if (cboPerfil.SelectedValue == "Solicitante")
                {
                    perfil = 4;
                }

                int estado = 0;
                if (cboEstado.SelectedValue == "Activo")
                {
                    estado = 1;
                }

                string area = cboArea.SelectedValue;
                string[] areaSplit = area.Split(' ');
                string areaOK = areaSplit[0];

                cmdExecute.Parameters.AddWithValue("@rut_usuario", txtRutUsuario.Text);
                cmdExecute.Parameters.AddWithValue("@nombre_usuario", txtNombreUsuario.Text);
                cmdExecute.Parameters.AddWithValue("@cargo", txtCargo.Text);
                cmdExecute.Parameters.AddWithValue("@cod_area", areaOK);
                cmdExecute.Parameters.AddWithValue("@cod_perfil", perfil);
                cmdExecute.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdExecute.Parameters.AddWithValue("@activo", estado);

                cmdExecute.ExecuteNonQuery();
                cmdExecute.Connection.Close();

                limpiaFormulario();

                Tools.tools.ClientAlert("Usuario Editado Exitosamente");
            }
        }
        protected void limpiaFormulario()
        {
            txtRutUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtCargo.Text = "";
            txtEmail.Text = "";
        }
        protected void cargaUsuarios()
        {
            string Sp = "SP_SEL_USUARIOS @ACTIVO = 1";

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    HtmlTableRow rowNew = new HtmlTableRow();
                    tblUsuarios.Controls.Add(rowNew);

                    HtmlTableCell cell_rut = new HtmlTableCell("td");
                    HtmlTableCell cell_nombre = new HtmlTableCell("td");
                    HtmlTableCell cell_cargo = new HtmlTableCell("td");
                    HtmlTableCell cell_area = new HtmlTableCell("td");
                    HtmlTableCell cell_perfil = new HtmlTableCell("td");
                    HtmlTableCell cell_email = new HtmlTableCell("td");
                    HtmlTableCell cell_estado = new HtmlTableCell("td");
                    HtmlTableCell cell_accion = new HtmlTableCell("td");

                    Label lblRut = new Label();
                    Label lblNombre = new Label();
                    Label lblcargo = new Label();
                    Label lblArea = new Label();
                    Label lblPerfil = new Label();
                    Label lblEmail = new Label();
                    Label lblEstado = new Label();
                    Label lblAccion = new Label();

                    lblRut.Text = row["rut_usuario"].ToString();
                    lblNombre.Text = row["nombre_usuario"].ToString();
                    lblcargo.Text = row["cargo"].ToString();
                    lblArea.Text = row["nombre_area"].ToString();
                    lblPerfil.Text = row["nombre_perfil"].ToString();
                    lblEmail.Text = row["email"].ToString();
                    lblAccion.Text = "<a href='EditarUsuario.aspx?rut=" + rutUsuario + "&usuario=" + row["rut_usuario"].ToString() + "' class='btn btn-info btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Editar</a>";

                    string Estado = row["activo"].ToString();
                    switch (Estado)
                    {
                        case "1":
                            lblEstado.Text = "<button type='button' class='btn btn-success btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Activo</button>";
                            break;

                        case "0":
                            lblEstado.Text = "<button type='button' class='btn btn-warning btn-xs'><span class='glyphicon glyphicon-floppy-disk' aria-hidden='true'></span> Inactivo</button>";
                            break;
                    }

                    cell_rut.Controls.Add(lblRut);
                    cell_nombre.Controls.Add(lblNombre);
                    cell_cargo.Controls.Add(lblcargo);
                    cell_area.Controls.Add(lblArea);
                    cell_perfil.Controls.Add(lblPerfil);
                    cell_email.Controls.Add(lblEmail);
                    cell_estado.Controls.Add(lblEstado);
                    cell_accion.Controls.Add(lblAccion);

                    cell_rut.Attributes.Add("class", "text-left");
                    cell_nombre.Attributes.Add("class", "text-left");
                    cell_cargo.Attributes.Add("class", "text-left");
                    cell_area.Attributes.Add("class", "text-left");
                    cell_perfil.Attributes.Add("class", "text-left");
                    cell_email.Attributes.Add("class", "text-left");
                    cell_estado.Attributes.Add("class", "text-left");

                    rowNew.Controls.Add(cell_rut);
                    rowNew.Controls.Add(cell_nombre);
                    rowNew.Controls.Add(cell_cargo);
                    rowNew.Controls.Add(cell_area);
                    rowNew.Controls.Add(cell_perfil);
                    rowNew.Controls.Add(cell_email);
                    rowNew.Controls.Add(cell_estado);
                    rowNew.Controls.Add(cell_accion);
                }
            }
        }
        protected void cargaDatosUsuario()
        {
            string Sp = "SP_SEL_USUARIO @RUT_USUARIO = "+usuarioEditar;

            using (DataTable dr = Conexion.GetDataTable(Sp))
            {
                foreach (DataRow row in dr.Rows)
                {
                    txtRutUsuario.Text = row["rut_usuario"].ToString();
                    txtRutUsuario.Enabled = false;
                    txtNombreUsuario.Text = row["nombre_usuario"].ToString();
                    txtCargo.Text = row["cargo"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    cboArea.Text = row["id_area"].ToString()+" - "+row["nombre_area"].ToString();
                    cboPerfil.Text = row["nombre_perfil"].ToString();
                    if (row["activo"].ToString() == "1")
                    {
                        cboEstado.Text = "Activo";
                    }
                    else
                    {
                        cboEstado.Text = "Inactivo";
                    }
                }
            }
        }
        protected void nuevoUsuario(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarUsuarios.aspx?rut=" + rutUsuario);
        }
    }
}