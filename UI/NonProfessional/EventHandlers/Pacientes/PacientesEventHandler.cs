using Dao;
using Logic;
using Logic.Exceptions;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Exceptions;
using UI.Helpers;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    public abstract class PacientesEventHandler : EventHandler
    {
        protected Paciente? modifyingPaciente = null;
        protected PacientesEventHandler(Form form)
        {
            _form = form;
        }
        protected void LoadComboboxes()
        {
            ComboBox cbxTipoDoc = (ComboBox)FormHelpers.FindControl(_form, "cbxTipoDoc");

            try
            {
                List<TipoDocumento> tiposDocumento = TipoDocumentoService.Instance.GetAll();

                cbxTipoDoc.DataSource = tiposDocumento;
                cbxTipoDoc.DisplayMember = "Descripcion";
                cbxTipoDoc.ValueMember = "Id";
            }
            catch (NoTipoDocumentoFoundException)
            {
                MessageBox.Show("No se encontraron tipos de documento cargados. Parametrízelos.", "Faltan parametrizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            ComboBox cbxObraSocial = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");

            try
            {
                List<ObraSocial> obraSocial = new List<ObraSocial>()
                {
                    new ObraSocial()
                    {
                        Id = Guid.Empty,
                        Nombre = "Ninguna",
                        Descripcion = "Ninguna obra social"
                    }
                };

                obraSocial.AddRange(ObraSocialService.Instance.GetAll());

                cbxObraSocial.DataSource = obraSocial;
                cbxObraSocial.DisplayMember = "Nombre";
                cbxObraSocial.ValueMember = "Id";
            }
            catch (NoObraSocialFoundException)
            {
                MessageBox.Show("No se encontraron obras sociales cargadas. Parametrízelas.", "Faltan parametrizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected void LoadPacienteData()
        {

            MaterialTextBox txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
            MaterialTextBox txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
            MaterialTextBox txtDireccion = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDireccion");
            ComboBox cbxTipoDocumento = (ComboBox)FormHelpers.FindControl(_form, "cbxTipoDoc");
            ComboBox cbxObraSocial = (ComboBox)FormHelpers.FindControl(_form, "cbxObraSocial");
            MaterialTextBox txtNroDoc = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNroDoc");
            MaterialTextBox txtFechaNac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");
            MaterialTextBox txtTelefono = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");
            MaterialTextBox txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

            Paciente protoPaciente = new Paciente()
            {
                TipoDocumento = (Guid)cbxTipoDocumento.SelectedValue,
                NumeroDocumento = txtNroDoc.Text
            };

            modifyingPaciente = PacienteService.Instance.GetOne(protoPaciente);

            txtNombre.Text = modifyingPaciente.Nombre;
            txtApellido.Text = modifyingPaciente.Apellido;
            txtDireccion.Text = modifyingPaciente.Direccion;
            cbxTipoDocumento.SelectedValue = modifyingPaciente.TipoDocumento;
            cbxObraSocial.SelectedValue = modifyingPaciente.ObraSocial ?? Guid.Empty;
            txtNroDoc.Text = modifyingPaciente.NumeroDocumento;
            txtFechaNac.Text = modifyingPaciente.FechaNacimiento.ToString("dd/MM/yyyy");
            txtTelefono.Text = $"{modifyingPaciente.Telefono}";
            txtEmail.Text = modifyingPaciente.Email;

        }

        protected abstract void ValidateFields();

        protected void ValidateNroDoc()
        {
            MaterialTextBox txtNroDoc = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNroDoc");

            txtNroDoc.Focus();

            if (txtNroDoc.Text == "")
            {
                throw new EmptyFieldException("Nro Documento");
            }
        }

        protected void ValidateNombre()
        {
            MaterialTextBox txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");

            txtNombre.Focus();

            if (txtNombre.Text == "")
            {
                throw new EmptyFieldException("Nombre");
            }
        }
        protected void ValidateApellido()
        {
            MaterialTextBox txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");

            txtApellido.Focus();

            if (txtApellido.Text == "")
            {
                throw new EmptyFieldException("Apellido");
            }
        }
        protected void ValidateFechaNacimiento()
        {
            MaterialTextBox txtFechaNac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtFechaNac");

            txtFechaNac.Focus();

            if (txtFechaNac.Text == "")
            {
                throw new EmptyFieldException("Fecha de nacimiento");
            }

            if (!DateTime.TryParseExact(txtFechaNac.Text, new[] { "ddMMyyyy", "dd/MM/yyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime fechaNacimiento))
            {
                throw new InvalidDateFormatException();
            }
        }
        protected void ValidateTelefono()
        {
            MaterialTextBox txtTelefono = (MaterialTextBox)FormHelpers.FindControl(_form, "txtTelefono");

            txtTelefono.Focus();

            if (txtTelefono.Text == "")
            {
                throw new EmptyFieldException("Teléfono");
            }

            if (!int.TryParse(txtTelefono.Text, out int num))
            {
                throw new InvalidFieldValueException("Teléfono");
            }
        }
        protected void ValidateEmail()
        {
            MaterialTextBox txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");

            txtEmail.Focus();

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                throw new EmptyFieldException("Correo electrónico");
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                throw new InvalidFieldValueException("Correo electrónico");
            }
        }
    }
}
