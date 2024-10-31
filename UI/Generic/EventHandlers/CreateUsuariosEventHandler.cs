using Dao;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.Generic.FormUsuarios.PopUps;
using UI.Helpers;


namespace UI.Generic.EventHandlers
{
    internal class CreateUsuariosEventHandler : UsuariosEventHandler
    {
        public CreateUsuariosEventHandler(Form form) : base(form)
        {
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            try
            {
                User protoUser = buildProtoUser();

                UserFacade.Register(protoUser);

                MessageBox.Show($"El usuario {protoUser.UserName} se creó correctamente.", "Operación realizada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearScreen();
            }
            catch (InvalidUserException ex)
            {
                MessageBox.Show($"{ex.Message}", "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UserAlreadyRegisteredException ex)
            {
                MessageBox.Show($"{ex.Message}", "El usuario ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                throw;
            }
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
        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        protected void ValidateFields()
        {
            throw new NotImplementedException();
        }
    }
}
