﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="SolicitudesIngresadasD.aspx.cs" Inherits="Target.Solicitante.SolicitudesIngresadasD" %>
<%@ MasterType virtualpath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

          <script type="text/javascript">
              $(function () {
                  $('#btnSolIngres').addClass('active');
              });

              $(window).load(function () {
                  $('#myModal').modal('show');
              });

              function solicitudDevuelta(rut_usuario) {
                  $('#myModal').modal().hide();
                  alert("Solicitud Devuelta Exitosamente");
                  window.location.href = "SolicitudesIngresadas.aspx?rut=" + rut_usuario + "";
              }

           </script>

        
    <h3>Solicitudes Ingresadas</h3>
    <div style="margin-left: 20px; margin-right:20px;">
        <table class="table-clientes table table-bordered table-striped small-thead" id="solicitudesIngresadas" runat="server">
			<thead>
                <tr class="font-white">
                   <th class="celeste-claro text-center">ID Solicitud</th>
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
    <div class="modal" id="myModal" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                    <div class="modal-header">
                         <div class="alert alert-info" role="alert">
                            <div class="h3 text-center">
                            <span class="glyphicon glyphicon-info-sign"></span> Devolver Solicitud
                            </div>  
                         </div>
                    </div>
                 <div class="modal-body">
                    <div style="margin-left: 7px; margin-right: 7px;">
                        <table class="table-clientes table table-bordered table-striped small-thead" id="Table1" runat="server">
                            <thead>
                                <tr class="font-white">
                                    <th class="celeste-claro text-center">Solicitud</th>
                                    <th class="celeste-claro text-center">Area</th>
                                    <th class="celeste-claro text-center">Fecha Ingreso</th>
                                    <th class="celeste-claro text-center">Fecha Salida</th>
                                    <th class="celeste-claro text-center">Tipo Solicitud</th>
                                    <th class="celeste-claro text-center">Solicitante</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><span runat="server" style="text-align:left !important;" id="lblSolicitud"></span></td>
                                    <td><span runat="server" style="text-align:left !important;" id="lblArea"></span></td>
                                    <td><span runat="server" style="text-align:left !important;" id="lblFechaIngreso"></span></td>
                                    <td><span runat="server" style="text-align:left !important;" id="lblFechaSalida"></span></td>
                                    <td><span runat="server" style="text-align:left !important;" id="lblTipoSolicitud"></span></td>
                                    <td><span runat="server" style="text-align:left !important;" id="lblSolicitante"></span></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                     <div class="row">
                        <div>
                            <div style="text-align:center !important;">
                                <label style="font-size: 14px;">Observación: </label>
                                <textarea id="txtObservacion" textmode="multiline" class="form-control" rows="2" runat="server"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
          <div class="modal-footer">
                 <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button id="btnAsignar" type="button" runat="server" onserverclick="devolverSolicitud" class="btn btn-primary">Devolver Solicitud</button>
          </div>
        </div>
    </div>
    </div>
</asp:Content>
