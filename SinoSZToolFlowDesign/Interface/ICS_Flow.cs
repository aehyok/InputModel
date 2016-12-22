using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.DOL;

namespace SinoSZToolFlowDesign.Interface
{
        /// <summary>
        /// 业务流程定义接口
        /// </summary>
        public interface ICS_Flow
        {
                /// <summary>
                /// 保存流程属性
                /// </summary>
                /// <param name="flow_BaseDefine"></param>
                /// <returns></returns>
                bool SaveFlowProperties(Flow_BaseDefine flow_BaseDefine);

                /// <summary>
                /// 保存新流程属性
                /// </summary>
                /// <param name="flow_BaseDefine"></param>
                /// <returns></returns>
                bool SaveNewFlowProperties(Flow_BaseDefine flow_BaseDefine);

                /// <summary>
                /// 通过ID取业务流程属性
                /// </summary>
                /// <param name="_id"></param>
                /// <returns></returns>
                Flow_BaseDefine GetFlowProperties(string _id);

                /// <summary>
                /// 通过流程名称取流程属性
                /// </summary>
                /// <param name="_flowName"></param>
                /// <returns></returns>
                Flow_BaseDefine GetFlowPropertiesByName(string _flowName);

                /// <summary>
                /// 取系统中的所有流程列表及属性
                /// </summary>
                /// <returns></returns>
                List<Flow_BaseDefine> GetFlows();

                /// <summary>
                /// 删除指定的流程
                /// </summary>
                /// <param name="_flowID"></param>
                /// <returns></returns>
                bool DeleteFlow(string _flowID);

                /// <summary>
                /// 保存修改过的流程状态
                /// </summary>
                /// <param name="flow_StateDefine"></param>
                /// <returns></returns>
                bool SaveFlowState(Flow_StateDefine flow_StateDefine);


                /// <summary>
                /// 取所有的流程中的状态
                /// </summary>
                /// <param name="flow_BaseDefine"></param>
                /// <returns></returns>
                List<Flow_StateDefine> GetFlowStatusByFlow(Flow_BaseDefine flow_BaseDefine);

                /// <summary>
                /// 保存新的流程状态
                /// </summary>
                /// <param name="flow_BaseDefine"></param>
                /// <param name="flow_StateDefine"></param>
                /// <returns></returns>
                bool SaveNewFlowState(Flow_BaseDefine flow_BaseDefine, Flow_StateDefine flow_StateDefine);

                /// <summary>
                /// 删除状态
                /// </summary>
                /// <param name="flow_StateID"></param>
                /// <returns></returns>
                bool DeleteFlowState(string flow_StateID);

                /// <summary>
                /// 取指定状态下的所有可操作动作
                /// </summary>
                /// <param name="flow_StateDefine"></param>
                /// <returns></returns>
                List<Flow_StateActionDefine> GetFlowStatusAction(Flow_StateDefine flow_StateDefine);

                /// <summary>
                /// 保存状态的动作定义
                /// </summary>
                /// <param name="flow_StateActionDefine"></param>
                /// <returns></returns>
                bool SaveStateAction(Flow_StateActionDefine flow_StateActionDefine);

                /// <summary>
                /// 保存新的动作定义
                /// </summary>
                /// <param name="flow_StateActionDefine"></param>
                /// <returns></returns>
                bool SaveNewStateAction(Flow_StateActionDefine flow_StateActionDefine);

                /// <summary>
                /// 删除指定动作
                /// </summary>
                /// <param name="p"></param>
                /// <returns></returns>
                bool DeleteStateAction(string _actionID);
        }
}
