$(function () {
    var l = abp.localization.getResource('AmlManagement');
    //var _createModal = new abp.ModalManager(abp.appPath + 'RemittanceManagement/Create');
    //var _updateModal = new abp.ModalManager(abp.appPath + 'RemittanceManagement/Update');



    var _dataTable = $('#RemittancesTable').DataTable(
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
            ajax: abp.libs.datatables.createAjax(amlManagement.samples.sample.getListRemittancesForAmlChecker),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                              
                                {
                                    text: l('Check'),
                                   // visible: abp.auth.isGranted('CurrencyManagment.Delete'),
                                    action: function (data) {
                                        amlManagement.samples.sample
                                            .checkAML(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    }
                                }
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
                  
                }, {
                    title: l('FirstName'),
                    data: "firstName",

                },
                 {
                    title: l('FatherName'),
                     data: "fatherName",

                },
                {
                    title: l('LastName'),
                    data: "lastName",

                }, {
                    title: l('State'),
                    data: "state",

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
