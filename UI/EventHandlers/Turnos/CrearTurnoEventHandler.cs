using Dao;
using Logic;
using Logic.Exceptions;
using Logic.StateMachines.TurnoStateMachine;
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
using UI.Helpers;
using UI.NonProfessional.TurnosForms;
using EventHandler = UI.Generic.EventHandler;
using Services.Facade.Extensions;

namespace UI.EventHandlers.Turnos
{
    internal class CrearTurnoEventHandler : TurnosEventHandler
    {
        private Paciente selectedPaciente { get; set; }
        public CrearTurnoEventHandler(Form form) : base(form)
        {
        }

        public void HandleOnEspecialidadValueChange(object sender, EventArgs e)
        {
            if (cbxEspecialidad.SelectedValue is Guid selectedValue && selectedValue != Guid.Empty)
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
            FormHelpers.TranslateControls(_form);
            LoadComboboxes();
            dtpFechaHoraTurno.Value = DateTime.Now;
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            if (DateIsInPast(dtpFechaHoraTurno.Value))
            {
                MessageBox.Show("La fecha del turno se encuentra en el pasado.".Translate(),
                                "Error agendando el turno".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (selectedProfessional.Id.Value == null)
            {
                MessageBox.Show("El profesional es obligatorio".Translate(),
                                "Error agendando el turno".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (selectedPaciente.Id == null)
            {
                MessageBox.Show("El paciente es obligatorio".Translate(),
                                "Error agendando el turno".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            Turno protoTurno = new Turno
            {
                Paciente = selectedPaciente.Id,
                Profesional = selectedProfessional.Id.Value,
                FechaHora = dtpFechaHoraTurno.Value,
                Especialidad = (Guid)cbxEspecialidad.SelectedValue
            };

            try
            {

                TurnoService.Instance.Agendar(protoTurno);

                MessageBox.Show("El turno se creó con éxito.".Translate(), 
                                "Operación exitosa".Translate(), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar Logs.".Translate(),
                                "Ocurrió un error inesperado.".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
            catch (PacienteDoesNotExistsException ex)
            {
                MessageBox.Show(ex.Message, "Paciente inexistente".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
