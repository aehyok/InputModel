using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        public enum MDType_RefDownloadMode
        {
                /// <summary>
                /// 一次性下载
                /// </summary>
                FullDownload = 1,
                /// <summary>
                /// 分级下载
                /// </summary>
                LevelDownload = 2,
        }
}
