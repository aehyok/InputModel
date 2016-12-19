﻿using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using System.IO;

namespace SinoSZJS.CS.BizMenu
{
        public class SinoMenuServerPlugin : IServerPlugin
        {
                private IServerApplication application;
                private string pluginName = "MenuServerPlugin";
                private string description = "系统菜单逻辑插件";

                #region IServerPlugin Members

                public IServerApplication ServerApplication
                {
                        get
                        {
                                return application;
                        }
                        set
                        {
                                application = value;
                        }
                }

                public string Name
                {
                        get
                        {
                                return pluginName;
                        }
                        set
                        {
                                pluginName = value;
                        }
                }

                public string Description
                {
                        get
                        {
                                return description;
                        }
                        set
                        {
                                description = value;
                        }
                }

                public void Load()
                {
                        application.WriteMessage(string.Format("{0}加载成功!", description));
                        application.AddRemotingService(pluginName, this);
                }

                public void UnLoad()
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public event EventHandler<EventArgs> Loading;

                public event EventHandler<EventArgs> ShowErrorMessage;

                public object GetServiceObject(string _serviceName)
                {
                        return new BIZ_Menu();
                }


                #endregion
        }
}
