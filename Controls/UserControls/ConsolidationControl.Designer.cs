namespace CustomControls.UserControls
{
    sealed partial class ConsolidationControl
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
            this.components = new System.ComponentModel.Container();
            this.trackContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keepThisTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.iTunesTracksGroupBox = new System.Windows.Forms.GroupBox();
            this.tracksGridView = new System.Windows.Forms.DataGridView();
            this.autoSelectButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.consolidatedTrackGroupBox = new System.Windows.Forms.GroupBox();
            this.consolidatedTrackGridView = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.consolidateButton = new System.Windows.Forms.Button();
            this.trackContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.iTunesTracksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracksGridView)).BeginInit();
            this.consolidatedTrackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consolidatedTrackGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // trackContextMenuStrip
            // 
            this.trackContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepThisTrackToolStripMenuItem});
            this.trackContextMenuStrip.Name = "contextMenuStrip";
            this.trackContextMenuStrip.ShowImageMargin = false;
            this.trackContextMenuStrip.Size = new System.Drawing.Size(121, 26);
            // 
            // keepThisTrackToolStripMenuItem
            // 
            this.keepThisTrackToolStripMenuItem.Name = "keepThisTrackToolStripMenuItem";
            this.keepThisTrackToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.keepThisTrackToolStripMenuItem.Text = "Keep this track";
            this.keepThisTrackToolStripMenuItem.Click += new System.EventHandler(this.KeepThisTrackToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.iTunesTracksGroupBox);
            this.splitContainer.Panel1.Controls.Add(this.autoSelectButton);
            this.splitContainer.Panel1.Controls.Add(this.refreshButton);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.consolidatedTrackGroupBox);
            this.splitContainer.Panel2.Controls.Add(this.cancelButton);
            this.splitContainer.Panel2.Controls.Add(this.consolidateButton);
            this.splitContainer.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 7;
            // 
            // iTunesTracksGroupBox
            // 
            this.iTunesTracksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iTunesTracksGroupBox.Controls.Add(this.tracksGridView);
            this.iTunesTracksGroupBox.Location = new System.Drawing.Point(0, 0);
            this.iTunesTracksGroupBox.Name = "iTunesTracksGroupBox";
            this.iTunesTracksGroupBox.Size = new System.Drawing.Size(800, 218);
            this.iTunesTracksGroupBox.TabIndex = 3;
            this.iTunesTracksGroupBox.TabStop = false;
            this.iTunesTracksGroupBox.Text = "Selected tracks";
            // 
            // tracksGridView
            // 
            this.tracksGridView.AllowUserToAddRows = false;
            this.tracksGridView.AllowUserToDeleteRows = false;
            this.tracksGridView.AllowUserToResizeColumns = false;
            this.tracksGridView.AllowUserToResizeRows = false;
            this.tracksGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tracksGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tracksGridView.CausesValidation = false;
            this.tracksGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tracksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tracksGridView.ContextMenuStrip = this.trackContextMenuStrip;
            this.tracksGridView.Location = new System.Drawing.Point(6, 19);
            this.tracksGridView.MultiSelect = false;
            this.tracksGridView.Name = "tracksGridView";
            this.tracksGridView.ReadOnly = true;
            this.tracksGridView.RowHeadersVisible = false;
            this.tracksGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tracksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tracksGridView.ShowCellErrors = false;
            this.tracksGridView.ShowCellToolTips = false;
            this.tracksGridView.ShowEditingIcon = false;
            this.tracksGridView.ShowRowErrors = false;
            this.tracksGridView.Size = new System.Drawing.Size(788, 193);
            this.tracksGridView.TabIndex = 0;
            this.tracksGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TracksGridView_CellFormatting);
            this.tracksGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TracksGridView_CellMouseDown);
            this.tracksGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TracksGridView_CellMouseMove);
            this.tracksGridView.Sorted += new System.EventHandler(this.TracksGridView_Sorted);
            // 
            // autoSelectButton
            // 
            this.autoSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSelectButton.Enabled = false;
            this.autoSelectButton.Location = new System.Drawing.Point(719, 224);
            this.autoSelectButton.Name = "autoSelectButton";
            this.autoSelectButton.Size = new System.Drawing.Size(75, 23);
            this.autoSelectButton.TabIndex = 5;
            this.autoSelectButton.Text = "Auto select";
            this.autoSelectButton.UseVisualStyleBackColor = true;
            this.autoSelectButton.Click += new System.EventHandler(this.AutoSelectButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(638, 224);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // consolidatedTrackGroupBox
            // 
            this.consolidatedTrackGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consolidatedTrackGroupBox.Controls.Add(this.consolidatedTrackGridView);
            this.consolidatedTrackGroupBox.Location = new System.Drawing.Point(0, 3);
            this.consolidatedTrackGroupBox.Name = "consolidatedTrackGroupBox";
            this.consolidatedTrackGroupBox.Size = new System.Drawing.Size(800, 207);
            this.consolidatedTrackGroupBox.TabIndex = 4;
            this.consolidatedTrackGroupBox.TabStop = false;
            this.consolidatedTrackGroupBox.Text = "Consolidated Track";
            // 
            // consolidatedTrackGridView
            // 
            this.consolidatedTrackGridView.AllowUserToAddRows = false;
            this.consolidatedTrackGridView.AllowUserToDeleteRows = false;
            this.consolidatedTrackGridView.AllowUserToResizeColumns = false;
            this.consolidatedTrackGridView.AllowUserToResizeRows = false;
            this.consolidatedTrackGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consolidatedTrackGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.consolidatedTrackGridView.CausesValidation = false;
            this.consolidatedTrackGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.consolidatedTrackGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consolidatedTrackGridView.Location = new System.Drawing.Point(6, 19);
            this.consolidatedTrackGridView.MultiSelect = false;
            this.consolidatedTrackGridView.Name = "consolidatedTrackGridView";
            this.consolidatedTrackGridView.ReadOnly = true;
            this.consolidatedTrackGridView.RowHeadersVisible = false;
            this.consolidatedTrackGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.consolidatedTrackGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.consolidatedTrackGridView.ShowCellErrors = false;
            this.consolidatedTrackGridView.ShowCellToolTips = false;
            this.consolidatedTrackGridView.ShowEditingIcon = false;
            this.consolidatedTrackGridView.ShowRowErrors = false;
            this.consolidatedTrackGridView.Size = new System.Drawing.Size(788, 182);
            this.consolidatedTrackGridView.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(719, 216);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // consolidateButton
            // 
            this.consolidateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.consolidateButton.Enabled = false;
            this.consolidateButton.Location = new System.Drawing.Point(638, 216);
            this.consolidateButton.Name = "consolidateButton";
            this.consolidateButton.Size = new System.Drawing.Size(75, 23);
            this.consolidateButton.TabIndex = 2;
            this.consolidateButton.Text = "Consolidate";
            this.consolidateButton.UseVisualStyleBackColor = true;
            this.consolidateButton.Click += new System.EventHandler(this.ConsolidateButton_Click);
            // 
            // ConsolidationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ConsolidationControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.trackContextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.iTunesTracksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracksGridView)).EndInit();
            this.consolidatedTrackGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.consolidatedTrackGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip trackContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem keepThisTrackToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox iTunesTracksGroupBox;
        private System.Windows.Forms.DataGridView tracksGridView;
        private System.Windows.Forms.Button autoSelectButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox consolidatedTrackGroupBox;
        private System.Windows.Forms.DataGridView consolidatedTrackGridView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button consolidateButton;
    }
}

