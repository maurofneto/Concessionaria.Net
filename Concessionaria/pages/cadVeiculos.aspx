<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadVeiculos.aspx.cs" Inherits="Concessionaria.pages.cadVeiculos" ClientIDMode="Static" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="TableCadVeiculo" runat="server" GridLines="None">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelNome" runat="server" Text="Nome:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelMarca" runat="server" Text="Marca:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxMarca" runat="server"></asp:TextBox>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelAno" runat="server" Text="Ano:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxAno" runat="server"></asp:TextBox>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelModelo" runat="server" Text="Modelo:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxModelo" runat="server"></asp:TextBox>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelCor" runat="server" Text="Cor:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBoxCor" runat="server"></asp:TextBox>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="LabelLoja" runat="server" Text="Loja:"></asp:Label>
            
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownListLoja" runat="server" >
                </asp:DropDownList>
                &nbsp;
                <img src="../Content/add.png" id="ImageButtonAddLoja" align="top" width="24" height="24" />
                <!-- <asp:ImageButton ImageAlign="Top" ID="ImageButtonAddLoja" ImageUrl="../Content/add.png" runat="server" Width="24" Height="24" /> -->
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" ColumnSpan="2" HorizontalAlign="Center">
                <img src="../Content/save.png" id="ImageButtonSalvar" align="Top" width="24" height="24" />
                <!-- <asp:ImageButton ID="ImageButtonSalvar" runat="server" 
                                ImageUrl="../Content/save.png" ImageAlign="Top" Width="24" Height="24" /> -->
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Content/cancel.png" id="ImageButtonCancelar" align="Top" width="24" height="24" />
                <!-- <asp:ImageButton ID="ImageButtonCancelar" runat="server" 
                                ImageUrl="../Content/cancel.png" ImageAlign="Top" Width="24" Height="24" /> -->
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div id="divResultado"></div>
    <br/>
    <br/>
    <div id="divLoja"></div>
    <script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function limparForm() {
            $("#TextBoxNome").val('');
            $("#TextBoxMarca").val('');
            $("#TextBoxAno").val('');
            $("#TextBoxModelo").val('');
            $("#TextBoxCor").val('');
            $("#DropDownListLoja").val(0);
            $("#TextBoxNome").focus();
        };

        $("#ImageButtonAddLoja").click(function () {
            $("#divLoja").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            var dados = {};
            var request = $.ajax({
                type: "POST",
                url: "../ajax/cadLojaAjax.aspx",
                data: dados
            });

            request.done(function (data) {
                $("#divLoja").html(data);
            });

            request.fail(function (jqXHR, textStatus) {
                $("#divLoja").html("");
                alert("Request failed: " + textStatus);
            });
        });
        $("#ImageButtonSalvar").click(function () {
            $("#divResultado").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            var dados = {
                Nome: $("#TextBoxNome").val(),
                Marca: $("#TextBoxMarca").val(),
                Ano: $("#TextBoxAno").val(),
                Modelo: $("#TextBoxModelo").val(),
                Cor: $("#TextBoxCor").val(),
                Loja: $("#DropDownListLoja").val()
            };
            var request = $.ajax({
                type: "POST",
                url: "../ajax/CRUD/Veiculo/crudVeiculo.aspx?acao=incluir",
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
        $("#ImageButtonCancelar").click(function() {
            limparForm();
        });
    </script>

</asp:Content>