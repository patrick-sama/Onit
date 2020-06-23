using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class Componente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codice { get; set; }

        [Required]
        public string Descrizione { get; set; }

        public string Note { get; set; }

        public ICollection<ComponenteDelCarello> ComponentiDelCarello { get; set; }
    }
}
