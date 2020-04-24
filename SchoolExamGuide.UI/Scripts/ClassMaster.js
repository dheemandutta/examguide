
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

    $('#ClassName').val("");

    //$('input:checkbox').removeAttr('checked');
}

function Add() {
    var postUrl = $('#SaveUpdateClassMaster').val();

    var res = validate();
    if (res === false) {
        return false;
    }

    //alert($('#FirstName').val());

    var classM = {
        ID: $('#ID').val(),
        ClassName: $('#ClassName').val()
    };

    console.log(classM);

    $.ajax({
        url: postUrl,
        data: JSON.stringify({ classMaster: classM }),
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
    if ($.fn.dataTable.isDataTable('#ClassMasterTable')) {
        table = $('#ClassMasterTable').DataTable();
        table.destroy();
    }

    $("#ClassMasterTable").DataTable({
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
                "data": "ClassName", "name": "ClassName", "autoWidth": true
            },
            {
                "data": "ID", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="GetClassMasterByID(' + data + ')"><i class="fa fa-edit"></i></a>';
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

function GetClassMasterByID(ID) {
    console.log(ID);

    var x = $("#getClassMasterByID").val();

    $.getJSON(x, { ID: ID }, function (result) {
        console.log(result);

        $('#ClassName').val(result.ClassName);

        $('#ID').val(result.ID);

    });
    return false;
}


function Delete(ID) {
    var ans = confirm("Do you want to delete the record?");
    var deleteUrl = $('#deleteClassMaster').val();
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