
function btnadd() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var email = $('#EMAIL').val();
    var hotline = $('#HOTLINE').val();
    var address = $('#ADDRESS').val();
    if (id == "") {
        return alert("Bạn chưa nhập id trung tâm")
    }
    if (name == "") {
        return alert("Bạn chưa nhập tên trung tâm")
    }
    if (email == "") {
        return alert("Bạn chưa nhập email trung tâm")
    }
    if (hotline == "") {
        return alert("Bạn chưa nhập hotline trung tâm")
    }
    if (address == "") {
        return alert("Bạn chưa nhập address trung tâm")
    }
    $.ajax({
        url: '/admin/trungtam/Addasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            EMAIL: email,
            HOTLINE: hotline,
            ADDRESS: address,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            $('#ID').val('');
            $('#NAME').val('');
            $('#EMAIL').val('');
            $('#HOTLINE').val('');
            $('#ADDRESS').val('');
        }
    });

}

function btndelete(id) {
    $.ajax({
        url: '/admin/trungtam/Delete',
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

function edittrungtam() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var email = $('#EMAIL').val();
    var hotline = $('#HOTLINE').val();
    var address = $('#ADDRESS').val();
    if (id == "") {
        return alert("Bạn chưa nhập id trung tâm")
    }
    if (name == "") {
        return alert("Bạn chưa nhập tên trung tâm")
    }
    if (email == "") {
        return alert("Bạn chưa nhập email trung tâm")
    }
    if (hotline == "") {
        return alert("Bạn chưa nhập hotline trung tâm")
    }
    if (address == "") {
        return alert("Bạn chưa nhập address trung tâm")
    }
    $.ajax({
        url: '/admin/trungtam/Editasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            EMAIL: email,
            HOTLINE: hotline,
            ADDRESS: address,
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