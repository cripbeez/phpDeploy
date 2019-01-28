using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace phpDeploy.Views.Settings
{
    public partial class Edit : Form
    {
        public bool HasUpdated = false;
        public bool MustUpdate = false;

        private void Error(string message)
        {
            MessageBox.Show(
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private bool ValidatePhpPath(bool silent = true)
        {
            string phpPath = phpPathTxt.Text;

            if (!phpPath.EndsWith(@"\"))
                phpPath += @"\";

            if (!Directory.Exists(phpPath))
            {
                if (!silent)
                    this.Error("The directory for the PHP installation could not be found.");

                return false;
            }

            if (!File.Exists(phpPath + "php.exe"))
            {
                if (!silent)
                    this.Error("No PHP binary found in the chosen directory.");

                return false;
            }

            return true;
        }
        private bool ValidateAppDir(bool silent = true)
        {
            string appDir = appDirTxt.Text;

            if (!appDir.EndsWith(@"\"))
                appDir += @"\";


            if (!Directory.Exists(appDir))
            {
                if (!silent)
                    this.Error("The chosen directory for application data could not be found.");

                return false;
            }

            return true;
        }
        private bool ValidateInputs(bool silent = true)
        {
            if (!ValidatePhpPath(silent))
                return false;

            if (!ValidateAppDir(silent))
                return false;

            return true;
        }
        private void ColorTextBoxes()
        {
            appDirTxt.ForeColor = (ValidateAppDir()) ? Color.Black : Color.Red;
            phpPathTxt.ForeColor = (ValidatePhpPath()) ? Color.Black : Color.Red;
        }

        private string ChooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        public Edit()
        {
            InitializeComponent();
        }
        private void Edit_Load(object sender, EventArgs e)
        {
            phpPathTxt.Text = App.Settings["php_path"] ?? "";
            appDirTxt.Text = App.Settings["app_dir"] ?? "";

            if(this.MustUpdate)
            {
                cancelBtn.Enabled = false;
            }

            foreach(Control control in this.Controls)
            {
                if(control is TextBox)
                {
                    control.KeyUp += (cSender, cE) =>
                    {
                        ColorTextBoxes();
                    };
                }
            }
        }
        private void phpPathBrowseBtn_Click(object sender, EventArgs e)
        {
            phpPathTxt.Text = ChooseFolder();
            ColorTextBoxes();
        }
        private void appDirBrowseBtn_Click(object sender, EventArgs e)
        {
            appDirTxt.Text = ChooseFolder();
            ColorTextBoxes();
        }
        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(false))
                return;

            App.Settings["php_path"] = phpPathTxt.Text;
            App.Settings["app_dir"] = appDirTxt.Text;

            this.HasUpdated = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool Dialog()
        {
            Edit edit = new Edit();
            edit.ShowDialog();
            return edit.HasUpdated;
        }
        public static void ForceUpdate()
        {
            Edit edit = new Edit();
            edit.MustUpdate = true;
            edit.ShowDialog();
        }
    }
}
