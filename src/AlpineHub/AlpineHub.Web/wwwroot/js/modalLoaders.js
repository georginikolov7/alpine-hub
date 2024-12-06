
$(function () {
    const deleteSlopeButton = $('.delete-slope-button');
    const deleteLiftButton = $('.delete-lift-button');
    const deleteUserButton = $('.delete-user-button');

    deleteUserButton.on('click', (e) => {
        const id = $(e.target).parent().parent().parent().find('td:first').text();

        $.ajax({ method: 'GET', url: '/Admin/Users/DeleteUser', data: { id: id } })
            .done(function success(data) {
                $('#deleteUserModal').html(data);
                $('#deleteUserModal').modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
    });

    deleteSlopeButton.on("click", (e) => {
        const trElement = $(e.target).parent().parent();
        const id = trElement.find('td:first').text();
        $.ajax({
            method: 'GET',
            url: "/Manager/DeleteSlope",
            data: { id: id },
        })
            .done(function success(data) {
                $('#deleteSlopeModal').html(data);
                $('#deleteSlopeModal').modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
    });

    deleteLiftButton.on("click", (e) => {
        const trElement = $(e.target).parent().parent();
        const id = trElement.find('td:first').text();
        $.ajax({
            method: 'GET',
            url: "/Manager/DeleteLift",
            data: { id: id },
        })
            .done(function success(data) {
                $('#deleteLiftModal').html(data);
                $('#deleteLiftModal').modal('show');
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