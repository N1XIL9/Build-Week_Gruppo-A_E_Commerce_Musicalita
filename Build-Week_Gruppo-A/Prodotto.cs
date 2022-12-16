using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_Week_Gruppo_A
{
    public class Prodotto
    {
        public int ID_Prodotto { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public decimal PrezzoVendita { get; set; }
        public decimal PrezzoPrecedente { get; set; }
        public string URLImg { get; set; }
        public string Descrizione { get; set; }
        public bool InPromozione { get; set; }
        public int ID_Categoria { get; set; }
        public string Tipologia { get; set; }
        public int Quantita { get; set; }



        public static List<Prodotto> ListaProdotti = new List<Prodotto>();

        public static List<Prodotto> CarrelloUtente = new List<Prodotto>();
    }
}