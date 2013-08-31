namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class PreviewDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewDataView));
            this.previewGroup1 = new PartialAssociationRules.PresentationViews.UserControls.PreviewGroup();
            this.SuspendLayout();
            // 
            // previewGroup1
            // 
            this.previewGroup1.BackColor = System.Drawing.Color.SteelBlue;
            this.previewGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGroup1.Location = new System.Drawing.Point(0, 0);
            this.previewGroup1.Name = "previewGroup1";
            this.previewGroup1.Size = new System.Drawing.Size(688, 395);
            this.previewGroup1.TabIndex = 0;
            this.previewGroup1.Load += new System.EventHandler(this.previewGroup1_Load);
            // 
            // PreviewDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(688, 395);
            this.Controls.Add(this.previewGroup1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PreviewDataView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Podgląd zbioru danych";
            this.ResumeLayout(false);

        }

        #endregion

        private PreviewGroup previewGroup1;


    }
}