using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZPluginFramework;
using SinoSZJS.CS.Tasks.Customs.TJS;

namespace SinoSZJS.CS.Tasks
{
    public class TaskServerPlugin : IServerPlugin
    {
        private IServerApplication application;
        private string pluginName = "TaskServerPlugin";
        private string description = "缉私办案工作平台任务插件库";
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
                return this.pluginName;
            }
            set
            {
                this.pluginName = value;
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
            AddNewTask(new TaskPlugin_TJS() as ITaskPlugin);


        }

        private void AddNewTask(ITaskPlugin _plugin)
        {
            application.AddTask(_plugin.Name, _plugin as ITaskPlugin);
        }

        public void UnLoad()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public event EventHandler<EventArgs> Loading;

        public event EventHandler<EventArgs> ShowErrorMessage;

        public object GetServiceObject(string _serviceName)
        {
            return null;
        }




        #endregion
    }
}
