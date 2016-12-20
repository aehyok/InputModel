using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.IMetaData;
using SinoSZJS.CS.BizMetaDataManager.DAL;


namespace SinoSZToolInputModelDefine
{
    public class DAConfig
    {
        private static IMetaDataFactroy _dataAccess = null;
        public static IMetaDataFactroy DataAccess
        {
            get
            {
                if (_dataAccess == null)
                {
                    _dataAccess = new OraMetaDataFactroy();
                }
                return _dataAccess;
            }
        }

        private static IMetaDataQueryFactroy _queryDataAccess = null;
        public static IMetaDataQueryFactroy QueryDataAccess
        {
            get
            {
                if (_queryDataAccess == null)
                {
                    _queryDataAccess = new OraMetaDataQueryFactroy();
                }
                return _queryDataAccess;
            }
        }
    }
}
