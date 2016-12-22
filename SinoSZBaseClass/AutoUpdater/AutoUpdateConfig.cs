using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace SinoSZBaseClass.AutoUpdater
{
        public class AutoUpdateConfig
        {
                private IList<UpdateFileInfo> _CurrentVersionFiles = null;
                private List<ClientPluginInfo> _PluginLists = null;

                public List<ClientPluginInfo> PluginList
                {
                        get { return _PluginLists; }
                        set { _PluginLists = value; }
                }


                public IList<UpdateFileInfo> CurrentVersionfiles
                {
                        get { return _CurrentVersionFiles; }
                        set { _CurrentVersionFiles = value; }
                }


                /// <summary>
                /// LoadConfig: Invoke this method when you are ready to populate this object
                /// </summary>
                public bool LoadConfig(string url, string user, string pass)
                {
                        try
                        {
                                //Load the xml config file
                                XmlDocument XmlDoc = new XmlDocument();
                                HttpWebResponse Response;
                                HttpWebRequest Request;
                                //Retrieve the File

                                Request = (HttpWebRequest)WebRequest.Create(url);
                                //Request.Headers.Add("Translate: f");
                                Request.Method = "GET";
                                Request.AllowAutoRedirect = true;

                                if (user != null && user != "")
                                        Request.Credentials = new NetworkCredential(user, pass);
                                else
                                        Request.Credentials = CredentialCache.DefaultCredentials;

                                Response = (HttpWebResponse)Request.GetResponse();

                                Stream respStream = null;
                                respStream = Response.GetResponseStream();

                                //Load the XML from the stream
                                XmlDoc.Load(respStream);

                                //Parse out the AvailableVersion
                                XmlNode AvailableVersionNode = XmlDoc.SelectSingleNode(@"//VersionConfig");

                                CheckFileList(AvailableVersionNode);
                                LoadPluginConfig(url, user, pass);
                                respStream.Close();
                                Response.Close();

                        }
                        catch (Exception e)
                        {
                                Debug.WriteLine("Failed to read the config file at: " + url);
                                Debug.WriteLine("Make sure that the config file is present and has a valid format");
                                Debug.WriteLine("Error Message: " + e.Message);
                                //XtraMessageBox.Show("Make sure that the config file is present and has a valid format");
                                return false;
                        }
                        return true;
                }

                private void WritePluginConfig()
                {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        XmlNode pluginNode = doc.SelectSingleNode("/configuration/PluginSection");
                        pluginNode.RemoveAll();
                        foreach (ClientPluginInfo _pinfo in this.PluginList)
                        {
                                XmlElement ele = doc.CreateElement("add");
                                XmlAttribute attr = doc.CreateAttribute("Name");
                                attr.Value = _pinfo.Name;
                                ele.SetAttributeNode(attr);
                                XmlAttribute attrType = doc.CreateAttribute("Type");
                                attrType.Value = _pinfo.Type;
                                ele.SetAttributeNode(attrType);

                                XmlAttribute attrAss = doc.CreateAttribute("Assembly");
                                attrAss.Value = _pinfo.Assembly;
                                ele.SetAttributeNode(attrAss);

                                XmlAttribute attrDes = doc.CreateAttribute("Description");
                                attrDes.Value = _pinfo.Assembly;
                                ele.SetAttributeNode(attrDes);
                                pluginNode.AppendChild(ele);
                        }
                        doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        ConfigurationManager.RefreshSection("PluginSection");
                }

                /// <summary>
                /// 取插件列表更新文件,注:文件须使用Unicode编码
                /// </summary>
                /// <param name="url"></param>
                /// <param name="user"></param>
                /// <param name="pass"></param>
                private void LoadPluginConfig(string url, string user, string pass)
                {
                        try
                        {
                                //Load the xml config file
                                XmlDocument XmlDoc = new XmlDocument();
                                HttpWebResponse Response;
                                HttpWebRequest Request;
                                //Retrieve the File
                                string _pluginUrl = url.Replace("UpdateVersion.xml", "UpdatePlugin.xml");
                                Request = (HttpWebRequest)HttpWebRequest.Create(_pluginUrl);
                                //Request.Headers.Add("Translate: f");
                                Request.Method = "GET";
                                Request.AllowAutoRedirect = true;
                                if (user != null && user != "")
                                        Request.Credentials = new NetworkCredential(user, pass);
                                else
                                        Request.Credentials = CredentialCache.DefaultCredentials;

                                Response = (HttpWebResponse)Request.GetResponse();

                                Stream respStream = null;
                                respStream = Response.GetResponseStream();

                                //Load the XML from the stream
                                XmlDoc.Load(respStream);

                                //Parse out the AvailableVersion
                                XmlNode PluginNode = XmlDoc.SelectSingleNode(@"//PluginSection");
                                CheckPlugin(PluginNode);

                                //Parse out the AppFileURL
                                //XmlNode AppFileURLNode = XmlDoc.SelectSingleNode(@"//AppFileURL");
                                //this.AppFileURL = AppFileURLNode.InnerText;
                                if (this.PluginList.Count > 0)
                                {
                                        WritePluginConfig();
                                }
                                respStream.Close();
                                Response.Close();
                        }
                        catch (Exception e)
                        {
                                string errmsg = e.Message;
                        }


                }

                private void CheckPlugin(XmlNode PluginNode)
                {
                        this.PluginList = new List<ClientPluginInfo>();
                        if (PluginNode == null) return;
                        foreach (XmlNode _fileNode in PluginNode.ChildNodes)
                        {
                                ClientPluginInfo _pInfo = new ClientPluginInfo();
                                _pInfo.Name = _fileNode.Attributes["Name"].Value;
                                _pInfo.Type = _fileNode.Attributes["Type"].Value;
                                _pInfo.Assembly = _fileNode.Attributes["Assembly"].Value;
                                _pInfo.Description = _fileNode.Attributes["Description"].Value;
                                this.PluginList.Add(_pInfo);
                        }
                }

                private void CheckFileList(XmlNode AvailableVersionNode)
                {
                        this._CurrentVersionFiles = new List<UpdateFileInfo>();
                        foreach (XmlNode _fileNode in AvailableVersionNode.ChildNodes)
                        {
                                string _fname = _fileNode.Attributes["Name"].Value;
                                string _version = _fileNode.Attributes["Version"].Value;
                                string _url = _fileNode.Attributes["AppFileURL"].Value;
                                UpdateFileInfo _finfo = new UpdateFileInfo(_fname, _version, _url);
                                this._CurrentVersionFiles.Add(_finfo);
                        }
                }
        }
}
