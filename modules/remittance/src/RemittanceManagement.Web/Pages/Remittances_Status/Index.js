$(function () {
    var l = abp.localization.getResource('RemittanceManagement');

 
    
    var _dataTable = $('#RemittancesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            processing: true,
            autoWidth: false,
            scrollCollapse: true,
            order: [[1, "desc"]],
        ajax: abp.libs.datatables.createAjax(remittanceManagement.remittances.remittance.getListRemittancesStatus),
        //ajax: abp.ajax($.extend(true, {
        //    url: abp.appPath + 'api/remittanceManagement/remittance/GetListRemittancesStatusAsync' ,
        //    type: 'GET',
        //})),
        columnDefs: [
            //    {
            //        rowAction: {
            //            items:
            //                [
            //                    {
            //                        text: l('Release'),
                                    
            //                    },
            //                ]
            //        }
            //},
            {
                title: l('SerialNumber'),
                data: "serialNumber"
            },


            {
                title: l('Amount'),
                data: "amount",

            }, {
                title: l('TotalAmount'),
                data: "totalAmount",

            }, {
                title: l('Type'),
                data: "type",
                render: function (data) {
                    return l('Enum:RemittanceType:' + data);
                }
            },
            {
                title: l('ApprovedDate'),
                data: "approvedDate"
            },  {
                title: l('ReleasedDate'),
                data: "releasedDate"
            }, {
                title: l('SenderName'),
                data: "senderName"
            }, {
                title: l('State'),
                data: "state",
                render: function (data) {
                    return l('Enum:Remittance_Status:' + data);
                }

            }, {
                    title: l('ReceiverFullName'),
                    data: "receiverFullName",

                }, {
                    title: l('CurrencyName'),
                    data: "currencyName",

                }
            ]
        })
    );




});
