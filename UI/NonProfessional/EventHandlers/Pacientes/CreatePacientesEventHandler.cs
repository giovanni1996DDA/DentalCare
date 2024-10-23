using Dao;
using Logic;
using Logic.Exceptions;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using UI.Exceptions;
using UI.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    public class CreatePacientesEventHandler : PacientesEventHandler
    {
        public CreatePacientesEventHandler(Form form) : base(form) 
        {
        }

        public override void HandleExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            try
            {
                ValidateFields();

                MaterialTextBox txtNombre    = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
                MaterialTextBox txtApellido  = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
                MaterialTextBox txtDireccion = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDireccion");
                ComboBox cbxTipoDocumento    = (ComboBox)FormHelpers.FindControl(_form, "cbxTipoDoc");
                ComboBox cbxObraSocial       = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");
                MaterialTextBox txtNroDoc    = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNroDoc");
                MaterialTextBox txtFechaNac  = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");
                MaterialTextBox txtTelefono  = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");
                MaterialTextBox txtEmail     = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

                Paciente paciente = new Paciente()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    TipoDocumento = (Guid)cbxTipoDocumento.SelectedValue,
                    NumeroDocumento = txtNroDoc.Text,
                    FechaNacimiento = FormHelpers.ParseFecha(txtFechaNac.Text),
                    Telefono = int.Parse(txtTelefono.Text),
                    ObraSocial = cbxObraSocial.SelectedValue as Guid?,
                    Email = txtEmail.Text
                };

                PacienteService.Instance.CreatePaciente(paciente);

                MessageBox.Show($"El paciente {paciente.Nombre} {paciente.Apellido} se creó correctamente.",
                                "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormHelpers.ClearControls(_form);
            }
            catch(PacienteAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message,
                                "Error creando el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MaterialTextBox txtNroDoc = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNroDoc");

                txtNroDoc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error creando el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            LoadComboboxes();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
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

        public override void HandleVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateFields()
        {
            ValidateNombre();
            ValidateApellido();
            ValidateNroDoc();
            ValidateFechaNacimiento();
            ValidateTelefono();
            ValidateEmail();
        }

    }
}
