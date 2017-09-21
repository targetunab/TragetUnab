<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="NuevaSolicitud.aspx.cs" Inherits="Target.Solicitud.NuevaSolicitud" %>

<%@ MasterType VirtualPath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

    <script type="text/javascript">
        $(function () {
            $('#btnNuevaSol').addClass('active');
        });
    </script>

    <h3>Nueva Solicitud</h3>
    <div id="formCreditoUnaCuotaCuoton" runat="server">
         <div class="col-xs-12">
               <div class="alert alert-danger" id="divError" runat="server" role="alert"></div>	
         </div>
        <div class="col-xs-12">
            <div class="well-white">
                <div class="row form-group">
                    <div class="col-xs-2">
                        <label class="control-label">Nombre Solicitud *</label>
                        <asp:TextBox ID="txtNombreSolicitud" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label" runat="server" id="Label1">Tipo Solicitud *</label>
                        <asp:DropDownList CssClass="input-sm form-control" ID="comboTipoSol" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Usuario Solicitante</label>
                        <label style="font-weight:100;"><span id="lblSolicitante" runat="server"></span></label>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Area Solicitante</label>
                        <label style="font-weight:100;"><span id="lblAreaSolicitante" runat="server"></span></label>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Fecha de Ingreso</label>
                        <label style="font-weight:100;"><span id="lblFechaIngreso" runat="server"></span></label>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Fecha de Salida *</label>
                        <asp:TextBox ID="txtFechaSalida" CssClass="form-control input-sm datepicker" runat="server" data-provide="datepicker" data-date-format="dd-mm-yyyy"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-6">
                        <label class="control-label left">Observación</label>
                        <textarea id="txtObservacion" textmode="multiline" class="form-control" rows="2" runat="server"></textarea>
                    </div>
                    <div class="col-xs-3">
                        <label class="control-label">Subir Ficha *</label>
                        <asp:FileUpload CssClass="form-control" ID="archivoFicha" runat="server" />
                    </div>
                </div>
                <div class="row form-group text-center footer-form">	
                      <asp:button runat="server" OnClick="validarIngreso" ID="btnIngrsarOperacion" class="btn btn-primary"  Text="Ingresar">
                      </asp:button>					
                </div>
            </div>
        </div>
    </div>

</asp:Content>
