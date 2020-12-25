using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameApp.Shared
{
    public class Name
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nimi vaaditaan.")]
        [MinLength(2, ErrorMessage = "Nimessä pitää olla vähintään kaksi merkkiä.")]
        [MaxLength(16, ErrorMessage = "Nimessä saa olla korkeintaan 16 merkkiä.")]
        public string Nimi { get; set; }

        [Range(1, 1000, ErrorMessage = "Nimiä voi lisätä 1 - 1000 kerralla.")]
        public int Amount { get; set; }
    }
}
