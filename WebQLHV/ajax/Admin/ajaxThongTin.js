
function btnadd() {
    var hang = $('#Hang').val();
    var trungtam = $('#TrungTam').val();
    var price = $('#PRICE').val();
    if (hang == "") {
        return alert("Bạn chưa nhập tên hạng")
    }
    if (trungtam == "") {
        return alert("Bạn chưa nhập tên trung tâm")
    }
    if (price == "") {
        return alert("Bạn chưa nhập giá")
    }
    $.ajax({
        url: '/admin/thongtin/Addasync',
        type: 'POST',
        data: {
            HANG: hang,
            TRUNGTAM: trungtam,
            PRICE: price,
        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message)
                $('#Hang').val('');
                $('#TrungTam').val('');
                $('#PRICE').val('');
            }
            else {
                alert(res.Message)
            }
        }
    });

}

function btndelete(id) {
    $.ajax({
        url: '/admin/thongtin/Delete',
        type: 'POST',
        data: {
            ID: id
        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message);
            }
            else {
                alert(res.Message)
            }
            location.reload();
        }
    });
}

function editthongtin() {
    var id = $('#ID').val();
    var hang = $('#Hang').val();
    var trungtam = $('#TrungTam').val();
    var price = $('#PRICE').val();
    if (hang == "") {
        return alert("Bạn chưa nhập tên hạng")
    }
    if (trungtam == "") {
        return alert("Bạn chưa nhập tên trung tâm")
    }
    if (price == "") {
        return alert("Bạn chưa nhập giá")
    }
    $.ajax({
        url: '/admin/thongtin/Editasync',
        type: 'POST',
        data: {
            ID: id,
            HANG: hang,
            TRUNGTAM: trungtam,
            PRICE: price,
        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            location.reload();

        }
    });
}