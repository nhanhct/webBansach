var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Users/Home/User_Home";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Users/GioHang/Payment";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProductCart = $('.txtQuantity');
            var carList = [];
            $.each(listProductCart, function (i, item) {
                carList.push({
                    SoLuong: $(item).val(),
                    SanPham:
                        { MaSP: $(item).data('id') }
                });
            });

            $.ajax({
                url: '/GioHang/CapNhat',
                data: { cartModel: JSON.stringify(carList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Users/GioHang/Index"
                    }
                }
            })

        });
        $('#btnDeleteAll').off('click').on('click', function () {

            $.ajax({
                url: '/Users/GioHang/XoaGH',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Users/GioHang"
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { MaSP: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Users/GioHang"
                    }
                }
            })
        });
    }
}
cart.init();