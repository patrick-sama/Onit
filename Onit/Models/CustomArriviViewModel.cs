using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onit.Models
{
    public class CustomArriviViewModel
    {
        //arrivi
        public string Identificativo { get; set; }
        public string Descrizione { get; set; }
        public DateTime Date { get; set; }

        //carello
        public string MatricolaCarello { get; set; }

        //locazione
        public string CodiceLocazione { get; set; }

        //area
        public int AreaId { get; set; }
    }
}
