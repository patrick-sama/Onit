using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class Locazione
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Codice { get; set; }

        [Required] [ForeignKey("AreaId")]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public ICollection<Arrivi> Arrivi { get; set; }

    }
}
