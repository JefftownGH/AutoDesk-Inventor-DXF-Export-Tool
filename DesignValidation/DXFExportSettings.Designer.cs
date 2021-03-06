namespace DesignValidation
{
    partial class DXFExportSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DXFLayersGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridDXFLayers = new System.Windows.Forms.DataGridView();
            this.LayerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolidLineColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DashedLineColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NoLineColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SavePropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.DirectoryBrowseButton = new System.Windows.Forms.Button();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.SaveInLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FileNameGroupBox = new System.Windows.Forms.GroupBox();
            this.AppendMaterialThicknessCheckbox = new System.Windows.Forms.CheckBox();
            this.AppendFoldedCheckbox = new System.Windows.Forms.CheckBox();
            this.DXFLayersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDXFLayers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SavePropertiesGroupBox.SuspendLayout();
            this.FileNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DXFLayersGroupBox
            // 
            this.DXFLayersGroupBox.Controls.Add(this.dataGridDXFLayers);
            this.DXFLayersGroupBox.Location = new System.Drawing.Point(22, 12);
            this.DXFLayersGroupBox.Name = "DXFLayersGroupBox";
            this.DXFLayersGroupBox.Size = new System.Drawing.Size(490, 184);
            this.DXFLayersGroupBox.TabIndex = 0;
            this.DXFLayersGroupBox.TabStop = false;
            this.DXFLayersGroupBox.Text = "DXF Layers";
            // 
            // dataGridDXFLayers
            // 
            this.dataGridDXFLayers.AllowUserToAddRows = false;
            this.dataGridDXFLayers.AllowUserToDeleteRows = false;
            this.dataGridDXFLayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDXFLayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LayerNameColumn,
            this.SolidLineColumn,
            this.DashedLineColumn,
            this.NoLineColumn});
            this.dataGridDXFLayers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridDXFLayers.Location = new System.Drawing.Point(21, 19);
            this.dataGridDXFLayers.Name = "dataGridDXFLayers";
            this.dataGridDXFLayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDXFLayers.Size = new System.Drawing.Size(450, 143);
            this.dataGridDXFLayers.TabIndex = 2;
            // 
            // LayerNameColumn
            // 
            this.LayerNameColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.LayerNameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.LayerNameColumn.FillWeight = 150F;
            this.LayerNameColumn.HeaderText = "Layer Name";
            this.LayerNameColumn.Name = "LayerNameColumn";
            this.LayerNameColumn.ReadOnly = true;
            this.LayerNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LayerNameColumn.ToolTipText = "The DXF layer";
            this.LayerNameColumn.Width = 175;
            // 
            // SolidLineColumn
            // 
            this.SolidLineColumn.DataPropertyName = "SolidLine";
            this.SolidLineColumn.HeaderText = "Solid Line";
            this.SolidLineColumn.Name = "SolidLineColumn";
            this.SolidLineColumn.Width = 75;
            // 
            // DashedLineColumn
            // 
            this.DashedLineColumn.DataPropertyName = "DashedLine";
            this.DashedLineColumn.HeaderText = "Dashed Line";
            this.DashedLineColumn.Name = "DashedLineColumn";
            this.DashedLineColumn.Width = 75;
            // 
            // NoLineColumn
            // 
            this.NoLineColumn.DataPropertyName = "NoLine";
            this.NoLineColumn.HeaderText = "No Line";
            this.NoLineColumn.Name = "NoLineColumn";
            this.NoLineColumn.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DXF Format";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(341, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(117, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Simplify Splines";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DXF Type";
            // 
            // SavePropertiesGroupBox
            // 
            this.SavePropertiesGroupBox.Controls.Add(this.DirectoryBrowseButton);
            this.SavePropertiesGroupBox.Controls.Add(this.FilePathTextBox);
            this.SavePropertiesGroupBox.Controls.Add(this.SaveInLabel);
            this.SavePropertiesGroupBox.Location = new System.Drawing.Point(24, 266);
            this.SavePropertiesGroupBox.Name = "SavePropertiesGroupBox";
            this.SavePropertiesGroupBox.Size = new System.Drawing.Size(488, 70);
            this.SavePropertiesGroupBox.TabIndex = 2;
            this.SavePropertiesGroupBox.TabStop = false;
            this.SavePropertiesGroupBox.Text = "Save Properties";
            // 
            // DirectoryBrowseButton
            // 
            this.DirectoryBrowseButton.Location = new System.Drawing.Point(382, 20);
            this.DirectoryBrowseButton.Name = "DirectoryBrowseButton";
            this.DirectoryBrowseButton.Size = new System.Drawing.Size(76, 23);
            this.DirectoryBrowseButton.TabIndex = 2;
            this.DirectoryBrowseButton.Text = "Browse...";
            this.DirectoryBrowseButton.UseVisualStyleBackColor = true;
            this.DirectoryBrowseButton.Click += new System.EventHandler(this.DirectoryBrowseButton_Click);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(70, 22);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(304, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // SaveInLabel
            // 
            this.SaveInLabel.AutoSize = true;
            this.SaveInLabel.Location = new System.Drawing.Point(17, 25);
            this.SaveInLabel.Name = "SaveInLabel";
            this.SaveInLabel.Size = new System.Drawing.Size(47, 13);
            this.SaveInLabel.TabIndex = 0;
            this.SaveInLabel.Text = "Save In:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(22, 421);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 30);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileNameGroupBox
            // 
            this.FileNameGroupBox.Controls.Add(this.AppendFoldedCheckbox);
            this.FileNameGroupBox.Controls.Add(this.AppendMaterialThicknessCheckbox);
            this.FileNameGroupBox.Location = new System.Drawing.Point(25, 342);
            this.FileNameGroupBox.Name = "FileNameGroupBox";
            this.FileNameGroupBox.Size = new System.Drawing.Size(486, 73);
            this.FileNameGroupBox.TabIndex = 5;
            this.FileNameGroupBox.TabStop = false;
            this.FileNameGroupBox.Text = "File Name Properties";
            // 
            // AppendMaterialThicknessCheckbox
            // 
            this.AppendMaterialThicknessCheckbox.AutoSize = true;
            this.AppendMaterialThicknessCheckbox.Location = new System.Drawing.Point(22, 34);
            this.AppendMaterialThicknessCheckbox.Name = "AppendMaterialThicknessCheckbox";
            this.AppendMaterialThicknessCheckbox.Size = new System.Drawing.Size(155, 17);
            this.AppendMaterialThicknessCheckbox.TabIndex = 2;
            this.AppendMaterialThicknessCheckbox.Text = "Append Material Thickness";
            this.AppendMaterialThicknessCheckbox.UseVisualStyleBackColor = true;
            // 
            // AppendFoldedCheckbox
            // 
            this.AppendFoldedCheckbox.AutoSize = true;
            this.AppendFoldedCheckbox.Location = new System.Drawing.Point(305, 34);
            this.AppendFoldedCheckbox.Name = "AppendFoldedCheckbox";
            this.AppendFoldedCheckbox.Size = new System.Drawing.Size(131, 17);
            this.AppendFoldedCheckbox.TabIndex = 3;
            this.AppendFoldedCheckbox.Text = "Append Folded Status";
            this.AppendFoldedCheckbox.UseVisualStyleBackColor = true;
            // 
            // DXFExportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.FileNameGroupBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SavePropertiesGroupBox);
            this.Controls.Add(this.DXFLayersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DXFExportSettings";
            this.Text = "DXFExportLayerList";
            this.DXFLayersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDXFLayers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SavePropertiesGroupBox.ResumeLayout(false);
            this.SavePropertiesGroupBox.PerformLayout();
            this.FileNameGroupBox.ResumeLayout(false);
            this.FileNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DXFLayersGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridDXFLayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayerNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SolidLineColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DashedLineColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NoLineColumn;
        private System.Windows.Forms.GroupBox SavePropertiesGroupBox;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label SaveInLabel;
        private System.Windows.Forms.Button DirectoryBrowseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox FileNameGroupBox;
        private System.Windows.Forms.CheckBox AppendFoldedCheckbox;
        private System.Windows.Forms.CheckBox AppendMaterialThicknessCheckbox;
    }
}