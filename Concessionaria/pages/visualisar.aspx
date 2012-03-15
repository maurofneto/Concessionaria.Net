<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="visualisar.aspx.cs" Inherits="Concessionaria.visualisar" ClientIDMode="Static" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="TableFiltros" runat="server" GridLines="Both">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelNome" runat="server" Text="Nome:" />
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxNome" runat="server" OnTextChanged="TextBoxNome_OnTextChanged" AutoPostBack="true" />
            </asp:TableCell><asp:TableCell runat="server">
                <asp:Label ID="LabelLoja" runat="server" Text="Loja:" />
            </asp:TableCell><asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownListLoja" runat="server" OnSelectedIndexChanged="DropDownListLoja_OnSelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled"></asp:DropDownList>
            </asp:TableCell></asp:TableRow></asp:Table>
    <img src="../Content/xml.png" id="imgXml" width="32" height="32"/>
    <asp:Table ID="tblDados" runat="server" GridLines="Both">
    </asp:Table>
    <div id="divVeiculo"></div>
    <div id="divLoja"></div>
    <div id="divXml" style="display: none;"><textarea id="TextAreaXml" cols="100" rows="20" wrap="true"></textarea></div>
    <script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function buscarVeiculo(id) {
            $("#divVeiculo").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            var dados = {
                Id: id
            };
            var request = $.ajax({
                type: "POST",
                url: "../ajax/CRUD/Veiculo/crudVeiculo.aspx?acao=buscar",
                data: dados
            });

            request.done(function (data) {
                $("#divVeiculo").html(data);
            });

            request.fail(function (jqXHR, textStatus) {
                $("#divVeiculo").html("");
                alert("Request failed: " + textStatus);
            });
        };
        
        function excluirVeiculo(id) {
            if (confirm("Deseja realmente excluir este veículo?")) {
                $("#divVeiculo").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
                var dados = {
                    Id: id
                };
                var request = $.ajax({
                    type: "POST",
                    url: "../ajax/CRUD/Veiculo/crudVeiculo.aspx?acao=excluir",
                    data: dados
                });

                request.done(function (data) {
                    $("#divVeiculo").html(data);
                });

                request.fail(function (jqXHR, textStatus) {
                    $("#divVeiculo").html("");
                    alert("Request failed: " + textStatus);
                });
            }
        };
        $("#imgXml").click(function () {
            var dados = {
                Loja: $("#DropDownListLoja").val(),
                Nome: $("#TextBoxNome").val()
            };
            var request = $.ajax({
                type: "POST",
                url: "../ajax/geraXmlDados.aspx",
                data: dados
            });

            request.done(function (data) {
                $("#divXml").show();
                $("#TextAreaXml").val(data);
            });

            request.fail(function (jqXHR, textStatus) {
                $("#divXml").hide();
                alert("Request failed: " + textStatus);
            });
        });
    </script></asp:Content>