
function btnadd() {
    var name = $('#NAME').val();
    var username = $('#USERNAME').val();
    var password = $('#PASSWORD').val();
    if (name == "") {
        return alert("Bạn chưa nhập tên người dùng")
    }
    if (username == "") {
        return alert("Bạn chưa nhập tên đăng nhập")
    }
    if (password == "") {
        return alert("Bạn chưa nhập mật khẩu")
    }
    $.ajax({
        url: '/admin/taikhoan/Addasync',
        type: 'POST',
        async: true,
        data: {
            NAME: name,
            USERNAME: username,
            PASSWORD: password,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            $('#NAME').val('');
            $('#USERNAME').val('');
            $('#PASSWORD').val('');
        }
    });
}


function btndelete(id) {
    $.ajax({
        url: '/admin/taikhoan/Delete',
        type: 'POST',
        data: {
            ID: id
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message);
            }
            else {
                alert(res.Message)
            }
            location.reload();
        }
    });
}

function btnedit() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var username = $('#USERNAME').val();
    var password = $('#PASSWORD').val();

    if (name == "") {
        return alert("Bạn chưa nhập tên người dùng")
    }
    if (username == "") {
        return alert("Bạn chưa nhập tên đăng nhập")
    }
    if (password == "") {
        return alert("Bạn chưa nhập mật khẩu")
    }
    $.ajax({
        url: '/admin/taikhoan/Editasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            USERNAME: username,
            PASSWORD: password,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            location.reload();

        }
    });
}