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
    internal class StudenteDAL : IDal<Studente>
    {
        private string? stringaConnessione;
        private IConfiguration? conf;

        public StudenteDAL(IConfiguration? configurazione)
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

        public List<Studente> findAll()
        {
            List<Studente> studenti = new List<Studente>();

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT * FROM Studente";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader["studenteId"]),
                        Nominativo = reader["nominativo"].ToString(),
                        Matricola = reader["matricola"].ToString(),
                    };

                    studenti.Add(studente);
                }

                connessione.Close();
            }

            return studenti;
        }

        //--------------------------------FindbyId------------------------------


        public Studente? findById(int id)
        {

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID, nominativo, matricola FROM Studente WHERE studenteID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nominativo = reader[1].ToString(),
                        Matricola = reader[3].ToString(),

                    };

                    connessione.Close();
                    return studente;
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

        public bool insert(Studente t)
        {
            throw new NotImplementedException();
        }

        public bool update(Studente t)
        {
            throw new NotImplementedException();
        }
    }
}
