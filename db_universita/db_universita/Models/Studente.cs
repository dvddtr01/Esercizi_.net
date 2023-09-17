using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_universita.Models
{
    internal class Studente
    {
        public int Id { get; set; }
        public string? Nominativo { get; set; }
        public string? Matricola { get; set; }

        public List<Studente_Corso> ElencoCorsi { get; set; } = new List<Studente_Corso>();

        public override string ToString()
        {
            return $"Studente {Id} {Nominativo} {Matricola}";
        }

    }
}
