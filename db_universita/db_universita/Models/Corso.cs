using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_universita.Models
{
    internal class Corso
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public int Crediti { get; set; }
        public string? Codice { get; set; }

        public List<Studente_Corso> ElencoStudenti { get; set; } = new List<Studente_Corso>();

        public override string ToString()
        {
            return $"Corso {Id} {Titolo} {Crediti} {Codice}";
        }
    }
}
