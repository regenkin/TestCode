/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.03.16
 * 描 述：权限验证模块
 */
(function ($, learun) {
    "use strict";

    $.fn.lrAuthorizeJfGrid = function (op) {
        var _headData = [];
        $.each(op.headData, function (id, item) {
            
            if (!!lrMouduleColumnList[item.name.toLowerCase()]) {
                _headData.push(item);
            }
        });
        op.headData = _headData;
        $('#girdtable').jfGrid(op);
    }

    $(function () {
        var $container = $('[learun-authorize="yes"]');
        $container.find('[id]').each(function () {
            var $this = $(this);
            var id = $this.attr('id');
            if (!lrMouduleButtonList[id]) {
                $this.remove();
            }
        });
        $container.find('.dropdown-menu').each(function () {
            var $this = $(this);
            if ($this.find('li').length == 0) {
                $this.remove();
            }
        });
        $container.css({ 'display': 'inline-block' });
    });

})(window.jQuery, top.learun);