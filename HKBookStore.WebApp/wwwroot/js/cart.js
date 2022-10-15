var CartController = function () {
    this.initialize = function () {
        loadData();
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: "/Cart/GetListItems",
            success: function (res) {
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;
                    html += "<tr>"
                        + "<td class=\"align-middle\"><img src=\"" + $('#hidBaseAddress').val() + item.productImage + "\" style=\"width: 50px;\">" + item.productName + "</td>"
                        + "<td class=\"align-middle\">" + numberWithCommas(item.price) + "</td>"
                        + "<td class=\"align-middle\">"
                        + "<div class=\"input-group quantity mx-auto\" style=\"width: 100px;\">"
                        + "<div class=\"input-group-btn\">"
                        + "<button class=\"btn btn-sm btn-primary btn-minus\">"
                        + "<i class=\"fa fa-minus\"></i>"
                        + "</button>"
                        + "</div>"
                        + "<input type=\"text\" class=\"form-control form-control-sm bg-secondary text-center\" value=\"" + item.quantity + "\">"
                        + "<div class=\"input-group-btn\">"
                        + "<button class=\"btn btn-sm btn-primary btn-plus\">"
                        + "<i class=\"fa fa-plus\"></i>"
                        + "</button>"
                        + "</div>"
                        + "</div>"
                        + "</td>"
                        + "<td class=\"align-middle\">" + numberWithCommas(amount) + "</td>"
                        + "<td class=\"align-middle\"><button class=\"btn btn-sm btn-primary\"><i class=\"fa fa-times\"></i></button></td>"
                        + "</tr>";
                    total += amount;
                });
                $('#cart_body').html(html);
                $('#lbl_total').text(numberWithCommas(total));
            }
        })
    }
}