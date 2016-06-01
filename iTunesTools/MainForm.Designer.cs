using System.Windows.Forms;

using CustomControls.UserControls;

namespace iTunesTools
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.consolidateTracksTabPage = new System.Windows.Forms.TabPage();
            this.consolidationControl = new CustomControls.UserControls.ConsolidationControl();
            this.findDuplicateTracksTabPage = new System.Windows.Forms.TabPage();
            this.findDuplicateTracksControl = new CustomControls.UserControls.FindDuplicateTracksControl();
            this.compilationBuilderTabPage = new System.Windows.Forms.TabPage();
            this.compilationBuilderControl = new CustomControls.UserControls.CompilationBuilderControl();
            this.orphanedMediaFilesTabPage = new System.Windows.Forms.TabPage();
            this.orphanedMediaFilesControl = new CustomControls.UserControls.OrphanedMediaFilesControl();
            this.tabControl.SuspendLayout();
            this.consolidateTracksTabPage.SuspendLayout();
            this.findDuplicateTracksTabPage.SuspendLayout();
            this.compilationBuilderTabPage.SuspendLayout();
            this.orphanedMediaFilesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.consolidateTracksTabPage);
            this.tabControl.Controls.Add(this.findDuplicateTracksTabPage);
            this.tabControl.Controls.Add(this.compilationBuilderTabPage);
            this.tabControl.Controls.Add(this.orphanedMediaFilesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1178, 614);
            this.tabControl.TabIndex = 1;
            // 
            // consolidateTracksTabPage
            // 
            this.consolidateTracksTabPage.Controls.Add(this.consolidationControl);
            this.consolidateTracksTabPage.Location = new System.Drawing.Point(4, 22);
            this.consolidateTracksTabPage.Name = "consolidateTracksTabPage";
            this.consolidateTracksTabPage.Size = new System.Drawing.Size(1170, 588);
            this.consolidateTracksTabPage.TabIndex = 0;
            this.consolidateTracksTabPage.Text = "Consolidate Tracks";
            this.consolidateTracksTabPage.UseVisualStyleBackColor = true;
            // 
            // consolidationControl
            // 
            this.consolidationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolidationControl.Location = new System.Drawing.Point(0, 0);
            this.consolidationControl.Name = "consolidationControl";
            this.consolidationControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.consolidationControl.Size = new System.Drawing.Size(1170, 588);
            this.consolidationControl.TabIndex = 0;
            // 
            // findDuplicateTracksTabPage
            // 
            this.findDuplicateTracksTabPage.Controls.Add(this.findDuplicateTracksControl);
            this.findDuplicateTracksTabPage.Location = new System.Drawing.Point(4, 22);
            this.findDuplicateTracksTabPage.Name = "findDuplicateTracksTabPage";
            this.findDuplicateTracksTabPage.Size = new System.Drawing.Size(1170, 588);
            this.findDuplicateTracksTabPage.TabIndex = 1;
            this.findDuplicateTracksTabPage.Text = "Find Duplicate Tracks";
            this.findDuplicateTracksTabPage.UseVisualStyleBackColor = true;
            // 
            // findDuplicateTracksControl
            // 
            this.findDuplicateTracksControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findDuplicateTracksControl.Location = new System.Drawing.Point(0, 0);
            this.findDuplicateTracksControl.Margin = new System.Windows.Forms.Padding(0);
            this.findDuplicateTracksControl.Name = "findDuplicateTracksControl";
            this.findDuplicateTracksControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.findDuplicateTracksControl.Size = new System.Drawing.Size(1170, 588);
            this.findDuplicateTracksControl.TabIndex = 0;
            // 
            // compilationBuilderTabPage
            // 
            this.compilationBuilderTabPage.Controls.Add(this.compilationBuilderControl);
            this.compilationBuilderTabPage.Location = new System.Drawing.Point(4, 22);
            this.compilationBuilderTabPage.Name = "compilationBuilderTabPage";
            this.compilationBuilderTabPage.Size = new System.Drawing.Size(1170, 588);
            this.compilationBuilderTabPage.TabIndex = 2;
            this.compilationBuilderTabPage.Text = "Compilation Builder";
            this.compilationBuilderTabPage.UseVisualStyleBackColor = true;
            // 
            // compilationBuilderControl
            // 
            this.compilationBuilderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compilationBuilderControl.Location = new System.Drawing.Point(0, 0);
            this.compilationBuilderControl.Name = "compilationBuilderControl";
            this.compilationBuilderControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.compilationBuilderControl.Size = new System.Drawing.Size(1170, 588);
            this.compilationBuilderControl.TabIndex = 0;
            // 
            // orphanedMediaFilesTabPage
            // 
            this.orphanedMediaFilesTabPage.Controls.Add(this.orphanedMediaFilesControl);
            this.orphanedMediaFilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.orphanedMediaFilesTabPage.Name = "orphanedMediaFilesTabPage";
            this.orphanedMediaFilesTabPage.Size = new System.Drawing.Size(1170, 588);
            this.orphanedMediaFilesTabPage.TabIndex = 3;
            this.orphanedMediaFilesTabPage.Text = "Orphaned Media Files";
            this.orphanedMediaFilesTabPage.UseVisualStyleBackColor = true;
            // 
            // orphanedMediaFilesControl
            // 
            this.orphanedMediaFilesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orphanedMediaFilesControl.Location = new System.Drawing.Point(0, 0);
            this.orphanedMediaFilesControl.Name = "orphanedMediaFilesControl";
            this.orphanedMediaFilesControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.orphanedMediaFilesControl.Size = new System.Drawing.Size(1170, 588);
            this.orphanedMediaFilesControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 614);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1186, 641);
            this.Name = "MainForm";
            this.Text = "iTunes Tools";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.consolidateTracksTabPage.ResumeLayout(false);
            this.findDuplicateTracksTabPage.ResumeLayout(false);
            this.compilationBuilderTabPage.ResumeLayout(false);
            this.orphanedMediaFilesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage consolidateTracksTabPage;
        private ConsolidationControl consolidationControl;
        private TabPage findDuplicateTracksTabPage;
        private FindDuplicateTracksControl findDuplicateTracksControl;
        private TabPage compilationBuilderTabPage;
        private CompilationBuilderControl compilationBuilderControl;
        private TabPage orphanedMediaFilesTabPage;
        private OrphanedMediaFilesControl orphanedMediaFilesControl;
    }
}