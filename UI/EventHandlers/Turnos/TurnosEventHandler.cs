using Dao;
using Logic;
using MaterialSkin.Controls;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helpers;
using UI.NonProfessional.TurnosForms;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers.Turnos
{
    internal abstract class TurnosEventHandler : EventHandler
    {
        protected Form _form;

        protected MaterialComboBox cbxEspecialidad;
        protected MaterialComboBox cbxTipoDocumento;
        protected MaterialTextBox txtApellidoProf;
        protected MaterialTextBox txtNombreProf;
        protected MaterialTextBox txtNombrePac;
        protected MaterialTextBox txtApellidoPac;
        protected MaterialTextBox txtNroDoc;
        protected DateTimePicker dtpFechaHoraTurno;
        protected MaterialButton btnSearchProf;

        protected User selectedProfessional { get; set; }

        public TurnosEventHandler(Form form)
        {
            _form = form;

            cbxEspecialidad = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxEspecialidad");
            cbxTipoDocumento = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxTipoDocumento");
            txtApellidoProf = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellidoProf");
            txtNombreProf = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombreProf");
            txtNombrePac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombrePac");
            txtApellidoPac = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellidoPac");
            txtNroDoc = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNroDoc");
            dtpFechaHoraTurno = (DateTimePicker)FormHelpers.FindControl(_form, "dtpFechaHoraTurno");
            btnSearchProf = (MaterialButton)FormHelpers.FindControl(_form, "btnSearchProf");

        }

        protected void LoadComboboxes()
        {
            try
            {
                List<Especialidad> especialidades = new List<Especialidad>
                {
                    new Especialidad()
                    {
                        Id = Guid.Empty,
                        Nombre = "None",
                    },
                };

                especialidades.AddRange(EspecialidadService.Instance.Get());

                cbxEspecialidad.DataSource = especialidades;
                cbxEspecialidad.DisplayMember = "Nombre"; // Propiedad a mostrar en el ComboBox
                cbxEspecialidad.ValueMember = "Id";

                List<TipoDocumento> tiposDocumento = new List<TipoDocumento>
                {
                    new TipoDocumento
                    {
                        Id = Guid.Empty,
                        Descripcion = "None",
                    }
                };

                tiposDocumento.AddRange(TipoDocumentoService.Instance.Get());

                cbxTipoDocumento.DataSource = tiposDocumento;
                cbxTipoDocumento.DisplayMember = "Descripcion"; // Propiedad a mostrar en el ComboBox
                cbxTipoDocumento.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void handleSearchProf(object sender, EventArgs e)
        {

            Especialidad protoEspecialidad = new Especialidad { Id = (Guid)cbxEspecialidad.SelectedValue };

            List<User> profesionales = new List<User>();

            List<User> protoUsers = new List<User>();

            try
            {
                protoUsers.AddRange(EspecialidadService.Instance.GetUsersByEspecialidad(protoEspecialidad));

                protoUsers.ForEach(protoUser =>
                {
                    protoUser.Apellido = string.IsNullOrEmpty(txtApellidoProf.Text) ? null : txtApellidoProf.Text;
                });

                FindProfesionalPopUp findProfessionalPopup = new FindProfesionalPopUp(protoUsers);
                findProfessionalPopup.ShowDialog();

                if (findProfessionalPopup.DialogResult == DialogResult.OK)
                {
                    selectedProfessional = findProfessionalPopup.SelectedProfessional;
                    txtApellidoProf.Text = selectedProfessional.Apellido;
                    txtNombreProf.Text = selectedProfessional.Nombre;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DateIsInPast(DateTime fechaAComparar)
        {
            return fechaAComparar < DateTime.Now;
        }
    }
}
