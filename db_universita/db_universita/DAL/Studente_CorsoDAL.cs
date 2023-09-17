using db_universita.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_universita.DAL
{
    internal class Studente_CorsoDAL : IDal<Studente_Corso>
    {
        private string? stringaConnessione;
        private IConfiguration? conf;

        public Studente_CorsoDAL(IConfiguration? configurazione)
        {
            conf = configurazione;
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------FindAll-----------------------------------------------

        public List<Studente_Corso> findAll()
        {
            List<Studente_Corso> studenti_corsi = new List<Studente_Corso>();

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT * FROM Studente_Corso";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Studente_Corso studente_Corso = new Studente_Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Studente = new StudenteDAL(conf).findById(Convert.ToInt32(reader[1])),
                        Corso = new CorsoDAL(conf).findById(Convert.ToInt32(reader[2]))
                    };

                    studenti_corsi.Add(studente_Corso);
                }

                connessione.Close();
            }

            return studenti_corsi;
        }

        //-------------------------------------------FindbyId-----------------------------------------------

        public Studente_Corso? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studente_corsoID, studenteRIF, corsoRIF FROM Studente_Corso WHERE studente_corsoID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente_Corso studente_Corso = new Studente_Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Studente = new StudenteDAL(conf).findById(Convert.ToInt32(reader[1])),
                        Corso = new CorsoDAL(conf).findById(Convert.ToInt32(reader[2]))
                    };

                    connessione.Close();
                    return studente_Corso;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }

        public bool insert(Studente_Corso t)
        {
            throw new NotImplementedException();
        }

        public bool update(Studente_Corso t)
        {
            throw new NotImplementedException();
        }
    }
}
