$(document).ready(function () {
    BindEmployeeGrid();
    $('#HireDate').datepicker({
        dateFormat: "dd/MM/yyyy"
    });
    $('#TerminationDate').datepicker({
        dateFormat: "dd/MM/yyyy"
    });
})
function AddEmployeeSuccess(data) {
    debugger;
    if (data) {
        $(':loading').loading('stop');
        window.location = $_EmployeeList;
    }
    else {
        return false;
    }

}
function onAddEditEmployee() {
    $('body').loading({
        stoppable: true,
        message: 'Updating Record........',
        theme: 'dark'
    });
}
function Actionbtn(cellvalue, options, rowObject) {
    var id = rowObject.EmployeeId;
    var html = '';
    html = "<a  id='" + id + "'  class='memberAction' name='" + id + "' style='color:blue;cursor:pointer;' type='button' title='Edit'  onClick='EditRecord(" + id + ")'  >EDIT</a>";
    html += "&nbsp;&nbsp;";
    html += "<a  id='" + id + "'  class='memberAction' name='" + id + "' style='color:blue;cursor:pointer;' type='button' title='delete'  onClick='DeleteRecord(" + id + ")'>Delete</a>";
    return html;
}
function EditRecord(Id) {
    window.location = $_EditEmployee + "?employeeid=" + Id
}
function DeleteRecord(Id) {
    if ((confirm("Are you sure you want to delete?"))) {
        $.ajax({
            type: 'Post',
            cache: 'false',
            url: $_DeleteEmployee ,
            data: { employeeId: Id },
            success: function (response) {                
                if (response) {
                    $("#jqlist").trigger("reloadGrid");
                }
            },
            error: function () {
                //$("#loader").hide();
            }
        });
    }
}
function formatDate(value) {
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
}
function ConvertHireDate(cellvalue, options, rowObject) {
    var date = new Date(parseInt(rowObject.HireDate.substr(6)));
    var parsedDate = formatDate(date);
    return parsedDate;

}
function ConvertTerminateDate(cellvalue, options, rowObject) {
    var date = new Date(parseInt(rowObject.HireDate.substr(6)));
    var parsedDate = formatDate(date);
    return parsedDate;

}
function BindEmployeeGrid() {
    $("#jqlist").jqGrid({
        url: $_GetEmployees,
        datatype: 'json',
        mtype: 'Get',
        colNames: ['EmployeeId', 'Title', 'FirstName', 'LastName', 'Address', 'HireDate', 'TerminationDate', 'Action'],
        colModel: [
            { key: true, hidden: true, name: 'EmployeeId', index: 'EmployeeId', editable: false },
            { key: false, name: 'Title', index: 'Title', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'FirstName', index: 'FirstName', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'LastName', index: 'LastName', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'Address', index: 'Address', editable: true, align: 'center' },
            { key: false, name: 'HireDate', index: 'HireDate', editable: true, align: 'center', formatter: ConvertHireDate },
            { key: false, name: 'TerminationDate', index: 'TerminationDate', editable: true, align: 'center', formatter: ConvertTerminateDate },
            { name: 'Action', index: 'Action', sortable: false, formatter: Actionbtn, align: "center" },

        ],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Employees list',
        emptyrecords: 'No Employees are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false,
        sortable: true,
        sortname: 'EmployeeId',
        sortorder: "desc",
    }).navGrid('#jqControls', { edit: false, add: false, del: false, search: true, refresh: true },
        {
            zIndex: 100,
            caption: "Search Employees",
            sopt: ['cn']
        }
        );
    $('#jqlist').jqGrid('setGridParam', { sortorder: 'desc' });
}