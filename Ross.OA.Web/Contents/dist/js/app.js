$(function () {
    $('#Logout').click(function () {
        confirmE('确定退出？', function () {
            $.post('/Manage/Logout', {}, function (response) {
                if (response.code == 100) {
                    window.location.href = '/Home/';
                }
                else {
                    toastr.error(response.message)
                }
            })
        });
    });

    $('[data-toggle="tooltip"]').tooltip()
})

function alertE(msg) {
    $.alert(msg);
}

function confirmE(msg, okFun) {
    $.confirm({
        title: 'Confirm',
        content: msg,
        buttons: {
            confirm: {
                text: '是',
                btnClass: 'btn-red',
                action: okFun
            },
            cancel: {
                text: '否',
                btnClass: 'btn-blue',
            }
        }
    });
}
var DataTableLanguage = {
    "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
    "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
    "sSearch": "搜索:",
    "sLoadingRecords": "载入中...",
    "sProcessing": "处理中...",
    "sLengthMenu": "显示 _MENU_ 项结果",
    "sZeroRecords": "没有匹配结果",
    "sInfoFiltered": "(过滤出 _MAX_ 项结果)",
    "oPaginate": {
        "sFirst": "首页",
        "sPrevious": "上页",
        "sNext": "下页",
        "sLast": "末页"
    }
}