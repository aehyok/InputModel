using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.DOL;
using SinoSZToolFlowDesign.DAL;
using SinoSZToolFlowDesign.Interface;

namespace SinoSZToolFlowDesign.BLL
{
        [Serializable]
        public class Biz_FlowState
        {
                protected List<Biz_StateAction> actions = null;
               
                public Biz_FlowState() { }
                public Biz_FlowState(string _id, Biz_FlowProperties _flow)
                {
                        _isNew = true;
                        this.flow = _flow;
                        this.stateDefine = new Flow_StateDefine(_id, "NEWSTATE", "新状态", "新状态", "通用", 1000);

                }

                public Biz_FlowState(Biz_FlowProperties _flow, Flow_StateDefine _state)
                {
                        _isNew = false;
                        this.flow = _flow;
                        this.stateDefine = (Flow_StateDefine)_state.Clone();
                }

                #region 私有属性
                private Biz_FlowProperties flow = null;
                protected Flow_StateDefine stateDefine = null;
                protected bool _isNew = true;
               

                #endregion


                #region 属性
                /// <summary>
                /// 主键值
                /// </summary>
                public string StateID
                {
                        get
                        {
                                if (stateDefine == null) return "";
                                return stateDefine.ID;
                        }
                }

                /// <summary>
                /// 状态名称
                /// </summary>
                public string StateName
                {
                        get
                        {
                                if (stateDefine == null) return "";
                                return stateDefine.Name;
                        }

                        set
                        {
                                if (stateDefine == null) return;
                                stateDefine.Name = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayName
                {
                        get
                        {
                                if (stateDefine == null) return "";
                                return stateDefine.DisplayName;
                        }
                        set
                        {
                                if (stateDefine == null) return;
                                stateDefine.DisplayName = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 状态描述
                /// </summary>
                public string Description
                {
                        get
                        {
                                if (stateDefine == null) return "";
                                return stateDefine.Description;
                        }

                        set
                        {
                                if (stateDefine == null) return;
                                stateDefine.Description = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 状态描述
                /// </summary>
                public string Type
                {
                        get
                        {
                                if (stateDefine == null) return "";
                                return stateDefine.Type;
                        }

                        set
                        {
                                if (stateDefine == null) return;
                                stateDefine.Type = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 显示顺序
                /// </summary>
                public int Order
                {
                        get
                        {
                                if (stateDefine == null) return 0;
                                return stateDefine.Order;
                        }

                        set
                        {
                                if (stateDefine == null) return;
                                stateDefine.Order = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 状态所在的流程
                /// </summary>
                public Biz_FlowProperties Flow
                {
                        get
                        {
                                if (flow == null) return null;
                                return flow;
                        }
                        set
                        {
                                flow = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 状态定义
                /// </summary>
                public Flow_StateDefine StateDefine
                {
                        get
                        {
                                return this.stateDefine;
                        }
                        set
                        {
                                this.stateDefine = value;
                                OnChanged();
                        }
                }

                public List<Biz_StateAction> Actions
                {
                        get
                        {
                                if (this.actions == null) LoadActions();
                                return this.actions;
                        }                   
                }


                #endregion

                #region 事件定义
                public event EventHandler<EventArgs> Changed;
                private void OnChanged()
                {
                        if (Changed != null)
                        {
                                Changed(this, new EventArgs());
                        }
                }
                #endregion

                #region 公共方法
                public bool Save()
                {
                       
                        if (_isNew)
                        {
                                bool _ret = Biz_FlowProperties.FlowInterface.SaveNewFlowState(this.Flow.FlowDefine, this.stateDefine);
                                if (_ret) _isNew = false;
                                return _ret;
                        }
                        else
                        {
                                return Biz_FlowProperties.FlowInterface.SaveFlowState(this.stateDefine);
                        }
                }

                public bool DeleteMe()
                {
                      
                        if (_isNew) return true;
                        return Biz_FlowProperties.FlowInterface.DeleteFlowState(this.StateID);

                }

                public bool LoadActions()
                {

                        List<Flow_StateActionDefine> _ts = Biz_FlowProperties.FlowInterface.GetFlowStatusAction(this.stateDefine);
                        this.actions = new List<Biz_StateAction>();
                        if (_ts == null) return true;
                        foreach (Flow_StateActionDefine _action in _ts)
                        {
                                Biz_StateAction _ret = new Biz_StateAction(this, _action);
                                this.actions.Add(_ret);
                        }
                        return true;
                }
                #endregion

                public override string ToString()
                {
                        return string.Format("[{0}] {1}",this.StateDefine.Name,this.StateDefine.DisplayName);
                }



        }
}
