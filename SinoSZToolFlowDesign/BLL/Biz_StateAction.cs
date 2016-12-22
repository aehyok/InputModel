using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.DOL;
using SinoSZToolFlowDesign.Interface;
using SinoSZToolFlowDesign.DAL;

namespace SinoSZToolFlowDesign.BLL
{
        public class Biz_StateAction
        {
                protected Flow_StateActionDefine _actionDefine=null;

                public Biz_StateAction() { }
                public Biz_StateAction(string _id, Biz_FlowState _state)
                {
                        _isNew = true;
                        stateDefine = _state;
                        _actionDefine = new Flow_StateActionDefine(_id, "NEWACTION", "新动作", _state.StateDefine, null, "业务流处理",3,0,"");
                }

                public Biz_StateAction(Biz_FlowState _state,Flow_StateActionDefine _action)
                {
                        _isNew = false;
                        stateDefine = _state;
                        _actionDefine = _action;
                }

                #region 属性
                /// <summary>
                /// 主键值
                /// </summary>
                public string ActionID
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                return _actionDefine.ActionID;
                        }
                }

                /// <summary>
                /// 参数定义
                /// </summary>
                public string ParamDefine
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                return _actionDefine.ParamDefine;
                        }

                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.ParamDefine = value;
                                OnChanged();
                        }
                }


                /// <summary>
                /// 动作名称
                /// </summary>
                public string ActionName
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                return _actionDefine.ActionName;
                        }

                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.ActionName = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 动作类型
                /// </summary>
                public string ActionType
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                return _actionDefine.ActionType;
                        }

                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.ActionType = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 显示顺序
                /// </summary>
                public int DisplayOrder
                {
                        get
                        {
                                if (_actionDefine == null) return 0;
                                return _actionDefine.DisplayOrder;
                        }

                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.DisplayOrder = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 使用者类型
                /// </summary>
                public int UserType
                {
                        get
                        {
                                if (_actionDefine == null) return 0;
                                return _actionDefine.UserType;
                        }

                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.UserType = value;
                                OnChanged();
                        }
                }
                /// <summary>
                /// 动作显示名称
                /// </summary>
                public string ActionTitle
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                return _actionDefine.ActionTitle;
                        }
                        set
                        {
                                if (_actionDefine == null) return;
                                _actionDefine.ActionTitle = value;
                                OnChanged();
                        }
                }

             
                /// <summary>
                /// 开始状态描述
                /// </summary>
                public string BeginStateName
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                if (_actionDefine.BeginState == null) return "";
                                return _actionDefine.BeginState.DisplayName;
                        }
                }

                /// <summary>
                /// 结束状态描述
                /// </summary>
                public string EndStateName
                {
                        get
                        {
                                if (_actionDefine == null) return "";
                                if (_actionDefine.EndState == null) return "";
                                return _actionDefine.EndState.DisplayName;
                        }                     
                }

                /// <summary>
                /// 开始状态
                /// </summary>
                public Biz_FlowState BeginState
                {
                        get
                        {
                                if (this.stateDefine == null) return null;
                                return this.stateDefine;
                        }
                        set
                        {
                                this.stateDefine = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 结束状态
                /// </summary>
                public Flow_StateDefine EndState
                {
                        get
                        {
                                if (this._actionDefine == null) return null;
                                return this._actionDefine.EndState;
                        }

                        set
                        {
                                if (this._actionDefine == null) return;
                                this._actionDefine.EndState = value;
                                OnChanged();
                        }
                }

                #endregion


                #region 私有属性               
                protected Biz_FlowState stateDefine = null;
                protected bool _isNew = true;
              
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
                                bool _ret = Biz_FlowProperties.FlowInterface.SaveNewStateAction(this._actionDefine);
                                if (_ret) _isNew = false;
                                return _ret;
                        }
                        else
                        {
                                return Biz_FlowProperties.FlowInterface.SaveStateAction(this._actionDefine);
                        }
                }

                public bool DeleteMe()
                {
                       
                        if (_isNew) return true;
                        return Biz_FlowProperties.FlowInterface.DeleteStateAction(this._actionDefine.ActionID);
                }

                #endregion

            
        }
}
