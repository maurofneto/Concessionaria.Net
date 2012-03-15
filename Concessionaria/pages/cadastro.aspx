<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Concessionaria.pages.cadastro" ClientIDMode="Static" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <input type="button" id="btnInserir" value="Inserir dados de Teste" />
    <!-- <input id="btIncluir" type="button" value="Incluir com AJAX" /> -->
        
    <div id="divResultado">Resultado: </div>
    
    <script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $("#btnInserir").click(function () {
            
            $("#divResultado").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            
            var dados = {};
            var request = $.ajax({
                type: "POST",
                url: "../ajax/inserirDadosTeste.aspx?acao=inserir",
                data: dados
            });
            
            request.done(function (data) {
                $("#divResultado").html(data);
            });
            
            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
            
        });
    </script>

</asp:Content>
