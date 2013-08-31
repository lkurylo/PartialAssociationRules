namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class DefaultParametersGroup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAlphaDefault = new System.Windows.Forms.NumericUpDown();
            this.nudGammaDefault = new System.Windows.Forms.NumericUpDown();
            this.nudSupportDefault = new System.Windows.Forms.NumericUpDown();
            this.nudConfidenceDefault = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGammaDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSupportDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidenceDefault)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 159);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(327, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametry";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudAlphaDefault, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudGammaDefault, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudSupportDefault, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudConfidenceDefault, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(321, 136);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alfa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gamma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Wsparcie[%]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "Zaufanie[%]";
            // 
            // nudAlphaDefault
            // 
            this.nudAlphaDefault.DecimalPlaces = 2;
            this.nudAlphaDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAlphaDefault.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlphaDefault.Location = new System.Drawing.Point(163, 2);
            this.nudAlphaDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudAlphaDefault.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.nudAlphaDefault.Name = "nudAlphaDefault";
            this.nudAlphaDefault.Size = new System.Drawing.Size(155, 22);
            this.nudAlphaDefault.TabIndex = 10;
            // 
            // nudGammaDefault
            // 
            this.nudGammaDefault.DecimalPlaces = 2;
            this.nudGammaDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudGammaDefault.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudGammaDefault.Location = new System.Drawing.Point(163, 36);
            this.nudGammaDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudGammaDefault.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGammaDefault.Name = "nudGammaDefault";
            this.nudGammaDefault.Size = new System.Drawing.Size(155, 22);
            this.nudGammaDefault.TabIndex = 11;
            // 
            // nudSupportDefault
            // 
            this.nudSupportDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSupportDefault.Location = new System.Drawing.Point(163, 70);
            this.nudSupportDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSupportDefault.Name = "nudSupportDefault";
            this.nudSupportDefault.Size = new System.Drawing.Size(155, 22);
            this.nudSupportDefault.TabIndex = 12;
            // 
            // nudConfidenceDefault
            // 
            this.nudConfidenceDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudConfidenceDefault.Location = new System.Drawing.Point(163, 104);
            this.nudConfidenceDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudConfidenceDefault.Name = "nudConfidenceDefault";
            this.nudConfidenceDefault.Size = new System.Drawing.Size(155, 22);
            this.nudConfidenceDefault.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(333, 159);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // DefaultParametersGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DefaultParametersGroup";
            this.Size = new System.Drawing.Size(333, 159);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGammaDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSupportDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidenceDefault)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAlphaDefault;
        private System.Windows.Forms.NumericUpDown nudGammaDefault;
        private System.Windows.Forms.NumericUpDown nudSupportDefault;
        private System.Windows.Forms.NumericUpDown nudConfidenceDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
