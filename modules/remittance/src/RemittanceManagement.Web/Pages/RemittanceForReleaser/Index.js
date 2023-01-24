$(function () {
    var l = abp.localization.getResource('RemittanceManagement');
    var _releaseModal = new abp.ModalManager(abp.appPath + 'RemittanceForReleaser/Release');

    debugger


    var _dataTable = $('#RemittancesTableReleaser').DataTable(
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
            ajax: abp.libs.datatables.createAjax(remittanceManagement.remittances.remittance.getListRemittancesForReleaser),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Release'),
                                    visible: abp.auth.isGranted('RemittanceManagement.Remittance.Released'),
                                    action: function (data) {
                                        _releaseModal.open({
                                            id: data.record.id
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
                    render: function (data) {
                        return l('Enum:Remittance_Status:' + data);
                    }
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

    _releaseModal.onResult(function () {
        _dataTable.ajax.reload();
    });
    _releaseModal.onClose(function () {
        _dataTable.ajax.reload();
    });





});
