<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="MisTramites.aspx.cs" Inherits="WFO.Procesos.Promotoria.MisTramites" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Mis trámites </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <p class="text-muted font-13 m-b-30">
                        Listado total de trámites registrados en el rango de 4 meses, a partir de la fecha del día de hoy. <asp:Label runat="server" ID="LabRespyuesta" Text=""></asp:Label>
                    </p>
                    <asp:Repeater ID="rptTramite" runat="server" OnItemCommand="rptTramite_ItemCommand">
                        <HeaderTemplate>
                            <table id="datatable-buttons" class="table table-striped table-bordered jambo_table bulk_action" style='width:100%'>
                                <thead>
                                    <tr>
                                        <th>Fecha de registro</th>
                                        <th>Número de trámite</th>
                                        <th>Orden de Trabajo</th>
                                        <th>Tipo Servicio</th>
                                        <th>Nombre del asegurado</th>
                                        <th>Fecha Firma de Solicitud </th>
                                        <th>Promotoría Clave</th>
                                        <th>Promotoría Zona</th>
                                        <th>Status</th>
                                        <th>Número de Póliza</th>
                                        <th>Prima total </th>
                                        <th>Prima excedente </th>
                                        <th>Prima diferencial </th>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("FechaRegistro","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                <td><%#Eval("FolioCompuesto")%></td>
                                <td><%#Eval("NumeroOrden")%></td>
                                <td><%#Eval("TipoServicio")%></td>
                                <td><%#Eval("Contratante")%></td>
                                <td><%#Eval("FechaSolicitud","{0:dd/MM/yyyy }")%></td>
                                <td><%#Eval("PromotoriaClave")%></td>
                                <td><%#Eval("PromotoriaZona")%></td>
                                <td><%#Eval("Estatus")%></td>
                                <td><%#Eval("IdSisLegados")%></td>
                                <td><%#Eval("PrimaTotal")%></td>
                                <td><%#Eval("PrimaExcedente")%></td>
                                <td><%#Eval("PrimaDiferencia")%></td>
                                <td><asp:ImageButton ID="imbtnConsultar" runat="server" ImageUrl="~/Imagenes/folder.png" CausesValidation="false" CommandName ="Consultar" CommandArgument='<%# Eval("Id")%>' /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

    <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Trámites por rango de fechas </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <p class="text-muted font-13 m-b-30">
                        Listado total de trámites registrados en el rango de 4 meses a partir de la fecha inicial, filtro realizado en base a fecha de registro al sistema.
                    </p>
                    <div class="row">
                        <asp:Label runat="server" ID="label1"  Font-Bold="True" Text="* Desde" class="control-label col-md-2 col-sm-2 col-xs-6"></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <dx:ASPxDateEdit ID="dtFechaTermino" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="" AutoPostBack="true">
                                <TimeSectionProperties>
                                    <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                </TimeSectionProperties>
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="dtFechaTermino" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                        </div>

                        <asp:Label runat="server" ID="labelFechaSolicitud"  Font-Bold="True" Text="* Hasta" class="control-label col-md-2 col-sm-2 col-xs-6"></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <dx:ASPxDateEdit ID="dtFechaInicio" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="" AutoPostBack="true" >
                                <TimeSectionProperties>
                                    <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                </TimeSectionProperties>
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="dtFechaInicio" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                        </div>

                        

                        
                    </div>

                    <div class="row">
                        <asp:Label ID="lblProducto" runat="server" Text="* Estado tramite" Font-Bold="true" class="control-label col-md-2 col-sm-2 col-xs-6 "></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <asp:DropDownList ID="LisCat_StatusTramite" runat="server" class="form-control">
                                <asp:ListItem Value=" ">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LisCat_StatusTramite" ErrorMessage="*" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-1 col-sm-1 col-xs-12 text-center">
                            <asp:Button ID="BtnContinuar" runat="server"  AutoPostBack="True" Text="Consultar" Class="btn btn-success" OnClick="BtnConsultar_Click"/>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-12 text-center">
                            <code><asp:Label ID="Mensajes" runat="server"></asp:Label></code>
                        </div>
                    </div>

                    <asp:Repeater ID="RepeaterFechas" runat="server" OnItemCommand="rptTramite_ItemCommand" Visible="false">
                        <HeaderTemplate>
                            <table id="example" class="table table-striped table-bordered jambo_table bulk_action" style='width:100%'>
                                <thead>
                                    <tr>
                                        <th>Fecha envío</th>
                                        <th>Número de trámite</th>
                                        <th>Orden de Trabajo</th>
                                        <th>Operación</th>
                                        <%--<th>Producto</th>--%>
                                        <th>Información del Contratante</th>
                                        <th>Fecha Firma de Solicitud </th>
                                        <th>Estado</th>
                                        <th>Número De Póliza De Los Sistemas Legados</th>
                                        <th>KWIK</th>
                                        <th>Prima total </th>
                                        <th>Prima excedente </th>
                                        <th>Prima diferencial </th>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("FechaRegistro","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                <td><%#Eval("FolioCompuesto")%></td>
                                <td><%#Eval("NumeroOrden")%></td>
                              <%--  <td><%#Eval("Operacion")%></td>--%>
                                <td><%#Eval("Producto")%></td>
                                <td><strong>Nombre: </strong><%#Eval("Contratante")%> <br /><%--<strong>RFC: </strong><%#Eval("RFC")%><br /><%#Eval("Titular")%>--%></td>
                                <td><%#Eval("FechaSolicitud","{0:dd/MM/yyyy }")%></td>
                                <td><%#Eval("Estatus")%></td>
                                <td><%#Eval("IdSisLegados")%></td>
                                <td><%#Eval("kwik")%></td>
                                <td><%#Eval("PrimaTotal")%></td>
                                <td><%#Eval("PrimaExcedente")%></td>
                                <td><%#Eval("PrimaDiferencia")%></td>
                                <td><asp:ImageButton ID="imbtnConsultar" runat="server" ImageUrl="~/Imagenes/folder.png" CommandName ="Consultar" CommandArgument='<%# Eval("Id")%>' /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        </ContentTemplate>
</asp:UpdatePanel>

    </div>
</asp:Content>
