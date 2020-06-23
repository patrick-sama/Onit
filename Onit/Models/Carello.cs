﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class Carello
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Matricola { get; set; }

        public ICollection<ComponenteDelCarello> ComponentiDelCarello { get; set; }

        public ICollection<Arrivi> Arrivi { get; set; }
    }
}
