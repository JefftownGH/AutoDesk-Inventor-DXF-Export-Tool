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
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.InspectComponent = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.Setup = new System.Windows.Forms.GroupBox();
            this.EditDXFExport = new System.Windows.Forms.Button();
            this.AddMaterial = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComponentErrors = new System.Windows.Forms.ListBox();
            this.ActionsGroupBox.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.Setup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionsGroupBox
            // 
            this.ActionsGroupBox.Controls.Add(this.button6);
            this.ActionsGroupBox.Controls.Add(this.button1);
            this.ActionsGroupBox.Controls.Add(this.InspectComponent);
            this.ActionsGroupBox.Controls.Add(this.Import);
            this.ActionsGroupBox.Location = new System.Drawing.Point(20, 15);
            this.ActionsGroupBox.Name = "ActionsGroupBox";
            this.ActionsGroupBox.Size = new System.Drawing.Size(439, 60);
            this.ActionsGroupBox.TabIndex = 14;
            this.ActionsGroupBox.TabStop = false;
            this.ActionsGroupBox.Text = "Actions";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(324, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 30);
            this.button6.TabIndex = 15;
            this.button6.Text = "Export DXF";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Design Analysis";
            this.button1.UseVisualStyleBackColor = true;
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
            this.BottomPanel.Controls.Add(this.Setup);
            this.BottomPanel.Controls.Add(this.ProgressBar);
            this.BottomPanel.Controls.Add(this.ActionsGroupBox);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 449);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(984, 112);
            this.BottomPanel.TabIndex = 14;
            // 
            // Setup
            // 
            this.Setup.Controls.Add(this.EditDXFExport);
            this.Setup.Controls.Add(this.AddMaterial);
            this.Setup.Controls.Add(this.button3);
            this.Setup.Controls.Add(this.button4);
            this.Setup.Location = new System.Drawing.Point(474, 15);
            this.Setup.Name = "Setup";
            this.Setup.Size = new System.Drawing.Size(438, 60);
            this.Setup.TabIndex = 16;
            this.Setup.TabStop = false;
            this.Setup.Text = "Setup";
            // 
            // EditDXFExport
            // 
            this.EditDXFExport.Location = new System.Drawing.Point(324, 19);
            this.EditDXFExport.Name = "EditDXFExport";
            this.EditDXFExport.Size = new System.Drawing.Size(100, 30);
            this.EditDXFExport.TabIndex = 15;
            this.EditDXFExport.Text = "Edit DXF Export";
            this.EditDXFExport.UseVisualStyleBackColor = true;
            this.EditDXFExport.Click += new System.EventHandler(this.EditDXFExport_Click);
            // 
            // AddMaterial
            // 
            this.AddMaterial.Location = new System.Drawing.Point(112, 19);
            this.AddMaterial.Name = "AddMaterial";
            this.AddMaterial.Size = new System.Drawing.Size(100, 30);
            this.AddMaterial.TabIndex = 14;
            this.AddMaterial.Text = "Add Material";
            this.AddMaterial.UseVisualStyleBackColor = true;
            this.AddMaterial.Click += new System.EventHandler(this.AddMaterial_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(218, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "Edit Costing";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "Settings";
            this.button4.UseVisualStyleBackColor = true;
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
            this.panel1.Location = new System.Drawing.Point(685, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 449);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComponentErrors);
            this.groupBox1.Location = new System.Drawing.Point(37, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 271);
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
            this.ComponentErrors.Size = new System.Drawing.Size(219, 238);
            this.ComponentErrors.TabIndex = 14;
            // 
            // DesignValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BottomPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "DesignValidationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Design Validation";
            this.ActionsGroupBox.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.Setup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox ActionsGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button InspectComponent;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.GroupBox Setup;
        private System.Windows.Forms.Button AddMaterial;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button EditDXFExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ComponentErrors;
        private System.Windows.Forms.Button button6;
    }
}

