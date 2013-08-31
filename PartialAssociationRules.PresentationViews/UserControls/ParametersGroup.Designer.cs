namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class ParametersGroup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudGamma = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudConfidence = new System.Windows.Forms.NumericUpDown();
            this.nudSupport = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSupport)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(199, 202);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametry";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 183);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nudAlpha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudGamma, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudConfidence, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudSupport, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 183);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nudAlpha
            // 
            this.nudAlpha.DecimalPlaces = 2;
            this.nudAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlpha.Location = new System.Drawing.Point(99, 2);
            this.nudAlpha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudAlpha.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(91, 22);
            this.nudAlpha.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alfa";
            // 
            // nudGamma
            // 
            this.nudGamma.DecimalPlaces = 2;
            this.nudGamma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudGamma.Location = new System.Drawing.Point(99, 47);
            this.nudGamma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudGamma.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGamma.Name = "nudGamma";
            this.nudGamma.Size = new System.Drawing.Size(91, 22);
            this.nudGamma.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 45);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gamma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 48);
            this.label3.TabIndex = 9;
            this.label3.Text = "Zaufanie[%]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wsparcie[%]";
            // 
            // nudConfidence
            // 
            this.nudConfidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudConfidence.Location = new System.Drawing.Point(99, 137);
            this.nudConfidence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudConfidence.Name = "nudConfidence";
            this.nudConfidence.Size = new System.Drawing.Size(91, 22);
            this.nudConfidence.TabIndex = 6;
            // 
            // nudSupport
            // 
            this.nudSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSupport.Location = new System.Drawing.Point(99, 92);
            this.nudSupport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSupport.Name = "nudSupport";
            this.nudSupport.Size = new System.Drawing.Size(91, 22);
            this.nudSupport.TabIndex = 5;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(205, 206);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // ParametersGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ParametersGroup";
            this.Size = new System.Drawing.Size(205, 206);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSupport)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.NumericUpDown nudConfidence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudGamma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown nudSupport;

    }
}
