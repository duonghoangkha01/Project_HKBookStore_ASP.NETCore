$('body').on('click', '.btn-add-cart', function (e) {
    e.preventDefault();
    const id = $(this).data('id');
    $.ajax({
        type: "POST",
        url: '/Cart/AddToCart',
        data: {
            productId: id,
        },
        success: function (res) {
            console.log(res)
        },
        error: function (err) {
            console.log(err);
        }
    });
})