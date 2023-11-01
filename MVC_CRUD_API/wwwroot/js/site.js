$(document).ready(function () {
    var globalId = "";
    Getdata();
});

/*$('#create').click()*/

function Getdata() {
    $.ajax({
        type: "GET",
        url: "Home/GetData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (i, item) {
                rows = "<tr>" +
                    "<td>" + item.name + "</td>" +
                    "<td>" + item.email + "</td>" +
                    "<td>" + item.phone + "</td>" +
                    "<td>" + item.address + "</td>" +
                    "<td> <a href='#' onclick='GetByID(\"" + item.id + "\");' data-bs-target='#UpdateByID' >Edit</a>  </td> " +
                    "<td> <a href='#' onclick='Info(\"" + item.id + "\");' data-bs-target='#DetailByID'>Info</a>  </td> " +
                    "<td> <a href='#' onclick='OpenDeleteModal(\"" + item.id + "\");' data-bs-target='#Delete' >Delete</a>  </td> </tr>";
                $('#Table').append(rows);
            });
        },
        failure: function (data) {
            alert("failure");
        },
        error: function (data) {
            /*alert("error from get data function");*/
        }
    });
}


function GetByID(id) {
    $.ajax({
        type: "GET",
        url: "Home/GetById/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#UpdateByID').modal("show");
            $('#ID').val(data.id);
            $('#name').val(data.name);
            $('#Uemail').val(data.email);
            $('#phone').val(data.phone);
            $('#address').val(data.address);
        },
        error: function (errormessage) {
            alert(errormessage);
        }
    });
}

function addvalidation() {
    var res = validate();
    if (res == false) {
        return false;
    }
    add();
}

function add() {
    var empmvc = {
        name: $("#namecreate").val(),
        address: $("#addresscreate").val(),
        email: $("#emailcreate").val(),
        phone: $("#phonecreate").val(),
    };

    $.ajax({
        url: "/Home/Create",
        type: "POST",
        data: JSON.stringify(empmvc),
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            $('#create').modal('hide');
            /*Getdata();*/
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Info(id) {
    $.ajax({
        type: "GET",
        url: "Home/GetById/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#DetailByID').modal("show");
            $('#IDinfo').val(data.id);
            $('#nameinfo').val(data.name);
            $('#emailinfo').val(data.email);
            $('#phoneinfo').val(data.phone);
            $('#addressinfo').val(data.address);
            // For Disable input
            $('#nameinfo').prop('disabled', true);
            $('#emailinfo').prop('disabled', true);
            $('#phoneinfo').prop('disabled', true);
            $('#addressinfo').prop('disabled', true);
        },
        error: function (errormessage) {
            alert(errormessage);
        }
    });
}


function Update() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var empmvc = {
        id: $('#ID').val(),
        name: $("#name").val(),
        email: $("#Uemail").val(),
        address: $("#address").val(),
        phone: $("#phone").val(),
    };
    $.ajax({
        url: "/Home/Update/",
        data: JSON.stringify(empmvc),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#ID').val(data.id);
            $('#name').val(data.name);
            $('#Uemail').val(data.email);
            $('#address').val(data.address);
            $('#phone').val(data.phone);
            $('#UpdateByID').modal('hide');
        },
        error: function (errormessage) {
            alert("Something Went Wrong!!!!");
        }
    });
}


function OpenDeleteModal(id) {
    globalId = id;
    $('#Delete').modal('show');
}
function ConfirmDelete() {
    $.ajax({
        url: "Home/Delete/" + globalId,
        type: "Get",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function () {
            $('#deleteContactModal').modal('hide');
            /*Getdata();*/
            location.reload();
        },
        error: function (errormessage) {
        }
    });
    return false;
}

function validate() {
    var isValid = true;
    if ($('#namecreate').val().trim() == "") {
        $('#namecreate').css('border-color', 'Red');
        $('#valfname').text('Name required');
        isValid = false;
    }
    else {
        $('#namecreate').css('border-color', 'lightgrey');
        $('#valfname').text();
        isValid = true;
    }

    if ($('#emailcreate').val().trim() == "") {
        $('#emailcreate').css('border-color', 'Red');
        $('#email').text('Email required');
        isValid = false;
    }
    else {
        $('#emailcreate').css('border-color', 'lightgrey');
        $('#email').text();
        isValid = true;
    }
    if ($('#phonecreate').val().trim() == "") {
        $('#phonecreate').css('border-color', 'Red');
        $('#phonevalidation').text('Number requered');
        isValid = false;
    }
    else {
        $('#phonecreate').css('border-color', 'lightgrey');
        $('#phonevalidation').text();
        isValid = true;
    }
    if ($('#addresscreate').val().trim() == "") {
        $('#addresscreate').css('border-color', 'Red');
        $('#addressval').text('Address required');
        isValid = false;
    }
    else {
        $('#addresscreate').css('border-color', 'lightgrey');
        $('#addressval').text();
        isValid = true;
    }
    return isValid;
}