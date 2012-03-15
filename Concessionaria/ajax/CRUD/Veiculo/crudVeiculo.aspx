<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crudVeiculo.aspx.cs" Inherits="Concessionaria.ajax.CRUD.Veiculo.crudVeiculo" %>
<script src="../../../Scripts/jquery-1.6.4.min.js" type="text/javascript"> </script>
<script type="text/javascript">
    function salvarVeiculo(id) {
        $("#divResultadoEdit").html('<img src="../Content/loading.gif" width="24" height="24" /> Carregando...');
        var dados = {
            Id: id,
            Nome: $("#txtNome").val(),
            Marca: $("#txtMarca").val(),
            Ano: $("#txtAno").val(),
            Modelo: $("#txtModelo").val(),
            Cor: $("#txtCor").val(),
            Loja: $("#cboLoja").val()
        };
        /*
        alert("Nome:" + dados.Nome + "\nMarca:" + dados.Marca + "\nAno:" +
            dados.Ano + "\nModelo:" + dados.Modelo + "\nCor:" + dados.Cor + "\nLoja:" + dados.Loja);
        */
        var request = $.ajax({
                type: "POST",
                url: "../ajax/CRUD/Veiculo/crudVeiculo.aspx?acao=salvar",
                data: dados
            });

        request.done(function(data) {
            $("#divResultadoEdit").html(data);
            $("#formVeiculo").hide();
        });

        request.fail(function(jqXHR, textStatus) {
            $("#divResultadoEdit").html("");
            alert("Request failed: " + textStatus);
        });
    };
    </script>