$(function () {
    var l = abp.localization.getResource("CacheManagement");

    var cacheManagementService = jS.abp.cacheManagement.controllers.cacheItems.cacheItem;

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "CacheManagement/EditModal",
        scriptUrl: abp.appPath + "Pages/CacheManagement/editModal.js",
        modalClass: "cacheManagementEdit"
    });
    
    var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            cacheName:'*',
            displayName: '',
           
        };
    };
    
    $('#DirectoryTree')
        .on('select_node.jstree', function (e, data) {
            var node = data.node;
            console.log(node);
            $(".selected-cache-name").html(node.text);
            $('#CacheItemTable').DataTable().ajax.url(abp.libs.datatables.createAjax(cacheManagementService.getList, function () {
                return {
                    filterText: $("#FilterText").val(),
                    cacheName: '*',
                    displayName: node.id,
                };
            })).load();
        })
        .on('move_node.jstree', function (e, data) {
            $('#DirectoryTree').jstree("refresh");
        })
        .jstree({
            'core': {
                'data': function (obj, callback) {
                    console.log("DirectoryTree");
                    cacheManagementService.getTree().done(function (trees) {
                        var mapToJsTreeNode = function (values) {
                            var map = function (value) {
                                return {
                                    id: value.cacheKey,
                                    text: value.cacheName,
                                    children: mapToJsTreeNode(value.children),
                                    state: {
                                        opened: false
                                    },
                                };
                            }

                            if (values) {
                                if (_.isArray(values)) {
                                    return _.map(values, function (value) {
                                        return map(value);
                                    });
                                } else {
                                    return map(values);
                                }
                            }
                        };

                        if (_.isArray(trees)) {
                            callback.call(this, mapToJsTreeNode(trees));
                        } else {

                        }
                    });

                },
                "check_callback": true
            },
            "plugins": ["dnd"]
        });
    

    var dataTable = $("#CacheItemTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(cacheManagementService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("ShowCache"),
                                visible: true,
                                action: function(data) {
                                    console.log(data);
                                    editModal.open({
                                        cacheKey: data.record.cacheKey
                                    });
                                }
                            },
                        ]
                }
            },
            { data: "cacheKey" },
        ]
    }));

    $("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();
    });

    $("#CleanAllCache").click(function (e) {
        abp.message.confirm(
            abp.localization.localize('AreYouSureToDelete', 'CacheManagement'),
            undefined,
            (isConfirmed) => {
                if (isConfirmed) {
                    abp.ui.setBusy();
                    cacheManagementService.clearAll().done(function () {
                        $('#DirectoryTree').jstree("refresh");
                        dataTable.ajax.reloadEx();
                    });
                    abp.ui.clearBusy();
                }
            }
        );
        
    });
})