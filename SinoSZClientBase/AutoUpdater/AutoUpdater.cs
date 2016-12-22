using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using SinoSZBaseClass.SharpZipLib.Zip;
using System.Reflection;
using SinoSZBaseClass;
using SinoSZBaseClass.AutoUpdater;
using System.Windows.Forms;
using System.IO.Compression;


namespace SinoSZClientBase.AutoUpdater
{
        public partial class AutoUpdater : Component
        {
                public bool _finishedFlag = false;

                public AutoUpdater()
                {
                        InitializeComponent();
                }

                public AutoUpdater(IContainer container)
                {
                        container.Add(this);

                        InitializeComponent();
                }

                #region 属性定义

                private string _LoginUserName;
                [DefaultValue(@"")]
                [Description("The UserName to authenticate with."),
                Category("AutoUpdater Configuration")]
                public string LoginUserName
                { get { return _LoginUserName; } set { _LoginUserName = value; } }

                private string _LoginUserPass;
                [DefaultValue(@"")]
                [Description("The Password to authenticate with."),
                Category("AutoUpdater Configuration")]
                public string LoginUserPass
                { get { return _LoginUserPass; } set { _LoginUserPass = value; } }

                private string _ConfigURL;
                [DefaultValue(@"http://localhost/UpdateConfig.xml")]
                [Description("The URL Path to the configuration file."),
                Category("AutoUpdater Configuration")]
                public string ConfigURL
                { get { return _ConfigURL; } set { _ConfigURL = value; } }

                private bool _AutoRestart;//If true, the app will restart automatically, if false the app will use the RestartForm to prompt the user, if RestartForm is null, it doesn't restart
                [DefaultValue(false)]
                [Description("Set to True if you want the app to restart automatically, set to False if you want to use the RestartForm to prompt the user, if RestartForm is null, the app will not restart."),
                Category("AutoUpdater Configuration")]
                public bool AutoRestart
                { get { return _AutoRestart; } set { _AutoRestart = value; } }

                private string _LocalPath = "";
                [DefaultValue(@"")]
                [Description("Local file path."),
                Category("Local File Path")]
                public string LocalPath
                {
                        get
                        {
                                return (_LocalPath == "") ?
                                        Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                                        : _LocalPath;
                        }
                        set { _LocalPath = value; }
                }

                #endregion


                #region 定义事件
                public event EventHandler<UpdateProgessEventArgs> UpdateProgress;
                virtual public void RaiseUpdateProgress(string _msg)
                {
                        if (UpdateProgress != null)
                        {
                                UpdateProgress(this, new UpdateProgessEventArgs(_msg));
                        }
                }

                public event EventHandler<ErrorEventArgs> UpdateError;
                virtual public void RaiseUpdateError(string _errorMsg)
                {
                        if (UpdateError != null)
                        {
                                UpdateError(this, new ErrorEventArgs(new Exception(_errorMsg)));
                        }
                }

                #endregion
                /// <summary>
                /// TryUpdate: Invoke this method when you are ready to run the update checking thread
                /// 此方法用于调用升级进程
                /// </summary>
                public void TryUpdate()
                {
                        Thread backgroundThread = new Thread(new ThreadStart(this.updateThread));
                        backgroundThread.IsBackground = true;
                        backgroundThread.Start();
                }

