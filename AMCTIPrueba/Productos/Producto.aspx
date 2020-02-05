<%@ Page Title="" Language="C#" MasterPageFile="~/Amcti.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="AMCTIPrueba.Productos.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelProducto" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <div class="row">
         <div class="col-sm-12">
             <label class="control-label" for="">Tipo específico con calidad</label>
             <asp:DropDownList ID="ListaTitulo" runat="server" CssClass="form-control input-focused" AutoPostBack="true" Width="50%" OnSelectedIndexChanged="ListaTitulo_SelectedIndexChanged" />
         </div>
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <asp:GridView ID="gridProductos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="titulo" HeaderText="Titulo del Producto" />
            <asp:BoundField DataField="seccionRegistro" HeaderText="Registro" />
            <asp:BoundField DataField="nomPublicador" HeaderText="Nombre del Publicador" />
        </Columns>
    </asp:GridView>
</asp:Content>
