using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Generic.EventHandlers
{
    class RestoreBackupEventHandler : EventHandler
    {
        protected MaterialTextBox txtBackup;
        protected MaterialComboBox cbxBackups;
        public RestoreBackupEventHandler(Form form)
        {
            _form = form;

            txtBackup = (MaterialTextBox)FormHelpers.FindControl(_form, "txtBackup");
            cbxBackups = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxBackups");
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            try
            {
                DataBaseFacade.BackupDatabase();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void HandleOnRestore(object sender, EventArgs e)
        {
            try
            {
                DataBaseFacade.RestoreBackup(cbxBackups.SelectedValue.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            FormHelpers.TranslateControls(_form);

            txtBackup.Text = ConfigurationManager.AppSettings["BackUpPath"];

            txtBackup.Refresh();

            List<BackupFile> backups = DataBaseFacade.GetAllBackups();

            cbxBackups.DataSource = backups;
            cbxBackups.DisplayMember = "FileName"; // Lo que se muestra al usuario
            cbxBackups.ValueMember = "FileName";
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
