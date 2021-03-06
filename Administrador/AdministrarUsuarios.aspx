﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="Target.Administrador.AdministrarUsuarios" %>

<%@ MasterType VirtualPath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

    <script type="text/javascript">
        $(function () {
            $('#btnUsuarios').addClass('active');
        });
    </script>
    <h3>Nuevo Usuario</h3>
    <div id="formCreditoUnaCuotaCuoton" runat="server">
         <div class="col-xs-12">
               <div class="alert alert-danger" id="divError" runat="server" role="alert"></div>	
         </div>
        <div class="col-xs-12">
            <div class="well-white">
                <div class="row form-group">
                    <div class="col-xs-2">
                        <label class="control-label">Rut Usuario *</label>
                        <asp:TextBox ID="txtRutUsuario" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label" runat="server" id="Label1">Nombre Completo *</label>
                        <asp:TextBox ID="txtNombreUsuario" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Cargo</label>
                        <asp:TextBox ID="txtCargo" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Area</label>
                        <asp:DropDownList CssClass="input-sm form-control" ID="cboArea" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Perfil</label>
                        <asp:DropDownList CssClass="input-sm form-control" ID="cboPerfil" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Email *</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group text-center footer-form">	
                      <asp:button runat="server" OnClick="insertarUsuario" ID="btnInsertarUsuario" class="btn btn-primary"  Text="Ingresar">
                      </asp:button>					
                </div>
            </div>
        </div>
    </div>

    <div style="margin-left: 20px; margin-right: 20px;">
        <table class="table-clientes table table-bordered table-striped small-thead" id="tblUsuarios" runat="server">
            <thead>
                <tr class="font-white">
                    <th class="celeste-claro text-center">Rut Usuario</th>
                    <th class="celeste-claro text-center">Nombre Usuario</th>
                    <th class="celeste-claro text-center">Cargo</th>
                    <th class="celeste-claro text-center">Area</th>
                    <th class="celeste-claro text-center">Perfil</th>
                    <th class="celeste-claro text-center">Email</th>
                    <th class="celeste-claro text-center">Estado</th>
                    <th class="celeste-claro text-center">Acción</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

</asp:Content>
