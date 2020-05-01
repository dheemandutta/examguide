function validate() {

    var myform = $('#MyForm');
    if (myform.parsley().validate()) {
        return true;
    }
    else {
        return false;
    }
}

function clearTextBox() {

    $('#ID').val('');
    $('#Name').val("");
    $('#State').val("");
    $('#District').val("");
    $('#ClassName').val("");
    $('#GuardiansName').val("");
    $('#GuardiansMob').val("");
    //$('input:checkbox').removeAttr('checked');
}

function Add() {
    var postUrl = $('#SaveUpdateStudentDetails').val();

    var res = validate();
    if (res === false) {
        return false;
    }

    //alert($('#FirstName').val());

    var studentD = {
        ID: $('#ID').val(),
        Name: $('#Name').val(),
        State: $('#State').val(),
        District: $('#District').val(),
        ClassName: $('#ClassName').val(),
        GuardiansName: $('#GuardiansName').val(),
        GuardiansMob: $('#GuardiansMob').val()
    };

    console.log(studentD);

    $.ajax({
        url: postUrl,
        data: JSON.stringify({ studentDetails: studentD }),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result > 0) {
                clearTextBox();
                SetUpGrid();
                swal("Good job!", "Data Saved Successfully", "success");

            }
            else {
                clearTextBox();
                SetUpGrid();
                swal("Sorry!", "Data Not Saved", "error");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadData() {
    var loadposturl = $('#loaddata').val();
    $.ajax({
        url: loadposturl,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            SetUpGrid();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function SetUpGrid() {
    var loadposturl = $('#loaddata').val();

    //do not throw error
    $.fn.dataTable.ext.errMode = 'none';
    //check if datatable is already created then destroy iy and then create it
    if ($.fn.dataTable.isDataTable('#StudentDetailsTable')) {
        table = $('#StudentDetailsTable').DataTable();
        table.destroy();
    }

    $("#StudentDetailsTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "bLengthChange": false, //disable entries dropdown
        "ajax": {
            "url": loadposturl,
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "Name", "name": "Name", "autoWidth": true
            },
            {
                "data": "State", "name": "State", "autoWidth": true
            },
            {
                "data": "District", "name": "District", "autoWidth": true
            },
            {
                "data": "ClassName", "name": "ClassName", "autoWidth": true
            },
            {
                "data": "GuardiansName", "name": "GuardiansName", "autoWidth": true
            },
            {
                "data": "GuardiansMob", "name": "GuardiansMob", "autoWidth": true
            },
            {
                "data": "ID", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="GetStudentDetailsByID(' + data + ')"><i class="fa fa-edit"></i></a>';
                }
            },
            {
                "data": "ID", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="Delete(' + data + ')"><i class="fa fa-trash"></i></a>';
                }
            }
        ]
    });
}

function GetStudentDetailsByID(ID) {
    console.log(ID);

    var x = $("#getStudentDetailsByID").val();

    $.getJSON(x, { ID: ID }, function (result) {
        console.log(result);

        $('#Name').val(result.StudentId);
        $('#State').val(result.StateId);
        $('#District').val(result.DistrictId);
        $('#ClassName').val(result.ClassId);
        $('#GuardiansName').val(result.GuardiansName);
        $('#GuardiansMob').val(result.GuardiansMob);

        $('#ID').val(result.ID);

    });
    return false;
}


function Delete(ID) {
    var ans = confirm("Do you want to delete the record?");
    var deleteUrl = $('#deleteStudentDetails').val();
    if (ans) {
        $.ajax({
            url: deleteUrl,
            data: JSON.stringify({ ID: ID }),
            type: "POST",
            contentType: "application/json;charser=UTF-8",
            dataType: "json",
            success: function (result) {

                if (result > 0) {
                    alert("Grade deleted successfully");

                    SetUpGrid();

                }
                else {
                    alert("Grade can not be deleted as this is already used.");
                }
            },
            error: function () {
                alert(errormessage.responseText);
            }
        });
    }
}