﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="SolicitudesAsignadas.aspx.cs" Inherits="Target.Analista.SolicitudesAsignadas" %>
<%@ MasterType virtualpath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

          <script type="text/javascript">
              $(function () {
                  $('#btnSolIngresadas').addClass('active');
              });
           </script>
        
    <h3>Solicitudes Asignadas</h3> 
    <div style="margin-left: 20px; margin-right:20px;">
        <table class="table-clientes table table-bordered table-striped small-thead" id="solicitudesIngresadas" runat="server">
			<thead>
                <tr class="font-white">
                   <th class="celeste-claro text-center">ID</th>
                   <th class="celeste-claro text-center">Solicitud</th>
                   <th class="celeste-claro text-center">Area</th>
                   <th class="celeste-claro text-center">Fecha Ingreso</th>
                   <th class="celeste-claro text-center">Fecha Salida</th>
                   <th class="celeste-claro text-center">Tipo Solicitud</th>
                   <th class="celeste-claro text-center">Solicitante</th>
                   <th class="celeste-claro text-center">Analista Responsable</th>
                   <th class="celeste-claro text-center">Estado</th>
                   <th class="celeste-claro text-center">Acción</th>
                </tr>
             </thead>
             <tbody>
                        
            </tbody>
        </table>
    </div>
</asp:Content>
