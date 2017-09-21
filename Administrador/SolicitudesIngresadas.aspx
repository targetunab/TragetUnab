<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="SolicitudesIngresadas.aspx.cs" Inherits="Target.Administrador.SolicitudesIngresadas" %>
<%@ MasterType virtualpath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

          <script type="text/javascript">
              $(function () {
                  $('#btnSolIngres').addClass('active');
              });
              function revisionPlan() {
                  $('#mymodal').modal('show');
              }
           </script>
        
    <h3>Solicitud Ingresadas</h3>
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
                </tr>
             </thead>
             <tbody>
                        
            </tbody>
        </table>
    </div>

<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Asignación de Solicitud</h4>
      </div>
      <div class="modal-body">
                <div style="margin-left: 7px; margin-right:7px;">
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
                   <td>Campaña Starbucks</td>
                   <td>Marketing</td>
                   <td>09/07/2017</td>
                   <td>20/07/1012</td>
                   <td>Campaña</td>
                   <td>Nicolas Vargas</td>
                       </tr>   
            </tbody>
        </table>
            </div>

          <div class="row">
              <div>
                                    <label style="font-size:14px;">Analista: </label>
                                    <select class="selectpicker">
  <option>Daniel Pedreros</option>
  <option>Ketchup</option>
  <option>Relish</option>
</select>

                                </div> 

          </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
        <button type="button" class="btn btn-primary">Asignar Solicitud</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>
