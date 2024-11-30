$(function () {
    
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

//function rowClickEventHandler(row) {
//    const id = $(row).find("td:first").text();

//    $.ajax({
//        method: 'GET',
//        url: '/Lift/GetLiftById',
//        data: { id: id }
//    })
//        .done(function success(data) {
//            $('#liftModalBody').html(data);
//            $('#liftModal').modal('show');
//        })
//        .fail(function fail(error) {
//            //TODO handle error
//        });
//}