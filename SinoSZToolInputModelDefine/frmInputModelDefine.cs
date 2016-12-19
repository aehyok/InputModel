using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using SinoSZToolInputModelDefine.EditPanel;
using DevExpress.XtraBars.Ribbon;
using SinoSZToolInputModelDefine.Define;
using DevExpress.XtraEditors;
using SinoSZToolInputModelDefine.Dialog;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.InputModel;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;

namespace SinoSZToolInputModelDefine
{
	public partial class frmInputModelDefine : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private IMenuControl CurrentControl = null;
		public frmInputModelDefine()
		{
			InitializeComponent();
		}

		private void frmInputModelDefine_Load(object sender, EventArgs e)
		{
			InitNodes();
         
		}

		public Object FocusedItem
		{
			get
			{
				if (treeList1.FocusedNode == null) return null;
				object _selectedObj = treeList1.FocusedNode.GetValue(this.treeListColumn1);
				return _selectedObj;
			}
		}

		private void InitNodes()
		{
			treeList1.Nodes.Clear();

                OraMetaDataFactroy _of = new OraMetaDataFactroy();
                IList<MD_Nodes> _nodes = _of.GetNodeList();
                foreach (MD_Nodes _node in _nodes)
                {
                    TreeListNode _fnode = treeList1.AppendNode(null, null);
                    _fnode.SetValue(this.treeListColumn1, _node);
                    _fnode.HasChildren = true;
                    _fnode.ImageIndex = 1;
                    _fnode.SelectImageIndex = 0;
                }
                ShowNodeData(treeList1.FocusedNode);
		}

		#region ShowFocusData
		private void ShowNodeData(TreeListNode _selectedNode)
		{
			this.splitContainerControl1.Panel2.Controls.Clear();
			CurrentControl = null;
			if (_selectedNode != null)
			{
				object _selectedObj = _selectedNode.GetValue(this.treeListColumn1);
				if (_selectedObj is MD_Nodes)
				{

				}

				if (_selectedObj is MD_InputModel)
				{
					MD_InputModel _model = _selectedObj as MD_InputModel;
					UC_InputModel _uc = new UC_InputModel(string.Format("{0}.{1}", _model.NameSpace, _model.ModelName));
					_uc.Dock = DockStyle.Fill;
					this.splitContainerControl1.Panel2.Controls.Add(_uc);
					CurrentControl = _uc as IMenuControl;

				}
				if (_selectedObj is MD_InputModel_ColumnGroup)
				{
					ShowInputModelColumns(_selectedObj as MD_InputModel_ColumnGroup);
				}

				if (_selectedObj is MD_InputModel_SaveTable)
				{
					ShowInputModelWriteTableDefine(_selectedObj as MD_InputModel_SaveTable);
				}

				if (_selectedObj is MD_InputModel_Child)
				{
					ShowInputModelChild(_selectedObj as MD_InputModel_Child);
				}

				if (_selectedObj is MD_Title)
				{
					MD_Title _title = _selectedObj as MD_Title;
					switch (_title.TitleType)
					{
						case "MD_INPUTGROUP":
							ShowInputModelColumns(_title.FatherObj as MD_InputModel);
							break;
						case "MD_SAVEDEFINE":
							break;
						case "MD_CHILDDEFINE":

							break;


					}
				}
			}
		}

		private void ShowInputModelChild(MD_InputModel_Child _InputModelChild)
		{
			UC_InputModel_Child _uc = new UC_InputModel_Child(_InputModelChild);
			_uc.Dock = DockStyle.Fill;
			_uc.MenuChanged += new EventHandler<EventArgs>(_uc_MenuChanged);
			this.splitContainerControl1.Panel2.Controls.Add(_uc);
			CurrentControl = _uc as IMenuControl;
		}

		void _uc_MenuChanged(object sender, EventArgs e)
		{
			RaiseMenuChanged();
		}

		private void ShowInputModelWriteTableDefine(MD_InputModel_SaveTable _saveTable)
		{
			UC_WriteTable _uc = new UC_WriteTable(_saveTable);
			_uc.Dock = DockStyle.Fill;
			this.splitContainerControl1.Panel2.Controls.Add(_uc);
			CurrentControl = _uc as IMenuControl;
		}

		private void ShowInputModelColumns(MD_InputModel_ColumnGroup _group)
		{
			UC_InputColumns _uc = new UC_InputColumns(_group);
			_uc.Dock = DockStyle.Fill;
			this.splitContainerControl1.Panel2.Controls.Add(_uc);
			CurrentControl = _uc as IMenuControl;
		}

