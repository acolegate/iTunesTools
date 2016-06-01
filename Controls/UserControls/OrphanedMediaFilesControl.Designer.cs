namespace CustomControls.UserControls
{
    partial class OrphanedMediaFilesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scanLibraryButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orphanedFilesListBox = new System.Windows.Forms.ListBox();
            this.moveOrphanedFilesButton = new System.Windows.Forms.Button();
            this.deleteOrphanedFilesButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanLibraryButton
            // 
            this.scanLibraryButton.Location = new System.Drawing.Point(0, 0);
            this.scanLibraryButton.Name = "scanLibraryButton";
            this.scanLibraryButton.Size = new System.Drawing.Size(75, 23);
            this.scanLibraryButton.TabIndex = 0;
            this.scanLibraryButton.Text = "Scan library";
            this.scanLibraryButton.UseVisualStyleBackColor = true;
            this.scanLibraryButton.Click += new System.EventHandler(this.ScanLibraryButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.orphanedFilesListBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 433);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // orphanedFilesListBox
            // 
            this.orphanedFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orphanedFilesListBox.HorizontalScrollbar = true;
            this.orphanedFilesListBox.Location = new System.Drawing.Point(6, 19);
            this.orphanedFilesListBox.Name = "orphanedFilesListBox";
            this.orphanedFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.orphanedFilesListBox.Size = new System.Drawing.Size(788, 407);
            this.orphanedFilesListBox.TabIndex = 0;
            // 
            // moveOrphanedFilesButton
            // 
            this.moveOrphanedFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveOrphanedFilesButton.Location = new System.Drawing.Point(558, 467);
            this.moveOrphanedFilesButton.Name = "moveOrphanedFilesButton";
            this.moveOrphanedFilesButton.Size = new System.Drawing.Size(118, 23);
            this.moveOrphanedFilesButton.TabIndex = 4;
            this.moveOrphanedFilesButton.Text = "Move orphaned files";
            this.moveOrphanedFilesButton.UseVisualStyleBackColor = true;
            this.moveOrphanedFilesButton.Click += new System.EventHandler(this.MoveOrphanedFilesButton_Click);
            // 
            // deleteOrphanedFilesButton
            // 
            this.deleteOrphanedFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteOrphanedFilesButton.Location = new System.Drawing.Point(682, 467);
            this.deleteOrphanedFilesButton.Name = "deleteOrphanedFilesButton";
            this.deleteOrphanedFilesButton.Size = new System.Drawing.Size(118, 23);
            this.deleteOrphanedFilesButton.TabIndex = 3;
            this.deleteOrphanedFilesButton.Text = "Delete orphaned files";
            this.deleteOrphanedFilesButton.UseVisualStyleBackColor = true;
            this.deleteOrphanedFilesButton.Click += new System.EventHandler(this.DeleteOrphanedFilesButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select destination folder...";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "[set programatically]";
            // 
            // OrphanedMediaFilesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveOrphanedFilesButton);
            this.Controls.Add(this.deleteOrphanedFilesButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scanLibraryButton);
            this.Name = "OrphanedMediaFilesControl";
            this.Size = new System.Drawing.Size(800, 490);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanLibraryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox orphanedFilesListBox;
        private System.Windows.Forms.Button moveOrphanedFilesButton;
        private System.Windows.Forms.Button deleteOrphanedFilesButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
    }
}
