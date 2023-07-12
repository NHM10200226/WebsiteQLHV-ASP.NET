
function btnadd() {
    var khoa = $('#KHOAHOC').val();
    var hocvien = $('#HOCVIEN').val();
    var lythuyet = $('#LYTHUYET').val();
    var thuchanh = $('#THUCHANH').val();
    if (khoa == "") {
        return alert("Bạn chưa nhập khóa học")
    }
    if (hocvien == "") {
        return alert("Bạn chưa nhập học viên")
    }
    if (lythuyet == "") {
        return alert("Bạn chưa nhập điểm lý thuyết")
    }
    if (thuchanh == "") {
        return alert("Bạn chưa nhập điểm thực hành")
    }
    $.ajax({
        url: '/admin/diem/Addasync',
        type: 'POST',
        async: true,
        data: {
            KHOAHOC: khoa,
            HOCVIEN: hocvien,
            LYTHUYET: lythuyet,
            THUCHANH: thuchanh,
        },
        success: function (res) {
            if (res.success == true) {
                alert(res.Message)
            }
            else {
                alert(res.Message)
            }
            $('#KHOAHOC').val('');
            $('#HOCVIEN').val('');
            $('#LYTHUYET').val('');
            $('#THUCHANH').val('');
        }
    });
}


function btndelete(id) {
    $.ajax({
        url: '/admin/diem/Delete',
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
    var khoa = $('#KHOAHOC').val();
    var hocvien = $('#HOCVIEN').val();
    var lythuyet = $('#LYTHUYET').val();
    var thuchanh = $('#THUCHANH').val();

    if (khoa == "") {
        return alert("Bạn chưa nhập khóa học")
    }
    if (hocvien == "") {
        return alert("Bạn chưa nhập học viên")
    }
    if (lythuyet == "") {
        return alert("Bạn chưa nhập điểm lý thuyết")
    }
    if (thuchanh == "") {
        return alert("Bạn chưa nhập điểm thực hành")
    }
    $.ajax({
        url: '/admin/diem/Editasync',
        type: 'POST',
        data: {
            ID: id,
            KHOAHOC: khoa,
            HOCVIEN: hocvien,
            LYTHUYET: lythuyet,
            THUCHANH: thuchanh,
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