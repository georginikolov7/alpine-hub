$(function () {
    $(".add-to-cart-form").on("submit", function (event) {
        event.preventDefault(); // Prevent the default form submission

        const form = $(this);
        const formData = form.serialize();

        // Perform AJAX request to add to cart
        $.ajax({
            method: 'GET',
            url: '/Cart/AddToCart',
            data: formData
        })
            .done(response => {
                alert("Item added to cart successfully.");

            }).fail(response => {
                if (response.status === 401) {
                    //Redirect to login page if not authenticated:
                    const loginUrl = `Identity/Account/Login?returnUrl=/Pass`;
                    window.location.href = loginUrl;


                } else {
                    alert("An error occurred while adding to cart. Please try again.");
                }
            });

    });
});

