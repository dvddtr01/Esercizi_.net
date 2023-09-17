using db_universita.Controllers;
using db_universita.DAL;
using db_universita.Models;

namespace db_universita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudenteController.getIstanza().tuttiStudenti();        // funziona abbastanza bene
            //CorsoController.getIstanza().tuttiCorsi();            // ho un problema nella colonna crediti e non riesco a capire il perchè, nel db e qui hanno lo stesso nome ma non riesce a trovarla
            //CorsoController.getIstanza().corsoId(1);   
            //StudenteController.getIstanza().studenteId(0);        // Index was outside the bounds of the array con Id = 1, se l'Id è 0 mi dice che l'array è vuoto, credo crei un array e non lo popoli

        }
    }
}