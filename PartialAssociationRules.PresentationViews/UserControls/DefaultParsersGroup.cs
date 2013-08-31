/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Windows.Forms;

namespace PartialAssociationRules.PresentationViews.UserControls
{
    public partial class DefaultParsersGroup : UserControl
    {
        public DefaultParsersGroup()
        {
            InitializeComponent();
        }

        public CheckBox TrimDataSet
        {
            get
            {
                return ckbTrimDataSet;
            }
        }

        public TextBox DefaultFilesCatalog
        {
            get
            {
                return txtLoadFileStartupCatalog;
            }
        }

        public TextBox AddRegexForNamesFilesTextBox
        {
            get
            {
                return txtAddRegex;
            }
        }

        public Button AddRegexForNamesFilesButton
        {
            get
            {
                return btnAddRegex;
            }
        }

        public ContextMenuStrip Menu
        {
            get
            {
                return contextMenuStrip1;
            }
        }

        public ListBox RegexsList
        {
            get
            {
                return lbRegexList;
            }
        }

        public ToolStripMenuItem DeleteSelected
        {
            get
            {
                return tsmiDeleteSelected;
            }
        }

        //public ToolStripMenuItem MoveUp
        //{
        //    get
        //    {
        //        return tsmiMoveUp;
        //    }
        //}

        //public ToolStripMenuItem MoveDown
        //{
        //    get
        //    {
        //        return tsmiMoveDown;
        //    }
        //}

        public ToolStripMenuItem Copy
        {
            get
            {
                return tsmiCopyToClipboard;
            }
        }

        public ToolStripMenuItem SetDefault
        {
            get
            {
                return tsmiSetDefault;
            }
        }
    }
}
