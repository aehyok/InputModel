using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolInputModelDefine.Define;

namespace SinoSZToolInputModelDefine
{
        public interface IMenuControl
        {
                List<MenuGroup> GetMenuGroups();

                event EventHandler<EventArgs> MenuChanged;

                bool DataChanged { get;}


                void DoSave();

                void DoCancel();

                void DoCommand(string CommandName);
        }
}