		private void ShowInputModelColumns(MD_InputModel _model)
		{
			UC_InputColumns _uc = new UC_InputColumns(_model);
			_uc.Dock = DockStyle.Fill;
			this.splitContainerControl1.Panel2.Controls.Add(_uc);
			CurrentControl = _uc as IMenuControl;
		}
		#endregion

		private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
		{
			//展开项
			TreeListNode _fnode = e.Node;
			object _value = _fnode.GetValue(this.treeListColumn1);
			if (_fnode.Nodes.Count == 0 && _fnode.HasChildren)
			{
				LoadChildData(_fnode, _value);
			}
		}

		#region LoadChildTreeItem
		private void LoadChildData(TreeListNode _fnode, object _value)
		{

			if (_value is MD_Nodes)
			{
				MD_Nodes _nodes = _value as MD_Nodes;
				LoadNamespaceOfNodes(_fnode, _nodes);
			}
			if (_value is MD_Namespace)
			{
				MD_Namespace _ns = _value as MD_Namespace;
				LoadInputViewOfNamespace(_fnode, _ns);
			}
			if (_value is MD_InputModel)
			{
				MD_InputModel _model = _value as MD_InputModel;
				LoadInputModelDetial(_fnode, _model);
			}


			if (_value is MD_Title)
			{
				MD_Title _title = _value as MD_Title;
				switch (_title.TitleType)
				{
					case "MD_INPUTCOLUMES":
						LoadInputModelColumnGroup(_fnode, _title.FatherObj as MD_InputModel);
						break;
					case "MD_SAVEDEFINE":
						Load_SaveDesTables(_fnode, _title.FatherObj as MD_InputModel);
						break;
					case "MD_CHILDDEFINE":
						Load_ChildModel(_fnode, _title.FatherObj as MD_InputModel);
						break;


				}
			}
		}

		private void Load_ChildModel(TreeListNode _fnode, MD_InputModel _model)
		{
			foreach (MD_InputModel_Child _child in _model.ChildInputModel)
			{
				TreeListNode _node = treeList1.AppendNode(null, _fnode);
				_node.SetValue(this.treeListColumn1, _child);
				_node.HasChildren = false;
				_node.ImageIndex = 4;
				_node.SelectImageIndex = 0;
			}
		}

		private void Load_SaveDesTables(TreeListNode _fnode, MD_InputModel _model)
		{
			foreach (MD_InputModel_SaveTable _st in _model.WriteTableNames)
			{
				TreeListNode _node = treeList1.AppendNode(null, _fnode);
				_node.SetValue(this.treeListColumn1, _st);
				_node.HasChildren = false;
				_node.ImageIndex = 4;
				_node.SelectImageIndex = 0;
			}
		}

		private void LoadInputModelColumnGroup(TreeListNode _fnode, MD_InputModel _model)
		{

			TreeListNode _node;
			_fnode.Nodes.Clear();

			MD_Title _title = new MD_Title("无分组", "MD_INPUTGROUP", _model);
			_node = treeList1.AppendNode(null, _fnode);
			_node.SetValue(this.treeListColumn1, _title);
			_node.HasChildren = false;
			_node.ImageIndex = 7;
			_node.SelectImageIndex = 0;

			foreach (MD_InputModel_ColumnGroup _group in _model.Groups)
			{
				_node = treeList1.AppendNode(null, _fnode);
				_node.SetValue(this.treeListColumn1, _group);
				_node.HasChildren = false;
				_node.ImageIndex = 7;
				_node.SelectImageIndex = 0;
			}

		}

		private void LoadInputModelDetial(TreeListNode _fnode, MD_InputModel _model)
		{
			MD_Title _title;
			TreeListNode _node;
			_fnode.Nodes.Clear();

			_title = new MD_Title("录入界面字段定义", "MD_INPUTCOLUMES", _model);
			_node = treeList1.AppendNode(null, _fnode);
			_node.SetValue(this.treeListColumn1, _title);
			_node.HasChildren = true;
			_node.ImageIndex = 5;
			_node.SelectImageIndex = 0;

			_title = new MD_Title("写入表定义", "MD_SAVEDEFINE", _model);
			_node = treeList1.AppendNode(null, _fnode);
			_node.SetValue(this.treeListColumn1, _title);
			_node.HasChildren = true;
			_node.ImageIndex = 4;
			_node.SelectImageIndex = 0;

			_title = new MD_Title("子记录录入模型", "MD_CHILDDEFINE", _model);
			_node = treeList1.AppendNode(null, _fnode);
			_node.SetValue(this.treeListColumn1, _title);
			_node.HasChildren = true;
			_node.ImageIndex = 6;
			_node.SelectImageIndex = 0;
		}

