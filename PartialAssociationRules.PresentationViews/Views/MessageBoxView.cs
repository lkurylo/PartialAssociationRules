/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System.Drawing;
using System.Windows.Forms;
using System;

namespace PartialAssociationRules.PresentationViews.Views
{
    /// <summary>
    /// This is a custom MessageBox view because in the default 
    /// there isn't a possibility to change the background color.
    /// </summary>
    public partial class MessageBoxView : Form
    {
        private static MessageBoxView MessageBox { set; get; }

        private Button Ok
        {
            get
            {
                return btnOk;
            }
        }

        private Button Cancel
        {
            get
            {
                return btnCancel;
            }
        }

        private string Message
        {
            set
            {
                lblMessage.Text = value;
            }
            get
            {
                return lblMessage.Text;
            }
        }

        private PictureBox Picture
        {
            get
            {
                return pbPicture;
            }
        }

        private MessageBoxView()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons,
            MessageBoxIcon icon)
        {
            //if (MessageBox == null)
            //{
            MessageBox = new MessageBoxView();
            //}

            MessageBox.Message = text;
            MessageBox.Text = caption;
            MessageBox.Picture.Image = MessageBox.MatchIcon(icon);
            MessageBox.SetButtons(buttons);

            MessageBox.Ok.DialogResult = DialogResult.OK;
            MessageBox.Cancel.DialogResult = DialogResult.Cancel;

            return MessageBox.ShowDialog();
        }

        private Bitmap MatchIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    return Bitmap.FromHicon(SystemIcons.Error.Handle);
                case MessageBoxIcon.Information:
                    return Bitmap.FromHicon(SystemIcons.Information.Handle);
                case MessageBoxIcon.Question:
                    return Bitmap.FromHicon(SystemIcons.Question.Handle);
                case MessageBoxIcon.Exclamation:
                    return Bitmap.FromHicon(SystemIcons.Exclamation.Handle);
            }

            return null;
        }

        private void SetButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    btnCancel.Visible = false;
                    tableLayoutPanel4.Controls.Add(this.btnOk, 1, 0);
                    break;
                case MessageBoxButtons.OKCancel:
                    break;
            }
        }
    }
}
