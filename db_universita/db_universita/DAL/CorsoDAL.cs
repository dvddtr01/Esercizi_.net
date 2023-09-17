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
    internal class CorsoDAL : IDal<Corso>
    {

        private string? stringaConnessione;
        private IConfiguration? conf;

        public CorsoDAL(IConfiguration? configurazione)
        {
            conf = configurazione;
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        #region Read

        //--------------------------------FindAll------------------------------


        public List<Corso> findAll()
        {
            List<Corso> corsi = new List<Corso>();

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT corsoID, titolo, crediti, codice FROM Corso;";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();          //Microsoft.Data.SqlClient.SqlException: 'Il nome di colonna 'crediti' non è valido.'

                while (reader.Read())
                {
                    Corso corso = new Corso()
                    {
                        Id = Convert.ToInt32(reader["corsoId"]),
                        Titolo = reader["titolo"].ToString(),
                        Crediti = Convert.ToInt32(reader["crediti"]),
                        Codice = reader["codice"].ToString(),
                    };

                    corsi.Add(corso);
                }

                connessione.Close();
            }

            return corsi;
        }

        //--------------------------------FindbyId------------------------------


        public Corso? findById(int id)
        {

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT corsoID, titolo, crediti, codice FROM Corso WHERE corsoID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Corso corso = new Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Titolo = reader[1].ToString(),
                        Crediti = Convert.ToInt32(reader[2]),
                        Codice = reader[3].ToString(),
         
                    };

                    connessione.Close();
                    return corso;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }
            }
        }
        
        #endregion
        
        public bool insert(Corso t)
        {
            throw new NotImplementedException();
        }

        public bool update(Corso t)
        {
            throw new NotImplementedException();
        }
    }
}
