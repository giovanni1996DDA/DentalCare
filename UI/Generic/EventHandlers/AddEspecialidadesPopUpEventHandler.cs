using Dao;
using Logic;
using Logic.Exceptions;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Generic.FormUsuarios.PopUps;
using UI.Helpers;
using Services.Facade.Extensions;

namespace UI.Generic.EventHandlers
{
    internal class AddEspecialidadesPopUpEventHandler : EventHandler
    {
        DataGridView dgvEspecialidades;
        public AddEspecialidadesPopUpEventHandler(Form form)
        {
            _form = form;

            dgvEspecialidades = (DataGridView)FormHelpers.FindControl(_form, "dgvEspecialidades");
        }
        public override async void HandleOnLoad(object sender, EventArgs e)
        {
            ConfigureEspecialidadesDataGridView();
            try
            {
                // Llamada asincrónica para obtener las especialidades
                List<Especialidad> especialidades = await EspecialidadService.Instance.GetAsync();

                dgvEspecialidades.DataSource = especialidades;
            }
            catch (NoEspecialidadFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureEspecialidadesDataGridView()
        {
            dgvEspecialidades.AutoGenerateColumns = false; // Desactivar generación automática de columnas

            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar la última columna para que ocupe el espacio restante
            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Limpiar columnas existentes
            dgvEspecialidades.Columns.Clear();

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre".Translate(),
                Name = "Nombre"
            });
        }
        public void HandleOnAdd(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Debe seleccionar la especialidad a agregar.".Translate(),
                                $"Error en la adición de especialidad".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvEspecialidades.SelectedRows[0];

            Especialidad especialidadSeleccionado = selectedRow.DataBoundItem as Especialidad;

            (_form as AddEspecialidadesPopUp).selectedEspecialidad = especialidadSeleccionado;

            _form.Close();
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            (_form as AddEspecialidadesPopUp).Canceled = true;
            _form.Close();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
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
