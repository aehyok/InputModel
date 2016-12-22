using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZToolFlowDesign.DOL
{
        [Serializable]
        public class Flow_StateActionDefine
        {
                private string actionID ;
                private string actionName ;
                private string actionTitle;
                private string actionType ;
                private int userType ;
                private int displayOrder ;
                private string param ;

                private Flow_StateDefine beginState ;
                private Flow_StateDefine endState ;


               
                public Flow_StateActionDefine(string _actionID, string _actionName, string _actionTitle, Flow_StateDefine _beginState, Flow_StateDefine _endState,
                                        string _actionType, int _userType,int _order,string _param)
                {
                        actionID = _actionID;
                        actionName = _actionName;
                        actionTitle = _actionTitle;
                        beginState = _beginState;
                        endState = _endState;
                        actionType = _actionType;
                        userType = _userType;
                        displayOrder = _order;
                        param = _param;
                }

                public string ParamDefine
                {
                        get { return param; }
                        set { param = value; }
                }
                       

                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                /// <summary>
                /// 状态变迁动作ID
                /// </summary>
                public string ActionID
                {
                        get { return actionID; }
                        set { actionID = value; }
                }

                /// <summary>
                /// 状态变迁动作名
                /// </summary>
                public string ActionName
                {
                        get { return actionName; }
                        set { actionName = value; }
                }

                /// <summary>
                /// 状态变迁动作显示名
                /// </summary>
                public string ActionTitle
                {
                        get { return actionTitle; }
                        set { actionTitle = value; }
                }

                /// <summary>
                /// 初始状态
                /// </summary>
                public Flow_StateDefine BeginState
                {
                        get { return beginState; }
                        set { beginState = value; }
                }

                /// <summary>
                /// 结束状态
                /// </summary>
                public Flow_StateDefine EndState
                {
                        get { return endState; }
                        set { endState = value; }
                }

                /// <summary>
                /// 动作类型　　(业务流处理:指移交流转等,常规动作:保存.打印,生成文书等)
                /// </summary>
                public string ActionType
                {
                        get { return actionType; }
                        set { actionType = value; }
                }

                /// <summary>
                /// 动作使用者类型(0 所有人 1,有查看权的人　2,历史处理人　3.当前处理人)　
                /// </summary>
                public int UserType
                {
                        get { return userType; }
                        set { userType = value; }
                }



        }
}
