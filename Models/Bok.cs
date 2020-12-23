using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Models
{
    public class Bok
    {
        //Tabell

        [Key]
        public int BokId { get; set; }
        [Required]
        public int Isbn { get; set; }
        [Required]
        public string Boktitel { get; set; }
        public string Betyg { get; set; }
        public int Utgivningsår { get; set; }

        //Nav
        public ICollection<BokFörfattare> BokFörfattare { get; set; }
        public ICollection<Boklån> Boklån { get; set; }

    }
}
