using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.InputModel
{
        [Serializable]
        public class MD_InputModel_Column
        {
                private string columnid = "";
                private string columnName = "";
                private string displayName = "";
                private int displayOrder = 0;
                private int maxLength = 0;
                private string columnType = "";

                private string inputModelID = "";
                private bool canSave = false;
                private bool canDisplay = true;
                private bool isCompute = false;
                private bool readOnly = false;

                private string dwdm = "";
                private string defaultValue = "";
                private string inputRule = "";
                private string dataChangedEvent = "";
                private string canEditRule = "";
                private int width = 1;
                private int lineHeight = 1;

                private int textAlign = 0;
                private string editFormat = "";
                private string displayFormat = "";

                private bool required = false;
                private string toolTipText = "";

                public int MaxInputLength
                {
                        get { return maxLength; }
                        set { maxLength = value; }
                }

                public string DataChangedEvent
                {
                        get { return dataChangedEvent; }
                        set { dataChangedEvent = value; }
                }

                public bool Required
                {
                        get { return required; }
                        set { required = value; }
                }

                public string ToolTipText
                {
                        get { return toolTipText; }
                        set { toolTipText = value; }
                }


                public int TextAlign
                {
                        get { return textAlign; }
                        set { textAlign = value; }
                }

                public string EditFormat
                {
                        get { return editFormat; }
                        set { editFormat = value; }
                }

                public string DisplayFormat
                {
                        get { return displayFormat; }
                        set { displayFormat = value; }
                }

                public int Width
                {
                        get { return width; }
                        set { width = value; }
                }

                public int LineHeight
                {
                        get { return lineHeight; }
                        set { lineHeight = value; }
                }


                public string DWDM
                {
                        get { return dwdm; }
                        set { dwdm = value; }
                }

                public string DefaultValue
                {
                        get { return defaultValue; }
                        set { defaultValue = value; }
                }
                public string InputRule
                {
                        get { return inputRule; }
                        set { inputRule = value; }
                }

                public string CanEditRule
                {
                        get { return canEditRule; }
                        set { canEditRule = value; }
                }

                public string InputModelID
                {
                        get { return inputModelID; }
                        set { inputModelID = value; }
                }
                public bool CanSave
                {
                        get { return canSave; }
                        set { canSave = value; }
                }
                public bool CanDisplay
                {
                        get { return canDisplay; }
                        set { canDisplay = value; }
                }
                public bool IsCompute
                {
                        get { return isCompute; }
                        set { isCompute = value; }
                }
                public bool ReadOnly
                {
                        get { return readOnly; }
                        set { readOnly = value; }
                }


                public string ColumnID
                {
                        get { return columnid; }
                        set { columnid = value; }
                }

                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }
                public string ColumnType
                {
                        get { return columnType; }
                        set { columnType = value; }
                }
                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                public MD_InputModel_Column(string _id, string _columnName, string _displayName, string _columnType, int _order, string _inputModelID,
                                                                                bool _canSave, bool _canDisplay, bool _isCompute, bool _readOnly, string _dwdm, string _defalutValue,
                                                                                string _inputRule, string _editRule, int _width, int _height, int _align, string _editFormat, string _displayFormat,
                                                                                bool _required, string _toolTipText, int _maxLength, string _dataChangedEvent)
                {
                        required = _required;
                        maxLength = _maxLength;
                        toolTipText = _toolTipText;
                        textAlign = _align;
                        editFormat = _editFormat;
                        displayFormat = _displayFormat;
                        columnid = _id;
                        columnName = _columnName;
                        displayName = _displayName;
                        columnType = _columnType;
                        displayOrder = _order;

                        inputModelID = _inputModelID;
                        canSave = _canSave;
                        canDisplay = _canDisplay;
                        isCompute = _isCompute;
                        readOnly = _readOnly;

                        dwdm = _dwdm;
                        defaultValue = _defalutValue;
                        inputRule = _inputRule;
                        canEditRule = _editRule;
                        width = _width;
                        lineHeight = _height;
                        dataChangedEvent = _dataChangedEvent;
                }




        }
}
