using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// <summary>
    /// 流程缓存定义
    /// </summary>
    [DataContract]
    public class SystemFlow
    {
        /// <summary>
        /// FLOW索引，键值为 flowID
        /// </summary>
        protected static Dictionary<string, Flow_EntityType> FlowDict = new Dictionary<string, Flow_EntityType>();
        /// <summary>
        /// 状态索引，键值为stateID
        /// </summary>
        protected static Dictionary<string, Flow_EntityStatus> StateDict = new Dictionary<string, Flow_EntityStatus>();
        /// <summary>
        /// 动作索引，键值为actionID
        /// </summary>
        protected static Dictionary<string, Flow_StateActionDefine> ActionDict = new Dictionary<string, Flow_StateActionDefine>();
        /// <summary>
        /// 流程的状态列表，键值为 flowID
        /// </summary>
        protected static Dictionary<string, List<Flow_EntityStatus>> StateListDict = new Dictionary<string, List<Flow_EntityStatus>>();
        /// <summary>
        /// 状态的动作列表，键值为stateID
        /// </summary>
        protected static Dictionary<string, List<Flow_StateActionDefine>> ActionListDict = new Dictionary<string, List<Flow_StateActionDefine>>();

        /// <summary>
        /// 流程代理
        /// </summary>
        public static IFlow Flow { get; set; }

        /// <summary>
        /// 添加一个流程
        /// </summary>
        /// <param name="flow"></param>
        public static void AddFlow(FlowEntity flow)
        {
            if (!FlowDict.ContainsKey(flow.Flow.Id))
            {
                FlowDict.Add(flow.Flow.Id, flow.Flow);

                List<Flow_EntityStatus> stateList = new List<Flow_EntityStatus>();
                foreach (var state in flow.StateList)
                {
                    StateDict.Add(state.State.Id, state.State);
                    stateList.Add(state.State);
                    List<Flow_StateActionDefine> actionList = new List<Flow_StateActionDefine>();
                    foreach (var action in state.ActionList)
                    {
                        ActionDict.Add(action.Action.ActionId, action.Action);
                        actionList.Add(action.Action);
                    }
                    ActionListDict.Add(state.State.Id, actionList);
                }
                StateListDict.Add(flow.Flow.Id, stateList);
            }
        }

        /// <summary>
        /// 通过flowID取流程定义
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        public static Flow_EntityType GetFlowDefine(string flowId)
        {
            if (Flow != null)
            {
                if (!FlowDict.ContainsKey(flowId))
                {
                    AddFlow(Flow.GetFlowByFlowId(flowId));
                }
                return FlowDict[flowId];
            }
            else
                return null;
        }

        public static Flow_StateActionDefine GetCreateAction(string flowId)
        {
            if (Flow != null)
            {
                if (!StateListDict.ContainsKey(flowId))
                {
                    AddFlow(Flow.GetFlowByFlowId(flowId));
                }
                foreach (var state in StateListDict[flowId])
                {
                    if (state.Type == "开始")
                    {
                        return GetActionList(state.Id).Find(a => { return a.UserType <= 3; });
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据stateName取状态定义。注意：调用该方法的前提是该流程定义已经加载到缓存
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public static Flow_EntityStatus GetStateByName(string stateName)
        {
            if (Flow != null)
            {
                foreach (var state in StateDict)
                {
                    if (state.Value.Name == stateName)
                    {
                        return state.Value;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据stateID取状态定义
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public static Flow_EntityStatus GetStateById(string stateId)
        {
            if (Flow != null)
            {
                if (!StateDict.ContainsKey(stateId))
                {
                    AddFlow(Flow.GetFlowByStateId(stateId));
                }
                return StateDict[stateId];
            }
            else
                return null;
        }

        /// <summary>
        /// 根据actionID取动作定义
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public static Flow_StateActionDefine GetActionById(string actionId)
        {
            if (Flow != null)
            {
                if (!ActionDict.ContainsKey(actionId))
                {
                    AddFlow(Flow.GetFlowByActionId(actionId));
                }
                return ActionDict[actionId];
            }
            else
                return null;
        }

        /// <summary>
        /// 根据stateID取状态的动作列表
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public static List<Flow_StateActionDefine> GetActionList(string stateId)
        {
            if (Flow != null)
            {
                if (!ActionListDict.ContainsKey(stateId))
                {
                    AddFlow(Flow.GetFlowByStateId(stateId));
                }
                return ActionListDict[stateId];
            }
            else
                return null;
        }

        /// <summary>
        /// 根据flowID取流程的状态列表
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        public static List<Flow_EntityStatus> GetStateList(string flowId)
        {
            if (Flow != null)
            {
                if (!StateListDict.ContainsKey(flowId))
                {
                    AddFlow(Flow.GetFlowByFlowId(flowId));
                }
                return StateListDict[flowId];
            }
            else
                return null;
        }

        /// <summary>
        /// 清空所有定义
        /// </summary>
        public static void Clear()
        {
            FlowDict.Clear();
            StateDict.Clear();
            ActionDict.Clear();
            StateListDict.Clear();
            ActionListDict.Clear();
        }
    }
}
