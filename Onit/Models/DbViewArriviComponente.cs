using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class DbViewArriviComponente
    {
        public string CodiceLocazione { get; set; }
        public int AreaId { get; set; }
        public string Matricola { get; set; }
        public string Descrizione { get; set; }
        public string Identificativo { get; set; }
        public CustomComponent[] ComponenteCarello { get; set; }
    }
}
