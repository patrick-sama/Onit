﻿showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

ajaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else {
                    $('#form-modal .modal-body').html(res.html);
                }
                 
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}


//Show Modal.
function AperturaModal() {
    $("#nuovoArrivoModal").modal();
}

//Aggiunta di piu componente.
$("#addToList").click(function (e) {
    e.preventDefault();

    if ($.trim($("#ComponenteCodice").val()) == "" || $.trim($("#quantity").val()) == "") return;

    var ComponenteId = $("#ComponenteCodice").val(),
        quantity = $("#quantity").val(),
        detailsTableBody = $("#detailsTable tbody");

    var componente = '<tr><td>' + ComponenteId + '</td><td>' + quantity + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(componente);
    clearItem();
});
// Add A New Component In The List, Clear Clean The Form For Add More items.
function clearItem() {
    $("#ComponenteCodice").val('');
    $("#quantity").val('');
}
//  Add/Remove A New Component In The List
$(document).on('click', 'a.deleteItem', function (e) {
    e.preventDefault();
    var $self = $(this);
    if ($(this).attr('data-itemId') == "0") {
        $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
            $(this).remove();
        });
    }
});


//After Click Save Button Pass All Data View To Controller For Save Database
function SalvaComponenteCarello(data) {
    var t = $("input[name='__RequestVerificationToken']").val();
    return $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: "/Arrivi/json",
        data: data,
        headers:
        {
            "RequestVerificationToken": t
        },
        success: function (result) {
            alert(result);
            location.reload();
        },
        error: function () {
            console.log(data);
        }
    });
}

//Collect Multiple Component in the List to Pass them To Controller
$("#SubmitArrivo").click(function (e) {
    //validation
        $("form[name='ArriviForm']").validate({
            // Specify validation rules
            rules: {
                // The key name on the left side is the name attribute
                // of an input field. Validation rules are defined
                // on the right side
                Identificativo: "required",
                Matricola: "required",
                Descrizione: "required",
                Locazione: "required"
            },
            // Specify validation error messages
            messages: {
                Identificativo: "Inserimento del codice identificativo obligatorio",
                Matricola: "Inserimento della matricola obligatorio",
                Descrizione: "Inserimento di una descrizione obligatorio",
                Locazione: "Inserimento della locazione obligatorio",
            },
            // Make sure the form is submitted to the destination defined
            // in the "action" attribute of the form when valid
            submitHandler: function (form) {
                form.submit();
            }
        });
    e.preventDefault();

    var componenteDelCar = [];
    componenteDelCar.length = 0;

    $.each($("#detailsTable tbody tr"), function () {
        componenteDelCar.push({
            ComponenteId: $(this).find('td:eq(0)').html(),
            Qty: parseInt($(this).find('td:eq(1)').html()),
        });
    });


    var data = JSON.stringify({
        CodiceLocazione: $("#Locazione").val(),
        AreaId: parseInt($("#Area").val()),
        Matricola: $("#Matricola").val(),
        Descrizione: $("#Descrizione").val(),
        Identificativo: $("#Identificativo").val(),
        ComponenteCarello: componenteDelCar
    });

    $.when(SalvaComponenteCarello(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });
});




//////////////////////////////////////////
/*
$("#SubmitArrivo").click(function (e) {
    e.preventDefault();
    var data;

    $.each($("#detailsTable tbody tr"), function () {
        data = {
            "Qty": parseInt($(this).find('td:eq(1)').html()),
            "CarelloId": 1,
            "ComponenteId": $(this).find('td:eq(0)').html()
        };
        JSON.stringify(data);
        SalvaComponenteCarello(data);
    });  
});

//Salva componente del carello 
function SalvaComponenteCarello(data) {
    var t = $("input[name='__RequestVerificationToken']").val();
    return $.ajax({
        contentType: 'application/json',
        dataType: 'json',
        type: 'POST',
        url: '/Arrivis/json',
        data: JSON.stringify(data),
        headers:
        {
            "RequestVerificationToken": t
        },
        success: function (result) {
            alert(result);
            location.reload();
        },
        error: function () {
            console.log(data);
        }
    });
}  */