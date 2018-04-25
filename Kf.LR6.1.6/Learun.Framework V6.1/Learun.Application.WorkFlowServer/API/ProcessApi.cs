using Learun.Application.WorkFlow;
using Nancy;
namespace Learun.Application.WorkFlowServer.API
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.05.12
    /// 描 述：流程进程实例API
    /// </summary>
    public class ProcessApi : BaseApi
    {
        /// <summary>
        /// 注册接口
        /// </summary>
        public ProcessApi()
            : base("/workflow")
        {
            Post["/bootstraper"] = Bootstraper;
            Post["/taskinfo"] = Taskinfo;
            Post["/processinfo"] = ProcessInfo;

            Post["/create"] = Create;
            Post["/audit"] = Audit;
        }

        /// <summary>
        /// 工作流引擎
        /// </summary>
        private WfEngineIBLL wfEngineIBLL = new WfEngineBLL();

        #region 获取信息
        /// <summary>
        /// 初始化流程模板->获取开始节点数据
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Bootstraper(dynamic _)
        {
            WfParameter wfParameter = this.GetReqData<WfParameter>();
            wfParameter.companyId = this.userInfo.companyId;
            wfParameter.departmentId = this.userInfo.departmentId;
            wfParameter.userId = this.userInfo.userId;
            wfParameter.userName = this.userInfo.realName;

            WfResult<WfContent> res = wfEngineIBLL.Bootstraper(wfParameter);
            return this.Success<WfResult<WfContent>>(res);
        }
        /// <summary>
        /// 获取流程审核节点的信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Taskinfo(dynamic _)
        {
            WfParameter wfParameter = this.GetReqData<WfParameter>();
            wfParameter.companyId = this.userInfo.companyId;
            wfParameter.departmentId = this.userInfo.departmentId;
            wfParameter.userId = this.userInfo.userId;
            wfParameter.userName = this.userInfo.realName;

            WfResult<WfContent> res = wfEngineIBLL.GetTaskInfo(wfParameter);
            return this.Success<WfResult<WfContent>>(res);
        }
        /// <summary>
        /// 获取流程实例信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response ProcessInfo(dynamic _)
        {
            WfParameter wfParameter = this.GetReqData<WfParameter>();
            wfParameter.companyId = this.userInfo.companyId;
            wfParameter.departmentId = this.userInfo.departmentId;
            wfParameter.userId = this.userInfo.userId;
            wfParameter.userName = this.userInfo.realName;

            WfResult<WfContent> res = wfEngineIBLL.GetProcessInfo(wfParameter);
            return this.Success<WfResult<WfContent>>(res);
        }
        #endregion

        #region 提交信息
        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Create(dynamic _)
        {
            WfParameter wfParameter = this.GetReqData<WfParameter>();
            wfParameter.companyId = this.userInfo.companyId;
            wfParameter.departmentId = this.userInfo.departmentId;
            wfParameter.userId = this.userInfo.userId;
            wfParameter.userName = this.userInfo.realName;

            WfResult res = wfEngineIBLL.Create(wfParameter);
            return this.Success<WfResult>(res);
        }
        /// <summary>
        /// 审核流程实例
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Audit(dynamic _)
        {
            WfParameter wfParameter = this.GetReqData<WfParameter>();
            wfParameter.companyId = this.userInfo.companyId;
            wfParameter.departmentId = this.userInfo.departmentId;
            wfParameter.userId = this.userInfo.userId;
            wfParameter.userName = this.userInfo.realName;

            WfResult res = wfEngineIBLL.Audit(wfParameter);
            return this.Success<WfResult>(res);
        }
        #endregion

    }
}
