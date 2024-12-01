const slopesCounterElement = $('#slopesCounter');
const liftsCounterElement = $('#liftsCounter');
$(function () {
    $.ajax({
        method: 'GET',
        url: 'https://localhost:7103/InfoCounters',
        xhrFields: { withCredentials: true }
    })
        .done(function success(data) {
            const totalSlopes = data.totalSlopesCount;
            const totalLifts = data.totalLiftsCount;
            const openSlopes = data.openSlopesCount;
            const openLifts = data.openLiftsCount;

            const span = $('#slopesCounter');
            slopesCounterElement.text(`${openSlopes}/${totalSlopes}`);
            liftsCounterElement.text(`${openLifts}/${totalLifts}`);
        })
        .fail(function fail(error) {
            slopesCounterElement.text('!');
            liftsCounterElement.text('!');
        });
});