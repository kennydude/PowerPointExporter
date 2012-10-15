namespace PowerPointExporter
{
    partial class ExportAsHandoutsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbExportNotes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbThreeP = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sorry, a few more details are required";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 117);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbExportNotes
            // 
            this.cbExportNotes.AutoSize = true;
            this.cbExportNotes.Location = new System.Drawing.Point(15, 34);
            this.cbExportNotes.Name = "cbExportNotes";
            this.cbExportNotes.Size = new System.Drawing.Size(235, 17);
            this.cbExportNotes.TabIndex = 5;
            this.cbExportNotes.Text = "Export with your notes on the right hand side";
            this.cbExportNotes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // rbThreeP
            // 
            this.rbThreeP.AutoSize = true;
            this.rbThreeP.Checked = true;
            this.rbThreeP.Location = new System.Drawing.Point(12, 76);
            this.rbThreeP.Name = "rbThreeP";
            this.rbThreeP.Size = new System.Drawing.Size(144, 17);
            this.rbThreeP.TabIndex = 7;
            this.rbThreeP.TabStop = true;
            this.rbThreeP.Text = "3 slides per page. Portrait";
            this.rbThreeP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Choose Export Template";
            // 
            // ExportAsHandoutsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 152);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbThreeP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbExportNotes);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportAsHandoutsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export As Handouts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox cbExportNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbThreeP;
        private System.Windows.Forms.Label label3;
    }
}