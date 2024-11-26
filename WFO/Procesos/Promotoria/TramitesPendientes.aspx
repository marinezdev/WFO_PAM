﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramitesPendientes.aspx.cs" Inherits="WFO.Procesos.Promotoria.TramitesPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Trámites Pendientes </h2>
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
                                        <th>&nbsp;</th>
                                        <th>Fecha de registro</th>
                                        <th>Número de trámite</th>
                                        <th>Orden de Trabajo</th>
                                        <th>Operación</th>
                                        <th>Nombre del asegurado</th>
                                        <th>Fecha Firma de Solicitud </th>
                                        <th>Stauts</th>
                                        <th>Prima Total</th>
                                        <th>Prima Excedente</th>
                                        <th>Diferencia en Prima</th>
                                        <th>Número póliza</th>
                                        <th>KWIK</th>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/folder.png" CommandName ="Consultar" CommandArgument='<%# Eval("Id")%>' /></td>
                                <td><%#Eval("FechaRegistro","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                <td><%#Eval("FolioCompuesto")%></td>
                                <td><%#Eval("NumeroOrden")%></td>
                                <td><%#Eval("Operacion")%></td>
                                <td><%#Eval("Contratante")%></td>
                                <td><%#Eval("FechaSolicitud","{0:dd/MM/yyyy }")%></td>
                                <td><%#Eval("Estatus")%></td>
                                <td><%#Eval("PrimaTotal")%></td>
                                <td><%#Eval("PrimaExcedente")%></td>
                                <td><%#Eval("PrimaDiferencia")%></td>
                                <td><%#Eval("IdSisLegados")%></td>
                                <td><%#Eval("kwik")%></td>
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
    </div>

</asp:Content>
