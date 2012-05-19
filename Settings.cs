using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Xml;

namespace PCGPS.Properties
{
    
    
    // このクラスでは設定クラスでの特定のイベントを処理することができます:
    //  SettingChanging イベントは、設定値が変更される前に発生します。
    //  PropertyChanged イベントは、設定値が変更された後に発生します。
    //  SettingsLoaded イベントは、設定値が読み込まれた後に発生します。
    //  SettingsSaving イベントは、設定値が保存される前に発生します。
    internal sealed partial class Settings {
        
        public Settings() {
            // // 設定の保存と変更のイベント ハンドラを追加するには、以下の行のコメントを解除します:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private string GetConfigFile(string basedir, string product, string assembly)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(basedir + product, assembly + "*", SearchOption.TopDirectoryOnly);
                foreach (string d in dirs)
                {
                    string[] vers = Directory.GetDirectories(d);
                    Array.Sort(vers);
                    Array.Reverse(vers);
                    foreach (string v in vers)
                    {
                        if (File.Exists(v + "\\user.config"))
                        {
                            return v + "\\user.config";
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public void CheckConfigFile()
        {
            if (!this.Saved)
            {
                string dir = Application.LocalUserAppDataPath;
                if (!File.Exists(dir + "\\user.config"))
                {
                    string[] folders = dir.Split(System.IO.Path.DirectorySeparatorChar);
                    string basedir = "";
                    for (int i = 0; i < folders.Length - 3; i++)
                    {
                        basedir += folders[i] + "\\";
                    }
                    string userconfig = GetConfigFile(basedir, "FUJITALAB", "ImacocoNow");
                    if (userconfig == null)
                    {
                        userconfig = GetConfigFile(basedir, "FUJITALAB", "PCGPSImakoko");
                    }
                    if (userconfig == null)
                    {
                        userconfig = GetConfigFile(basedir, "PCGPS", "PCGPSImakoko");
                    }
                    if (userconfig != null)
                    {
                        LoadFromFile(userconfig);
                        this.Save();
                    }
                }
            }
            this.PropertyChanged += this.PropertyChangedEventHandler;
        }
        
        public void LoadFromFile(string filename)
        {
            XmlDocument doc = new XmlDocument();
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                doc.Load(stream);
            }
            foreach (XmlNode node in doc.GetElementsByTagName("setting"))
            {
                string name = node.Attributes["name"].Value;
                string value = "";
                if (node.Attributes["serializeAs"].Value == "String") {
                    value = node.FirstChild.InnerText;
                }

                switch (name)
                {
                    case "Port":
                        this.Port = value;
                        break;
                    case "Baud":
                        this.Baud = value;
                        break;
                    case "AddLatLon":
                        try
                        {
                            this.AddLatLon = Boolean.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "AddMapURL":
                        try
                        {
                            this.AddMapURL = Boolean.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "ImakokoHeader":
                        this.ImakokoHeader = value;
                        break;
                    case "IntervalType":
                        try
                        {
                            this.IntervalType = int.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "MapURL":
                        this.MapURL = value;
                        break;
                    case "Password":
                        this.Password = value;
                        break;
                    case "PostDataInterval":
                        try
                        {
                            this.PostDataInterval = int.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "PrivatePoint":
                        try
                        {
                            this.PrivatePoint = new System.Collections.Specialized.StringCollection();
                            foreach (XmlNode cn in node.FirstChild.FirstChild.ChildNodes)
                            {
                                PrivatePoint.Add(cn.InnerText);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "Radius":
                        this.Radius = value;
                        break;
                    case "Saved":
                        try
                        {
                            this.Saved = bool.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "ServerSave":
                        try
                        {
                            this.ServerSave = bool.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "SpeedFilter":
                        try
                        {
                            this.SpeedFilter = bool.Parse(value);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    case "TinyURL":
                        this.TinyURL = value;
                        break;
                    case "TwitterID":
                        this.TwitterID = value;
                        break;
                    case "TwitterPW":
                        this.TwitterPW = value;
                        break;
                    case "User":
                        this.User = value;
                        break;
                    
                }
            }
        }

        private void PropertyChangedEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.Save();
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // SettingChangingEvent イベントを処理するコードをここに追加してください。
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // SettingsSaving イベントを処理するコードをここに追加してください。
        }

        
    }
}
