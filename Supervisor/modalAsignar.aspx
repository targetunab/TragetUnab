<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="modalAsignar.aspx.cs" Inherits="Target.Supervisor.modalAsignar" %>

<%@ MasterType VirtualPath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

    <script type="text/javascript">
        $(function () {
            $('#btnSolIngres').addClass('active');
        });

        function CierraVentana() {
            window.close();
        }

        $(window).load(function () {
            $('#myModal').modal('show');
        });

        function asignacionCorrecta(rut_usuario) {
            $('#myModal').modal().hide();
            alert("Analista Asignado Correctamente");
            window.location.href = "SolicitudesIngresadas.aspx?rut="+rut_usuario+"";
        }

    </script>

    <h3>Solicitud Ingresadas</h3>
    <div style="margin-left: 20px; margin-right: 20px;">
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
                            <div class="h4 text-center">
                            <span class="glyphicon glyphicon-info-sign"></span> Asignación de Solicitud
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
                                <tr style="text-align: left !important;">
                                    <td><span runat="server" class="text-left" id="lblSolicitud"></span></td>
                                    <td><span runat="server" class="text-left" id="lblArea"></span></td>
                                    <td><span runat="server" class="text-left" id="lblFechaIngreso"></span></td>
                                    <td><span runat="server" class="text-left" id="lblFechaSalida"></span></td>
                                    <td><span runat="server" class="text-left" id="lblTipoSolicitud"></span></td>
                                    <td><span runat="server" class="text-left" id="lblSolicitante"></span></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div>
                            <div style="text-align:center !important;">
                                <label style="font-size: 14px;">Analista: </label>
                                <asp:DropDownList ID="cboAnalistaResp" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
          <div class="modal-footer">
                 <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button id="btnAsignar" type="button" runat="server" onserverclick="AsignarSolicitud" class="btn btn-primary">Asignar Solicitud</button>
          </div>
        </div>
    </div>
    </div>


</asp:Content>
