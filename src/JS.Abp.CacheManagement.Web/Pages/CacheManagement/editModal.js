var abp = abp || {};
abp.modals.CacheManagement = function () {

    $("#DeleteButton").click(function (e) {
           
            abp.message.confirm(
                abp.localization.localize('AreYouSureToDelete', 'CacheManagement'),
                undefined,
                (isConfirmed) => {
                    if (isConfirmed) {
                        abp.ui.setBusy();
                        $.ajax({
                            url: '/api/cache-management/cache-item/' + $('#CacheKey').val(),
                            type: 'Delete',

                            contentType: 'application/json',
                            success: function () {
                                abp.notify.success(abp.localization.localize('SuccessfullyDeleted', 'CacheManagement'));
                                abp.ui.clearBusy();
                                $('#CacheManagementEditModal').modal('hide');
                                //location.reload();
                            },
                            error: function (e) {
                                abp.ui.clearBusy();
                                abp.message.error(e.responseJSON.error.details, e.responseJSON.error.message);
                            }
                        });
                    }
                }
            );
        }
    );
};