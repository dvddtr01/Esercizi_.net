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
    internal class CorsoController
    {

        private IConfiguration? configurazione;

        private static CorsoController? istanza;

        public static CorsoController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new CorsoController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }


            return istanza;
        }

        private CorsoController()
        {

        }

        public void tuttiCorsi()
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);

            List<Corso> corsi = corDal.findAll();

            foreach (var corso in corsi)
            {
                Console.WriteLine($"ID: {corso.Id}, Titolo: {corso.Titolo}, Crediti: {corso.Crediti}, Codice: {corso.Codice}");
            }
        }

        public void corsoId(int Id) {
        

                CorsoDAL corDal = new CorsoDAL(configurazione);

                Console.WriteLine(corDal.findById(Id));

            
        }
    }
}

