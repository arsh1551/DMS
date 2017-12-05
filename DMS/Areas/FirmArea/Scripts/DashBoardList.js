$(document).ready(function myfunction() {
    BindPackageGrid();
});


function Actionbtn(cellvalue, options, rowObject) {
    var id = rowObject.ClientId;
    // var refNo = rowObject.Reference;
    var html = '';
    html = "<a  id='" + id + "'  class='memberAction' name='" + id + "' title='Edit'  onClick='EditRecord(" + id + ")'  ><i style='font-size:14px' class='fa fa-pencil-square-o'></i></a>";
    html += "&nbsp;&nbsp;";
    html += "<a  id='" + id + "'  class='memberAction' name='" + id + "' title='delete'  onClick='DeleteRecord(" + id + ")'><i style='font-size:14px' class='fa fa-trash-o' ></i></a>";


    return html;
}

function EditRecord(Id) {
   

    $.post("/FirmArea/Firm/GetClient/", { ClientId: Id }, function (response) {
        if (response.result == 'InvalidLogin') {
            //show invalid login
        }
        else if (response.result == 'Error') {
            //show error
        }
        else if (response.result == 'Redirect') {
            //redirecting to main page from here for the time being.
            window.location = response.url;
        }
    });
    //  $("#DivPlanForm").load(baseurl + "/FirmArea/Firm/GetClient/", { ClientId: Id });
    // window.load("/FirmArea/Firm/GetClient/", { ClientId: Id });
    //$.ajax({
    //    type: 'Post',
    //    cache: 'false',
    //    url: "/FirmArea/Firm/GetClient/",
    //    data: { ClientId: Id },
    //    success: function (response) {
    //        //console.log(response);
    //        if (response) {


    //        }

    //    },
    //    error: function () {
    //        //$("#loader").hide();

    //    }

    //});

}

function DeleteRecord(Id) {

    if ((confirm("Are you sure you want to delete?"))) {
        $.ajax({
            type: 'Post',
            cache: 'false',
            url: "/FirmArea/Firm/DeleteClient/",
            data: { Id: Id },
            success: function (response) {
                //console.log(response);
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

function BindPackageGrid() {
    debugger;
    $("#jqlist").jqGrid({

        url: "/FirmArea/Firm/GetClients/",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ClientId', 'FirstName', 'LastName', 'SSN', 'EmailAddress', 'PhoneNumber', ''],
        colModel: [
            { key: true, hidden: true, name: 'ClientId', index: 'ClientId', editable: true },
            { key: false, name: 'FirstName', index: 'FirstName', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'LastName', index: 'LastName', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'SSN', index: 'SSN', editable: true, sortable: true, align: 'center' },
            { key: false, name: 'EmailAddress', index: 'EmailAddress', editable: true, align: 'center' },
            { key: false, name: 'PhoneNumber', index: 'PhoneNumber', editable: true, align: 'center' },
            // { key: false, name: 'YearlyRate', index: 'YearlyRate', editable: true, edittype: 'select', editoptions: { value: { 'M': 'Male', 'F': 'Female', 'N': 'None' } } },
            //{ key: false, name: 'SetUpFee', index: 'ClassName', editable: true, edittype: 'select', editoptions: { value: { '1': '1st Class', '2': '2nd Class', '3': '3rd Class', '4': '4th Class', '5': '5th Class' } } },
            //   { key: false, name: 'CreatedDate', align: 'center', index: 'CreatedDate', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' } },

            { name: '', index: '', sortable: false, formatter: Actionbtn, align: "center" },

        ],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: '<h2>Client List</h2>',
        emptyrecords: 'No Plans Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: 2,
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false,
        sortable: true,
        sortname: 'FirstName',
        sortorder: "desc",
        //forceClientSorting: true,
        //loadonce: true
    }).navGrid('#jqControls', { edit: false, add: false, del: false, search: true, refresh: true },
        {
            zIndex: 100,
            caption: "Search Students",
            sopt: ['cn']
        }

        );

    //{
    //    zIndex: 100,
    //    url: '/Student/Edit',
    //    closeOnEscape: true,
    //    closeAfterEdit: true,
    //    recreateForm: true,
    //    afterComplete: function (response) {
    //        if (response.responseText) {
    //            alert(response.responseText);
    //        }
    //    }
    //},
    //{
    //    zIndex: 100,
    //    url: "/Student/Create",
    //    closeOnEscape: true,
    //    closeAfterAdd: true,
    //    afterComplete: function (response) {
    //        if (response.responseText) {
    //            alert(response.responseText);
    //        }
    //    }
    //},
    //{
    //    zIndex: 100,
    //    url: "/Student/Delete",
    //    closeOnEscape: true,
    //    closeAfterDelete: true,
    //    recreateForm: true,
    //    msg: "Are you sure you want to delete Student... ? ",
    //    afterComplete: function (response) {
    //        if (response.responseText) {
    //            alert(response.responseText);
    //        }
    //    }
    //});

    //$(".memberAction").click(function () {

    //    var pkgId = $(this).attr("id");
    //    //var ref = $(this).attr("name");
    //    alert("PackageId:" + pkgId);
    //    //do remove ajax call with mopId
    //});


}