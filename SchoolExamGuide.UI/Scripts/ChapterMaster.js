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
    $('#drpClass').val("");
    $('#drpSubject').val("");
    $('#txtChapterName').val("");
    $('#Id').val('');
}

function saveorupdatechapter() {
    var postUrl = $('#saveorupdate').val();

    var res = validate();
    if (res == false) {
        return false;
    }

    var chapter = {
        Id: $('#Id').val(),
        ChapterName: $('#txtChapterName').val(),
        SubjectId: $('#drpSubject').val()
    };

    $.ajax({
        url: postUrl,
        data: JSON.stringify({ chapter: chapter }),
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

function loaddata() {
   
    var postUrl = $('#loaddata').val();
    $.ajax({
        url: postUrl,
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
    var postUrl = $('#loaddata').val();
   
    $.fn.dataTable.ext.errMode = 'none';

    if ($.fn.dataTable.isDataTable('#chapterTable')) {
        table = $('#chapterTable').DataTable();
        table.destroy();
    }

    $("#chapterTable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "bLengthChange": false,
        "ajax": {
            "url": postUrl,
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
                "data": "ChapterName", "name": "ChapterName", "autoWidth": true
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="GetChaptertMasterByID(' + data + ')"><i class="fa fa-edit"></i></a>';
                }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a href="#" onclick="Delete(' + data + ')"><i class="fa fa-trash"></i></a>';
                }
            }
        ]
    });
}

function GetChaptertMasterByID(Id) {
    var postUrl = $('#getchapterbychapterid').val();
    $.ajax({
        url: postUrl,
        data: {
            Id: Id
        },
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        async: "false",
        datatype: "json",
        success: function (result) {
            $('#drpClass').val(result.ClassID);
            $('#drpSubject').val(result.SubjectId);
            $('#txtChapterName').val(result.ChapterName);
            $('#ID').val(result.ID);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Delete(Id) {
    var deleteUrl = $('#deletechapterbychapterid').val();
    alert("Method called");
    $.ajax({
        url: deleteUrl,
        data: JSON.stringify({ Id: Id}),
        type: "POST",
        contentType: "application/json;charser=UTF-8",
        dataType: "json",
        success: function (result) {

            if (result > 0) {
                alert("Chapeter deleted successfully");
                clearTextBox()
                SetUpGrid();
            }
            else {
                alert("Chapter can not be deleted as this is already used.");
                clearTextBox()
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
