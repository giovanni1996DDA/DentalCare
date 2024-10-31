using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Generic.EventHandlers
{
    public class TextBoxEventHandler
    {
        private readonly string _placeholderText = "********************";
        public void HandleOnEnter(object sender, EventArgs e)
        {
            MaterialTextBox txtbx = sender as MaterialTextBox;

            if (txtbx.Text == _placeholderText)
            {
                txtbx.Text = string.Empty;
            }
        }
        public void HandleOnLeave(object sender, EventArgs e)
        {
            MaterialTextBox textBox = sender as MaterialTextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = _placeholderText;
            }
        }
    }
}
