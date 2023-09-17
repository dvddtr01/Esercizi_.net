using db_universita.DAL;
using db_universita.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace db_universita.Controllers
{
    internal class StudenteController
    {

        private IConfiguration? configurazione;

        private static StudenteController? istanza;

        public static StudenteController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new StudenteController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }


            return istanza;
        }

        private StudenteController()
        {

        }

        public void tuttiStudenti()
        {
            StudenteDAL stuDal = new StudenteDAL(configurazione);

            List<Studente> studenti = stuDal.findAll();

            foreach (var studente in studenti)
            {
                Console.WriteLine($"ID: {studente.Id}, Nominativo: {studente.Nominativo}, Matricola: {studente.Matricola}");
            }
        }

        public void studenteId(int stuId)
        {
            
                StudenteDAL stuDal = new StudenteDAL(configurazione);

                Console.WriteLine(stuDal.findById(stuId));
            
        }

        }


    }