                /// <summary>
                /// updateThread: This is the Thread that runs for checking updates against the config file
                /// 此方法先通过与配置文件进行比较，然后下载版本最新的程序
                /// </summary>
                private void updateThread()
                {
                        AssemblyName myAssemblyName = null;
                        string stUpdateName = "update";
                        AutoUpdateConfig config = new AutoUpdateConfig();
                        RaiseUpdateProgress(string.Format("正在检查版本号..."));
                        //For using untrusted SSL Certificates
                        System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

                        //Do the load of the config file
                        if (config.LoadConfig(this.ConfigURL, this.LoginUserName, this.LoginUserPass))
                        {
                                IList<UpdateFileInfo> _needUpdateList = new List<UpdateFileInfo>();
                                foreach (UpdateFileInfo _cvfile in config.CurrentVersionfiles)
                                {

                                        string _fname = string.Format("{0}\\{1}", LocalPath, _cvfile.FileName);
                                        RaiseUpdateProgress(string.Format("比较文件{0}的版本号...",_cvfile.FileName));
                                        //取当前版本号  
                                        if (File.Exists(_fname))
                                        {
                                                myAssemblyName = AssemblyName.GetAssemblyName(_fname);
                                                //比较版本号,如果有新版本，加入下载更新列表                                       
                                                Version vConfig = new Version(_cvfile.AvailableVersion);
                                                if (myAssemblyName.Version < vConfig)
                                                {
                                                        _needUpdateList.Add(_cvfile);
                                                }
                                        }
                                        else
                                        {
                                                //如果本地不存在此文件
                                                _needUpdateList.Add(_cvfile);
                                        }
                                }

                                if (_needUpdateList.Count > 0)　　//如果需下载列表中有记录
                                {
                                        foreach (UpdateFileInfo _nuFile in _needUpdateList)
                                        {
                                                int i = 0;
                                                while (i < 3)
                                                {
                                                        i++;
                                                        if (UpdateFileProcess(_nuFile, stUpdateName))
                                                        {
                                                                i = 100;
                                                        }
                                                }
                                                if (i < 90)
                                                {
                                                        RaiseUpdateError(string.Format("下载升级文件{0}失败！\n自动更新过程失败！", _nuFile.AppFileURL));
                                                        this._finishedFlag = true;
                                                        return;
                                                }
                                        }
                                        if (this.AutoRestart) this.restart();
                                }
                        }
                        else
                                RaiseUpdateError(string.Format("{0}中未找到版本信息，无法完成自动更新。请重新配置自动更新地址！ ", this.ConfigURL));
                        this._finishedFlag = true;

                }

                private bool UpdateFileProcess(UpdateFileInfo _nuFile, string stUpdateName)
                {
                        //改显示信息
                        RaiseUpdateProgress(string.Format("正在下载{0}文件{1}版本...", _nuFile.FileName, _nuFile.AvailableVersion));
                        //下载                                                
                        DirectoryInfo diDest = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
                        string stPath = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + _nuFile.FileName + ".zip";

                        if (this.downloadFile(_nuFile.AppFileURL, stPath))
                        {
                                //XtraMessageBox.Show("Downloaded New File");
                                string stDest = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + stUpdateName + System.IO.Path.DirectorySeparatorChar;
                                if (!Directory.Exists(stDest))
                                {
                                        Directory.CreateDirectory(stDest);
                                }
                                stDest += _nuFile.FileName;
                                //Extract Zip File
                                try
                                {
                                        //this.unzip(stPath, stDest);
                                        DecompressFile(stPath, stDest);
                                }
                                catch (Exception e)
                                {
                                        RaiseUpdateError(string.Format("解压升级文件{0}失败！\n自动更新过程失败！\n {1}", _nuFile.AppFileURL, e.Message));
                                        return false;
                                }

                                //Delete Zip File
                                File.Delete(stPath);
                                //Restart App if Necessary
                                //If true, the app will restart automatically, if false the app will use the RestartForm to prompt the user, if RestartForm is null, it doesn't restart
                                //else don't restart
                        }
                        else
                        {
                                return false;
                        }
                        return true;
                }

