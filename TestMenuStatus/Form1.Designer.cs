namespace TestMenuStatus
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddSubmenu = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.submenusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStatus1 = new SoftCircuits.MenuStatus.MenuStatus(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnAddSubmenu);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(568, 292);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(568, 362);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip2);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(553, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddSubmenu
            // 
            this.btnAddSubmenu.Location = new System.Drawing.Point(12, 12);
            this.btnAddSubmenu.Name = "btnAddSubmenu";
            this.btnAddSubmenu.Size = new System.Drawing.Size(115, 23);
            this.btnAddSubmenu.TabIndex = 0;
            this.btnAddSubmenu.Text = "&Add Submenu";
            this.btnAddSubmenu.UseVisualStyleBackColor = true;
            this.btnAddSubmenu.Click += new System.EventHandler(this.btnAddSubmenu_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file1ToolStripMenuItem,
            this.file2ToolStripMenuItem,
            this.file3ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // file1ToolStripMenuItem
            // 
            this.file1ToolStripMenuItem.Name = "file1ToolStripMenuItem";
            this.file1ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.file1ToolStripMenuItem.Text = "File 1";
            // 
            // file2ToolStripMenuItem
            // 
            this.file2ToolStripMenuItem.Name = "file2ToolStripMenuItem";
            this.file2ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.file2ToolStripMenuItem.Text = "File 2";
            // 
            // file3ToolStripMenuItem
            // 
            this.file3ToolStripMenuItem.Name = "file3ToolStripMenuItem";
            this.file3ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.file3ToolStripMenuItem.Text = "File 3";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit1ToolStripMenuItem,
            this.edit2ToolStripMenuItem,
            this.edit3ToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // edit1ToolStripMenuItem
            // 
            this.edit1ToolStripMenuItem.Name = "edit1ToolStripMenuItem";
            this.edit1ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.edit1ToolStripMenuItem.Text = "Edit 1";
            // 
            // edit2ToolStripMenuItem
            // 
            this.edit2ToolStripMenuItem.Name = "edit2ToolStripMenuItem";
            this.edit2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.edit2ToolStripMenuItem.Text = "Edit 2";
            // 
            // edit3ToolStripMenuItem
            // 
            this.edit3ToolStripMenuItem.Name = "edit3ToolStripMenuItem";
            this.edit3ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.edit3ToolStripMenuItem.Text = "Edit 3";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.options1ToolStripMenuItem,
            this.options2ToolStripMenuItem,
            this.options3ToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // options1ToolStripMenuItem
            // 
            this.options1ToolStripMenuItem.Name = "options1ToolStripMenuItem";
            this.options1ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.options1ToolStripMenuItem.Text = "Options 1";
            // 
            // options2ToolStripMenuItem
            // 
            this.options2ToolStripMenuItem.Name = "options2ToolStripMenuItem";
            this.options2ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.options2ToolStripMenuItem.Text = "Options 2";
            // 
            // options3ToolStripMenuItem
            // 
            this.options3ToolStripMenuItem.Name = "options3ToolStripMenuItem";
            this.options3ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.options3ToolStripMenuItem.Text = "Options 3";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 24);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(568, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenusToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // submenusToolStripMenuItem
            // 
            this.submenusToolStripMenuItem.Name = "submenusToolStripMenuItem";
            this.submenusToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.submenusToolStripMenuItem.Text = "Submenus";
            // 
            // menuStatus1
            // 
            this.menuStatus1.SelectedMenuItemChanged += new System.EventHandler<SoftCircuits.MenuStatus.SelectedMenuItemChangedArgs>(this.menuStatus1_SelectedMenuItemChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 362);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem file1ToolStripMenuItem;
        private ToolStripMenuItem file2ToolStripMenuItem;
        private ToolStripMenuItem file3ToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem edit1ToolStripMenuItem;
        private ToolStripMenuItem edit2ToolStripMenuItem;
        private ToolStripMenuItem edit3ToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem options1ToolStripMenuItem;
        private ToolStripMenuItem options2ToolStripMenuItem;
        private ToolStripMenuItem options3ToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem submenusToolStripMenuItem;
        private SoftCircuits.MenuStatus.MenuStatus menuStatus1;
        private Button btnAddSubmenu;
    }
}