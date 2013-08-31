namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class ResultGrid
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.associationRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperBound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowerBound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theSamesRules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 297);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(475, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wynik";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvResult, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(467, 266);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.AutoGenerateColumns = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.associationRule,
            this.support,
            this.confidence,
            this.length,
            this.upperBound,
            this.lowerBound,
            this.theSamesRules});
            this.dgvResult.DataSource = this.bindingSource1;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 2);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(461, 262);
            this.dgvResult.TabIndex = 2;
            // 
            // associationRule
            // 
            this.associationRule.HeaderText = "Reguła";
            this.associationRule.Name = "associationRule";
            this.associationRule.ReadOnly = true;
            this.associationRule.Width = 309;
            // 
            // support
            // 
            this.support.HeaderText = "Wsparcie[%]";
            this.support.Name = "support";
            this.support.ReadOnly = true;
            this.support.Width = 78;
            // 
            // confidence
            // 
            this.confidence.HeaderText = "Zaufanie[%]";
            this.confidence.Name = "confidence";
            this.confidence.ReadOnly = true;
            this.confidence.Width = 78;
            // 
            // length
            // 
            this.length.HeaderText = "Długość";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            this.length.Width = 59;
            // 
            // upperBound
            // 
            this.upperBound.HeaderText = "Górna granica";
            this.upperBound.Name = "upperBound";
            this.upperBound.ReadOnly = true;
            // 
            // lowerBound
            // 
            this.lowerBound.HeaderText = "Dolna granica";
            this.lowerBound.Name = "lowerBound";
            this.lowerBound.ReadOnly = true;
            // 
            // theSamesRules
            // 
            this.theSamesRules.HeaderText = "Liczba";
            this.theSamesRules.Name = "theSamesRules";
            this.theSamesRules.ReadOnly = true;
            this.theSamesRules.Width = 52;
            // 
            // ResultGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResultGrid";
            this.Size = new System.Drawing.Size(483, 297);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn associationRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn support;
        private System.Windows.Forms.DataGridViewTextBoxColumn confidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn upperBound;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowerBound;
        private System.Windows.Forms.DataGridViewTextBoxColumn theSamesRules;
    }
}
