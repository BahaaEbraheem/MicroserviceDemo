$(function () {
    var l = abp.localization.getResource('RemittanceManagement');
    var _dataTable = $('#RemittancesTableSupervisor').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            processing: true,
            autoWidth: false,
            scrollCollapse: true,
            order: [[1, "desc"]],
            ajax: abp.libs.datatables.createAjax(remittanceManagement.remittances.remittance.getListRemittancesForSupervisor),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Approve'),
                                    visible: abp.auth.isGranted('RemittanceManagement.Remittance.Approved'),
                                    action: function (data) {
                                        remittanceManagement.remittances.remittance
                                            .setApprove(data.record)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    }
                                },                               
                            ]
                    }
                },
                {
                    title: l('SerialNumber'),
                    data: "serialNumber"
                },
                {
                    title: l('Amount'),
                    data: "amount",
                  
                },
                {
                    title: l('TotalAmount'),
                    data: "totalAmount",
                  
                },
                {
                    title: l('ReceiverFullName'),
                    data: "receiverFullName",

                }, {
                    title: l('CurrencyName'),
                    data: "currencyName",

                }, {
                    title: l('SenderName'),
                    data: "senderName",

                }, {
                    title: l('State'),
                    data: "state",

                }, {
                    title: l('StatusDate'),
                    data: "statusDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
           
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );






});
