<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadLojaAjax.aspx.cs" Inherits="Concessionaria.ajax.cadLojaAjax" %>
<head>
    <style type="text/css">
        .style1
        {
            width: 51px;
        }

        .style2
        {
            width: 109px;
        }
    </style>
</head>
<img src="../Content/del.png" width="16" height="16" id="imgOcultarLoja" align="absmiddle"/>
Cadastro de Loja em Ajax
<br/>
<br/>
<table>
    <tr>
        <td class="style1">
            Nome:</td>
        <td class="style2">
            <input id="txtNomeLoja" type="text" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <img id="imgSalvarLoja" alt="Salvar" src="../Content/save.png" align="Top" width="24" height="24" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img id="imgCancelarLoja" alt="Cancelar" src="../Content/cancel.png" align="Top" width="24" height="24" />
        </td>
    </tr>
</table>
<div id="divResultadoLoja"></div>
<script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"> </script>
<script type="text/javascript">
        function limparFormLoja() {
            $("#txtNomeLoja").val('');
            $("#txtNomeLoja").focus();
        };

        $("#imgOcultarLoja").click(function() {
            $("#divLoja").html("");
        });

        $("#imgSalvarLoja").click(function() {
            $("#divResultadoLoja").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
            var dados = {
                Nome: $("#txtNomeLoja").val()
            };
            var request = $.ajax({
                    type: "POST",
                    url: "../ajax/CRUD/Loja/crudLoja.aspx?acao=incluir",
                    data: dados
                });

            request.done(function(data) {
                $("#divResultadoLoja").html(data);
                limparFormLoja();
            });

            request.fail(function(jqXHR, textStatus) {
                $("#divResultadoLoja").html("");
                alert("Request failed: " + textStatus);
            });

        });
        $("#imgCancelarLoja").click(function() {
            limparFormLoja();
        });
    </script>