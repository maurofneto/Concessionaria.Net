<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadLojas.aspx.cs" Inherits="Concessionaria.pages.cadLojas"  ClientIDMode="Static" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelNome" runat="server" Text="Nome:" />
            
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxNome" runat="server" />
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Center" ColumnSpan="2">
                <img src="../Content/save.png" id="imgSalvar" align="top" width="24" height="24"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Content/cancel.png" id="imgCancelar" align="Top" width="24" height="24" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div id="divResultado"></div>
    <script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function limparForm() {
            $("#TextBoxNome").val('');
            $("#TextBoxNome").focus();
        };

        $("#imgSalvar").click(function () {
            $("#divResultado").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            var dados = {
                Nome: $("#TextBoxNome").val()
            };
            var request = $.ajax({
                type: "POST",
                url: "../ajax/CRUD/Loja/crudLoja.aspx?acao=incluir",
                data: dados
            });

            request.done(function (data) {
                $("#divResultado").html(data);
                limparForm();
            });

            request.fail(function (jqXHR, textStatus) {
                $("#divResultado").html("");
                alert("Request failed: " + textStatus);
            });

        });
        $("#imgCancelar").click(function () {
            limparForm();
        });
    </script>
</asp:Content>