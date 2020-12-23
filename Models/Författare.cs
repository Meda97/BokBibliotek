using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Models
{
    public class Författare
    {
        //Tabell

        [Key]
        public int FörfattareId { get; set; }
        [Required]
        public string FörfattareNamn { get; set; }

        //Nav
        public ICollection<BokFörfattare> BokFörfattare { get; set; }
    }
}
