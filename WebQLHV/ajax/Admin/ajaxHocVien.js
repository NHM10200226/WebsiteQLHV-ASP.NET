
function hienhocphi() {

    var hangthi = $("#HANGTHI").val();
    var ttam = $("#TRUNGTAM").val();
    // Dùng ajax để lấy giá tiền tương ứng với hạng thi
    $.ajax({
        url: '/admin/hocvien/GetHocPhi',
        data: {
            IDHANG: hangthi,
            IDTRUNGTAM: ttam
        },
        success: function (res) {
            if (res.Success == true) {
                // Gán giá trị học phí vào hộp văn bản
                $("#HOCPHI").val(res.Gia);
            } else if ($("#TRUNGTAM").val() == "NONE")
            {
                $("#HOCPHI").val('Chưa chọn trung tâm');
            }
            if ($("#HANGTHI").val() == "NONE") {
                $("#HOCPHI").val('Chưa chọn hạng thi');
            }
        }
    });
}

$('#HANGTHI').on('change', hienhocphi);

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#PreviewHA').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#HINHANH").change(function () {
    readURL(this);
});

function btnadd() {
    var hoten = $('#HOTEN').val();
    var sdt = $('#SDT').val();
    var ngaysinh = $('#NGAYSINH').val();
    var cmnd = $('#CMND').val();
    var ngaycap = $('#NGAYCAP').val();
    var noicap = $('#NOICAP').val();
    var gioitinh = $('#GIOITINH').val();
    var hangthi = $('#HANGTHI').val();
    var diachi = $('#DIACHI').val();
    var noihoc = $('#NOIHOC').val();
    var hocphi = $('#HOCPHI').val();
    var ttam = $('#TRUNGTAM').val();
    var ghichu = $('#GHICHU').val();
    var previewhinhanh = $("#PreviewHA").attr("src")
    if (typeof previewhinhanh === "undefined") {
        previewhinhanh = "";
    } else {
        if (previewhinhanh == "/Content/img/no-image.jpg") {
            previewhinhanh = "";
        }
    };
    if (hoten == "") {
        return alert("Bạn chưa nhập tên ")
    }
    if (sdt == "") {
        return alert("Bạn chưa nhập tên sdt")
    }
    if (ngaysinh == "") {
        return alert("Bạn chưa nhập ngay sinh")
    }
    if (cmnd == "") {
        return alert("Bạn chưa nhập cmnd ")
    }
    if (ngaycap == "") {
        return alert("Bạn chưa nhập ngay cap")
    }
    if (noicap == "") {
        return alert("Bạn chưa nhập noi cap")
    }
    if (gioitinh == "") {
        return alert("Bạn chưa nhập gioi tinh ")
    }
    if (hangthi == "") {
        return alert("Bạn chưa nhập hang thi")
    }
    if (diachi == "") {
        return alert("Bạn chưa nhập dia chi")
    }
    $.ajax({
        url: '/admin/hocvien/Addasync',
        type: 'POST',
        data: {
            HOTEN: hoten,
            SDT: sdt,
            NGAYSINH: ngaysinh,
            CMND: cmnd,
            NGAYCAP: ngaycap,
            NOICAP: noicap,
            GIOITINH: gioitinh,
            HANGTHI: hangthi,
            DIACHI: diachi,
            NOIHOC: noihoc,
            HOCPHI: hocphi,
            TRUNGTAM: ttam,
            GHICHU: ghichu,
            HINHANH: JSON.stringify(previewhinhanh)

        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message)
                location.reload();
            }
            else {
                alert(res.Message)
            }
        }
    });
}


    function btndelete(id) {
        $.ajax({
            url: '/admin/hocvien/Delete',
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

function edithocvien() {
    var id = $('#ID').val();
    var hoten = $('#HOTEN').val();
    var sdt = $('#SDT').val();
    var ngaysinh = $('#NGAYSINH').val();
    var cmnd = $('#CMND').val();
    var ngaycap = $('#NGAYCAP').val();
    var noicap = $('#NOICAP').val();
    var gioitinh = $('#GIOITINH').val();
    var hangthi = $('#HANGTHI').val();
    var diachi = $('#DIACHI').val();
    var noihoc = $('#NOIHOC').val();
    var hocphi = $('#HOCPHI').val();
    var ttam = $('#TRUNGTAM').val();
    var ghichu = $('#GHICHU').val();
    var previewhinhanh = $("#PreviewHA").attr("src")
    if (typeof previewhinhanh === "undefined") {
        previewhinhanh = "";
    } else {
        if (previewhinhanh == "/Content/img/no-image.jpg") {
            previewhinhanh = "";
        }
    };
    $.ajax({
        url: '/admin/hocvien/Editasync',
        type: 'POST',
        data: {
            ID: id,
            HOTEN: hoten,
            SDT: sdt,
            NGAYSINH: ngaysinh,
            CMND: cmnd,
            NGAYCAP: ngaycap,
            NOICAP: noicap,
            GIOITINH: gioitinh,
            HANGTHI: hangthi,
            DIACHI: diachi,
            NOIHOC: noihoc,
            HOCPHI: hocphi,
            TRUNGTAM: ttam,
            GHICHU: ghichu,
            HINHANH: JSON.stringify(previewhinhanh)
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