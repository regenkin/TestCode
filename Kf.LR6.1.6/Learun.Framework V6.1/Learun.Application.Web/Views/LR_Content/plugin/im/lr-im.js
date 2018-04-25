/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.03.22
 * 描 述：即时聊天-》系统内部通讯
 */
/*网页端操作*/
(function ($, learun) {
    "use strict";
    var userinfo;

    $.lrIM = {
        init: function () {
            $._lrIM.render();

            
        },

        // 添加一条信息
        // id:消息主键;name:消息名称;msg:消息内容;img:消息头像
        addMsgTolist: function (id, name, msg, img) {
            var $list = $('#learun_im_last_list');
            var $item = $list.find('[data-value="' + id + '"]');
            if ($item.length > 0) {


            }
            else {
                var _html = '<li data-value="' + id + '">';
                _html += '<img src="' + top.$.rootUrl + '/Content/images/learunim/' + img + '">';
                _html += '';
                _html += '<div class="lr-im-onemsg">';
                _html += '<p class="lr-im-onemsg-title">' + name + '</p>';
                _html += '<p class="lr-im-onemsg-content">' + msg + '</p>';
                _html += '</div></li>';
            }
        }
        // 更新某一个聊天对象消息数量
        , updateMsgNum: function (id, num) {

        }
    };

    $._lrIM = {
        render: function () {
            var _html = '<div class="lr-im-icon"  ><a href="javascript:;" id="lr_imicon_btn" title="企业内部通讯"><i class="fa fa-commenting"></i><span class="label label-success"></span></a></div>';
            _html += '<div class="lr-im-wrap" >';
            /*联系人列表*/
            _html += '<div class="lr-im-user-list" style="display:none;" id="learun_im_list" >';
            _html += '<div class="lr-im-header">企业内部通讯<div class="lr-im-close"><a id="learun_im_close" href="javascript:;">×</a></div></div>';
            _html += '<div class="lr-im-search"><input type="text" placeholder="搜索：同事名称、讨论组名称"><i class="fa fa-search"></i></div>';

            _html += '<div class="lr-im-body">';

            _html += '<div class="lr-im-body-nav" id="learun_im_list_nav" ><ul>';
            _html += '<li class="active nav_tab" data-value="last"><a title="最近回话"><i class="fa fa-comment"></i></a></li>';
            _html += '<li class="nav_tab" data-value="user"><a title="联系人"><i class="fa fa-user"></i></a></li>';
            _html += '<li class="nav_tab" data-value="group"><a title="讨论组"><i class="fa fa-users" style="font-size: 20px;"></i></a></li>';
            _html += '</ul></div>';

            _html += '<div class="lr-im-body-list" id="learun_im_body_list">';

            
               

            _html += '<ul id="learun_im_last_list" class="active" ></ul>';
            _html += '<ul id="learun_im_user_list" style="display:none;" ><li id="learun_im_mydepartment"><a class="lr-im-item"><i class="fa fa-caret-right"></i><span>本部门</span><em> 0/0 </em></a><ul class="learun-im-chatlist"></ul></li></ul>';
            _html += '<ul id="learun_im_group_list" style="display:none;" ></ul>';

            _html += '</div>';

            _html += '</div>';//<div class="lr-im-body">
            _html += '</div>';//<div class="lr-im-user-list">

            /*聊天窗口*/
            _html += '<div class="lr-im-window" style="display:none;" id="learun_im_window">';

            _html += '<div class="lr-im-window-header"><span class="text"></span><div class="close"><a href="javascript:;">×</a></div></div>';
            _html += '<div class="lr-im-window-tool"><a class="lr-im-window-tool-face " title="选择表情"><i class="fa fa-meh-o"></i></a></div>';
            _html += '<div class="lr-im-window-send"><textarea autofocus="" placeholder="按回车发送消息,shift+回车换行"></textarea></div>'

            _html += '</div>';

            _html += '</div>';

            $('body').append(_html);



            /*注册事件*/
            // 外部触发按钮
            $('#lr_imicon_btn').on('click', function () {
                var $im = $('#learun_im_list');
                if ($im.is(':hidden')) {
                    $im.show();
                }
            });

            // 关闭按钮
            $('#learun_im_close').on('click', function () {
                var $im = $('#learun_im_list');
                var $im_message_window = $('#learun_im_window');
                $im.hide();
                $im_message_window.hide();
            });

            // 联系人列表切换
            $('#learun_im_list_nav li').on('click', function () {
                var $this = $(this);
                if (!$this.hasClass('active')) {
                    var $parent = $this.parent();
                    $parent.find('.active').removeClass('active');
                    $this.addClass('active');

                    var id = '#learun_im_' + $this.attr('data-value') + '_list';
                    var $list = $(id);

                    $('#learun_im_body_list>ul.active').removeClass('active').hide();
                    $list.addClass('active').show();
                }
            });

            // 右键菜单
            $('#learun_im_body_list').learuncontextmenu({
                before: function (e, $panel) {
                    
                },
                menulist: [
                    {
                        id: 'addfirend',
                        text: '添加好友',
                        click: $._lrIM.addFirend
                    },
                    {
                        id: 'addteam',
                        text: '添加分组',
                        click: function () {

                        }
                    },
                    {
                        id: 'renameteam',
                        text: '重命名分组',
                        click: function () {

                        }
                    },
                    {
                        id: 'renameteam',
                        text: '新建群组',
                        click: function () {

                        }
                    },
                    {
                        id: 'renameteam',
                        text: '重命名群',
                        click: function () {

                        }
                    }

                ]
            });


        }
         , addFirend: function () {// 添加好友
             learun.layerForm({
                 id: 'form',
                 title: '添加好友',
                 url: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
                 width: 800,
                 height: 520,
                 maxmin: true,
                 callBack: function (id) {
                     return top[id].acceptClick(function (users) {
                         console.log(users);
                     });
                 }
             });
         }


       

       
       
    }

   
})(jQuery, top.learun);
/*连接服务端操作*/
(function ($, learun) {
    "use strict";
    var userinfo;
    var imChat;

    $.imServer = {
        init: function () {
            return;
            /* 首先需要获取用户的登录信息 */
            $.imServer.getUserInfo(function () {
                // 初始化客户端界面代码
                $.lrIM.init();
                // 连接服务端
                $.imServer.connect();
            });
        }
        // 连接服务端
        , connect: function () {
            $.ajax({
                url: userinfo.imUrl + "/hubs",
                type: "get",
                dataType: "text",
                success: function (data) {
                    eval(data);
                    //Set the hubs URL for the connection
                    $.connection.hub.url = userinfo.imUrl;
                    $.connection.hub.qs = { "userId": userinfo.UserId };
                    // Declare a proxy to reference the hub.
                    imChat = $.connection.ChatsHub;
                    $.imServer.registerClient();
                    // 连接成功后注册服务器方法
                    $.connection.hub.start().done(function () {
                        $.imServer.registerServer();
                        $.imServer.afterSuccess();
                    });
                    //断开连接后
                    $.connection.hub.disconnected(function () {
                        $.imServer.disconnected();
                    });
                }
            });
        }
        // 连接成功后执行方法
        , afterSuccess: function () {

        }
        // 断开连接后执行
        , disconnected: function () {

        }

        // 注册客户端方法
        , registerClient: function () {

        }
        // 注册服务端方法
        , registerServer: function () {

        }



        // 获取用户登录信息
        , getUserInfo: function (callback) {
            userinfo = learun.clientdata.get(['userinfo']);
            if (!!userinfo) {
                callback();
            }
            else {
                setTimeout(function () {
                    $.imServer.getUserInfo(callback);
                }, 100);
            }
        }
    };
})(jQuery, top.learun);