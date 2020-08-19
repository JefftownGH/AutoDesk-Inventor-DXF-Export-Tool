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
            this.ActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.EditDXFExport = new System.Windows.Forms.Button();
            this.ExportDXFButton = new System.Windows.Forms.Button();
            this.InspectComponent = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComponentErrors = new System.Windows.Forms.ListBox();
            this.ActionsGroupBox.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionsGroupBox
            // 
            this.ActionsGroupBox.Controls.Add(this.EditDXFExport);
            this.ActionsGroupBox.Controls.Add(this.ExportDXFButton);
            this.ActionsGroupBox.Controls.Add(this.InspectComponent);
            this.ActionsGroupBox.Controls.Add(this.Import);
            this.ActionsGroupBox.Location = new System.Drawing.Point(20, 15);
            this.ActionsGroupBox.Name = "ActionsGroupBox";
            this.ActionsGroupBox.Size = new System.Drawing.Size(439, 60);
            this.ActionsGroupBox.TabIndex = 14;
            this.ActionsGroupBox.TabStop = false;
            this.ActionsGroupBox.Text = "Actions";
            // 
            // EditDXFExport
            // 
            this.EditDXFExport.Location = new System.Drawing.Point(218, 19);
            this.EditDXFExport.Name = "EditDXFExport";
            this.EditDXFExport.Size = new System.Drawing.Size(100, 30);
            this.EditDXFExport.TabIndex = 16;
            this.EditDXFExport.Text = "Edit DXF Export";
            this.EditDXFExport.UseVisualStyleBackColor = true;
            this.EditDXFExport.Click += new System.EventHandler(this.EditDXFExport_Click);
            // 
            // ExportDXFButton
            // 
            this.ExportDXFButton.Location = new System.Drawing.Point(324, 19);
            this.ExportDXFButton.Name = "ExportDXFButton";
            this.ExportDXFButton.Size = new System.Drawing.Size(100, 30);
            this.ExportDXFButton.TabIndex = 15;
            this.ExportDXFButton.Text = "Export DXF";
            this.ExportDXFButton.UseVisualStyleBackColor = true;
            this.ExportDXFButton.Click += new System.EventHandler(this.ExportDXFButton_Click);
            // 
            // InspectComponent
            // 
            this.InspectComponent.Location = new System.Drawing.Point(112, 19);
            this.InspectComponent.Name = "InspectComponent";
            this.InspectComponent.Size = new System.Drawing.Size(100, 30);
            this.InspectComponent.TabIndex = 13;
            this.InspectComponent.Text = "Inspect Item";
            this.InspectComponent.UseVisualStyleBackColor = true;
            this.InspectComponent.Click += new System.EventHandler(this.InspectComponent_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(6, 19);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(100, 30);
            this.Import.TabIndex = 12;
            this.Import.Text = "Import Model";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ProgressBar);
            this.BottomPanel.Controls.Add(this.ActionsGroupBox);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 430);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1184, 106);
            this.BottomPanel.TabIndex = 14;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(20, 81);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 15);
            this.ProgressBar.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(885, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 430);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComponentErrors);
            this.groupBox1.Location = new System.Drawing.Point(37, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 294);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // ComponentErrors
            // 
            this.ComponentErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ComponentErrors.FormattingEnabled = true;
            this.ComponentErrors.Location = new System.Drawing.Point(6, 19);
            this.ComponentErrors.Name = "ComponentErrors";
            this.ComponentErrors.Size = new System.Drawing.Size(219, 264);
            this.ComponentErrors.TabIndex = 14;
            // 
            // DesignValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1184, 536);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BottomPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DesignValidationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Design Validation";
            this.ActionsGroupBox.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox ActionsGroupBox;
        private System.Windows.Forms.Button InspectComponent;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ComponentErrors;
        private System.Windows.Forms.Button ExportDXFButton;
        private System.Windows.Forms.Button EditDXFExport;
    }
}