                /// <summary>
                /// downloadFile: Download a file from the specified url and copy it to the specified path
                /// 下载升级文件
                /// </summary>
                private bool downloadFile(string url, string path)
                {
                        try
                        {
                                //create web request/response
                                HttpWebResponse Response;
                                HttpWebRequest Request;

                                Request = (HttpWebRequest)WebRequest.Create(url);
                                //Request.Headers.Add("Translate: f");
                                Request.Method = "GET";
                                if (this.LoginUserName != null && this.LoginUserName != "")
                                        Request.Credentials = new NetworkCredential(this.LoginUserName, this.LoginUserPass);
                                else
                                        Request.Credentials = CredentialCache.DefaultCredentials;
                                Request.AllowAutoRedirect = true;

                                Response = (HttpWebResponse)Request.GetResponse();

                                Stream respStream = null;
                                respStream = Response.GetResponseStream();

                                //Do the Download
                                byte[] buffer = new byte[4096];
                                int length;

                                FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write);

                                length = respStream.Read(buffer, 0, 4096);
                                while (length > 0)
                                {
                                        fs.Write(buffer, 0, length);
                                        length = respStream.Read(buffer, 0, 4096);
                                }
                                fs.Close();
                                respStream.Close();
                                Response.Close();
                                
                        }
                        catch (Exception e)
                        {
                                string _msg = string.Format("Problem copying file from:{0} to: {1} \n ErrorMsg:{2}", url, path, e.Message);
                                //ErrorLogClass.WriteLog(_msg, "ERROR");
                                if (File.Exists(path))
                                        File.Delete(path);
                                return false;
                        }
                        return true;
                }


                /// <summary>
                /// 旧版方法，已经不用．　unzip: Open the zip file specified by stZipPath, into the stDestPath Directory
                /// 将压缩文件解包
                /// </summary>
                private void unzip(string stZipPath, string stDestPath)
                {
                        ZipInputStream s = new ZipInputStream(File.OpenRead(stZipPath));

                        ZipEntry theEntry;
                        while ((theEntry = s.GetNextEntry()) != null)
                        {

                                string fileName = stDestPath + Path.GetDirectoryName(theEntry.Name) + System.IO.Path.DirectorySeparatorChar + Path.GetFileName(theEntry.Name);

                                //create directory for file (if necessary)
                                Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                                if (!theEntry.IsDirectory)
                                {
                                        FileStream streamWriter = File.Create(fileName);

                                        int size = 2048;
                                        byte[] data = new byte[2048];
                                        while (true)
                                        {
                                                size = s.Read(data, 0, data.Length);
                                                if (size > 0)
                                                {
                                                        streamWriter.Write(data, 0, size);
                                                }
                                                else
                                                {
                                                        break;
                                                }
                                        }

                                        streamWriter.Close();
                                }
                        }
                        s.Close();
                }

                /// <summary>
                /// 新版解压缩方法
                /// </summary>
                /// <param name="sourceFile"></param>
                /// <param name="destinationFile"></param>
                public static void DecompressFile(string sourceFile, string destinationFile)
                {
                        if (!File.Exists(sourceFile)) throw new FileNotFoundException();
                        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
                        {
                                byte[] quartetBuffer = new byte[4];
                                int position = (int)sourceStream.Length - 4;
                                sourceStream.Position = position;
                                sourceStream.Read(quartetBuffer, 0, 4);
                                sourceStream.Position = 0;
                                int checkLength = BitConverter.ToInt32(quartetBuffer, 0);
                                byte[] buffer = new byte[checkLength + 100];
                                using (GZipStream decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true))
                                {
                                        int total = 0;
                                        for (int offset = 0; ; )
                                        {
                                                int bytesRead = decompressedStream.Read(buffer, offset, 100);
                                                if (bytesRead == 0) break;
                                                offset += bytesRead;
                                                total += bytesRead;
                                        }
                                        using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create))
                                        {
                                                destinationStream.Write(buffer, 0, total);
                                                destinationStream.Flush();
                                        }
                                }
                        }
                }


                /// <summary>
                /// restart: Restart the app, the AppStarter will be responsible for actually restarting the main application.
                /// 退出老程序，并重新启动引导程序
                /// </summary>
                private void restart()
                {
                        Environment.ExitCode = 2; //the surrounding AppStarter must look for this to restart the app.
                        Application.Exit();
                }

        }

        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
                public TrustAllCertificatePolicy()
                { }

                public bool CheckValidationResult(ServicePoint sp,
                        System.Security.Cryptography.X509Certificates.X509Certificate cert, WebRequest req, int problem)
                {
                        return true;
                }
        }
}
