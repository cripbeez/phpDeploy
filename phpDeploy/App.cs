using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace phpDeploy
{
    public class App : ApplicationContext
    {
        public static Library.Deployments.DeploymentCollection Deployments;
        public static Library.Settings.Settings Settings;

        public static string WorkingDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }
        
        public static class Taskbar
        {
            private static NotifyIcon Icon;

            public static void Create()
            {
                Icon = new NotifyIcon();
            }

            public static void Hide()
            {
                Icon.Visible = false;
            }
            public static void Show()
            {
                Icon.Visible = true;
            }

            public static void SetIcon(Icon icon)
            {
                Icon.Icon = icon;
            }
            public static void SetIcon(string icon)
            {
                if (!File.Exists(icon))
                    return;

                Icon.Icon = new Icon(icon);
            }

            public static void UpdateText()
            {
                Icon.Text = $"phpDeploy - {App.Deployments.CurrentlyRunning} Running, {App.Deployments.NotRunning} Stopped.";
            }
            public static void UpdateMenus()
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                var refresh = new ToolStripMenuItem("Refresh");
                refresh.Click += (sender, e) =>
                {
                    App.Taskbar.Update();
                };

                var reload = new ToolStripMenuItem("Reload");
                reload.Click += (sender, e) =>
                {
                    Program.App.Reload();
                };

                var deployments = new ToolStripMenuItem("Deployments");
                foreach (var deployment in App.Deployments)
                    deployments.DropDownItems.Add(deployment.GetMenu());

                var all = new ToolStripMenuItem("All");
                all.Visible = App.Deployments.Count > 0;

                var startAll = new ToolStripMenuItem("Start");
                startAll.Click += (sender, e) =>
                {
                    App.Deployments.StartAll();
                    App.Taskbar.Update();
                };
                var stopAll = new ToolStripMenuItem("Stop");
                stopAll.Click += (sender, e) =>
                {
                    App.Deployments.StopAll();
                    App.Taskbar.Update();
                };
                var restartAll = new ToolStripMenuItem("Restart");
                restartAll.Click += (sender, e) =>
                {
                    App.Deployments.RestartAll();
                    App.Taskbar.Update();
                };
                all.DropDownItems.AddRange(new ToolStripItem[]
                {
                    startAll,
                    stopAll,
                    restartAll
                });

                var newDeployment = new ToolStripMenuItem("New..");
                newDeployment.Click += (sender, e) =>
                {
                    Views.Deployment.Edit.NewDialog();
                    Program.App.Reload();
                };

                deployments.DropDownItems.AddRange(new ToolStripItem[]
                {
                    new ToolStripSeparator(),
                    all,
                    new ToolStripSeparator(),
                    newDeployment
                });

                var exit = new ToolStripMenuItem("Exit");
                exit.Click += (sender, e) =>
                {
                    Program.App.Stop();
                };
                menu.Items.AddRange(new ToolStripItem[]
                {
                    refresh,
                    reload,
                    new ToolStripSeparator(),
                    deployments,
                    new ToolStripSeparator(),
                    exit
                });
                Taskbar.Icon.ContextMenuStrip = menu;
            }
            public static void Update()
            {
                UpdateMenus();
                UpdateText();
            }
        }

        public App()
        {
            App.Settings = new Library.Settings.Settings();

            this.Start();
        }

        private bool SettingsNeedUpdate()
        {
            if (App.Settings["php_path"] == null)
                return true;

            if (!Directory.Exists(App.Settings["php_path"]))
                return true;

            if (App.Settings["app_dir"] == null)
                return true;

            if (!Directory.Exists(App.Settings["app_dir"]))
                return true;

            return false;
        }
        private void LoadDeployments()
        {
            App.Deployments = Library.Deployments.DeploymentCollection.DeployDirectory(App.Settings["app_dir"]);
        }

        private void Start()
        {
            /*
             * Let's make sure all the settings are valid.
             */
            while(this.SettingsNeedUpdate())
                Views.Settings.Edit.ForceUpdate();

            /*
             * Alright.
             * Now we can start loading deployments.
             */
            this.LoadDeployments();

            /*
             * Finally, build the taskbar menu.
             */
            App.Taskbar.Create();
            App.Taskbar.SetIcon(App.WorkingDirectory + @"\phpDeploy.ico");
            App.Taskbar.Update();
            App.Taskbar.Show();
            
        }
        private void Stop()
        {
            App.Deployments.StopAll();

            App.Taskbar.Hide();
            this.ExitThread();
        }
        public void Reload()
        {
            App.Deployments.StopAll();
            Program.App.LoadDeployments();
            App.Taskbar.Update();
        }
    }
}
