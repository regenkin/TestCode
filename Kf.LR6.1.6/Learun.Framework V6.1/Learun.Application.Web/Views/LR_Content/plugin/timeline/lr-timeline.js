/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力 软信息技术有限公司
 * 创建人：力 软-前端开发组
 * 日 期：2017.03.22
 * 描 述：时间轴方法（降序）
 */
$.fn.lrtimeline = function (op) {
    var dfop = {
        nodelist: [

        ]
    };
    $.extend(dfop, op || {});
    var $self = $(this);
    if ($self.length == 0) {
        return $self;
    }
    dfop.id = $self.attr('id');
    if (!dfop.id) {
        return false;
    }
    $self.addClass('lr-timeline');
    var $wrap = $('<div class="lr-timeline-allwrap"></div>');
    var $ul = $('<ul></ul>');

    // 开始节点
    var $begin = $('<li class="lr-timeline-header"><div>当前</div></li>')
    $ul.append($begin);

    // 中间节点
    var $li = $('<li class="lr-timeline-item" ><div class="lr-timeline-wrap lr-timeline-current" ></div></li>');
    var $itemwrap = $li.find('.lr-timeline-wrap');
    var $itemcontent = $('<div class="lr-timeline-content"><span class="arrow"></span></div>');
    $itemcontent.append('<div class="lr--timeline-title">普通节点审核</div>');
    $itemcontent.append('<div class="lr--timeline-body"><span>审核人</span>正在处理中!</div>')
    $itemwrap.append('<span class="lr-timeline-date">2017-08-28 16:18:33</span>');
    $itemwrap.append($itemcontent);
    $ul.append($li);
    // 结束节点
    $ul.append('<li class="lr-timeline-ender"><div>发起</div></li>');
    
    $wrap.html($ul);
    $self.html($wrap);

};