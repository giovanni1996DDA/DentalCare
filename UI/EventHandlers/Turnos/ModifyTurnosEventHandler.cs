using Dao;
using Logic;
using Logic.Enums;
using Logic.Exceptions;
using Logic.StateMachines.TurnoStateMachine;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.Helpers;

namespace UI.EventHandlers.Turnos
{
    internal class ModifyTurnosEventHandler : TurnosEventHandler
    {
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private MaterialButton btnSave;
        private MaterialButton btnEliminar;
        private DataGridView dgvTurnos;

        private BindingList<Turno> dgvTurnosDataSource = new BindingList<Turno>();

        private Turno selectedTurno;

        public ModifyTurnosEventHandler(Form form) : base(form)
        {
            dtpFechaDesde = (DateTimePicker)FormHelpers.FindControl(_form, "dtpFechaDesde");
            dtpFechaHasta = (DateTimePicker)FormHelpers.FindControl(_form, "dtpFechaHasta");
            dgvTurnos = (DataGridView)FormHelpers.FindControl(_form, "dgvTurnos");
            btnSave = (MaterialButton)FormHelpers.FindControl(_form, "btnSave");
            btnEliminar = (MaterialButton)FormHelpers.FindControl(_form, "btnEliminar");
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public override void HandleOnDelete(object sender, EventArgs e)
        {
            Turno protoTurno = new Turno
            {
                Id = selectedTurno.Id,
                Paciente = selectedTurno.Paciente1.Id,
                Profesional = selectedProfessional.Id.Value,
                Estado = selectedTurno.Estado,
                FechaHora = dtpFechaHoraTurno.Value,
                Especialidad = (Guid)cbxEspecialidad.SelectedValue
            };

            try
            {
                TurnoStateMachine sm = new TurnoStateMachine(protoTurno);

                sm.Cerrar();

                TurnoService.Instance.Update(protoTurno, ignoreOverlapping: true);

                MessageBox.Show($"La operación se realizó correctamente.",
                                "Operación exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (TurnoIsOverlappingException ex)
            {
                MessageBox.Show($"{ex.Message}",
                                "No hay resultados.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (TurnoDoesNotExistException ex)
            {
                MessageBox.Show($"{ex.Message}",
                                "No hay resultados.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar Logs.",
                                "Ocurrió un error inesperado.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
            SetupScreen();

            SetupDgvTurnos();
        }

        private void SetupDgvTurnos()
        {
            //Configuración del DataGridView
            dgvTurnos.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvTurnos.ScrollBars = ScrollBars.Both;

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoPaciente",
                HeaderText = "Paciente",
                Name = "NombreCompletoPaciente"
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompletoProfesional",
                HeaderText = "Profesional",
                Name = "NombreCompletoProfesional"
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                Name = "Especialidad"
            });
            // Agregar columna para el texto del TipoPermiso
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha y hora del turno",
                Name = "FechaHora"
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Name = "Estado"
            });



            // Vincular el BindingList como DataSource
            dgvTurnos.DataSource = dgvTurnosDataSource;
            dgvTurnos.ClearSelection();
        }
        private void SetupScreen()
        {
            LoadComboboxes();
            dtpFechaHoraTurno.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now.AddDays(5);
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            if (DateIsInPast(dtpFechaHoraTurno.Value))
            {
                MessageBox.Show("La fecha del turno se encuentra en el pasado.",
                                "Error agendando el turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            Turno protoTurno = new Turno
            {
                Id = selectedTurno.Id,
                Paciente = selectedTurno.Paciente1.Id,
                Profesional = selectedProfessional.Id.Value,
                Estado = (int)EstadosTurnosEnum.Agendado,
                FechaHora = dtpFechaHoraTurno.Value,
                Especialidad = (Guid)cbxEspecialidad.SelectedValue
            };

            try
            {
                TurnoService.Instance.Update(protoTurno);

                MessageBox.Show($"La operación se realizó correctamente.",
                                "Operación exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (TurnoIsOverlappingException ex)
            {
                MessageBox.Show($"{ex.Message}",
                                "No hay resultados.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (TurnoDoesNotExistException ex)
            {
                MessageBox.Show($"{ex.Message}",
                                "No hay resultados.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar Logs.",
                                "Ocurrió un error inesperado.",
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

        public void HandleDgvTurnosCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que no sea un encabezado
            {
                // Obtiene la fila correspondiente al índice donde ocurrió el doble clic
                DataGridViewRow selectedRow = dgvTurnos.Rows[e.RowIndex];

                // Convierte el DataBoundItem al tipo de objeto original (por ejemplo, Turno)
                selectedTurno = selectedRow.DataBoundItem as Turno;

                if (selectedTurno != null)
                {
                    EnableFields();

                    CompleteFields();

                    FormHelpers.RefreshControls(_form);
                }
            }
        }

        private void CompleteFields()
        {
            cbxEspecialidad.SelectedValue = selectedTurno.Especialidad;

            selectedProfessional = UserFacade.GetOne(new User { Id = selectedTurno.Profesional });

            txtApellidoProf.Text = selectedProfessional.Apellido;
            txtNombreProf.Text = selectedProfessional.Nombre;

            cbxTipoDocumento.SelectedValue = selectedTurno.Paciente1.TipoDocumento1.Id;
            txtNroDoc.Text = selectedTurno.Paciente1.NumeroDocumento;
            txtNombrePac.Text = selectedTurno.Paciente1.Nombre;
            txtApellidoPac.Text = selectedTurno.Paciente1.Apellido;

            dtpFechaHoraTurno.Value = selectedTurno.FechaHora;
        }

        private void EnableFields()
        {
            cbxEspecialidad.Enabled = true;
            txtApellidoProf.Enabled = true;
            dtpFechaHoraTurno.Enabled = true;
            btnSearchProf.Enabled = true;
            btnEliminar.Enabled = true;
            btnSave.Enabled = true;
        }
        internal void HandleSearchTurno(object? sender, EventArgs e)
        {
            try
            {
                dgvTurnosDataSource.Clear();

                TurnoService.Instance.GetBetween(dtpFechaDesde.Value, dtpFechaHasta.Value).ForEach(dgvTurnosDataSource.Add);

                dgvTurnos.Refresh();
            }
            catch (NoTurnosFoundException ex)
            {
                MessageBox.Show($"{ex.Message}",
                                "No hay resultados.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar Logs.",
                                "Ocurrió un error inesperado.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
