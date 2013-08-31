namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class DefaultReportsGroup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ckIncludePercentageOfSeparatedRows = new System.Windows.Forms.CheckBox();
            this.ckSystemInReport = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDefaultReportType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 187);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raport";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ckIncludePercentageOfSeparatedRows, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.ckSystemInReport, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbDefaultReportType, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(231, 160);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ckIncludePercentageOfSeparatedRows
            // 
            this.ckIncludePercentageOfSeparatedRows.AutoSize = true;
            this.ckIncludePercentageOfSeparatedRows.Checked = true;
            this.ckIncludePercentageOfSeparatedRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIncludePercentageOfSeparatedRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckIncludePercentageOfSeparatedRows.Location = new System.Drawing.Point(3, 131);
            this.ckIncludePercentageOfSeparatedRows.Name = "ckIncludePercentageOfSeparatedRows";
            this.ckIncludePercentageOfSeparatedRows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckIncludePercentageOfSeparatedRows.Size = new System.Drawing.Size(225, 26);
            this.ckIncludePercentageOfSeparatedRows.TabIndex = 5;
            this.ckIncludePercentageOfSeparatedRows.Text = "Dołączyć % odseparowanych wierszy";
            this.ckIncludePercentageOfSeparatedRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckIncludePercentageOfSeparatedRows.UseVisualStyleBackColor = true;
            // 
            // ckSystemInReport
            // 
            this.ckSystemInReport.AutoSize = true;
            this.ckSystemInReport.Checked = true;
            this.ckSystemInReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSystemInReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckSystemInReport.Location = new System.Drawing.Point(3, 99);
            this.ckSystemInReport.Name = "ckSystemInReport";
            this.ckSystemInReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckSystemInReport.Size = new System.Drawing.Size(225, 26);
            this.ckSystemInReport.TabIndex = 4;
            this.ckSystemInReport.Text = "System informacyjny w raporcie TXT";
            this.ckSystemInReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckSystemInReport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format raportu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDefaultReportType
            // 
            this.cbDefaultReportType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDefaultReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultReportType.FormattingEnabled = true;
            this.cbDefaultReportType.Location = new System.Drawing.Point(3, 35);
            this.cbDefaultReportType.Name = "cbDefaultReportType";
            this.cbDefaultReportType.Size = new System.Drawing.Size(225, 24);
            this.cbDefaultReportType.TabIndex = 1;
            // 
            // DefaultReportsGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DefaultReportsGroup";
            this.Size = new System.Drawing.Size(243, 187);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDefaultReportType;
        private System.Windows.Forms.CheckBox ckIncludePercentageOfSeparatedRows;
        private System.Windows.Forms.CheckBox ckSystemInReport;
    }
}
