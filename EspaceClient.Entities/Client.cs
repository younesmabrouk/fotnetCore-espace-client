﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EspaceClient.Entities
{

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Contrat> Contrats { get; set; }
    }

}
