
function btnadd() {
    var name = $('#NAME').val();
    var dateopen = $('#DATEOPEN').val();
    if (name == "") {
        return alert("Bạn chưa nhập tên khóa học")
    }
    if (dateopen == "") {
        return alert("Bạn chưa nhập ngày khai giảng")
    }
    $.ajax({
        url: '/admin/khoahoc/Addasync',
        type: 'POST',
        async: true,
        data: {
            NAME: name,
            DATEOPEN: dateopen,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            $('#NAME').val('');
            $('#DATEOPEN').val('');
        }
    });
}


function btndelete(id) {
    $.ajax({
        url: '/admin/khoahoc/Delete',
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

function editkhoahoc() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var dateopen = $('#DATEOPEN').val();

    if (name == "") {
        return alert("Bạn chưa nhập tên")
    }
    if (dateopen == "") {
        return alert("Bạn chưa nhập ngày khai giảng")
    }
    $.ajax({
        url: '/admin/khoahoc/Editasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            DATEOPEN: dateopen,
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