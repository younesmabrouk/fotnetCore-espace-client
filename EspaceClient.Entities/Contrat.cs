using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspaceClient.Entities
{
    public class Contrat
    {
        public int ContratId { get; set; }
        public string Name { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
