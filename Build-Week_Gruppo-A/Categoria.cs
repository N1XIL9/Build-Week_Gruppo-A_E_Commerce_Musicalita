using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_Week_Gruppo_A
{
    public class Categoria
    {
        public int ID_Categoria { get; set; }
        public string Tipologia { get; set; }

        public static List<Categoria> Categorie = new List<Categoria>();
    }
}