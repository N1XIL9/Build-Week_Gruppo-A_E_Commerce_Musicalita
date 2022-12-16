using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_Week_Gruppo_A
{
    public class Ordine
    {
        public int ID_Ordine { get; set; }
        public int ID_Utente { get; set; }
        public decimal TotaleOrdine { get; set; }
        public DateTime DataOrdine { get; set; }

        public static List<Ordine> listaOrdini = new List<Ordine>();
    }
}