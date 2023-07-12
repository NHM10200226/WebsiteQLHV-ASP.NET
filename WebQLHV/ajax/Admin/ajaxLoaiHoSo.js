
function btnadd() {
    var name = $('#NAME').val();
    var trungtam = $('#TRUNGTAM').val();
    var status = $('#STATUS').val();
    $.ajax({
        url: '/admin/LoaiHoSo/Addasync',
        type: 'POST',
        data: {
            NAME: name,
            TRUNGTAM: trungtam,
            STATUS: status,
        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message)
                $('#NAME').val('');
                $('#TRUNGTAM').val('');
                $('#STATUS').val('');
            }
            else {
                alert(res.Message)
            }
        }
    });
}


function btndelete(id) {
    $.ajax({
        url: '/admin/LoaiHoSo/Delete',
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
function btnduyet(id) {
    $.ajax({
        url: '/admin/LoaiHoSo/duyet',
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
function btnhuyduyet(id) {
    $.ajax({
        url: '/admin/LoaiHoSo/huyduyet',
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

function editLoaiHoSo() {
    var id = $('#ID').val();
    var name = $('#NAME').val();
    var trungtam = $('#TRUNGTAM').val();
    $.ajax({
        url: '/admin/LoaiHoSo/Editasync',
        type: 'POST',
        data: {
            ID: id,
            NAME: name,
            TRUNGTAM: trungtam,
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