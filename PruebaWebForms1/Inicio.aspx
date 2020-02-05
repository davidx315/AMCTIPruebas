<%@ Page Title="" Language="C#" MasterPageFile="~/Prueba.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PruebaWebForms1.Inicio" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
                 <div>
                   <a href="Pagina2.aspx">Pagina2</a>
                 </div>
                   <br />
                 <div>
                   <label>Ingrese el primer numero</label>
                   <asp:TextBox ID="txtPrimerNumero" runat="server" BackColor="WhiteSmoke" TextMode="Number" OnTextChanged="txtPrimerNumero_TextChanged" AutoPostBack="true"></asp:TextBox>
                   <br />
                   <label>Ingrese el segundo numero</label>
                   <asp:TextBox ID="txtSegundoNumero" runat="server" BackColor="WhiteSmoke" TextMode="Number"></asp:TextBox>
                   <br />
                   <asp:Button ID="btnGenerarResultado" runat="server" Text="Generar Resultado" OnClick="btnGenerarResultado_Click" />
                   <br />
                   <asp:Label ID="lblResultado" BackColor="Red" runat="server"></asp:Label>
                   <br />
                   <asp:Label ID="lblText1" BackColor="Green" runat="server"></asp:Label>

               </div>
        </ContentTemplate>
     </asp:UpdatePanel>      
</asp:Content>
