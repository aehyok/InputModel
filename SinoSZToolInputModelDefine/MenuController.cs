using System;
using System.Collections.Generic;
using System.Text;
using SinoSZToolInputModelDefine.Dialog;
using System.Windows.Forms;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine
{
        public class MenuController
        {
                public static MD_InputModel AddInputModel(MD_Namespace _ns)
                {
                        Dialog_AddInputModel _f = new Dialog_AddInputModel(_ns);
                        if (_f.ShowDialog() == DialogResult.OK)
                        {
                                return _f.NewInputModel();
                        }
                        else
                        {
                                return null;
                        }
                }

                public static MD_InputModel_ColumnGroup AddInputGroup(MD_InputModel _model)
                {
                        string _newid = DAConfig.DataAccess.GetNewID();
                        MD_InputModel_ColumnGroup _group = new MD_InputModel_ColumnGroup(_newid, _model.ID, _newid, _model.Groups.Count + 1);
                        if (DAConfig.DataAccess.AddNewInputModelGroup(_group))
                        {
                                return _group;
                        }
                        else
                        {
                                return null;
                        }
                }
        }
}
