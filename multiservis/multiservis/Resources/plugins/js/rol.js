﻿var est = true;
$(document).ready(function () {
    Listar();
});

$('#activo').click(function () {
    est = true;
});

$('#inactivo').click(function () {
    est = false;
});

function CargarEstadoEnChck(flag) {
    if (flag) {
        $('#activo').prop('checked', true);
    }
    else {
        $('#inactivo').prop('checked', true);
    }
};

function LimpiarCampos() {
    $('#id').val(0);
    $('#nombre').val('');
};

function Nuevo() {
    LimpiarCampos();
    est = true;
    CargarEstadoEnChck(est);
    $('#modalDatos').modal('open');
    var codigo = '<p class="red-text text-darken-3 flow-text">CREAR NUEVO ROL</p>';
    $('#cabeceraModal').html(codigo);
};

$('#aceptar').click(function () {
    if (EvaluarVacios()) {
        Guardar();
    }
});

$('#cancelar').click(function () {
    LimpiarCampos();
    $('#modalDatos').modal('close');
});

function EvaluarVacios() {
    if ($('#nombre').val() == '') {
        Materialize.toast('El campo nombre no puede estar vacio!', 8000);
        return false;
    }
    else {
        return true;
    }
};

function Guardar() {
    var i = $('#id').val();
    var nom = $('#nombre').val();
    $.getJSON("/Rol/Guardar", { id: i, nombre: nom, estado: est }, function (e) {
        if (e != "") {
            Materialize.toast(e, 8000);
        }
        else {
            Materialize.toast('Registro exitoso!', 8000);
            LimpiarCampos();
            $('#modalDatos').modal('close');
            Listar();
        }
    });
    Listar();
};

function Editar(id) {
    var o = { id: id };
    $.getJSON("/Rol/Get", o, function (obj) {

        var codigo = '<p class="red-text text-darken-3 flow-text">EDITAR ' + obj.nombre + '</p>';
        $('#cabeceraModal').html(codigo);
        $("#id").val(id);
        $("#nombre").val(obj.nombre);
        est = obj.estado;
        CargarEstadoEnChck(est);
        Materialize.updateTextFields();
    });
    $('#campo_estado').show();
    $('#modalDatos').modal('open');
};

function Listar() {
    $.getJSON("/Rol/Listar", null, function (cadena) {
        $("#tabla").html(cadena);
        CrearDataTable();
    });
    $('#btnListar').show();
};
function ModalConfirmar(id, nom) {
    $('#idEliminar').val(id);
    $('#nomEliminar').val(nom);
    var codigo = '<p class="red-text text-darken-3 flow-text">Esta seguro que desea Eliminar ' + nom + '?</p>';
    $('#cabeceraModalEliminar').html(codigo);
    $('#modalEliminar').modal('open');
};

$('#aceptarEliminar').click(function () {
    Eliminar($('#idEliminar').val());
    $('#modalEliminar').modal('close');
    Materialize.toast('El rol fue eliminado exitosamente!', 8000);
    Listar();
});

$('#cancelarEliminar').click(function () {
    $('#idEliminar').val('');
    $('#nomEliminar').val('');
    $('#modalEliminar').modal('close');
});

function Eliminar(id) {
    var o = { id: id };
    $.getJSON("/Rol/Delete", o, function (e) {
        Listar();
    });
};
