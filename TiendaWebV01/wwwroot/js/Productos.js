function ObtenerProductosByCategoria(IdCategoria, Nombre) {
    var IdMarca = document.getElementById("SelectMarca").value;
    var URL = '/Home/ProductosByCategoria';
    $.ajax({
        type: 'GET',
        url: URL,
        data: {
            IdCategoria: IdCategoria,
            IdMarca: IdMarca
        },
        success: function (data) {
            $("#div_Productos").html('');
            $("#div_Productos").html(data);
        }
    });
    document.getElementById("spanCategoria").innerText = Nombre;
    document.getElementById("SelectCategoria").value = IdCategoria;
};
function ObtenerProductosByMarca(IdMarca, Nombre) {
    var IdCategoria = document.getElementById("SelectCategoria").value;
    var URL = '/Home/ProductosByMarca';
    $.ajax({
        type: 'GET',
        url: URL,
        data: {
            IdCategoria: IdCategoria,
            IdMarca: IdMarca
        },
        success: function (data) {
            $("#div_Productos").html('');
            $("#div_Productos").html(data);
        }
    });
    document.getElementById("spanMarca").innerText = Nombre;
    document.getElementById("SelectMarca").value = IdMarca;
};