using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BokBibliotek.Models
{
    public class Boklån
    {
        //Tabell
        //lägg till bokId och låntagreId
        [Key]
        public int BoklånId { get; set; }

        // FK
        public int LåntagareId { get; set; }
        public int BokId { get; set; }
        //sista gången med ________
        public bool Utlånad { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Lånedatum { get; set; }
        public DateTime? Returdatum { get; set; }

        //Nav
        public Låntagare Låntagare { get; set; }
        public Bok Bok { get; set; }

    }
}
