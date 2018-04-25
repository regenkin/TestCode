﻿/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.17
 * 描 述：单据编码	
 */
var refreshGirdData; // 更新数据
var selectedRow;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'Form',
                    title: '添加委托',
                    url: top.$.rootUrl + '/LR_WorkFlowModule/WfDelegateRule/Form',
                    height: 600,
                    width: 800,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                selectedRow = $('#girdtable').jfGridGet('rowdata');
                var keyValue = $('#girdtable').jfGridValue('F_RuleId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'Form',
                        title: '编辑单据编码',
                        url: top.$.rootUrl + '/LR_SystemModule/CodeRule/Form',
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#girdtable').jfGridValue('F_RuleId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_SystemModule/CodeRule/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
        },
        initGird: function () {
            $('#girdtable').lrAuthorizeJfGrid({
                //url: top.$.rootUrl + '/LR_SystemModule/CodeRule/GetPageList',
                headData: [
                    { label: '被委托人', name: 'F_ToUserName', width: 150, align: 'left' },
                    {
                        label: '开始时间', name: 'F_BeginDate', width: 130, align: 'left',
                        formatter: function (cellvalue) {
                            return learun.formatDate(cellvalue, 'yyyy-MM-dd');
                        }
                    },
                    {
                        label: '结束时间', name: 'F_EndDate', width: 130, align: 'left',
                        formatter: function (cellvalue) {
                            return learun.formatDate(cellvalue, 'yyyy-MM-dd');
                        }
                    },
                    { label: '委托人', name: 'F_CreateUserName', width: 100, align: 'left' },
                    {
                        label: '创建时间', name: 'F_CreateDate', width: 130, align: 'left',
                        formatter: function (cellvalue) {
                            return learun.formatDate(cellvalue, 'yyyy-MM-dd hh:mm');
                        }
                    },
                    { label: "委托说明", name: "F_Description", width: 200, align: "left" }
                ],
                mainId: 'F_RuleId',
                reloadSelected: true,
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            $('#girdtable').jfGridSet('reload', { param: param });
        }
    };

    // 保存数据后回调刷新
    refreshGirdData = function () {
        page.search();
    }

    page.init();
}


