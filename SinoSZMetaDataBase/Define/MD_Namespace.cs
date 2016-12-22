using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        /// <summary>
        /// �����ռ�Ԫ���ݶ���
        /// </summary>
        /// 
        [Serializable]
        public class MD_Namespace
        {
                private string _namespace;              //�����ռ���
                private string _description;            //����
                private string _displayTitle;           //��ʾ����
                private string _owner;                  //���������ݿ��е�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                private string _menuPosition;           //�˵����ڵ�λ��(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                private int _displayOrder;              //��ʾ˳��
                private string _dwdm;                   //�ڵ����,ָϵͳ����װ�ķ��������ڵĵ�λ����,���������ֽڵ�
                private string _concepts;               //���ռ������ĸ�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                private IList<MD_Table> _tableList = new List<MD_Table>();
                private IList<MD_QueryModel> _queryModelList = new List<MD_QueryModel>();     //���ռ�������ļ���  
                private IList<MD_RefTable> _refTableList = new List<MD_RefTable>();     
                private MD_Nodes _node;

                /// <summary>
                /// �����ռ���
                /// </summary>
                public string NameSpace
                {
                        get
                        {
                                return _namespace;
                        }
                        set
                        {
                                _namespace = value;
                        }
                }

                /// <summary>
                /// ����
                /// </summary>
                public string Description
                {
                        get
                        {
                                return _description;
                        }
                        set
                        {
                                _description = value;
                        }
                }

                /// <summary>
                /// ��ʾ����
                /// </summary>
                public string DisplayTitle
                {
                        get
                        {
                                return _displayTitle;
                        }
                        set
                        {
                                _displayTitle = value;
                        }
                }

                /// <summary>
                /// ���������ݿ��е�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                /// </summary>
                public string Owner
                {
                        get
                        {
                                return _owner;
                        }
                        set
                        {
                                _owner = value;
                        }
                }

                /// <summary>
                /// �˵����ڵ�λ��(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                /// </summary>
                public string MenuPosition
                {
                        get
                        {
                                return _menuPosition;
                        }
                        set
                        {
                                _menuPosition = value;
                        }
                }

                /// <summary>
                /// �ڵ����,ָϵͳ����װ�ķ��������ڵĵ�λ����,���������ֽڵ�
                /// </summary>
                public string DWDM
                {
                        get
                        {
                                return _dwdm;
                        }
                        set
                        {
                                _dwdm = value;
                        }
                }

                /// <summary>
                /// ���ռ������ĸ�����(����������,������Ϊ�˼��ݴ�ǰ�İ汾)
                /// </summary>
                public string Concepts
                {
                        get
                        {
                                return _concepts;
                        }
                        set
                        {
                                _concepts = value;
                        }
                }

                /// <summary>
                /// ��ʾ˳��
                /// </summary>
                public int DisplayOrder
                {
                        get
                        {
                                return _displayOrder;
                        }
                        set
                        {
                                _displayOrder = value;
                        }
                }

                /// <summary>
                /// �����ռ��еı�
                /// </summary>
                public IList<MD_Table> TableList
                {
                        get
                        {
                                return _tableList;
                        }
                        set
                        {
                                _tableList = value;
                        }
                }

                /// <summary>
                /// �����ռ�Ĳ�ѯģ��
                /// </summary>
                public IList<MD_QueryModel> QueryModelList
                {
                        get
                        {
                                return _queryModelList;
                        }
                        set
                        {
                                _queryModelList = value;
                        }
                }


                public IList<MD_RefTable> RefTableList
                {
                        get { return _refTableList; }
                        set { _refTableList = value; }
                }

                /// <summary>
                /// �����ռ����ڽڵ�
                /// </summary>
                public MD_Nodes Nodes
                {
                        get
                        {
                                return _node;
                        }
                        set
                        {
                                _node = value;
                        }
                }

                public MD_Namespace(string _namespacename,string _des,string _menupos,string _display,string _ow,int _disorder,string _dw,
                          string _con)
                {
                        this._namespace = _namespacename;
                        this._description = _des;
                        this._displayOrder = _disorder;
                        this._displayTitle = _display;
                        this._dwdm = _dw;
                        this._menuPosition = _menupos;
                        this._owner = _ow;
                        this._concepts = _con;
                }

                public override string ToString()
                {
                        return string.Format("�����ռ�[{0}]",this.DisplayTitle);
                }


                        
        }
}
