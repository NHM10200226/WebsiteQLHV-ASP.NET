
let fileData = [];

const convertBase64 = (file) => {
    return new Promise((resolve, reject) => {
        const fileReader = new FileReader();
        fileReader.readAsDataURL(file);

        fileReader.onload = () => {
            resolve(fileReader.result);
        };

        fileReader.onerror = (error) => {
            reject(error);
        };
    });
};

function checkFile(fileTybe) {
    switch (fileTybe) {
        case 'image/jpg':
        case 'image/jpeg':
        case 'image/raw':
        case 'image/bmp':
        case 'image/png':
        case 'image/webp':
        case 'application/pdf':
        case 'application/msword':
        case 'application/vnd.openxmlformats-officedocument.wordprocessingml.document':
        case 'application/vnd.ms-excel':
        case 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet':
            return true;
    }
    return false;
}
function OnchangeFile(FileThis) {

    for (var i = 0; i < $(FileThis).get(0).files.length; ++i) {
        if (checkFile($(FileThis).get(0).files[i].type)) {
            UpdateFile(FileThis, i);
            console.log(UpdateFile)

        }
        else {
            toastr.error(`Lỗi ! File ${$(FileThis).get(0).files[i].name} không được hỗ trợ`);
        }
    }
    console.log(fileData)
}
async function UpdateFile(FileThis, i) {
    const file = $(FileThis).get(0).files[i];
    const base64 = await convertBase64(file);
    fileData.push({
        BASE64: base64,
        NAME: $(FileThis).get(0).files[i].name.replace(/,/g, ' ')
    });
}
function btnadd() {
    var LoaiHoSo = $('#LoaiHoSo').val();
    var hocvien = $('#HocVien').val();
    var ghichu = $('#GHICHU').val();
    $.ajax({
        url: '/admin/HoSo/Addasync',
        type: 'POST',
        dataType: 'json',
        data: {
            LOAIHOSO: LoaiHoSo,
            HOCVIEN: hocvien,
            GHICHU: ghichu,
            HOSO: JSON.stringify(fileData)
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
        url: '/admin/HoSo/Delete',
        type: 'POST',
        data: {
            ID: id
        },
        success: function (res) {
            if (res.Success == true) {
                alert(res.Message);
                location.reload();
            }
            else {
                alert(res.Message)
            }
        }
    });
}
