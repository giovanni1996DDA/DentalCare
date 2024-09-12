using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        
        [Required
            (ErrorMessage = "El usuario es obligatorio.")]
        public string UserName { get; set; }

        [Required
            (ErrorMessage = "La contraseña es obligatoria.")]
        [RegularExpression
            (@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número, un símbolo y al menos 8 caracteres.")]
        public string Password { get; set; }

        public List<Acceso> Accesos = new List<Acceso>();
        public User()
        {
            //Id = Guid.NewGuid();
        }
    }
}
