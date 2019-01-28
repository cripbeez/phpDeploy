namespace phpDeploy.Views.Settings
{
    partial class Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.phpPathLbl = new System.Windows.Forms.Label();
            this.appDirLbl = new System.Windows.Forms.Label();
            this.phpPathTxt = new System.Windows.Forms.TextBox();
            this.appDirTxt = new System.Windows.Forms.TextBox();
            this.appDirBrowseBtn = new System.Windows.Forms.Button();
            this.phpPathBrowseBtn = new System.Windows.Forms.Button();
            this.doneBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phpPathLbl
            // 
            this.phpPathLbl.AutoSize = true;
            this.phpPathLbl.Location = new System.Drawing.Point(12, 9);
            this.phpPathLbl.Name = "phpPathLbl";
            this.phpPathLbl.Size = new System.Drawing.Size(144, 13);
            this.phpPathLbl.TabIndex = 0;
            this.phpPathLbl.Text = "Path to your PHP installation:";
            // 
            // appDirLbl
            // 
            this.appDirLbl.AutoSize = true;
            this.appDirLbl.Location = new System.Drawing.Point(12, 48);
            this.appDirLbl.Name = "appDirLbl";
            this.appDirLbl.Size = new System.Drawing.Size(185, 13);
            this.appDirLbl.TabIndex = 1;
            this.appDirLbl.Text = "Path to your application root directory:";
            // 
            // phpPathTxt
            // 
            this.phpPathTxt.Location = new System.Drawing.Point(15, 25);
            this.phpPathTxt.Name = "phpPathTxt";
            this.phpPathTxt.Size = new System.Drawing.Size(230, 20);
            this.phpPathTxt.TabIndex = 2;
            // 
            // appDirTxt
            // 
            this.appDirTxt.Location = new System.Drawing.Point(15, 64);
            this.appDirTxt.Name = "appDirTxt";
            this.appDirTxt.Size = new System.Drawing.Size(230, 20);
            this.appDirTxt.TabIndex = 3;
            // 
            // appDirBrowseBtn
            // 
            this.appDirBrowseBtn.Location = new System.Drawing.Point(251, 62);
            this.appDirBrowseBtn.Name = "appDirBrowseBtn";
            this.appDirBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.appDirBrowseBtn.TabIndex = 4;
            this.appDirBrowseBtn.Text = "Browse..";
            this.appDirBrowseBtn.UseVisualStyleBackColor = true;
            this.appDirBrowseBtn.Click += new System.EventHandler(this.appDirBrowseBtn_Click);
            // 
            // phpPathBrowseBtn
            // 
            this.phpPathBrowseBtn.Location = new System.Drawing.Point(251, 23);
            this.phpPathBrowseBtn.Name = "phpPathBrowseBtn";
            this.phpPathBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.phpPathBrowseBtn.TabIndex = 5;
            this.phpPathBrowseBtn.Text = "Browse..";
            this.phpPathBrowseBtn.UseVisualStyleBackColor = true;
            this.phpPathBrowseBtn.Click += new System.EventHandler(this.phpPathBrowseBtn_Click);
            // 
            // doneBtn
            // 
            this.doneBtn.Location = new System.Drawing.Point(251, 106);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(75, 23);
            this.doneBtn.TabIndex = 6;
            this.doneBtn.Text = "Done";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(170, 106);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 141);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.phpPathBrowseBtn);
            this.Controls.Add(this.appDirBrowseBtn);
            this.Controls.Add(this.appDirTxt);
            this.Controls.Add(this.phpPathTxt);
            this.Controls.Add(this.appDirLbl);
            this.Controls.Add(this.phpPathLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Edit";
            this.Text = "phpDeploy Configuration";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label phpPathLbl;
        private System.Windows.Forms.Label appDirLbl;
        private System.Windows.Forms.TextBox phpPathTxt;
        private System.Windows.Forms.TextBox appDirTxt;
        private System.Windows.Forms.Button appDirBrowseBtn;
        private System.Windows.Forms.Button phpPathBrowseBtn;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}