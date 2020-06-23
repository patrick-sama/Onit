using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codice { get; set; }


    }
}
