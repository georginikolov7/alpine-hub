
$(function () {

    const deleteSlopeButtons = $('.delete-slope-button');
    const deleteLiftButtons = $('.delete-lift-button');
    const deleteLiftTypeButtons = $('.delete-lift-type-button');
    const deletePassPeriodButtons = $('.delete-period-button');
    const deletePassAgeGroupButtons = $('.delete-age-group-button');
    const deletePassButtons = $('.delete-pass-button');
    const modalId = '#deleteConfirmModal';
    function loadDeleteConfirmModal(url, entityId) {
        $.ajax({
            method: 'GET',
            url: url,
            data: { id: entityId }
        })
            .done(function success(data) {
                $(modalId).html(data);
                $(modalId).modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
    }

    deletePassButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();
        loadDeleteConfirmModal('/ManagePasses/DeletePass', id);
    });
    deletePassAgeGroupButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();
        loadDeleteConfirmModal('/ManagePassAgeGroups/DeleteAgeGroup', id);
    });
    deletePassPeriodButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();

        loadDeleteConfirmModal('/ManagePassPeriods/DeletePeriod', id);
    });

    deleteLiftTypeButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();

        loadDeleteConfirmModal('/ManageLifts/DeleteLiftType', id);

    });
    deleteSlopeButtons.on("click", (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();

        loadDeleteConfirmModal('/ManageSlopes/DeleteSlope', id);
    });

    deleteLiftButtons.on("click", (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();
        loadDeleteConfirmModal('/ManageLifts/DeleteLift', id);
    });


    $('#slopeTable tbody').on('click', 'tr', (e) => {
        const id = $(e.currentTarget).find('td:first').text();
        $.ajax({
            method: 'GET',
            url: '/Slope/GetSlopeById',
            data: { id: id }
        })
            .done(function success(data) {
                $('#slopeModalBody').html(data);
                $('#slopeModal').modal('show');
            })
            .fail(function fail(error) {
                //TODO handle error
            });
    });

    $('#liftTable tbody').on('click', 'tr', (e) => {
        const id = $(e.currentTarget).find("td:first").text();

        $.ajax({
            method: 'GET',
            url: '/Lift/GetLiftById',
            data: { id: id }
        })
            .done(function success(data) {
                $('#liftModalBody').html(data);
                $('#liftModal').modal('show');
            })
            .fail(function fail(error) {
                //TODO handle error
            });
    });
});