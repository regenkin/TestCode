/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.18
 * 描 述：工作委托
 */
var acceptClick;
var bootstrap = function ($, learun) {
    "use strict";
    var categoryId = '';
    var keyword = '';
    var schemeList = [];
    var schemeListSelected = {};

    var render = function () {
        var $warp = $('<div></div>');
        for (var i = 0, l = schemeList.length; i < l; i++) {
            var item = schemeList[i];
            var ponit;

            if (categoryId != '') {
                if (item.F_Category == categoryId) {
                    ponit = item;
                }
            }
            else {
                ponit = item;
            }

            if (!!ponit) {
                if (keyword != '') {
                    if (ponit.F_Name.indexOf(keyword) == -1 && ponit.F_Code.indexOf(keyword) == -1) {
                        ponit = null;
                    }
                }
            }

            if (!!ponit) {// 刷新流程模板数据
                var _cardbox = "";
                _cardbox += '<div class="card-box" data-value="' + item.F_Id + '" >';
                _cardbox += '    <div class="card-box-img">';
                _cardbox += '        <img src="' + top.$.rootUrl + '/Content/images/filetype/Scheme.png" />';
                _cardbox += '    </div>';
                _cardbox += '    <div class="card-box-content">';
                _cardbox += '        <p>名称：' + item.F_Name + '</p>';
                _cardbox += '        <p>编号：' + item.F_Code + '</p>';
                _cardbox += '    </div>';
                _cardbox += '</div>';                var $cardbox = $(_cardbox);                $cardbox[0].shceme = item;                $warp.append($cardbox);
            }
        }
        $warp.find('.card-box').on('click', function () {
            var $this = $(this);
            var value = $this.attr(item.F_Id);
            if ($this.hasClass('active')) {
                $this.removeClass('active');
                delete schemeListSelected[value];
            }
            else {
                schemeListSelected[value] = $this[0].shceme;
                $this.addClass('active');
            }
        });

        $('#main_list').html($warp);
    }

    var page = {
        init: function () {
            page.bind();
        },
        bind: function () {
            // 加载自定义流程列表
            learun.httpAsync('GET', top.$.rootUrl + '/LR_WorkFlowModule/WfScheme/GetCustmerSchemeInfoList', {}, function (data) {
                schemeList = data;
                render();
            });

            $('#F_ToUserId').lrUserSelect(0);

            $("#txt_keyword").keydown(function (event) {
                if (event.keyCode == 13) {
                    keyword = $(this).val();
                    render();
                }
            });
            // 滚动条
            $('#main_list_warp').mCustomScrollbar({ // 优化滚动条
                theme: "minimal-dark"
            });
        }
    };
    // 保存数据
    acceptClick = function () {
        
    };
    page.init();
}