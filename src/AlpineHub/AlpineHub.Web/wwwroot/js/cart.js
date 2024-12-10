$(function () {
    const UnexpectedError = "Unexpected error occurred. Please try again.";
    const ReloadUrl = window.location.href;
    function updateCartCounter(count) {
        const cartCounter = $("#cartCounter");
        cartCounter.text(count);
    }

    // Update cart counter:
    $.ajax({
        method: 'GET',
        url: '/Cart/GetCartCount'
    })
        .done(response => {
            updateCartCounter(response);

        }).fail(response => {
            console.error(response);
        });

    //Update quntity:
    $('.update-quantity-form').on('change', e => {
        e.preventDefault();
        const formData = $(e.currentTarget).serialize();

        $.ajax({
            method: 'GET',
            url: '/Cart/UpdateItemQuantity',
            data: formData
        })
            .done(response => {
                window.location.href = ReloadUrl;
            })
            .fail(response => {
                alert(UnexpectedError);
            });

    });

    // Add to cart form submission:
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
                updateCartCounter(response);

            }).fail(response => {
                if (response.status === 401) {
                    //Redirect to login page if not authenticated:
                    const loginUrl = `Identity/Account/Login?returnUrl=/Pass`;
                    window.location.href = loginUrl;


                } else {
                    alert(UnexpectedError);
                }
            });
    });
});

