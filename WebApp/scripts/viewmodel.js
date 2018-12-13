function ViewModel() {
    self = this;
    //创建变量
    self.contacts = ko.observableArray();//当前联系人列表
    self.contact = ko.observable(); //当前编辑联系人

    //获取当前联系人列表
    self.load = function () {
        $.ajax({
            url: "http://localhost/webhost/api/contacts",
            type: "get",
            success: function (result) {
                self.contacts(result);
            }
        });
    };

    //弹出编辑器
    self.showDialog = function (data) {
        if (!data.Id) {
            data = { Id: "", Name: "", PhoneNo: "", EmailAddress: "", Address: "" }
        }
        self.contact(data);
        $(".modal").modal("show");
    }

    //保存
    self.save = function () {
        $(".modal").modal("hide");
        if (self.contact().Id) {
            $.ajax({
                url: "http://localhost/webhost/api/contacts/" + self.contact.Id,
                type: 'get',
                data: self.contact(),
                success: function () {
                    self.load();
                }

            });
        }
        else {
            $.ajax({
                url: "http://localhost/webhost/api/contacts",
                type: 'post',
                data: self.contact(),
                success: function () {
                    self.load();
                }
            });
        }
    }

    //删除联系人
    self.delete = function (data) {
        $.ajax({
            url: 'http://localhost/webhost/api/contacts/' + data.Id,
            type: 'DELETE',
            dataType: "json",
            success: function (data, statusText) {
                self.load();
            },
            error: function (request, textStatus, error) {
                alert(error);
                debugger;
            }
        });
    };

    self.close = function () {
        $("#modal").modal('hide');
    }

    self.load();
}

function AddressModel() {
    var self = this;

    self.province = ko.observable("江苏省");
    self.city = ko.observable("南京");
    self.district = ko.observable("工业园区");
    self.street = ko.observable("星塘街");
    self.address = ko.observable();

    self.format = function () {
        if (self.province() && self.city() && self.street() && self.district()) {
            var address = self.province() + " " + self.city() + " " + self.district() + " ";
            self.address(address);
        }
        else {
            alert("请提供完整的地址信息");
        }
    }

    self.format();
}

$(function () {
    //ko.applyBindings(new AddressModel());
    ko.applyBindings(new ViewModel());

});

