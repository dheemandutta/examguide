//saveorupdatesubject
//drpClass
//txtSubjectName
//SaveOrUpate
//clearTextBox
//subjectTable


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
    $('#txtSubjectName').val("");
    $('#drpClass').val("");
    $('#ID').val('');
}

function saveorupdatesubject() {
    var postUrl = $('#saveorupdatesubject').val();

    var res = validate();

    if (res == false) {
        return false;
    }

    var subject = {
        ID: $('#ID').val(),
        SubjectName: $('#txtSubjectName').val(),
        ClassID: $('#drpClass').val()
    };

    $.ajax({
        url: postUrl,
        data: JSON.stringify({ subject: subject }),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result > 0) {                
                alert("Good job! Data Saved Successfully");
                clearTextBox();
                SetUpGrid();
            }
            else {
                alert("Sorry! Data Not Saved");
                clearTextBox();
                SetUpGrid();
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
    $.fn.dataTable.ext.errMode = 'none';

    if ($.fn.dataTable.isDataTable('#subjectTable')) {
        table = $('#subjectTable').DataTable();
        table.destroy();
    }

    $("#subjectTable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "bLengthChange": false,
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
                "data": "SubjectName", "name": "SubjectName", "autoWidth": true
            },
            {
                "data": "ID", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="GetSubjectMasterByID(' + data + ')"><i class="fa fa-edit"></i></a>';
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

function GetSubjectMasterByID(ID) {
    var x = $("#getsubjectbysubjectid").val();
    $.ajax({
        url: x,
        data: {
            ID: ID
        },
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        async: "false",
        datatype: "json",
        success: function (result) {
            $('#drpClass').val(result.ClassID);
            $('#txtSubjectName').val(result.SubjectName);
            $('#ID').val(result.ID);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Delete(ID) {
   
    var deleteUrl = $('#deletesubjectbyid').val();
    
        $.ajax({
            url: deleteUrl,
            data: JSON.stringify({ ID: ID }),
            type: "POST",
            contentType: "application/json;charser=UTF-8",
            dataType: "json",
            success: function (result) {
              
                if (result > 0) {
                    alert("Subject deleted successfully");
                    clearTextBox()
                    SetUpGrid();

                }
                else {
                    alert("Subject can not be deleted as this is already used.");
                    clearTextBox()
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
   
}