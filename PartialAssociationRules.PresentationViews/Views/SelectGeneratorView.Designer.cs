namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class SelectGeneratorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectGeneratorView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectGeneratorPanel1 = new PartialAssociationRules.PresentationViews.UserControls.SelectGeneratorPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.selectGeneratorPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 147);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // selectGeneratorPanel1
            // 
            this.selectGeneratorPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.selectGeneratorPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectGeneratorPanel1.Location = new System.Drawing.Point(2, 2);
            this.selectGeneratorPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.selectGeneratorPanel1.Name = "selectGeneratorPanel1";
            this.selectGeneratorPanel1.Size = new System.Drawing.Size(414, 143);
            this.selectGeneratorPanel1.TabIndex = 0;
            // 
            // SelectGeneratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(418, 147);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SelectGeneratorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybierz generator";
            this.Load += new System.EventHandler(this.SelectGeneratorView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.SelectGeneratorPanel selectGeneratorPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}