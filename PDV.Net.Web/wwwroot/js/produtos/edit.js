$(document).ready(() => {
    $('#ValorHelper').change(() => {
        $('#Valor').val($('#ValorHelper').cleanVal());
    });

    $('#CustoHelper').change(() => {
        $('#Custo').val($('#CustoHelper').cleanVal());
    });
});