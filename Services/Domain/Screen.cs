using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Screen
    {
        [Key]
        public string OptionName { get; set; }
        [Key]
        public string ScreenName { get; set; }
        public Guid? Acceso { get; set; }
    }
}
