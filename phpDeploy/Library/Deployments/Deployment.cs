using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace phpDeploy.Library.Deployments
{
    public class Deployment
    {
        public int Id;
        public string Name;
        public string WorkingDirectory;
        public string ListenString;
        public string Attributes;

        public bool Running
        {
            get
            {
                try { Process.GetProcessById(this._process.Id); }
                catch { return false; }
                return true;
            }
        }
        public bool Valid
        {
            get
            {
                if (this._file["name"] == null)
                    return false;

                if (this._file["listen_str"] == null)
                    return false;

                if (this._file["attributes"] == null)
                    return false;

                return true;
            }
        }

        private Xml.XmlKeyValueFile _file;
        private Process _process;

        public Deployment(string deploymentFilePath)
        {
            this._file = new Xml.XmlKeyValueFile(deploymentFilePath);

            if (!this.Valid)
                return;

            this.Name = this._file["name"];
            this.WorkingDirectory = new FileInfo(deploymentFilePath).Directory.FullName;
            this.ListenString = this._file["listen_str"];
            this.Attributes = this._file["attributes"];
        }

        public Deployment Start()
        {
            if (!this.Valid)
                return this;

            this._process = new Process();
            this._process.StartInfo.FileName = $"{App.Settings["php_path"]}\\php.exe";
            this._process.StartInfo.Arguments = $"-S {this.ListenString} -t \"{this.WorkingDirectory}\"";
            this._process.StartInfo.UseShellExecute = false;
            this._process.StartInfo.RedirectStandardInput = true;
            this._process.StartInfo.RedirectStandardOutput = false;
            this._process.StartInfo.CreateNoWindow = true;
            this._process.Start();

            return this;
        }
        public Deployment Stop()
        {
            if (!this.Valid)
                return this;

            if (!this.Running)
                return null;

            this._process.Kill();
            return this;
        }
        public Deployment Restart()
        {
            if (!this.Valid)
                return this;

            if (!this.Running)
                return null;

            this._process.Kill();
            this.Start();
            return this;
        }

        public void Save()
        {
            if (!this.Valid)
                return;

            this._file["name"] = this.Name;
            this._file["listen_str"] = this.ListenString;
            this._file["attributes"] = this.Attributes;

            this._file.Save();
        }

        public ToolStripMenuItem GetMenu()
        {
            ToolStripMenuItem thisMenu = new ToolStripMenuItem(this.Name);

            /*
                (url)
                started
                -
                start
                stop
                restart
                -
                delete
                edit..
            */

            var listenStr = new ToolStripMenuItem(this.ListenString);
            listenStr.Click += (sender, e) =>
            {
                Process.Start($"http://{this.ListenString}");
            };
            listenStr.Visible = this.Running;

            var running = new ToolStripMenuItem("Status: " + ((this.Running) ? "Started" : "Stopped"));
            running.Enabled = false;

            var start = new ToolStripMenuItem("Start");
            start.Click += (sender, e) =>
            {
                this.Start();
                App.Taskbar.Update();
            };
            start.Visible = !this.Running;

            var stop = new ToolStripMenuItem("Stop");
            stop.Click += (sender, e) =>
            {
                this.Stop();
                App.Taskbar.Update();
            };
            stop.Visible = this.Running;

            var restart = new ToolStripMenuItem("Restart");
            restart.Click += (sender, e) =>
            {
                this.Restart();
                App.Taskbar.Update();
            };
            restart.Visible = this.Running;

            var edit = new ToolStripMenuItem("Edit..");
            edit.Click += (sender, e) =>
            {
                Views.Deployment.Edit.EditDialog(this.Id);
                Program.App.Reload();
            };

            var delete = new ToolStripMenuItem("Delete");
            delete.Click += (sender, e) =>
            {
                if(MessageBox.Show($"Are you sure you want to delete {this.Name}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(this.WorkingDirectory + @"\phpDeploy.xml");
                    Program.App.Reload();
                }
            };

            thisMenu.DropDownItems.AddRange(new ToolStripItem[]
            {
                listenStr,
                running,
                new ToolStripSeparator(),
                start,
                stop,
                restart,
                new ToolStripSeparator(),
                edit,
                delete
            });

            return thisMenu;
        }

        public static Deployment Create(string name, string listenStr, string attributes, string workingDir)
        {
            string path = workingDir + "\\phpDeploy.xml";
            Xml.XmlKeyValueFile xkvf = Xml.XmlKeyValueFile.Create(path);
            xkvf["name"] = name;
            xkvf["listen_str"] = listenStr;
            xkvf["attributes"] = attributes;
            xkvf.Save();

            return new Deployment(path);
        }

    }
}
