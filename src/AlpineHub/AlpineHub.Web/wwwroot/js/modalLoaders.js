
$(function () {
    const deleteSlopeButtons = $('.delete-slope-button');
    const deleteLiftButtons = $('.delete-lift-button');
    const deleteLiftTypeButtons = $('.delete-lift-type-button');

    deleteLiftTypeButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().find('td:first').text();

        $.ajax({
            method:
                'GET',
            url: '/ManageLifts/DeleteLiftType',
            data: { id: id }
        })
            .done(data => {
                $('#deleteConfirmModal').html(data);
                $('#deleteConfirmModal').modal('show');
            }).fail(data => {

            })
    });
    deleteSlopeButtons.on("click", (e) => {
        const trElement = $(e.target).parent().parent();
        const id = trElement.find('td:first').text();
        $.ajax({
            method: 'GET',
            url: "/ManageSlopes/DeleteSlope",
            data: { id: id },
        })
            .done(function success(data) {
                $('#deleteConfirmModal').html(data);
                $('#deleteConfirmModal').modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
    });

    deleteLiftButtons.on("click", (e) => {
        const trElement = $(e.target).parent().parent();
        const id = trElement.find('td:first').text();
        $.ajax({
            method: 'GET',
            url: "/ManageLifts/DeleteLift",
            data: { id: id },
        })
            .done(function success(data) {
                $('#deleteConfirmModal').html(data);
                $('#deleteConfirmModal').modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
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