using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using UI.Helpers;
using UI.NonProfessional.EventHandlers.TurnosForms;
using UI.NonProfessional.TurnosForms;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers
{
    internal class FindProfesionalPopUpEventHandler : EventHandler
    {
        private readonly FindProfesionalPopUp _form;
        private List<User> _professionasToSearch;
        protected DataGridView dgvProfesionales;

        public FindProfesionalPopUpEventHandler(FindProfesionalPopUp form, List<User> users)
        {
            _form = form;
            _professionasToSearch = users;

            dgvProfesionales = (DataGridView)FormHelpers.FindControl(_form, "dgvProfesionales");
        }

        public override void HandleOnExit(object sender, EventArgs e)
        {
            _form.DialogResult = DialogResult.Cancel;
            _form.Close();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            if (dgvProfesionales.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Debe seleccionar el permiso a agregar.",
                                $"Error en la adición de permiso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvProfesionales.SelectedRows[0];

            _form.SelectedProfessional = selectedRow.DataBoundItem as User;

            _form.DialogResult = DialogResult.OK;

            _form.Close();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            //_professionasToSearch = _professionasToSearch.
            _professionasToSearch = _professionasToSearch.Select(prof =>
                                                                {
                                                                    try
                                                                    {
                                                                        return UserFacade.GetOne(prof);
                                                                    }
                                                                    catch (NoUsersFoundException)
                                                                    {
                                                                        return null;
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        throw;
                                                                    }
                                                                })
                                                                .Where(prof => prof != null)
                                                                .ToList();

            if (!_professionasToSearch.Any())
            {
                MessageBox.Show($"No se encontraron usuarios con el criterio de búsqueda seleccionado.",
                                "No se encontraron usuarios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _form.Close();
            }

            ConfigureDgvProfesional();
        }
        private void ConfigureDgvProfesional()
        {
            // Configuración del DataGridView
            dgvProfesionales.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar la última columna para que ocupe el espacio restante
            dgvProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar columna de Nombre
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });

            // Agregar columna para el texto del Modulo
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "Apellido"
            });

            // Vincular el BindingList como DataSource
            dgvProfesionales.DataSource = _professionasToSearch;
            dgvProfesionales.ClearSelection();
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