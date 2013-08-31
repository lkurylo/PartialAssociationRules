namespace PartialAssociationRules.PresentationViews.UserControls
{
    partial class MainFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.resultGrid1 = new PartialAssociationRules.PresentationViews.UserControls.ResultGrid();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataSourceGroup1 = new PartialAssociationRules.PresentationViews.UserControls.DataSourceGroup();
            this.parametersGroup1 = new PartialAssociationRules.PresentationViews.UserControls.ParametersGroup();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.algorithmsListGroup1 = new PartialAssociationRules.PresentationViews.UserControls.AlgorithmsListGroup();
            this.summaryGroup1 = new PartialAssociationRules.PresentationViews.UserControls.SummaryGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAlgorithmName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAlgorithmRunLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings,
            this.ShowInstruction,
            this.About,
            this.Close});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(994, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.ImageTransparentColor = System.Drawing.Color.White;
            this.Settings.Name = "Settings";
            this.Settings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.Settings.ShowShortcutKeys = false;
            this.Settings.Size = new System.Drawing.Size(109, 24);
            this.Settings.Text = "&Ustawienia";
            // 
            // ShowInstruction
            // 
            this.ShowInstruction.Image = ((System.Drawing.Image)(resources.GetObject("ShowInstruction.Image")));
            this.ShowInstruction.ImageTransparentColor = System.Drawing.Color.White;
            this.ShowInstruction.Name = "ShowInstruction";
            this.ShowInstruction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.ShowInstruction.Size = new System.Drawing.Size(99, 24);
            this.ShowInstruction.Text = "&Instrukcja";
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.SteelBlue;
            this.About.Image = ((System.Drawing.Image)(resources.GetObject("About.Image")));
            this.About.ImageTransparentColor = System.Drawing.Color.White;
            this.About.Name = "About";
            this.About.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.About.Size = new System.Drawing.Size(122, 24);
            this.About.Text = "&O programie";
            // 
            // Close
            // 
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.ImageTransparentColor = System.Drawing.Color.White;
            this.Close.Name = "Close";
            this.Close.ShortcutKeyDisplayString = "";
            this.Close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Close.Size = new System.Drawing.Size(90, 24);
            this.Close.Text = "&Zamknij";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 608);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(986, 575);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.79975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.20026F));
            this.tableLayoutPanel2.Controls.Add(this.resultGrid1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 291);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // resultGrid1
            // 
            this.resultGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid1.Location = new System.Drawing.Point(215, 2);
            this.resultGrid1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.resultGrid1.Name = "resultGrid1";
            this.resultGrid1.Size = new System.Drawing.Size(761, 289);
            this.resultGrid1.TabIndex = 11;
            this.resultGrid1.Load += new System.EventHandler(this.resultGrid1_Load);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dataSourceGroup1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.parametersGroup1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1, 1, 4, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(208, 289);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // dataSourceGroup1
            // 
            this.dataSourceGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceGroup1.Location = new System.Drawing.Point(2, 2);
            this.dataSourceGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.dataSourceGroup1.Name = "dataSourceGroup1";
            this.dataSourceGroup1.Size = new System.Drawing.Size(204, 124);
            this.dataSourceGroup1.TabIndex = 6;
            this.dataSourceGroup1.Load += new System.EventHandler(this.dataSourceGroup1_Load);
            // 
            // parametersGroup1
            // 
            this.parametersGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersGroup1.Location = new System.Drawing.Point(2, 130);
            this.parametersGroup1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.parametersGroup1.Name = "parametersGroup1";
            this.parametersGroup1.Size = new System.Drawing.Size(204, 159);
            this.parametersGroup1.TabIndex = 4;
            this.parametersGroup1.Load += new System.EventHandler(this.parametersGroup1_Load);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.80989F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.19011F));
            this.tableLayoutPanel4.Controls.Add(this.algorithmsListGroup1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.summaryGroup1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 303);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(978, 268);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // algorithmsListGroup1
            // 
            this.algorithmsListGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algorithmsListGroup1.Location = new System.Drawing.Point(2, 0);
            this.algorithmsListGroup1.Margin = new System.Windows.Forms.Padding(2, 0, 6, 2);
            this.algorithmsListGroup1.Name = "algorithmsListGroup1";
            this.algorithmsListGroup1.Size = new System.Drawing.Size(479, 266);
            this.algorithmsListGroup1.TabIndex = 9;
            this.algorithmsListGroup1.Load += new System.EventHandler(this.algorithmsListGroup1_Load);
            // 
            // summaryGroup1
            // 
            this.summaryGroup1.AutoScroll = true;
            this.summaryGroup1.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.summaryGroup1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.summaryGroup1.DataSetName = "";
            this.summaryGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summaryGroup1.Location = new System.Drawing.Point(492, 0);
            this.summaryGroup1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 4);
            this.summaryGroup1.Name = "summaryGroup1";
            this.summaryGroup1.Size = new System.Drawing.Size(481, 264);
            this.summaryGroup1.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslAlgorithmName,
            this.toolStripStatusLabel2,
            this.tsslAlgorithmRunLength});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(994, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(74, 20);
            this.toolStripStatusLabel1.Text = "Algorytm:";
            // 
            // tsslAlgorithmName
            // 
            this.tsslAlgorithmName.Name = "tsslAlgorithmName";
            this.tsslAlgorithmName.Size = new System.Drawing.Size(15, 20);
            this.tsslAlgorithmName.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(119, 20);
            this.toolStripStatusLabel2.Text = "Długość trwania:";
            // 
            // tsslAlgorithmRunLength
            // 
            this.tsslAlgorithmRunLength.BackColor = System.Drawing.Color.SkyBlue;
            this.tsslAlgorithmRunLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsslAlgorithmRunLength.Name = "tsslAlgorithmRunLength";
            this.tsslAlgorithmRunLength.Size = new System.Drawing.Size(15, 20);
            this.tsslAlgorithmRunLength.Text = "-";
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Częściowe reguły asocjacyjne";
            this.Load += new System.EventHandler(this.MainFormView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem About;
        private new System.Windows.Forms.ToolStripMenuItem Close;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem ShowInstruction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ResultGrid resultGrid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DataSourceGroup dataSourceGroup1;
        private ParametersGroup parametersGroup1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private AlgorithmsListGroup algorithmsListGroup1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslAlgorithmName;
        private System.Windows.Forms.ToolStripStatusLabel tsslAlgorithmRunLength;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private SummaryGroup summaryGroup1;

    }
}

