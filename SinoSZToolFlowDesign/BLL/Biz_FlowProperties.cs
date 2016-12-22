using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolFlowDesign.DOL;
using SinoSZToolFlowDesign.Interface;
using SinoSZToolFlowDesign.DAL;
using SinoSZBaseClass.Misc;
using System.Configuration;

namespace SinoSZToolFlowDesign.BLL
{
        [Serializable]
        public class Biz_FlowProperties
        {
                public Biz_FlowProperties() { }

                public Biz_FlowProperties(string _id)
                {
                        _isNew = true;
                        _flowDefine = new Flow_BaseDefine(Guid.NewGuid().ToString(), "新流程", "", "0");
                }

                public Biz_FlowProperties(Flow_BaseDefine _flow)
                {
                        _flowDefine = _flow;
                        _isNew = false;
                }

                #region 私有属性
                protected Flow_BaseDefine _flowDefine = null;
                protected bool _isNew = true;
                static private ICS_Flow flowInterface = null;
                static public ICS_Flow FlowInterface
                {
                        get
                        {
                                if (flowInterface == null)
                                {
                                        string dbType = ConfigurationManager.AppSettings["DataBaseType"].ToUpper();
                                        switch (dbType)
                                        {
                                                case "ORACLE":
                                                        DA_FlowDefine _da = new DA_FlowDefine();
                                                        flowInterface = _da as ICS_Flow;
                                                        break;
                                                case "ACCESS":
                                                        DA_FlowDefine_Accesss _daAccess = new DA_FlowDefine_Accesss();
                                                        flowInterface = _daAccess as ICS_Flow;
                                                        break;
                                        }
                                }
                                return flowInterface;
                        }
                        set
                        {
                                flowInterface = value;
                        }
                }

                protected List<Biz_FlowState> status = null;
                #endregion

                #region 属性
                public List<Biz_FlowState> Status
                {
                        get
                        {
                                return status;
                        }
                }

                /// <summary>
                /// 主键值
                /// </summary>
                public string ID
                {
                        get
                        {
                                if (_flowDefine == null) return "";
                                return _flowDefine.ID;
                        }
                }

                /// <summary>
                /// 流程名称
                /// </summary>
                public string Name
                {
                        get
                        {
                                if (_flowDefine == null) return "";
                                return _flowDefine.FlowName;
                        }

                        set
                        {
                                if (_flowDefine == null) return;
                                _flowDefine.FlowName = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 流程描述
                /// </summary>
                public string Description
                {
                        get
                        {
                                if (_flowDefine == null) return "";
                                return _flowDefine.Description;
                        }

                        set
                        {
                                if (_flowDefine == null) return;
                                _flowDefine.Description = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 组织机构的根ID
                /// </summary>
                public string RootDWID
                {
                        get
                        {
                                if (_flowDefine == null) return "";
                                return _flowDefine.RootDWID;
                        }

                        set
                        {
                                if (_flowDefine == null) return;
                                _flowDefine.RootDWID = value;
                                OnChanged();
                        }
                }


                /// <summary>
                /// 流程属性定义
                /// </summary>
                public Flow_BaseDefine FlowDefine
                {
                        get { return _flowDefine; }
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
                /// <summary>
                /// 保存流程属性定义
                /// </summary>
                /// <returns></returns>
                public bool Save()
                {
                        if (FlowInterface == null) return false;
                        if (_isNew)
                        {
                                bool _ret = FlowInterface.SaveNewFlowProperties(this._flowDefine);
                                if (_ret) _isNew = false;
                                return _ret;
                        }
                        else
                        {
                                return FlowInterface.SaveFlowProperties(this._flowDefine);
                        }
                }

                /// <summary>
                /// 取指定ID的流程属性定义
                /// </summary>
                /// <param name="_id">通过ID取流程属性定义</param>
                /// <returns></returns>
                static public Biz_FlowProperties GetFlowProperties(string _id)
                {
                        if (FlowInterface == null) return null;
                        Flow_BaseDefine _flow = FlowInterface.GetFlowProperties(_id);
                        return new Biz_FlowProperties(_flow);
                }

                /// <summary>
                /// 取指定名称的流程属性定义
                /// </summary>
                /// <param name="_flowName">流程名称</param>
                /// <returns></returns>
                static public Biz_FlowProperties GetFlowPropertiesByName(string _flowName)
                {
                        if (FlowInterface == null) return null;
                        Flow_BaseDefine _flow = FlowInterface.GetFlowPropertiesByName(_flowName);
                        return new Biz_FlowProperties(_flow);
                }

                /// <summary>
                /// 取系统中所有的流程定义
                /// </summary>
                /// <returns></returns>
                static public List<Biz_FlowProperties> GetAllFlows()
                {
                        if (FlowInterface == null) return null;
                        List<Flow_BaseDefine> _flows = FlowInterface.GetFlows();
                        List<Biz_FlowProperties> _ret = new List<Biz_FlowProperties>();
                        foreach (Flow_BaseDefine _fd in _flows)
                        {
                                _ret.Add(new Biz_FlowProperties(_fd));
                        }
                        return _ret;
                }

                /// <summary>
                /// 删除本流程定义
                /// </summary>
                /// <returns></returns>
                public bool DeleteMe()
                {
                        if (FlowInterface == null) return false;
                        if (_isNew) return true;
                        return FlowInterface.DeleteFlow(this.ID);
                }

                /// <summary>
                /// 加载本流程的所有状态
                /// </summary>
                /// <returns></returns>
                public bool LoadStatus()
                {
                        if (FlowInterface == null) return false;
                        List<Flow_StateDefine> _ts = FlowInterface.GetFlowStatusByFlow(this._flowDefine);
                        this.status = new List<Biz_FlowState>();
                        if (_ts == null) return true;
                        foreach (Flow_StateDefine _sd in _ts)
                        {
                                Biz_FlowState _ret = new Biz_FlowState(this, _sd);
                                this.status.Add(_ret);
                        }
                        return true;
                }
                #endregion


                public override string ToString()
                {
                        return string.Format("[{0}]{1}", this.Name, this.Description);
                }


                internal Biz_FlowState GetStateDefine(Flow_StateDefine flow_StateDefine)
                {
                        if (flow_StateDefine == null) return null;
                        foreach (Biz_FlowState _st in this.Status)
                        {
                                if (_st.StateID == flow_StateDefine.ID)
                                {
                                        return _st;
                                }
                        }
                        return null;
                }
        }
}
