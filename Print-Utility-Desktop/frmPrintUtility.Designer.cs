namespace Print_Utility_Desktop
{
    partial class frmPrintUtility
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuParent = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.gpbPrinter = new System.Windows.Forms.GroupBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtShare = new System.Windows.Forms.TextBox();
            this.lblShare = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.lblPrinters = new System.Windows.Forms.Label();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.mnuParent.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.gpbPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuParent
            // 
            this.mnuParent.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuParent.Location = new System.Drawing.Point(0, 0);
            this.mnuParent.Name = "mnuParent";
            this.mnuParent.Size = new System.Drawing.Size(690, 33);
            this.mnuParent.TabIndex = 0;
            this.mnuParent.Text = "Parent Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlContainer.Controls.Add(this.cmbPrinters);
            this.pnlContainer.Controls.Add(this.gpbPrinter);
            this.pnlContainer.Controls.Add(this.lblPrinters);
            this.pnlContainer.Controls.Add(this.cmbFloor);
            this.pnlContainer.Controls.Add(this.lblFloor);
            this.pnlContainer.Controls.Add(this.cmbLocation);
            this.pnlContainer.Controls.Add(this.lblLocation);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 33);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(690, 417);
            this.pnlContainer.TabIndex = 1;
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(12, 126);
            this.cmbPrinters.MaxDropDownItems = 10;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(663, 33);
            this.cmbPrinters.TabIndex = 7;
            // 
            // gpbPrinter
            // 
            this.gpbPrinter.Controls.Add(this.btnInstall);
            this.gpbPrinter.Controls.Add(this.txtDescription);
            this.gpbPrinter.Controls.Add(this.lblDescription);
            this.gpbPrinter.Controls.Add(this.txtShare);
            this.gpbPrinter.Controls.Add(this.lblShare);
            this.gpbPrinter.Controls.Add(this.txtName);
            this.gpbPrinter.Controls.Add(this.lblPrinter);
            this.gpbPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gpbPrinter.Location = new System.Drawing.Point(3, 177);
            this.gpbPrinter.Name = "gpbPrinter";
            this.gpbPrinter.Size = new System.Drawing.Size(684, 240);
            this.gpbPrinter.TabIndex = 6;
            this.gpbPrinter.TabStop = false;
            this.gpbPrinter.Text = "Printer Manager";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(10, 188);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(662, 34);
            this.btnInstall.TabIndex = 6;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 144);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(662, 31);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 116);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 25);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtShare
            // 
            this.txtShare.Location = new System.Drawing.Point(363, 72);
            this.txtShare.Name = "txtShare";
            this.txtShare.ReadOnly = true;
            this.txtShare.Size = new System.Drawing.Size(309, 31);
            this.txtShare.TabIndex = 3;
            // 
            // lblShare
            // 
            this.lblShare.AutoSize = true;
            this.lblShare.Location = new System.Drawing.Point(361, 44);
            this.lblShare.Name = "lblShare";
            this.lblShare.Size = new System.Drawing.Size(60, 25);
            this.lblShare.TabIndex = 2;
            this.lblShare.Text = "Share:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 72);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(294, 31);
            this.txtName.TabIndex = 1;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(6, 44);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(63, 25);
            this.lblPrinter.TabIndex = 0;
            this.lblPrinter.Text = "Name:";
            // 
            // lblPrinters
            // 
            this.lblPrinters.AutoSize = true;
            this.lblPrinters.Location = new System.Drawing.Point(12, 98);
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(75, 25);
            this.lblPrinters.TabIndex = 4;
            this.lblPrinters.Text = "Printers:";
            // 
            // cmbFloor
            // 
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(375, 49);
            this.cmbFloor.MaxDropDownItems = 10;
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(300, 33);
            this.cmbFloor.TabIndex = 3;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(375, 21);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(57, 25);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "Floor:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.AllowDrop = true;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(12, 49);
            this.cmbLocation.MaxDropDownItems = 10;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(300, 33);
            this.cmbLocation.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 21);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(83, 25);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // frmPrintUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.mnuParent);
            this.MainMenuStrip = this.mnuParent;
            this.Name = "frmPrintUtility";
            this.Text = "Printer Finder";
            this.Load += new System.EventHandler(this.frmPrintUtility_Load);
            this.mnuParent.ResumeLayout(false);
            this.mnuParent.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.gpbPrinter.ResumeLayout(false);
            this.gpbPrinter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mnuParent;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Panel pnlContainer;
        private GroupBox gpbPrinter;
        private TextBox txtName;
        private Label lblPrinter;
        private Label lblPrinters;
        private ComboBox cmbFloor;
        private Label lblFloor;
        private ComboBox cmbLocation;
        private Label lblLocation;
        private ComboBox cmbPrinters;
        private Button btnInstall;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtShare;
        private Label lblShare;
    }
}