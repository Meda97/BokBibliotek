using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Models
{
    public class Låntagare
    {
        //Tabell

        [Key]
        public int LåntagareId { get; set; }
        [Required]
        public string Förnamn { get; set; }
        [Required]
        public string Efternamn { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }

        //Nav
        public ICollection<Boklån> Boklån { get; set; }

    }
}
