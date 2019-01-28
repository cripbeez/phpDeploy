namespace phpDeploy.Views.Deployment
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.listenStrTxt = new System.Windows.Forms.TextBox();
            this.listenStrLbl = new System.Windows.Forms.Label();
            this.attributesTxt = new System.Windows.Forms.TextBox();
            this.attributesLbl = new System.Windows.Forms.Label();
            this.doneBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.workingDirTxt = new System.Windows.Forms.TextBox();
            this.workingDirLbl = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(25, 9);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(69, 6);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(442, 20);
            this.nameTxt.TabIndex = 2;
            // 
            // listenStrTxt
            // 
            this.listenStrTxt.Location = new System.Drawing.Point(69, 32);
            this.listenStrTxt.Name = "listenStrTxt";
            this.listenStrTxt.Size = new System.Drawing.Size(442, 20);
            this.listenStrTxt.TabIndex = 4;
            this.listenStrTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listenStrTxt_KeyUp);
            // 
            // listenStrLbl
            // 
            this.listenStrLbl.AutoSize = true;
            this.listenStrLbl.Location = new System.Drawing.Point(12, 35);
            this.listenStrLbl.Name = "listenStrLbl";
            this.listenStrLbl.Size = new System.Drawing.Size(51, 13);
            this.listenStrLbl.TabIndex = 3;
            this.listenStrLbl.Text = "Listen At:";
            // 
            // attributesTxt
            // 
            this.attributesTxt.Location = new System.Drawing.Point(69, 58);
            this.attributesTxt.Name = "attributesTxt";
            this.attributesTxt.Size = new System.Drawing.Size(442, 20);
            this.attributesTxt.TabIndex = 6;
            // 
            // attributesLbl
            // 
            this.attributesLbl.AutoSize = true;
            this.attributesLbl.Location = new System.Drawing.Point(12, 61);
            this.attributesLbl.Name = "attributesLbl";
            this.attributesLbl.Size = new System.Drawing.Size(54, 13);
            this.attributesLbl.TabIndex = 5;
            this.attributesLbl.Text = "Attributes:";
            // 
            // doneBtn
            // 
            this.doneBtn.Location = new System.Drawing.Point(436, 111);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(75, 23);
            this.doneBtn.TabIndex = 7;
            this.doneBtn.Text = "Done";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(355, 111);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // workingDirTxt
            // 
            this.workingDirTxt.Enabled = false;
            this.workingDirTxt.Location = new System.Drawing.Point(69, 84);
            this.workingDirTxt.Name = "workingDirTxt";
            this.workingDirTxt.Size = new System.Drawing.Size(361, 20);
            this.workingDirTxt.TabIndex = 10;
            // 
            // workingDirLbl
            // 
            this.workingDirLbl.AutoSize = true;
            this.workingDirLbl.Location = new System.Drawing.Point(12, 87);
            this.workingDirLbl.Name = "workingDirLbl";
            this.workingDirLbl.Size = new System.Drawing.Size(52, 13);
            this.workingDirLbl.TabIndex = 9;
            this.workingDirLbl.Text = "Directory:";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(436, 82);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 11;
            this.browseBtn.Text = "Browse..";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 146);
            this.ControlBox = false;
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.workingDirTxt);
            this.Controls.Add(this.workingDirLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.attributesTxt);
            this.Controls.Add(this.attributesLbl);
            this.Controls.Add(this.listenStrTxt);
            this.Controls.Add(this.listenStrLbl);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Edit";
            this.Text = "-";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox listenStrTxt;
        private System.Windows.Forms.Label listenStrLbl;
        private System.Windows.Forms.TextBox attributesTxt;
        private System.Windows.Forms.Label attributesLbl;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox workingDirTxt;
        private System.Windows.Forms.Label workingDirLbl;
        private System.Windows.Forms.Button browseBtn;
    }
}