using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace phpDeploy.Library.Xml
{
    class XmlKeyValueFile
    {
        private readonly string _filePath;
        public string FilePath { get; }

        private Dictionary<string, string> _settings;

        public XmlKeyValueFile(string fP)
        {
            XmlDocument _xdoc;
            this._filePath = fP;
            this._settings = new Dictionary<string, string>();

            if (!File.Exists(fP))
            {
                throw new FileNotFoundException();
            }

            _xdoc = new XmlDocument();
            _xdoc.Load(fP);

            XmlNode root = _xdoc.SelectSingleNode("config");
            if (root == null)
            {
                throw new InvalidDataException();
            }
            if (root.ChildNodes.Count == 0)
            {
                return;
            }
            
            foreach (XmlNode setting in root.ChildNodes)
            {
                if (setting.Name != "setting") continue;

                if (setting.Attributes["name"] == null)
                {
                    throw new InvalidDataException();
                }
                if (setting.Attributes["value"] == null)
                {
                    throw new InvalidDataException();
                }

                this._settings.Add(
                    setting.Attributes["name"].Value.ToString(),
                    setting.Attributes["value"].Value.ToString()
                );
            }


        }
        public string this[string key]
        {
            get
            {
                if (!this._settings.Keys.Contains(key)) return null;
                return this._settings[key];
            }
            set
            {
                if (!this._settings.Keys.Contains(key))
                {
                    this._settings.Add(
                        key,
                        value
                    );
                    return;
                }
                this._settings[key] = value;
            }
        }

        public void Save()
        {
            XmlDocument xDoc = new XmlDocument();

            XmlNode root = xDoc.CreateNode(XmlNodeType.Element, "config", "");

            foreach (KeyValuePair<string, string> setting in this._settings)
            {
                XmlNode settingNode = xDoc.CreateNode(XmlNodeType.Element, "setting", "");

                XmlAttribute settingNameAttr = xDoc.CreateAttribute("name");
                settingNameAttr.Value = setting.Key;
                settingNode.Attributes.Append(settingNameAttr);

                XmlAttribute settingValueAttr = xDoc.CreateAttribute("value");
                settingValueAttr.Value = setting.Value;
                settingNode.Attributes.Append(settingValueAttr);

                root.AppendChild(settingNode);
            }

            xDoc.AppendChild(root);
            xDoc.Save(this._filePath);
        }

        public static XmlKeyValueFile Create(string filePath)
        {
            if (File.Exists(filePath)) return new XmlKeyValueFile(filePath);
            File.Create(filePath).Close();
            File.WriteAllText(filePath, "<config></config>");
            return new XmlKeyValueFile(filePath);
        }
    }
}
