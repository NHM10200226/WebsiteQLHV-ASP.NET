
function btnadd() {
    var name = $('#NAME').val();
    var status = $('#STATUS').val();
    if (name == "") {
        return alert("Bạn chưa nhập tên hạng")
    }
    if (status == "") {
        return alert("Bạn chưa nhập trạng thái")
    }
    $.ajax({
        url: '/admin/hanggplx/Addasync',
        type: 'POST',
        async:true,
        data: {
            NAME: name,
            STATUS: status,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            $('#NAME').val('');
            $('#STATUS').val('');
        }
    });
}


function btndelete(id) {
    $.ajax({
        url: '/admin/hanggplx/Delete',
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

function edithanggplx() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var status = $('#STATUS').val();

    if (name == "") {
        return alert("Bạn chưa nhập tên")
    }
    if (status == "") {
        return alert("Bạn chưa nhập trạng thái")
    }
    $.ajax({
        url: '/admin/hanggplx/Editasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            STATUS: status,
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