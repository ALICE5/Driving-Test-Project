$(function () {
    jQuery.validator.addMethod("istxtname", function (value, element) {
        return this.optional(element) || /^[A-Za-z0-9_\-\u4e00-\u9fa5]+$/.test(value);
    }, "用户名只能包括中文、英文字母、数字、下划线和"-"");
    jQuery.validator.addMethod("istxtemail", function (value, element) {
        return this.optional(element) || /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/.test(value);
    }, "请输入正确的邮箱");
    $("#loginForm").validate({
		errorElement: "span",
        rules: {
            txtname: {
                required: true,
                istxtname: true,
                minlength: 3,
                maxlength: 16
            },
            txtpwd1: {
                required: true,
                minlength: 6,
                maxlength: 16
            },
            txtpwd2: {
                required: true,
                equalTo: "#txtpwd1"
            },
            txtemail: {
                required: true,
                email: true,
                istxtemail: true
            },
        },
        messages: {
            txtname: {
                required: "请输入会员账号",
                minlength: "会员名在3-16个字符内",
                maxlength: "会员名在3-16个字符内",
                remote: "该会员名已经存在"
            },
            txtpwd1: {
                required: "请输入密码",
                minlength: "密码在6-16个字符内",
                maxlength: "密码在6-16个字符内"
            },
            txtpwd2: {
                required: "请输入密码",
                equalTo: "密码与确认密码不一致"
            },
            txtemail: "请输入正确的邮箱",
        },

        submitHandler: function (form) {
            $("#btnEnter").hide().after("<span>正在申请中，请稍后...</span>");
            form.submit();
        },
    });
})