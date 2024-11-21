using Dao;
using Logic;
using Logic.Enums;
using Logic.Exceptions;
using Logic.StateMachines.TurnoStateMachine;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers.Turnos
{
    public class RecepcionarTurnoEventHandler : EventHandler
    {
        private DataGridView dgvTurnos;
        private MaterialButton btnRecepcionar;

        private BindingList<Turno> dgvTurnosDataSource = new BindingList<Turno>();

        public RecepcionarTurnoEventHandler(Form form)
        {
            _form = form;
            dgvTurnos = (DataGridView)FormHelpers.FindControl(_form, "dgvTurnos");
            btnRecepcionar = (MaterialButton)FormHelpers.FindControl(_form, "btnRecepcionar");
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
            SetupDgvTurnos();

            try
            {
                TurnoService.Instance.GetToday().ForEach(dgvTurnosDataSource.Add);

                btnRecepcionar.Enabled = true;
            }
            catch (NoTurnosFoundException ex)
            {
                MessageBox.Show("No se encuentran turnos a recepcionar el dia de hoy.",
                                "No se encontraron turnos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                "Error agendando el turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void SetupDgvTurnos()
        {
            //Configuración del DataGridView
            dgvTurnos.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un turno a recepcionar.",
                                "Seleccione un turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dgvTurnos.SelectedRows[0];

            // Obtén el objeto Turno enlazado a esta fila
            Turno selectedTurno = selectedRow.DataBoundItem as Turno;

            try
            {
                TurnoStateMachine sm = new TurnoStateMachine(selectedTurno);

                sm.Recepcionar();

                TurnoService.Instance.Update(selectedTurno, ignoreOverlapping: true);

                MessageBox.Show("El turno se recepcionó correctamente",
                                "Operación exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dgvTurnos.Refresh();
            }
            catch (StateChangeNotPossibleException ex)
            {
                MessageBox.Show(ex.Message,
                                "Seleccione un turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
    }
}
