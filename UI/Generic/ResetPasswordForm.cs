using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic.EventHandlers;

namespace UI.Generic
{
    public partial class ResetPasswordForm : Form
    {
        private ResetPasswordEventHandler _eventHandler;
        public ResetPasswordForm()
        {
            InitializeComponent();

            _eventHandler = new ResetPasswordEventHandler(this);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            btnReset.Click += _eventHandler.HandleOnSaveChanges;
            chkShowPassword.CheckedChanged += _eventHandler.HandleOnShowPassword;
        }
    }
}
