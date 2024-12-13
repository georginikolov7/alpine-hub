const deleteUserButtons = $('.delete-user-button');
const assignRoleButtons = $(".assign-role-button");
const removeRoleButtons = $(".remove-role-button");
$(function () {

    deleteUserButtons.on('click', (e) => {
        const id = $(e.target).parent().parent().parent().find('td:first').text();

        $.ajax({ method: 'GET', url: '/Admin/Users/DeleteUser', data: { id: id } })
            .done(function success(data) {
                $('#deleteConfirmModal').html(data);
                $('#deleteConfirmModal').modal('show');
            })
            .fail(function fail(data) {
                //TODO handle error
            });
    });

    assignRoleButtons.on('click', (e) => {
        const userId = $(e.target).parent().find('.id-container').text();

        $.ajax({
            method: 'GET',
            url: '/Admin/Users/AssignRole',
            data: { id: userId }
        })
            .done((data) => {
                $('#roleModal').html(data);
                $('#roleModal').modal('show');
            })
            .fail((data) => {
            })

    });

    removeRoleButtons.on('click', (e) => {
        const userId = $(e.target).parent().find('.id-container').text();

        $.ajax({
            method: 'GET',
            url: '/Admin/Users/RemoveRole',
            data: { id: userId }
        }).done((data) => {
            $('#roleModal').html(data);
            $('#roleModal').modal('show');
        }).fail((data) => {

        });
    });
});
