namespace SlackerEdit
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.m_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_NewFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_OpenFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_SaveFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_NewSectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_DeleteSectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_FontToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_LargerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_SmallerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_ApplyColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_PickColorToolStripCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_BoldToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_ItalicToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_LeftJustifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_CenterJustifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_RightJustifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.m_SplitterContainer = new System.Windows.Forms.SplitContainer();
            this.m_MenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_SplitterContainer)).BeginInit();
            this.m_SplitterContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MenuStrip
            // 
            this.m_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sectionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.m_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_MenuStrip.Name = "m_MenuStrip";
            this.m_MenuStrip.Size = new System.Drawing.Size(782, 24);
            this.m_MenuStrip.TabIndex = 0;
            this.m_MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewMenuItem,
            this.FileOpenMenuItem,
            this.FileSaveMenuItem,
            this.FileExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // FileNewMenuItem
            // 
            this.FileNewMenuItem.Name = "FileNewMenuItem";
            this.FileNewMenuItem.Size = new System.Drawing.Size(103, 22);
            this.FileNewMenuItem.Text = "New";
            this.FileNewMenuItem.Click += new System.EventHandler(this.FileNewMenuOnClick);
            // 
            // FileOpenMenuItem
            // 
            this.FileOpenMenuItem.Name = "FileOpenMenuItem";
            this.FileOpenMenuItem.Size = new System.Drawing.Size(103, 22);
            this.FileOpenMenuItem.Text = "Open";
            this.FileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuOnClick);
            // 
            // FileSaveMenuItem
            // 
            this.FileSaveMenuItem.Name = "FileSaveMenuItem";
            this.FileSaveMenuItem.Size = new System.Drawing.Size(103, 22);
            this.FileSaveMenuItem.Text = "Save";
            this.FileSaveMenuItem.Click += new System.EventHandler(this.FileSaveMenuOnClick);
            // 
            // FileExitMenuItem
            // 
            this.FileExitMenuItem.Name = "FileExitMenuItem";
            this.FileExitMenuItem.Size = new System.Drawing.Size(103, 22);
            this.FileExitMenuItem.Text = "Exit";
            this.FileExitMenuItem.Click += new System.EventHandler(this.OnMenuExit);
            // 
            // sectionsToolStripMenuItem
            // 
            this.sectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteSectionMenuItem,
            this.renameSectionMenuItem});
            this.sectionsToolStripMenuItem.Name = "sectionsToolStripMenuItem";
            this.sectionsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.sectionsToolStripMenuItem.Text = "Sections";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddSectionMenuOnClick);
            // 
            // deleteSectionMenuItem
            // 
            this.deleteSectionMenuItem.Name = "deleteSectionMenuItem";
            this.deleteSectionMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteSectionMenuItem.Text = "Delete";
            this.deleteSectionMenuItem.Click += new System.EventHandler(this.DeleteSectionMenuOnClick);
            // 
            // renameSectionMenuItem
            // 
            this.renameSectionMenuItem.Name = "renameSectionMenuItem";
            this.renameSectionMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameSectionMenuItem.Text = "Rename";
            this.renameSectionMenuItem.Click += new System.EventHandler(this.RenameSectionMenuOnClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.HelpAboutMenuOnClick);
            // 
            // m_StatusStrip
            // 
            this.m_StatusStrip.Location = new System.Drawing.Point(0, 466);
            this.m_StatusStrip.Name = "m_StatusStrip";
            this.m_StatusStrip.Size = new System.Drawing.Size(782, 22);
            this.m_StatusStrip.TabIndex = 1;
            this.m_StatusStrip.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_NewFileToolStripButton,
            this.m_OpenFileToolStripButton,
            this.m_SaveFileToolStripButton,
            this.toolStripSeparator6,
            this.m_NewSectionToolStripButton,
            this.m_DeleteSectionToolStripButton,
            this.toolStripSeparator1,
            this.m_FontToolStripComboBox,
            this.toolStripSeparator2,
            this.m_LargerToolStripButton,
            this.m_SmallerToolStripButton,
            this.toolStripSeparator3,
            this.m_ApplyColorToolStripButton,
            this.m_PickColorToolStripCombo,
            this.toolStripSeparator4,
            this.m_BoldToolStripButton,
            this.m_ItalicToolStripButton,
            this.toolStripSeparator5,
            this.m_LeftJustifyToolStripButton,
            this.m_CenterJustifyToolStripButton,
            this.m_RightJustifyToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_NewFileToolStripButton
            // 
            this.m_NewFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_NewFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_NewFileToolStripButton.Image")));
            this.m_NewFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_NewFileToolStripButton.Name = "m_NewFileToolStripButton";
            this.m_NewFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_NewFileToolStripButton.Text = "Create a New File";
            this.m_NewFileToolStripButton.Click += new System.EventHandler(this.NewFileToolStripButtonOnClick);
            // 
            // m_OpenFileToolStripButton
            // 
            this.m_OpenFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_OpenFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_OpenFileToolStripButton.Image")));
            this.m_OpenFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_OpenFileToolStripButton.Name = "m_OpenFileToolStripButton";
            this.m_OpenFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_OpenFileToolStripButton.Text = "Open a File";
            this.m_OpenFileToolStripButton.Click += new System.EventHandler(this.OpenFileToolStripButtonOnClick);
            // 
            // m_SaveFileToolStripButton
            // 
            this.m_SaveFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_SaveFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_SaveFileToolStripButton.Image")));
            this.m_SaveFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_SaveFileToolStripButton.Name = "m_SaveFileToolStripButton";
            this.m_SaveFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_SaveFileToolStripButton.Text = "Save the current File";
            this.m_SaveFileToolStripButton.Click += new System.EventHandler(this.SaveFileToolStripButtonOnClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // m_NewSectionToolStripButton
            // 
            this.m_NewSectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_NewSectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_NewSectionToolStripButton.Image")));
            this.m_NewSectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_NewSectionToolStripButton.Name = "m_NewSectionToolStripButton";
            this.m_NewSectionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_NewSectionToolStripButton.Text = "Create a new Section";
            this.m_NewSectionToolStripButton.Click += new System.EventHandler(this.AddSectionToolStripButtonOnClick);
            // 
            // m_DeleteSectionToolStripButton
            // 
            this.m_DeleteSectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_DeleteSectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_DeleteSectionToolStripButton.Image")));
            this.m_DeleteSectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_DeleteSectionToolStripButton.Name = "m_DeleteSectionToolStripButton";
            this.m_DeleteSectionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_DeleteSectionToolStripButton.Text = "Delete the selected Section";
            this.m_DeleteSectionToolStripButton.Click += new System.EventHandler(this.DeleteSectionToolStripButtonOnClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_FontToolStripComboBox
            // 
            this.m_FontToolStripComboBox.Name = "m_FontToolStripComboBox";
            this.m_FontToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.m_FontToolStripComboBox.Text = "Fonts";
            this.m_FontToolStripComboBox.DropDownClosed += new System.EventHandler(this.FontTypeComboOnClose);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_LargerToolStripButton
            // 
            this.m_LargerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_LargerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_LargerToolStripButton.Image")));
            this.m_LargerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_LargerToolStripButton.Name = "m_LargerToolStripButton";
            this.m_LargerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_LargerToolStripButton.Text = "Increase Font Size";
            this.m_LargerToolStripButton.Click += new System.EventHandler(this.TextLargerToolButtonOnClick);
            // 
            // m_SmallerToolStripButton
            // 
            this.m_SmallerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_SmallerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_SmallerToolStripButton.Image")));
            this.m_SmallerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_SmallerToolStripButton.Name = "m_SmallerToolStripButton";
            this.m_SmallerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_SmallerToolStripButton.Text = "Decrease Font Size";
            this.m_SmallerToolStripButton.Click += new System.EventHandler(this.TextSmallerToolButtonOnClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_ApplyColorToolStripButton
            // 
            this.m_ApplyColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_ApplyColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_ApplyColorToolStripButton.Image")));
            this.m_ApplyColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_ApplyColorToolStripButton.Name = "m_ApplyColorToolStripButton";
            this.m_ApplyColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_ApplyColorToolStripButton.Text = "Change Font Color";
            this.m_ApplyColorToolStripButton.Click += new System.EventHandler(this.TextColorToolButtonOnClick);
            this.m_ApplyColorToolStripButton.Paint += new System.Windows.Forms.PaintEventHandler(this.TextColorToolButtonPaint);
            // 
            // m_PickColorToolStripCombo
            // 
            this.m_PickColorToolStripCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black",
            "Red",
            "Green",
            "Blue",
            "Yellow"});
            this.m_PickColorToolStripCombo.AutoSize = false;
            this.m_PickColorToolStripCombo.DropDownWidth = 70;
            this.m_PickColorToolStripCombo.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Green",
            "Blue",
            "Yellow"});
            this.m_PickColorToolStripCombo.Name = "m_PickColorToolStripCombo";
            this.m_PickColorToolStripCombo.Size = new System.Drawing.Size(12, 23);
            this.m_PickColorToolStripCombo.Text = "Select Font Color";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // m_BoldToolStripButton
            // 
            this.m_BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BoldToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_BoldToolStripButton.Image")));
            this.m_BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BoldToolStripButton.Name = "m_BoldToolStripButton";
            this.m_BoldToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_BoldToolStripButton.Text = "Make Text Bold";
            this.m_BoldToolStripButton.Click += new System.EventHandler(this.BoldTextToolButtonOnClick);
            // 
            // m_ItalicToolStripButton
            // 
            this.m_ItalicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_ItalicToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_ItalicToolStripButton.Image")));
            this.m_ItalicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_ItalicToolStripButton.Name = "m_ItalicToolStripButton";
            this.m_ItalicToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_ItalicToolStripButton.Text = "Make Text Italic";
            this.m_ItalicToolStripButton.Click += new System.EventHandler(this.ItalicTextToolButtonOnClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // m_LeftJustifyToolStripButton
            // 
            this.m_LeftJustifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_LeftJustifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_LeftJustifyToolStripButton.Image")));
            this.m_LeftJustifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_LeftJustifyToolStripButton.Name = "m_LeftJustifyToolStripButton";
            this.m_LeftJustifyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_LeftJustifyToolStripButton.Text = "Left Justify";
            this.m_LeftJustifyToolStripButton.Click += new System.EventHandler(this.TextLeftToolButtonOnClick);
            // 
            // m_CenterJustifyToolStripButton
            // 
            this.m_CenterJustifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_CenterJustifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_CenterJustifyToolStripButton.Image")));
            this.m_CenterJustifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_CenterJustifyToolStripButton.Name = "m_CenterJustifyToolStripButton";
            this.m_CenterJustifyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_CenterJustifyToolStripButton.Text = "Center Justify";
            this.m_CenterJustifyToolStripButton.Click += new System.EventHandler(this.TextCenterToolButtonOnClick);
            // 
            // m_RightJustifyToolStripButton
            // 
            this.m_RightJustifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_RightJustifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("m_RightJustifyToolStripButton.Image")));
            this.m_RightJustifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_RightJustifyToolStripButton.Name = "m_RightJustifyToolStripButton";
            this.m_RightJustifyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.m_RightJustifyToolStripButton.Text = "Right Justify";
            this.m_RightJustifyToolStripButton.Click += new System.EventHandler(this.TextRightToolButtonOnClick);
            // 
            // m_SplitterContainer
            // 
            this.m_SplitterContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_SplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_SplitterContainer.Location = new System.Drawing.Point(0, 49);
            this.m_SplitterContainer.Name = "m_SplitterContainer";
            this.m_SplitterContainer.Size = new System.Drawing.Size(782, 417);
            this.m_SplitterContainer.SplitterDistance = 150;
            this.m_SplitterContainer.TabIndex = 3;
            this.m_SplitterContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.OnSplitterMoved);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 488);
            this.Controls.Add(this.m_SplitterContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.m_StatusStrip);
            this.Controls.Add(this.m_MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.m_MenuStrip;
            this.Name = "MainFrm";
            this.Text = "Slacker 2000 Song Editor";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.OnLayout);
            this.Resize += new System.EventHandler(this.OnResize);
            this.m_MenuStrip.ResumeLayout(false);
            this.m_MenuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_SplitterContainer)).EndInit();
            this.m_SplitterContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip m_StatusStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer m_SplitterContainer;
        private TreeViewEx m_TreeView;
        private RichTextBoxEx m_EditControl;          
        private System.Windows.Forms.ToolStripMenuItem sectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox m_PickColorToolStripCombo;
        private System.Windows.Forms.ToolStripComboBox m_FontToolStripComboBox;
        private System.Windows.Forms.ToolStripButton m_NewFileToolStripButton;
        private System.Windows.Forms.ToolStripButton m_OpenFileToolStripButton;
        private System.Windows.Forms.ToolStripButton m_SaveFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton m_NewSectionToolStripButton;
        private System.Windows.Forms.ToolStripButton m_DeleteSectionToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_LargerToolStripButton;
        private System.Windows.Forms.ToolStripButton m_SmallerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_ApplyColorToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_BoldToolStripButton;
        private System.Windows.Forms.ToolStripButton m_ItalicToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton m_LeftJustifyToolStripButton;
        private System.Windows.Forms.ToolStripButton m_CenterJustifyToolStripButton;
        private System.Windows.Forms.ToolStripButton m_RightJustifyToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem FileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileNewMenuItem;
    }
}

