namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class DataSourceGroup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnGenerateSet = new System.Windows.Forms.Button();
            this.btnPreviewData = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(198, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zbiór danych";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerateSet, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPreviewData, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 132);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.AllowDrop = true;
            this.btnLoadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoadFile.ForeColor = System.Drawing.Color.Black;
            this.btnLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadFile.Location = new System.Drawing.Point(3, 2);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(186, 40);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Wczytaj";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSet
            // 
            this.btnGenerateSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGenerateSet.Location = new System.Drawing.Point(3, 46);
            this.btnGenerateSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateSet.Name = "btnGenerateSet";
            this.btnGenerateSet.Size = new System.Drawing.Size(186, 40);
            this.btnGenerateSet.TabIndex = 1;
            this.btnGenerateSet.Text = "Wygeneruj";
            this.btnGenerateSet.UseVisualStyleBackColor = true;
            // 
            // btnPreviewData
            // 
            this.btnPreviewData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreviewData.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPreviewData.Location = new System.Drawing.Point(3, 90);
            this.btnPreviewData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreviewData.Name = "btnPreviewData";
            this.btnPreviewData.Size = new System.Drawing.Size(186, 40);
            this.btnPreviewData.TabIndex = 2;
            this.btnPreviewData.Text = "Podejrzyj";
            this.btnPreviewData.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "arff";
            this.openFileDialog1.Filter = "ARFF files|*.arff|CSV files|*.csv|TXT files|*.txt|ZIP archives|*.zip";
            this.openFileDialog1.InitialDirectory = ".";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(204, 155);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // DataSourceGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DataSourceGroup";
            this.Size = new System.Drawing.Size(204, 155);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGenerateSet;
        private System.Windows.Forms.Button btnPreviewData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
