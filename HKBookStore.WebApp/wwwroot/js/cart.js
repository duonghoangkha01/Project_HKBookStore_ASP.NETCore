var CartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            updateCart(id, quantity);
        });
        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0);
        });
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                productid: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: "/Cart/GetListItems",
            success: function (res) {
                if (res.length === 0) {
                    $('#tbl_cart').hide();
                }
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;
                    html += "<tr>"
                        + "<td class=\"align-middle\"><img class=\"float-left\" src=\"" + $('#hidBaseAddress').val() + item.productImage + "\" style=\"width: 50px;\">" + item.productName + "</td>"
                        + "<td class=\"align-middle\">" + numberWithCommas(item.price) + "</td>"
                        + "<td class=\"align-middle\">"
                        + "<div class=\"input-group quantity mx-auto\" style=\"width: 100px;\">"
                        + "<div class=\"input-group-btn\">"
                        + "<button class=\"btn btn-sm btn-primary btn-minus\" data-id=\"" + item.productId + "\">"
                        + "<i class=\"fa fa-minus\"></i>"
                        + "</button>"
                        + "</div>"
                        + "<input type=\"text\" class=\"form-control form-control-sm bg-secondary text-center\" id=\"txt_quantity_" + item.productId + "\" value=\"" + item.quantity + "\">"
                        + "<div class=\"input-group-btn\">"
                        + "<button class=\"btn btn-sm btn-primary btn-plus\" data-id=\"" + item.productId + "\">"
                        + "<i class=\"fa fa-plus\"></i>"
                        + "</button>"
                        + "</div>"
                        + "</div>"
                        + "</td>"
                        + "<td class=\"align-middle\">" + numberWithCommas(amount) + "</td>"
                        + "<td class=\"align-middle\"><button class=\"btn btn-sm btn-primary btn-remove\" data-id=\"" + item.productId + "\"><i class=\"fa fa-times\"></i></button></td>"
                        + "</tr>";
                    total += amount;
                });
                $('#cart_body').html(html);
                $('#lbl_subtotal').text(numberWithCommas(total));
                $('#lbl_total').text(numberWithCommas(total));
            }
        })
    }
}