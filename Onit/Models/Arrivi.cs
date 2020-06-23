using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class Arrivi
    {
        [Required]
        public string Descrizione { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("CarelloId")]
        public int CarelloId { get; set; }
        public Carello Carello { get; set; }

        [Required]
        [ForeignKey("LocazioneId")]
        public int LocazioneId { get; set; }
        public Locazione Locazione { get; set; }

    }
}
