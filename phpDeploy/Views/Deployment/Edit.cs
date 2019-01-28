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

namespace phpDeploy.Views.Deployment
{
    public partial class Edit : Form
    {
        public int CurrentDeployment = -1;
        private bool IsEditing
        {
            get
            {
                if(this.CurrentDeployment > -1)
                {
                    if(App.Deployments[this.CurrentDeployment] != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public Edit(int currentDeploy = -1)
        {
            InitializeComponent();
            this.CurrentDeployment = currentDeploy;
        }

        private bool ValidateListenStr()
        {
            string[] split = listenStrTxt.Text.Split(':');

            if (split.Count() != 2)
                return false;

            return true;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            if(this.IsEditing)
            {
                this.Text = "Editing Deployment: " + App.Deployments[this.CurrentDeployment].Name;
                doneBtn.Text = "Save";

                nameTxt.Text = App.Deployments[this.CurrentDeployment].Name;
                listenStrTxt.Text = App.Deployments[this.CurrentDeployment].ListenString;
                attributesTxt.Text = App.Deployments[this.CurrentDeployment].Attributes;

                browseBtn.Enabled = false;
                workingDirTxt.Text = App.Deployments[this.CurrentDeployment].WorkingDirectory;
            }
            else
            {
                this.Text = "New Deployment";
                doneBtn.Text = "Create";
            }
        }
        private void listenStrTxt_KeyUp(object sender, KeyEventArgs e)
        {
            listenStrTxt.ForeColor = (ValidateListenStr()) ? Color.Black : Color.Red;
        }

        public static void EditDialog(int id)
        {
            Edit edit = new Edit(id);
            edit.ShowDialog();
        }
        public static void NewDialog()
        {
            Edit edit = new Edit();
            edit.ShowDialog();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = App.Settings["app_dir"];
            fbd.ShowDialog();

            if (!fbd.SelectedPath.StartsWith(App.Settings["app_dir"]))
            {
                MessageBox.Show("The deployment must be within the application directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            workingDirTxt.Text = fbd.SelectedPath;
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if(this.IsEditing)
            {

                App.Deployments[this.CurrentDeployment].Name = nameTxt.Text;
                App.Deployments[this.CurrentDeployment].ListenString = listenStrTxt.Text;
                App.Deployments[this.CurrentDeployment].Attributes = attributesTxt.Text;
                App.Deployments[this.CurrentDeployment].Save();

                this.Close();
                return;
            }

            App.Deployments.Create(nameTxt.Text, listenStrTxt.Text, attributesTxt.Text, workingDirTxt.Text);
            this.Close();
            return;
        }
    }
}
