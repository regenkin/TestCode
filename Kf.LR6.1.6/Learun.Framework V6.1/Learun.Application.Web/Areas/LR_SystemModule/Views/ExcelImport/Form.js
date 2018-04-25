/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.17
 * 描 述：导入配置
 */
var keyValue = request('keyValue');
var moduleId = request('moduleId');

var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var cols = [];


    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_ModuleBtnId').lrselect({
                url: top.$.rootUrl + '/LR_SystemModule/Module/GetButtonList',
                param: {
                    moduleId: moduleId
                },
                value: 'F_ModuleButtonId',
                text: 'F_FullName'
            });
            $('#F_ErrorType').lrselect().lrselectSet('1');
            $('#girdtable').jfGrid({
                headData: [
                    { label: "字段", name: "ModuleName", width: 160, align: "left" },
                    { label: "Excel列名", name: "F_Name", width: 160, align: "left" },
                    { label: "唯一性", name: "F_ModuleUrl", width: 60, align: "center" },
                    { label: "描述", name: "F_ModuleUrl", width: 200, align: "left" },
                    { label: "操作", name: "F_ModuleUrl", width: 50, align: "center" }
                ]
            });
            $('#lr_filedtree').lrtree({
                nodeCheck: function (item) {
                    console.log(item);
                    if (item.checkstate == '1') {

                    }
                    else {

                    }
                    var point = {
                        //ModuleName.
                    };
                    cols.push(point);
                }
            });
            $('#lr_dbtree').lrtree({
                url: top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetTreeList',
                nodeClick: function (item) {
                    if (!item.hasChildren) {
                        learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/DatabaseTable/GetFieldTreeList', { databaseLinkId: item.value, tableName: item.text }, function (res) {
                            $('#lr_filedtree').lrtreeSet('refresh', { data: res });
                            $('#lr_filedtree').lrtreeSet('allCheck');
                        });
                    }
                    else {
                        $('#lr_filedtree').lrtreeSet('refresh', { data: [] });
                    }
                }
            });
            
        },
        initData: function () {
           
        }
    };

    acceptClick = function (callBack) {
       
    }
    page.init();
}
