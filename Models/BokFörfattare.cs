using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Models
{
    public class BokFörfattare
    {
        //KopplingsTabell till bok och författare

        public int BokId { get; set; }
        public int FörfattareId { get; set; }

        //Nav
        public Bok Bok { get; set; }
        public Författare Författare { get; set; }
    }
}
