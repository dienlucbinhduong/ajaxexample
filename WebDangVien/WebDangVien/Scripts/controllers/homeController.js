var homeconfig = {
    pageSize: 3,
    pageIndex: 1,
}
var homeController = {
    init: function () {
        homeController.loadData();
        homeController.registerEvent();
    },
    registerEvent: function () {
        //Sự kiện khi nhấn enter sửa Salary
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                //alert(id);
                homeController.updateSalary(id, value);
            }
        });
    },
    updateSalary: function (id, value) {
        var data = {
            ID: id,
            Salary: value
        };
        $.ajax({
            url: '/AJAX/Update',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    alert('Update succeed.');

                }
                else {
                    alert('Update false');
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/AJAX/LoadData',
            type: 'GET',
            //Thêm vào khi phân trang
            data:{
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            //
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    // alert(1);
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Lock</span>"
                        });
                        $('#tblData').html(html);

                        //Thêm vào khi phân trang
                        homeController.pageing(response.total, function () {
                            homeController.loadData();
                        });
                        //

                        homeController.registerEvent();
                    })
                }
            }
        })

    },
    //Thêm vào khi phân trang
    pageing: function (totalRow, callback) {
        //Phân trang sử dụng http://esimakin.github.io/twbs-pagination/
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Trước",
            last: "Cuối",
            prev: "Sau",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
    //
}
    homeController.init();