		private void LoadInputViewOfNamespace(TreeListNode _fnode, MD_Namespace _ns)
		{
			_fnode.Nodes.Clear();
			IList<MD_InputModel> _models = DAConfig.DataAccess.GetInputModelOfNamespace(_ns.NameSpace);
			foreach (MD_InputModel _inputModel in _models)
			{
				TreeListNode _node = treeList1.AppendNode(null, _fnode);
				_node.SetValue(this.treeListColumn1, _inputModel);
				_node.HasChildren = true;
				_node.ImageIndex = 3;
				_node.SelectImageIndex = 0;
			}
		}

		private void LoadNamespaceOfNodes(TreeListNode _fnode, MD_Nodes _mnode)
		{
			_fnode.Nodes.Clear();
			_mnode.NameSpaces = DAConfig.DataAccess.GetNameSpaceAtNode(_mnode.DWDM) as List<MD_Namespace>;
			foreach (MD_Namespace _ns in _mnode.NameSpaces)
			{
				TreeListNode _node = treeList1.AppendNode(null, _fnode);
				_node.SetValue(this.treeListColumn1, _ns);
				_node.HasChildren = true;
				_node.ImageIndex = 2;
				_node.SelectImageIndex = 0;
			}
		}
		#endregion

		private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			ShowNodeData(e.Node);
			RaiseMenuChanged();
		}

		private void RaiseMenuChanged()
		{
			object _selectedObj = FocusedItem;
			this.ribbonPage1.Groups.Clear();

			if (_selectedObj is MD_Nodes)
			{

			}

			if (_selectedObj is MD_Namespace)
			{
				this.ribbonPage1.Groups.Add(this.RPG_MODEL);
				bt_AddInputModel.Enabled = true;
				bt_DelInputModel.Enabled = false;
				bt_ImportModel.Enabled = true;
				bt_ExportModel.Enabled = false;
			}

			if (_selectedObj is MD_InputModel)
			{
				this.ribbonPage1.Groups.Add(this.RPG_MODEL);
				bt_AddInputModel.Enabled = false;
				bt_DelInputModel.Enabled = true;
				bt_ImportModel.Enabled = false;
				bt_ExportModel.Enabled = true;
			}
			if (_selectedObj is MD_InputModel_ColumnGroup)
			{
				this.ribbonPage1.Groups.Add(this.RPG_GROUP);
				this.bt_AddGroup.Enabled = false;
				this.bt_DelGroup.Enabled = true;
			}

			if (_selectedObj is MD_InputModel_SaveTable)
			{
				this.ribbonPage1.Groups.Add(this.RPG_DESTABLE);
				this.bt_AddSaveTable.Enabled = false;
				this.bt_DelSaveTable.Enabled = true;

			}
			if (_selectedObj is MD_InputModel_Child)
			{
				this.ribbonPage1.Groups.Add(this.RPG_CHILD);
				this.bt_AddChild.Enabled = false;
				this.bt_DelChild.Enabled = true;
			}

			if (_selectedObj is MD_Title)
			{
				MD_Title _title = _selectedObj as MD_Title;
				switch (_title.TitleType)
				{
					case "MD_INPUTCOLUMES":
						this.ribbonPage1.Groups.Add(this.RPG_GROUP);
						this.bt_AddGroup.Enabled = true;
						this.bt_DelGroup.Enabled = false;
						break;
					case "MD_SAVEDEFINE":
						this.ribbonPage1.Groups.Add(this.RPG_DESTABLE);
						this.bt_AddSaveTable.Enabled = true;
						this.bt_DelSaveTable.Enabled = false;
						break;
					case "MD_CHILDDEFINE":
						this.ribbonPage1.Groups.Add(this.RPG_CHILD);
						this.bt_AddChild.Enabled = true;
						this.bt_DelChild.Enabled = false;
						break;


				}
			}



			if (CurrentControl != null)
			{
				foreach (MenuGroup _g in CurrentControl.GetMenuGroups())
				{
					RibbonPageGroup _group = new RibbonPageGroup();
					_group.Text = _g.GroupTitle;
					foreach (string _bname in _g.Buttons)
					{
						BarButtonItem _item = GetButtonByName(_bname);
						if (_item != null) _group.ItemLinks.Add(_item);
					}
					this.ribbonPage1.Groups.Add(_group);
				}

				if (CurrentControl.DataChanged)
				{
					this.ribbonPage1.Groups.Add(this.RPG_SAVE);
				}
			}
		}

		private BarButtonItem GetButtonByName(string _bname)
		{
			foreach (BarButtonItem _bt in this.ribbon.Items)
			{
				if (_bt.Tag == _bname)
				{
					return _bt;
				}
			}
			return null;
		}

		private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_Namespace)
			{
				MD_Namespace _ns = _selectedObj as MD_Namespace;
				MD_InputModel _model = MenuController.AddInputModel(_ns);
				if (treeList1.FocusedNode != null && _model != null)
				{
					if (treeList1.FocusedNode.Nodes.Count > 0)
					{
						TreeListNode _node = treeList1.AppendNode(null, treeList1.FocusedNode);
						_node.SetValue(this.treeListColumn1, _model);
						_node.HasChildren = true;
						_node.ImageIndex = 3;
						_node.SelectImageIndex = 0;
					}
					else
					{
						treeList1.FocusedNode.HasChildren = true;
					}
				}
			}
		}

		private void bt_DelInputModel_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_InputModel)
			{
				MD_InputModel _model = _selectedObj as MD_InputModel;
				if (XtraMessageBox.Show(string.Format("是否确定要删除录入模型[{0}.{1}]?", _model.NameSpace, _model.ModelName),
					"系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (DAConfig.DataAccess.DelInputModel(_model.ID))
					{
						XtraMessageBox.Show("删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.treeList1.Nodes.Remove(this.treeList1.FocusedNode);
					}
					else
					{
						XtraMessageBox.Show("删除失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

			}
		}

		private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoSave();
			}
		}

		private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCancel();
			}
		}

		private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_Title)
			{
				MD_Title _title = _selectedObj as MD_Title;
				MD_InputModel _oldModel = _title.FatherObj as MD_InputModel;
				if (_title.TitleType == "MD_INPUTCOLUMES")
				{
					MD_InputModel_ColumnGroup _group = MenuController.AddInputGroup(_title.FatherObj as MD_InputModel);
					if (_group != null)
					{
						MD_InputModel _model = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", _oldModel.NameSpace, _oldModel.ModelName));
						_title.FatherObj = _model;
						this.treeList1.FocusedNode.Nodes.Clear();
						this.treeList1.FocusedNode.HasChildren = true;
						this.treeList1.FocusedNode.Expanded = false;

					}
					else
					{
						XtraMessageBox.Show("添加分组失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void bt_DelGroup_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_InputModel_ColumnGroup)
			{
				MD_InputModel_ColumnGroup _group = _selectedObj as MD_InputModel_ColumnGroup;

				if (DAConfig.DataAccess.DelInputModelColumnGroup(_group.ModelID, _group.GroupID))
				{
					TreeListNode _pnode = this.treeList1.FocusedNode.ParentNode;
					_pnode.Nodes.Clear();
					MD_Title _title = _pnode.GetValue(this.treeListColumn1) as MD_Title;
					MD_InputModel _oldModel = _title.FatherObj as MD_InputModel;
					MD_InputModel _model = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", _oldModel.NameSpace, _oldModel.ModelName));
					_title.FatherObj = _model;
					_pnode.HasChildren = true;
					_pnode.Expanded = false;

				}
				else
				{
					XtraMessageBox.Show("删除分组失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
		}

		private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("录入字段移往其它组");
			}
		}

		private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("添加字段");
			}
		}

		private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("删除字段");
			}
		}

		private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_Title)
			{
				MD_Title _title = _selectedObj as MD_Title;
				MD_InputModel _oldModel = _title.FatherObj as MD_InputModel;
				if (_title.TitleType == "MD_SAVEDEFINE")
				{
					Dialog_AddSaveTable _f = new Dialog_AddSaveTable();
					if (_f.ShowDialog() == DialogResult.OK)
					{
						if (DAConfig.DataAccess.AddNewInputModelSavedTable(_oldModel.ID, _f.TableName))
						{
							MD_InputModel _model = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", _oldModel.NameSpace, _oldModel.ModelName));
							_title.FatherObj = _model;
							this.treeList1.FocusedNode.Nodes.Clear();
							this.treeList1.FocusedNode.HasChildren = true;
							this.treeList1.FocusedNode.Expanded = false;


						}
					}
				}
			}
		}

		/// <summary>
		/// 导入录入模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_ImportModel_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_Namespace)
			{
				MD_Namespace _ns = _selectedObj as MD_Namespace;
				OpenFileDialog _sf = new OpenFileDialog();
				_sf.Filter = "备份文件|*.XML";
				_sf.FilterIndex = 1;
				if (_sf.ShowDialog() == DialogResult.OK)
				{
					ImportInputModelController _ic = new ImportInputModelController(_sf.FileName, _ns);
					try
					{
						_ic.Import();
						XtraMessageBox.Show("导入成功！", "系统提示");
						OraMetaDataFactroy _of = new OraMetaDataFactroy();
						MD_InputModel _model = _of.GetInputModel(_ns.NameSpace, _ic.ModelName);
						if (treeList1.FocusedNode != null && _model != null)
						{
							if (treeList1.FocusedNode.Nodes.Count > 0)
							{
								TreeListNode _node = treeList1.AppendNode(null, treeList1.FocusedNode);
								_node.SetValue(this.treeListColumn1, _model);
								_node.HasChildren = true;
								_node.ImageIndex = 3;
								_node.SelectImageIndex = 0;
							}
							else
							{
								treeList1.FocusedNode.HasChildren = true;
							}
						}
					}
					catch (Exception ex)
					{
						XtraMessageBox.Show(ex.Message, "导入失败");
					}
				}
			}
		}

		/// <summary>
		/// 导出录入模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_ExportModel_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_InputModel)
			{
				Dialog_ExportInputModel _f = new Dialog_ExportInputModel(_selectedObj as MD_InputModel);
				_f.ShowDialog();
			}
		}


		private void bt_DelSaveTable_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_InputModel_SaveTable)
			{
				MD_InputModel_SaveTable _table = _selectedObj as MD_InputModel_SaveTable;

				if (XtraMessageBox.Show(string.Format("确定要删除写入表{0}吗？", _table.TableName), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (DAConfig.DataAccess.DelInputModelSavedTable(_table.ID))
					{
						//MD_InputModel _model = DAConfig.QueryDataAccess.GetInputModelByID(_table.InputModelID);
						this.treeList1.Nodes.Remove(this.treeList1.FocusedNode);
					}
				}

			}
		}

		private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("同步字段");
			}
		}

		private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("添加写入表字段");
			}
		}

		private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("删除写入表字段");
			}

		}

		private void bt_AddChild_ItemClick(object sender, ItemClickEventArgs e)
		{
			//添加子录入模型
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_Title)
			{
				MD_Title _title = _selectedObj as MD_Title;
				MD_InputModel _mainModel = _title.FatherObj as MD_InputModel;

				Dialog_AddChildModel _f = new Dialog_AddChildModel();
				if (_f.ShowDialog() == DialogResult.OK)
				{
					MD_InputModel _childModel = _f.ChildModel;

					if (DAConfig.DataAccess.AddChildInputModel(_mainModel.ID, _childModel.ID))
					{
						MD_InputModel _model = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", _mainModel.NameSpace, _mainModel.ModelName));
						_title.FatherObj = _model;
						this.treeList1.FocusedNode.Nodes.Clear();
						this.treeList1.FocusedNode.HasChildren = true;
						this.treeList1.FocusedNode.Expanded = false;
					}
				}
			}
		}

		private void bt_DelChild_ItemClick(object sender, ItemClickEventArgs e)
		{
			object _selectedObj = FocusedItem;
			if (_selectedObj is MD_InputModel_Child)
			{
				MD_InputModel_Child _child = _selectedObj as MD_InputModel_Child;

				if (DAConfig.DataAccess.DelInputModelChild(_child.ID))
				{
					TreeListNode _node = this.treeList1.FocusedNode;
					this.treeList1.MoveNext();
					this.treeList1.DeleteNode(_node);
				}
				else
				{
					XtraMessageBox.Show("删除子模型失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("添加子模型参数");
			}
		}

		private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.CurrentControl != null)
			{
				this.CurrentControl.DoCommand("删除子模型参数");
			}
		}







	}
}