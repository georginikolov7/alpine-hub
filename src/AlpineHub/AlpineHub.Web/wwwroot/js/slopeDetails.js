
$(function () {
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
});

