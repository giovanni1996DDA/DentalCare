using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    public class VisualizePacientesEventHandler : PacientesEventHandler
    {
        public VisualizePacientesEventHandler(Form form) : base(form)
        {
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            LoadComboboxes();
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    OnEnterPressed();
                    break;
            }
        }
        private void OnEnterPressed()
        {
            VisualizePaciente();
        }

        public override void HandleVisualize(object sender, EventArgs e)
        {
            VisualizePaciente();
        }

        private void VisualizePaciente()
        {
            try
            {
                ValidateNroDoc();
                LoadPacienteData();
                FormHelpers.RefreshControls(_form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error en la búsqueda del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormHelpers.ClearControls(_form);
            }
        }

        protected override void ValidateFields()
        {
            //Este método no va a ser llamado nunca desde esta clase.
            throw new NotImplementedException();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
