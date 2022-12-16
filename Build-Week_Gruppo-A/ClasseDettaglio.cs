using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_Week_Gruppo_A
{
    public class  ClasseDettaglio
    {
        public string Marca { get; set; }
        public string Modello { get; set; }
        public int Quantita { get; set; }
        public DateTime DataOrdine { get; set; }
        public decimal Totale { get; set; }

        public static List<ClasseDettaglio> ListaDettagli = new List<ClasseDettaglio>();
    }
}