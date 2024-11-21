using Services.Dao.Factory;
using Services.Dao.Implementations.SQLServer;
using Services.Dao.Interfaces;
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

namespace UI.Generic.FormsParametrizaciones.FormsRestoreBackup
{
    public partial class RestoreBackupForm : Form
    {
        private RestoreBackupEventHandler _eventHandler;
        public RestoreBackupForm()
        {
            InitializeComponent();

            _eventHandler = new RestoreBackupEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            btnBackup.Click += _eventHandler.HandleOnCreate;
            btnRestore.Click += _eventHandler.HandleOnRestore;
        }
    }
}
