<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Template.Master" CodeBehind="Generacion.aspx.cs" Inherits="Target.Analista.Generacion" %>
<%@ MasterType virtualpath="~/Master/Template.Master" %>

<asp:Content ID="contentBody" ContentPlaceHolderID="cphBody" runat="server">

          <script type="text/javascript">
              $(function () {
                  $('#btnGeneracion').addClass('active');
              });
           </script>

    <style type="text/css">
        .form-group
        {
             text-align:left !important;
        }

    </style>
        
    <h4>Generación de Base de Clientes</h4>
    <table class="table-clientes table table-bordered table-striped small-thead" id="Table1" runat="server">
			<thead>
                <tr class="font-white">
                    <th class="celeste-claro text-center">Solicitud</th>
                    <th class="celeste-claro text-center">Area</th>
                    <th class="celeste-claro text-center">Fecha Ingreso</th>
                    <th class="celeste-claro text-center">Fecha Salida</th>
                    <th class="celeste-claro text-center">Tipo Solicitud</th>
                    <th class="celeste-claro text-center">Solicitante</th>
                    <th class="celeste-claro text-center">Observación</th>
                    <th class="celeste-claro text-center">Ficha</th>
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
                   <td><span runat="server" style="text-align:left !important;" id="lblObservacion"></span></td>
                   <td><span runat="server" style="text-align:left !important;" id="lblDescargar"></span></td>
                </tr>   
            </tbody>
        </table>
    <div id="formCreditoUnaCuotaCuoton" runat="server">
        <div class="col-xs-12">
            <div class="well-white">
                <h5 style="font-weight:bold">Tenencia de Productos - Marcas Cliente</h5>
                <div class="row form-group">
                    <div class="col-xs-2">
                        <input type="checkbox" id="cboxCtaCte" runat="server"> Cuenta Corriente
                    </div>
                    <div class="col-xs-6">
                        <strong>Segmento:</strong>&nbsp;&nbsp;
                        <input type="checkbox" id="cboxSegMasiva" runat="server"> Masiva &nbsp;
                        <input type="checkbox" id="cboxSegMedia" runat="server"> Renta Media &nbsp; 
                        <input type="checkbox" id="cboxSegAlta" runat="server"> Renta Alta &nbsp;
                        <input type="checkbox" id="cboxSegPyme" runat="server"> Pyme &nbsp;
                        <input type="checkbox" id="cboxSegEmpresa" runat="server"> Empresas 
                    </div>
                    <div class="col-xs-4">
                        <strong>Cliente:</strong>&nbsp&nbsp;
                        <input type="checkbox" id="cboxDigital" runat="server"> Digital &nbsp;
                        <input type="checkbox" id="cboxActivo" runat="server"> Activo &nbsp;
                        <input type="checkbox" id="cboxVinculado" runat="server"> Vinculado &nbsp;
                        <input type="checkbox" id="cboxPremium" runat="server"> Premium
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-8">
                        <strong>Tarjeta de Crédito:</strong>&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcCualquiera" runat="server"> Cualquiera&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcMastercard" runat="server"> Mastercard&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcAmex" runat="server"> Amex&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcVisa" runat="server"> Visa&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcGold" runat="server"> Gold&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcPlatinum" runat="server"> Platinum&nbsp;&nbsp;
                        <input type="checkbox" id="cboxTcWorldMember" runat="server"> World Member&nbsp;&nbsp;
                    </div>
                    <div class="col-xs-2">
                        <label class="control-label">Cupo Total ></label>
                        <asp:TextBox ID="txtTcCupoTotal" CssClass="form-control input-sm" runat="server" onkeypress="return validarN(event)"></asp:TextBox>
                    </div>  
                    <div class="col-xs-2">
                        <label class="control-label">Cupo Disponible ></label>
                        <asp:TextBox ID="txtTcCupoDisponible" CssClass="form-control input-sm" runat="server" onkeypress="return validarN(event)"></asp:TextBox>
                    </div>      
                </div>
                <div class="row form-group">
                    <div class="col-xs-4">
                        <strong>Inversiones:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxFFMM" runat="server"> FFMM &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxDAP" runat="server"> DAP &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="col-xs-5">
                        <strong>Créditos:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxHipotecario" runat="server"> Hipotecario &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxComercial" runat="server"> Comercial &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxConsumo" runat="server"> Consumo &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="col-xs-3">
                    </div>     
                </div>
            </div>
            <div class="well-white">
                <h5 style="font-weight:bold">Datos Personales</h5>
                <div class="row form-group">
                    <div class="col-xs-12">
                        <label class="control-label" runat="server" id="Label5">Región:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <select class="selectpicker" name="region" id="cboRegion" runat="server">
                            <option value="Cuaquiera">Cualquiera</option>
                            <option value="Metropolitana">Metropolitana</option>
                            <option value="Regiones">Regiones</option>
                        </select>
                    </div>   
                </div>
                <div class="row form-group">
                    <div class="col-xs-3">
                        <label class="control-label">Renta ></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="text" name="quantity" id="txtRenta" runat="server" style="width:100px" />
                    </div>   
                    <div class="col-xs-3">
                        <label class="control-label" runat="server" id="Label2">Edad: de&nbsp;&nbsp;</label>
                        <input type="text" name="quantity" id="txtEdadDesde" runat="server" style="width:50px" min="18" max="80" />
                        <label>a&nbsp;&nbsp;</label>
                        <input type="text" id="txtEdadHasta" runat="server" style="width:50px" name="quantity" min="18" max="80" />
                    </div>  
                    <div class="col-xs-4">
                        <label class="control-label" runat="server" id="Label3">Sexo:</label>
                        <select class="selectpicker" name="sexo" id="cboSexo" runat="server">
                            <option value="Cuaquiera">Cualquiera</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Femenino">Femenino</option>
                        </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <label class="control-label" runat="server" id="Label4">Estado Civil:</label>
                        <select class="selectpicker" name="estadoCivil" id="cboEstadoCivil" runat="server">
                            <option value="Cualquiera">Cualquiera</option>
                            <option value="Soltero">Soltero</option>
                            <option value="Casado">Casado</option>
                            <option value="Unión Civil">Unión Civil</option>
                            <option value="Divorciado">Divorciado</option>
                        </select>
                    </div>  
                    <div class="col-xs-2">
                        <input type="checkbox" id="cboxVehiculo" runat="server"> Registra Vehículo
                    </div>              
                </div>
            </div>
            <div class="well-white">
                <h5 style="font-weight:bold">Compras en Comercios</h5>
                <div class="row form-group">
                    <div class="col-xs-3">
                         <strong>Seleccione los rubros deseados:</strong>                      
                    </div>
                    <div class="col-xs-9">
                        <asp:DropDownList ID="cboRubroComercial1" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="cboRubroComercial2" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:DropDownList ID="cboRubroComercial3" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:DropDownList ID="cboRubroComercial4" runat="server"></asp:DropDownList>                       
                    </div>
                </div>  
                <div class="row form-group">
                    <div class="col-xs-3">
                        <strong>Fecha de compras:</strong> 
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cboFechaCompras" runat="server"></asp:DropDownList>
                    </div>
                </div>              
            </div>
            <div class="well-white">
                <h5 style="font-weight:bold">Exclusiones</h5>
                <div class="row form-group">
                    <div class="col-xs-4">
                         <strong>Seleccione los grupos de clientes a excluir:</strong>                      
                    </div>
                    <div class="col-xs-8">
                        <input type="checkbox" id="cboxMorosos" runat="server" /> Morosos &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxMolestos" runat="server" /> Molestos &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxFallecidos" runat="server" /> Fallecidos &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="checkbox" id="cboxMailNoValido" runat="server" /> Mail no válido &nbsp;&nbsp;&nbsp;&nbsp;
                    </div>                     
                </div>             
            </div>
            <div class="row text-center footer-form">	
                  <asp:button runat="server" ID="btnGenerar" OnClick="validaDatos" class="btn btn-primary"  Text="Generar">
                  </asp:button>	
			</div><!--fin form productos-->
            <!--FIN WELL-->
        </div>
    </div>

</asp:Content>
