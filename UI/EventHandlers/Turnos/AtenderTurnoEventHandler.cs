using Dao;
using Logic.Exceptions;
using Logic.StateMachines.TurnoStateMachine;
using Logic;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helpers;
using UI.Perofessional.Turnos;
using EventHandler = UI.Generic.EventHandler;
using UI.Perofessional;
using UI.Interfaces;

namespace UI.EventHandlers.Turnos
{
    public class AtenderTurnoEventHandler : EventHandler
    {
        private DataGridView dgvTurnos;
        private MaterialButton btnAtender;

        private BindingList<Turno> dgvTurnosDataSource = new BindingList<Turno>();

        private static List<IcstObserver> observers = new List<IcstObserver>();
        public AtenderTurnoEventHandler(Form atenderTurnoForm)
        {
            _form = atenderTurnoForm;
            dgvTurnos = (DataGridView)FormHelpers.FindControl(_form, "dgvTurnos");
            btnAtender = (MaterialButton)FormHelpers.FindControl(_form, "btnAtender");
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
                TurnoService.Instance.GetRecepcionados().ForEach(dgvTurnosDataSource.Add);

                btnAtender.Enabled = true;
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
                TurnoService.Instance.Atender(selectedTurno);

                MessageBox.Show("El turno se atendió correctamente",
                                "Operación exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                observers.ForEach(obs => obs.Notify(selectedTurno.Paciente1));

                dgvTurnos.Refresh();
            }
            catch (StateChangeNotPossibleException ex)
            {
                MessageBox.Show(ex.Message,
                                "Seleccione un turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                "Error agendando el turno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
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
        public static void Suscribe(IcstObserver obj)
        {
            observers.Add(obj);
        }
    }
}
