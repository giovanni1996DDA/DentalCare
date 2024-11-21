using Dao;
using Logic;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.EventHandlers.Pacientes
{
    public class ModifyPacientesEventHandler : PacientesEventHandler
    {
        public ModifyPacientesEventHandler(Form form) : base(form)
        {
        }
        public override void HandleOnLoad(object sender, EventArgs e)
        {
            FormHelpers.TranslateControls(_form);
            LoadComboboxes();
        }
        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
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
            try
            {
                ValidateNroDoc();

                LoadPacienteData();

                EnableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error en la modificación del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            if (modifyingPaciente == null)
            {
                MessageBox.Show("Debe seleccionar el paciente que desea modificar.",
                                "Error en la modificación del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ValidateFields();

                MaterialTextBox txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
                MaterialTextBox txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
                MaterialTextBox txtDireccion = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDireccion");
                ComboBox cbxObraSocial = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");
                MaterialTextBox txtFechaNac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");
                MaterialTextBox txtTelefono = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");
                MaterialTextBox txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

                modifyingPaciente.Nombre = txtNombre.Text;
                modifyingPaciente.Apellido = txtApellido.Text;
                modifyingPaciente.Direccion = txtDireccion.Text;
                modifyingPaciente.ObraSocial = cbxObraSocial.SelectedValue as Guid?;
                modifyingPaciente.FechaNacimiento = FormHelpers.ParseFecha(txtFechaNac.Text);
                modifyingPaciente.Telefono = int.Parse(txtTelefono.Text);
                modifyingPaciente.Email = txtEmail.Text;


                PacienteService.Instance.UpdatePaciente(modifyingPaciente);

                MessageBox.Show($"El paciente {modifyingPaciente.Nombre} {modifyingPaciente.Apellido} se actrualizó correctamente.",
                "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormHelpers.ClearControls(_form);
                DisableControls();
                modifyingPaciente = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error en la modificación del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected override void ValidateFields()
        {
            ValidateNombre();
            ValidateApellido();
            ValidateFechaNacimiento();
            ValidateTelefono();
            ValidateEmail();
        }

        private void EnableControls()
        {
            MaterialTextBox txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
            MaterialTextBox txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
            MaterialTextBox txtDireccion = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDireccion");
            ComboBox cbxObraSocial = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");
            MaterialTextBox txtFechaNac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");
            MaterialTextBox txtTelefono = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");
            MaterialTextBox txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            cbxObraSocial.Enabled = true;
            txtFechaNac.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void DisableControls()
        {
            MaterialTextBox txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
            MaterialTextBox txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
            MaterialTextBox txtDireccion = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDireccion");
            ComboBox cbxObraSocial = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");
            MaterialTextBox txtFechaNac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");
            MaterialTextBox txtTelefono = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");
            MaterialTextBox txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            cbxObraSocial.Enabled = false;
            txtFechaNac.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
        }

        public override void HandleOnCreate(object sender, EventArgs e)
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

        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
