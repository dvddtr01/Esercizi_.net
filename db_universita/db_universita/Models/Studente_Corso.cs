using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_universita.Models
{
    internal class Studente_Corso
    {
        public int Id { get; set; }
        public Studente? Studente { get; set; }
        public Corso? Corso { get; set; }
      
    }
}
