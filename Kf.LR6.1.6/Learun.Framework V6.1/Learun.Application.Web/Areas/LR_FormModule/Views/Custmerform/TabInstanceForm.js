/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.17
 * 描 述：自定义表单
 */
var id = request('id');
var keyValue = request('keyValue');

var acceptClick;

var bootstrap = function ($, learun) {
    "use strict";
    var formModule;
    var page = {
        init: function () {
            if (!!id) {
                $.lrSetForm(top.$.rootUrl + '/LR_FormModule/Custmerform/GetFormData?keyValue=' + id, function (data) {//
                    formModule = JSON.parse(data.schemeEntity.F_Scheme);
                    $.lrCustmerFormRender(formModule.data);
                    page.bind();
                });
            }
            page.initData();

        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_FormModule/Custmerform/GetInstanceForm?schemeInfoId=' + id + '&keyValue=' + keyValue, function (data) {//
                    page.setFormData(data);
                });
            }
        },
        setFormData: function (data) {
            if (!!formModule) {
                $.each(data, function (id, item) {
                    $('body').lrSetCustmerformData(item[0]);
                });
            }
            else {
                setTimeout(function () {
                    page.setFormData(data);
                }, 100);
            }
        },
        bind: function () {
           
            // 保存数据
            $('#savaAndAdd').on('click', function () {
                acceptClick(0);
            });
            $('#save').on('click', function () {
                acceptClick(1);
            });
        }
    };
    page.init();


    // 保存数据
    acceptClick = function (type) {// 0保存并新增 1保存
        console.log('cbb');
        //if (!$.lrValidCustmerform()) {
        //    return false;
        //}
        var formData = $('body').lrGetCustmerformData(keyValue);
        var postData =
            {
                formData: JSON.stringify(formData)
            };

        console.log(formData);

        //learun.layerConfirm('注：您确认要保存吗？', function (res, index) {
        //    if (res) {
        //        $.lrSaveForm(top.$.rootUrl + '/LR_FormModule/Custmerform/SaveInstanceForm?keyValue=' + keyValue + "&schemeInfoId=" + id, postData, function (res) {
        //            if (res.code == 200) {
        //                if (type == 0) {
        //                    learun.frameTab.close(id);
        //                    learun.frameTab.open({ F_ModuleId: id, F_Icon: 'fa fa-pencil-square-o', F_FullName: '新增', F_UrlAddress: '/LR_FormModule/Custmerform/TabInstanceForm?id=' + id });
        //                }
        //                else {
        //                    learun.frameTab.close(id);
        //                }
        //            }
        //        });
        //        top.layer.close(index); //再执行关闭                  
        //    }
        //});
    };
}