using Dao;
using Logic;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.NonProfessional.TurnosForms;
using EventHandler = UI.Generic.EventHandler;

namespace UI.NonProfessional.EventHandlers.Turnos
{
    internal class CrearTurnoEventHandler : TurnosEventHandler
    {
        private User selectedProfessional { get; set; }
        private Paciente selectedPaciente { get; set; }
        public CrearTurnoEventHandler(Form form) : base(form)
        {
        }

        public void HandleOnEspecialidadValueChange(object sender, EventArgs e)
        {
            if(cbxEspecialidad.SelectedValue is Guid selectedValue && selectedValue != Guid.Empty)
            {
                txtApellidoProf.Enabled = true;
                btnSearchProf.Enabled = true;
            }
            else
            {
                txtApellidoProf.Enabled = false;
                btnSearchProf.Enabled = false;
                txtApellidoProf.Text = string.Empty;
                txtNombreProf.Text = string.Empty;
            }
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            LoadComboboxes();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            Turno protoTurno = new Turno
            {
                Paciente = selectedPaciente.Id,
                Profesional = selectedProfessional.Id.Value,
                Estado = (int)EstadosTurnosEnum.Abierto,
                FechaHora = dtpFechaHoraTurno.Value
            };

            try
            {
                TurnoService.Instance.Create(protoTurno);

                MessageBox.Show("El turno se creó con éxito.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException)
            {

            }
            catch (Exception)
            {

                throw;
            }
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
                    protoUser.Apellido = txtApellidoProf.Text;
                });

                FindProfesionalPopUp findProfessionalPopup = new FindProfesionalPopUp(protoUsers);
                findProfessionalPopup.ShowDialog();

                if(findProfessionalPopup.DialogResult == DialogResult.OK)
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

        public void handleSearchPac(object sender, EventArgs e)
        {
            Paciente protoPaciente = new Paciente
            {
                TipoDocumento = (Guid)cbxTipoDocumento.SelectedValue,
                NumeroDocumento = txtNroDoc.Text
            };

            try
            {
                selectedPaciente = PacienteService.Instance.GetOneByDocument(protoPaciente);

                txtNombrePac.Text = selectedPaciente.Nombre;
                txtApellidoPac.Text = selectedPaciente.Apellido;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
