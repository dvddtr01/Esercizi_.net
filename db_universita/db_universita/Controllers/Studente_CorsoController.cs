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
    internal class Studente_CorsoController
    {


        private IConfiguration? configurazione;

        private static Studente_CorsoController? istanza;

        public static Studente_CorsoController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new Studente_CorsoController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }


            return istanza;
        }

        private Studente_CorsoController()
        {

        }
    }
}

