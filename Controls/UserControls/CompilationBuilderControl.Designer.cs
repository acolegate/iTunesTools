namespace CustomControls.UserControls
{
    partial class CompilationBuilderControl
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
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.TextBox();
            this.parseTextButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.identifiedTracksGroupBox = new System.Windows.Forms.GroupBox();
            this.compilationTracksDataGridView = new System.Windows.Forms.DataGridView();
            this.savePlaylistButton = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.textGroupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.identifiedTracksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compilationTracksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.tabControl);
            this.textGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textGroupBox.Location = new System.Drawing.Point(0, 0);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Size = new System.Drawing.Size(800, 250);
            this.textGroupBox.TabIndex = 0;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text processing";
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(794, 231);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox);
            this.tabPage1.Controls.Add(this.parseTextButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(786, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raw text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Margin = new System.Windows.Forms.Padding(0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(786, 167);
            this.textBox.TabIndex = 0;
            this.textBox.WordWrap = false;
            // 
            // parseTextButton
            // 
            this.parseTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.parseTextButton.Location = new System.Drawing.Point(712, 180);
            this.parseTextButton.Name = "parseTextButton";
            this.parseTextButton.Size = new System.Drawing.Size(75, 23);
            this.parseTextButton.TabIndex = 1;
            this.parseTextButton.Text = "Parse text";
            this.parseTextButton.UseVisualStyleBackColor = true;
            this.parseTextButton.Click += new System.EventHandler(this.ParseTextButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(786, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Processing report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox.Size = new System.Drawing.Size(786, 202);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // identifiedTracksGroupBox
            // 
            this.identifiedTracksGroupBox.Controls.Add(this.compilationTracksDataGridView);
            this.identifiedTracksGroupBox.Controls.Add(this.savePlaylistButton);
            this.identifiedTracksGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identifiedTracksGroupBox.Location = new System.Drawing.Point(0, 0);
            this.identifiedTracksGroupBox.Name = "identifiedTracksGroupBox";
            this.identifiedTracksGroupBox.Size = new System.Drawing.Size(800, 242);
            this.identifiedTracksGroupBox.TabIndex = 1;
            this.identifiedTracksGroupBox.TabStop = false;
            this.identifiedTracksGroupBox.Text = "Identified tracks";
            // 
            // compilationTracksDataGridView
            // 
            this.compilationTracksDataGridView.AllowUserToAddRows = false;
            this.compilationTracksDataGridView.AllowUserToDeleteRows = false;
            this.compilationTracksDataGridView.AllowUserToResizeColumns = false;
            this.compilationTracksDataGridView.AllowUserToResizeRows = false;
            this.compilationTracksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compilationTracksDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.compilationTracksDataGridView.CausesValidation = false;
            this.compilationTracksDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.compilationTracksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compilationTracksDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.compilationTracksDataGridView.Location = new System.Drawing.Point(6, 19);
            this.compilationTracksDataGridView.MultiSelect = false;
            this.compilationTracksDataGridView.Name = "compilationTracksDataGridView";
            this.compilationTracksDataGridView.RowHeadersVisible = false;
            this.compilationTracksDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.compilationTracksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.compilationTracksDataGridView.ShowCellErrors = false;
            this.compilationTracksDataGridView.ShowCellToolTips = false;
            this.compilationTracksDataGridView.ShowEditingIcon = false;
            this.compilationTracksDataGridView.ShowRowErrors = false;
            this.compilationTracksDataGridView.Size = new System.Drawing.Size(788, 188);
            this.compilationTracksDataGridView.TabIndex = 2;
            // 
            // savePlaylistButton
            // 
            this.savePlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePlaylistButton.Location = new System.Drawing.Point(719, 213);
            this.savePlaylistButton.Name = "savePlaylistButton";
            this.savePlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.savePlaylistButton.TabIndex = 0;
            this.savePlaylistButton.Text = "Save playlist";
            this.savePlaylistButton.UseVisualStyleBackColor = true;
            this.savePlaylistButton.Click += new System.EventHandler(this.SavePlaylistButton_Click);
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
            this.splitContainer.Panel1.Controls.Add(this.textGroupBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.identifiedTracksGroupBox);
            this.splitContainer.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 2;
            // 
            // CompilationBuilderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CompilationBuilderControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.textGroupBox.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.identifiedTracksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compilationTracksDataGridView)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.Button parseTextButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.GroupBox identifiedTracksGroupBox;
        private System.Windows.Forms.Button savePlaylistButton;
        private System.Windows.Forms.DataGridView compilationTracksDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}
