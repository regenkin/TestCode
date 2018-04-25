/*
 * 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2017 上海力软信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.03.17
 * 描 述：获取客户端数据
 */
/*
`*******************登录后数据***********************
 *userinfo----------------------用户登录信息

 *modules-----------------------功能模块
 *modulesTree-------------------按照父节点的功能模块
 *modulesMap--------------------主键对应实例数据

 *******************使用时异步获取*******************
 *user--------------------------用户数据
    learun.clientdata.getAsync('user', {
        userId: value,
        callback: function (item) {
            callback(item.F_RealName);
        }
    });
 *department--------------------部门数据
    learun.clientdata.getAsync('department', {
        key: value,
        companyId: row.F_CompanyId,
        callback: function (item) {
            callback(item.F_FullName);
        }
    });
 *company----------------------公司
    learun.clientdata.getAsync('company', {
            key: value,
            callback: function (_data) {
                _data.F_FullName
            }
   });
 *db--------------------------数据库
    learun.clientdata.getAsync('db', {
            key: value,
            callback: function (_data) {
                _data.F_DBName
            }
   });
 *dataItem--------------------数据字典
 learun.clientdata.getAsync('dataItem', {
            key: value,
            itemCode:itemCode,
            callback: function (_data) {
                _data.F_ItemName
            }
   });
 *custmerData-----------------自定义数据
 learun.clientdata.getAsync('custmerData', {
        url: url,
        key: value,
        valueId: valueId,
        callback: function (item) {
            callback(item.F_FullName);
        }
    });
*/
(function ($, learun) {
    "use strict";

    var callback = null;
    var clientDataFn = {};
    var clientAsyncData = {};
    var clientData = {};
    var loadSate ={
        no:-1,  // 还未加载
        yes:1,  // 已经加载成功
        ing:0,  // 正在加载中
        fail:2  // 加载失败
    };
    function excelImportTemplateFormat() {//excel导入模板数据格式化
        $.each(clientData.excelImportTemplate, function (i, item) {
            clientData.excelImportTemplate[i] = {
                keys: item
            }
        });
    }
    function get(key, data) {
        var res = "";
        var len = data.length;
        if (len == undefined) {
            res = data[key];
        }
        else {
            for (var i = 0; i < len; i++) {
                if (key(data[i])) {
                    res = data[i];
                    break;
                }
            }
        }
        return res;
    }
    function initLoad() {
        var res = loadSate.yes;
        for (var id in clientDataFn) {
            var _fn = clientDataFn[id];
            if (_fn.state == loadSate.fail) {
                res = loadSate.fail;
                break;
            }
            else if (_fn.state == loadSate.no) {
                res = loadSate.ing;
                _fn.init();
            }
            else if (_fn.state == loadSate.ing) {
                res = loadSate.ing;
            }
        }
        return res;
    }
    
    learun.clientdata = {
        init: function (fn) {
           
            if (callback == null) {
                callback = fn;
            }
            var res = initLoad();
            if (res == loadSate.yes) {
                // 成功后显示页面去掉加载动画和处理一些回调函数
                callback(true);
            }
            else if (res == loadSate.ing) {
                setTimeout(learun.clientdata.init, 100);// 如果还在加载100ms后再检测
            }
            else {
                // 加载失败后处理
                callback(false);
            }
        },
        get: function (nameArray) {//[key,function (v) { return v.key == value }]
            var res = "";
            if (!nameArray) {
                return res;
            }
            var len = nameArray.length;
            var data = clientData;
            for (var i = 0; i < len; i++) {
                res = get(nameArray[i], data);
                if (res != "" && res != undefined) {
                    data = res;
                }
                else {
                    break;
                }
            }
            res = res || "";
            return res;
        },
        getAsync: function (name, op) {//
            return clientAsyncData[name].get(op);
        }
    };

    /*******************登录后数据***********************/
    // 注册数据的加载方法
    // 功能模块数据
    clientDataFn.modules = {
        state: loadSate.no,
        init: function () {
            //初始化加载数据
            clientDataFn.modules.state = loadSate.ing;
            learun.httpAsyncGet($.rootUrl + '/LR_SystemModule/Module/GetModuleList', function (res) {
                if (res.code == learun.httpCode.success) {
                    clientData.modules = res.data;
                    clientDataFn.modules.toMap();
                    clientDataFn.modules.state = loadSate.yes;
                }
                else {
                    clientData.modules = [];
                    clientDataFn.modules.toMap();
                    clientDataFn.modules.state = loadSate.fail;
                }
            });
        },
        toMap: function () {
            //转化成树结构 和 转化成字典结构
            var modulesTree = {};
            var modulesMap = {};
            var _len = clientData.modules.length;
            for (var i = 0; i < _len; i++)
            {
                var _item = clientData.modules[i];
                if (_item.F_EnabledMark == 1) {
                    modulesTree[_item.F_ParentId] = modulesTree[_item.F_ParentId] || [];
                    modulesTree[_item.F_ParentId].push(_item);
                    modulesMap[_item.F_ModuleId] = _item;
                }
            }
            clientData.modulesTree = modulesTree;
            clientData.modulesMap = modulesMap;
        }
    };
    // 登录用户信息
    clientDataFn.userinfo = {
        state: loadSate.no,
        init: function () {
            //初始化加载数据
            clientDataFn.userinfo.state = loadSate.ing;
            learun.httpAsyncGet($.rootUrl + '/Login/GetUserInfo', function (res) {
                if (res.code == learun.httpCode.success) {
                    clientData.userinfo = res.data;
                    clientDataFn.userinfo.state = loadSate.yes;
                }
                else {
                    clientDataFn.userinfo.state = loadSate.fail;
                }
            });
        }
    };
    /*******************使用时异步获取*******************/
    // 公司信息
    clientAsyncData.company = {
        timeout: 300000,// 默认时间5分钟
        states: loadSate.no,
        get: function (op) {
            if (clientAsyncData.company.states == loadSate.no) {
                clientAsyncData.company.states = loadSate.ing;
                clientAsyncData.company.load();
            }

            if (clientAsyncData.company.states == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.company.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData['company'];
                if (!!data) {
                    op.callback(clientAsyncData.company.find(op.key, data));
                } else {
                    op.callback({});
                }
            }
        },
        load: function () {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_OrganizationModule/Company/GetList', null, function (data) {
                if (!!data) {
                    clientData['company'] = data;
                }
                clientAsyncData.company.states = loadSate.yes;
                setTimeout(function () {
                    clientAsyncData.company.states = loadSate.no;
                }, clientAsyncData.company.timeout);// 数据过期时间
            });
        },
        find: function (key, data) {
            var res = {};
            for (var i = 0, l = data.length; i < l; i++) {
                if (data[i].F_CompanyId == key) {
                    res = data[i];

                    break;
                }
            }
            return res;
        }
    };

    // 部门信息
    clientAsyncData.department = {
        timeout: 300000,// 默认时间5分钟
        states: {},
        get: function (op) {
            if (clientAsyncData.department.states[op.companyId] == undefined || clientAsyncData.department.states[op.companyId] == loadSate.no) {
                clientAsyncData.department.states[op.companyId] = loadSate.ing;
                clientAsyncData.department.load(op.companyId);
            }

            if (clientAsyncData.department.states[op.companyId] == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.department.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData[op.companyId];
                if (!!data) {
                    op.callback(clientAsyncData.department.find(op.key, data));
                } else {
                    op.callback({});
                }
            }
        },
        load: function (companyId) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_OrganizationModule/Department/GetList', { companyId: companyId }, function (data) {
                if (!!data) {
                    clientData[companyId] = data;
                }
                clientAsyncData.department.states[companyId] = loadSate.yes;
                setTimeout(function () {
                    clientAsyncData.department.states[companyId] = loadSate.no;
                }, clientAsyncData.department.timeout);// 如果还在加载100ms后再检测
            });
        },
        find: function (key, data) {
            var res = {};
            for (var i = 0, l = data.length; i < l; i++) {
                if (data[i].F_DepartmentId == key) {
                    res = data[i];
                    
                    break;
                }
            }
            return res;
        }
    };
    clientAsyncData.departmentone = {
        states: {},
        get: function (op) {
            clientData.departmentone = clientData.departmentone || {};
            if (clientAsyncData.departmentone.states[op.departmentId] == undefined || clientAsyncData.departmentone.states[op.departmentId] == loadSate.no) {
                clientAsyncData.departmentone.states[op.departmentId] = loadSate.ing;
                clientAsyncData.departmentone.load(op.departmentId);
            }

            if (clientAsyncData.departmentone.states[op.departmentId] == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.departmentone.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData.departmentone[op.departmentId];
                if (!!data) {
                    op.callback(data);
                } else {
                    op.callback({});
                }
            } 
        },
        load: function (departmentId) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_OrganizationModule/Department/GetEntity', { departmentId: departmentId }, function (data) {
                if (!!data) {
                    clientData.departmentone[departmentId] = data;
                }
                clientAsyncData.departmentone.states[departmentId] = loadSate.yes;
            });
        }
    };


    // 用户信息
    clientAsyncData.user = {
        states: {},
        get: function (op) {
            clientData.user = clientData.user || {};
            if (clientAsyncData.user.states[op.userId] == undefined || clientAsyncData.user.states[op.userId] == loadSate.no) {
                clientAsyncData.user.states[op.userId] = loadSate.ing;
                clientAsyncData.user.load(op.userId);
            }

            if (clientAsyncData.user.states[op.userId] == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.user.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData.user[op.userId];
                if (!!data) {
                    op.callback(data, op);
                } else {
                    op.callback({}, op);
                }
            }
              
        },
        load: function (userId) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_OrganizationModule/User/GetUserEntity', { userId: userId }, function (data) {
                if (!!data) {
                    clientData.user[userId] = data;
                }
                clientAsyncData.user.states[userId] = loadSate.yes;
            });
        }
    };

    // 数据库连接数据
    clientAsyncData.db = {
        timeout: 600000,// 默认时间10分钟
        states: loadSate.no,
        get: function (op) {
            if (clientAsyncData.db.states == loadSate.no) {
                clientAsyncData.db.states = loadSate.ing;
                clientAsyncData.db.load();
            }

            if (clientAsyncData.db.states == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.db.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData['db'];
                if (!!data) {
                    op.callback(clientAsyncData.db.find(op.key, data));
                } else {
                    op.callback({});
                }
            }
        },
        load: function () {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/DatabaseLink/GetList', null, function (data) {
                if (!!data) {
                    clientData['db'] = data;
                }
                clientAsyncData.db.states = loadSate.yes;
                setTimeout(function () {
                    clientAsyncData.db.states = loadSate.no;
                }, clientAsyncData.db.timeout);// 数据过期时间
            });
        },
        find: function (key, data) {
            var res = {};
            for (var i = 0, l = data.length; i < l; i++) {
                if (data[i].F_DatabaseLinkId == key) {
                    res = data[i];
                    break;
                }
            }
            return res;
        }
    };

    // 数据字典
    clientAsyncData.dataItem = {
        states: {},
        get: function (op) {
            clientData.dataItem = clientData.dataItem || {};
            if (clientAsyncData.dataItem.states[op.itemCode] == undefined || clientAsyncData.dataItem.states[op.itemCode] == loadSate.no) {
                clientAsyncData.dataItem.states[op.itemCode] = loadSate.ing;
                clientAsyncData.dataItem.load(op.itemCode);
            }
            if (clientAsyncData.dataItem.states[op.itemCode] == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.dataItem.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData.dataItem[op.itemCode];
                if (!!data) {
                    op.callback(clientAsyncData.dataItem.find(op.key, data));
                } else {
                    op.callback({});
                }
            }
        },
        load: function (itemCode) {
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/DataItem/GetDetailList', { itemCode: itemCode }, function (data) {
                if (!!data) {
                    clientData.dataItem[itemCode] = data;
                }
                clientAsyncData.dataItem.states[itemCode] = loadSate.yes;
            });
        },
        find: function (key, data) {
            var res = {};
            for (var i = 0, l = data.length; i < l; i++) {
                if (data[i].F_ItemValue == key) {
                    res = data[i];
                    break;
                }
            }
            return res;
        }
    };
    // 获取自定义数据 url key valueId
    clientAsyncData.custmerData = {
        timeout: 300000,// 默认时间5分钟
        states: {},
        get: function (op) {
            if (clientAsyncData.custmerData.states[op.url] == undefined || clientAsyncData.custmerData.states[op.url] == loadSate.no) {
                clientAsyncData.custmerData.states[op.url] = loadSate.ing;
                clientAsyncData.custmerData.load(op.url);
            }

            if (clientAsyncData.custmerData.states[op.url] == loadSate.ing) {
                var op2 = op;
                setTimeout(function () {
                    clientAsyncData.custmerData.get(op2);
                }, 100);// 如果还在加载100ms后再检测
            }
            else {
                var data = clientData[op.url];
                if (!!data) {
                    op.callback(clientAsyncData.custmerData.find(op.key, op.valueId, data));
                } else {
                    op.callback({});
                }
            }
        },
        load: function (url) {
            learun.httpAsync('GET', top.$.rootUrl + url, {}, function (data) {
                if (!!data) {
                    clientData[url] = data;
                }
                clientAsyncData.custmerData.states[url] = loadSate.yes;
                setTimeout(function () {
                    clientAsyncData.custmerData.states[url] = loadSate.no;
                }, clientAsyncData.custmerData.timeout);// 如果还在加载100ms后再检测
            });
        },
        find: function (key, valueId, data) {
            var res = {};
            for (var i = 0, l = data.length; i < l; i++) {
                if (data[i][valueId] == key) {
                    res = data[i];
                    break;
                }
            }
            return res;
        }
    };
})(window.jQuery, top.learun);