namespace DesignValidation
{
    partial class DesignValidationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignValidationForm));
            this.ActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.EditDXFExport = new System.Windows.Forms.Button();
            this.ExportDXFButton = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.LogOutputListBox = new System.Windows.Forms.ListBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InventorIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.ActionsGroupBox.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionsGroupBox
            // 
            this.ActionsGroupBox.Controls.Add(this.EditDXFExport);
            this.ActionsGroupBox.Controls.Add(this.ExportDXFButton);
            this.ActionsGroupBox.Controls.Add(this.Import);
            this.ActionsGroupBox.Location = new System.Drawing.Point(20, 15);
            this.ActionsGroupBox.Name = "ActionsGroupBox";
            this.ActionsGroupBox.Size = new System.Drawing.Size(275, 60);
            this.ActionsGroupBox.TabIndex = 14;
            this.ActionsGroupBox.TabStop = false;
            this.ActionsGroupBox.Text = "Actions";
            // 
            // EditDXFExport
            // 
            this.EditDXFExport.Location = new System.Drawing.Point(97, 19);
            this.EditDXFExport.Name = "EditDXFExport";
            this.EditDXFExport.Size = new System.Drawing.Size(80, 30);
            this.EditDXFExport.TabIndex = 16;
            this.EditDXFExport.Text = "Settings";
            this.EditDXFExport.UseVisualStyleBackColor = true;
            this.EditDXFExport.Click += new System.EventHandler(this.EditDXFExport_Click);
            // 
            // ExportDXFButton
            // 
            this.ExportDXFButton.Location = new System.Drawing.Point(187, 19);
            this.ExportDXFButton.Name = "ExportDXFButton";
            this.ExportDXFButton.Size = new System.Drawing.Size(80, 30);
            this.ExportDXFButton.TabIndex = 15;
            this.ExportDXFButton.Text = "Export DXF";
            this.ExportDXFButton.UseVisualStyleBackColor = true;
            this.ExportDXFButton.Click += new System.EventHandler(this.ExportDXFButton_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(8, 19);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(80, 30);
            this.Import.TabIndex = 12;
            this.Import.Text = "Import ";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.LogOutputListBox);
            this.BottomPanel.Controls.Add(this.ProgressBar);
            this.BottomPanel.Controls.Add(this.ActionsGroupBox);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 430);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(834, 106);
            this.BottomPanel.TabIndex = 14;
            // 
            // LogOutputListBox
            // 
            this.LogOutputListBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.LogOutputListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogOutputListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutputListBox.ForeColor = System.Drawing.Color.Green;
            this.LogOutputListBox.FormattingEnabled = true;
            this.LogOutputListBox.ItemHeight = 15;
            this.LogOutputListBox.Location = new System.Drawing.Point(310, 20);
            this.LogOutputListBox.Name = "LogOutputListBox";
            this.LogOutputListBox.Size = new System.Drawing.Size(500, 75);
            this.LogOutputListBox.TabIndex = 16;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(20, 81);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(275, 16);
            this.ProgressBar.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesignValidation.Properties.Resources.DXFExportWizardLogo_2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // InventorIconImageList
            // 
            this.InventorIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("InventorIconImageList.ImageStream")));
            this.InventorIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.InventorIconImageList.Images.SetKeyName(0, "AssemblyIcon.PNG");
            this.InventorIconImageList.Images.SetKeyName(1, "Part.PNG");
            this.InventorIconImageList.Images.SetKeyName(2, "SheetmetalIcon.PNG");
            this.InventorIconImageList.Images.SetKeyName(3, "GreenTick.png");
            this.InventorIconImageList.Images.SetKeyName(4, "RedCross.png");
            // 
            // DesignValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(834, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BottomPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DesignValidationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "DXF Export Wizard";
            this.ActionsGroupBox.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ActionsGroupBox;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button ExportDXFButton;
        private System.Windows.Forms.Button EditDXFExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox LogOutputListBox;
        private System.Windows.Forms.ImageList InventorIconImageList;
    }
}

