namespace CustomControls.UserControls
{
    partial class FindDuplicateTracksControl
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.scanForDuplicatesButton = new System.Windows.Forms.Button();
            this.tracksGroupBox = new System.Windows.Forms.GroupBox();
            this.tracksDataGridView = new System.Windows.Forms.DataGridView();
            this.duplicateTracksGroupBox = new System.Windows.Forms.GroupBox();
            this.duplicatesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tracksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).BeginInit();
            this.duplicateTracksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.scanForDuplicatesButton);
            this.splitContainer.Panel1.Controls.Add(this.tracksGroupBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.duplicateTracksGroupBox);
            this.splitContainer.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 0;
            // 
            // scanForDuplicatesButton
            // 
            this.scanForDuplicatesButton.Location = new System.Drawing.Point(0, 0);
            this.scanForDuplicatesButton.Name = "scanForDuplicatesButton";
            this.scanForDuplicatesButton.Size = new System.Drawing.Size(114, 23);
            this.scanForDuplicatesButton.TabIndex = 5;
            this.scanForDuplicatesButton.Text = "Scan for duplicates";
            this.scanForDuplicatesButton.UseVisualStyleBackColor = true;
            this.scanForDuplicatesButton.Click += new System.EventHandler(this.ScanForDuplicatesButton_Click);
            // 
            // tracksGroupBox
            // 
            this.tracksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tracksGroupBox.Controls.Add(this.tracksDataGridView);
            this.tracksGroupBox.Location = new System.Drawing.Point(0, 26);
            this.tracksGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.tracksGroupBox.Name = "tracksGroupBox";
            this.tracksGroupBox.Size = new System.Drawing.Size(800, 224);
            this.tracksGroupBox.TabIndex = 4;
            this.tracksGroupBox.TabStop = false;
            this.tracksGroupBox.Text = "Tracks";
            // 
            // tracksDataGridView
            // 
            this.tracksDataGridView.AllowUserToAddRows = false;
            this.tracksDataGridView.AllowUserToDeleteRows = false;
            this.tracksDataGridView.AllowUserToResizeColumns = false;
            this.tracksDataGridView.AllowUserToResizeRows = false;
            this.tracksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tracksDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tracksDataGridView.CausesValidation = false;
            this.tracksDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tracksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tracksDataGridView.Location = new System.Drawing.Point(6, 19);
            this.tracksDataGridView.MultiSelect = false;
            this.tracksDataGridView.Name = "tracksDataGridView";
            this.tracksDataGridView.ReadOnly = true;
            this.tracksDataGridView.RowHeadersVisible = false;
            this.tracksDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tracksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tracksDataGridView.ShowCellErrors = false;
            this.tracksDataGridView.ShowCellToolTips = false;
            this.tracksDataGridView.ShowEditingIcon = false;
            this.tracksDataGridView.ShowRowErrors = false;
            this.tracksDataGridView.Size = new System.Drawing.Size(788, 199);
            this.tracksDataGridView.TabIndex = 0;
            // 
            // duplicateTracksGroupBox
            // 
            this.duplicateTracksGroupBox.Controls.Add(this.duplicatesDataGridView);
            this.duplicateTracksGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duplicateTracksGroupBox.Location = new System.Drawing.Point(0, 0);
            this.duplicateTracksGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.duplicateTracksGroupBox.Name = "duplicateTracksGroupBox";
            this.duplicateTracksGroupBox.Size = new System.Drawing.Size(800, 242);
            this.duplicateTracksGroupBox.TabIndex = 5;
            this.duplicateTracksGroupBox.TabStop = false;
            this.duplicateTracksGroupBox.Text = "Duplicate tracks";
            // 
            // duplicatesDataGridView
            // 
            this.duplicatesDataGridView.AllowUserToAddRows = false;
            this.duplicatesDataGridView.AllowUserToDeleteRows = false;
            this.duplicatesDataGridView.AllowUserToResizeColumns = false;
            this.duplicatesDataGridView.AllowUserToResizeRows = false;
            this.duplicatesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicatesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.duplicatesDataGridView.CausesValidation = false;
            this.duplicatesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.duplicatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.duplicatesDataGridView.Location = new System.Drawing.Point(6, 19);
            this.duplicatesDataGridView.MultiSelect = false;
            this.duplicatesDataGridView.Name = "duplicatesDataGridView";
            this.duplicatesDataGridView.ReadOnly = true;
            this.duplicatesDataGridView.RowHeadersVisible = false;
            this.duplicatesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.duplicatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.duplicatesDataGridView.ShowCellErrors = false;
            this.duplicatesDataGridView.ShowCellToolTips = false;
            this.duplicatesDataGridView.ShowEditingIcon = false;
            this.duplicatesDataGridView.ShowRowErrors = false;
            this.duplicatesDataGridView.Size = new System.Drawing.Size(788, 217);
            this.duplicatesDataGridView.TabIndex = 0;
            // 
            // FindDuplicateTracksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "FindDuplicateTracksControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tracksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).EndInit();
            this.duplicateTracksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox tracksGroupBox;
        private System.Windows.Forms.Button scanForDuplicatesButton;
        private System.Windows.Forms.DataGridView tracksDataGridView;
        private System.Windows.Forms.GroupBox duplicateTracksGroupBox;
        private System.Windows.Forms.DataGridView duplicatesDataGridView;
    }
}
