using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class ComponenteDelCarello
    {
        [Required]
        public int Qty { get; set; }

        [Required]
        [ForeignKey("CarelloId")]
        public int CarelloId { get; set; }
        public Carello Carello { get; set; }

        [Required]
        [ForeignKey("ComponenteId")]
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }
    }
}
