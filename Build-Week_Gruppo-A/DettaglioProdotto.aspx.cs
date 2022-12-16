using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A
{
    public partial class DettaglioProdotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IdCategoria = Request.QueryString["IdCategoria"];

            string id = Request.QueryString["Id"];

            foreach (Prodotto item in Prodotto.ListaProdotti)
            {
                if( Convert.ToInt32(id) == item.ID_Prodotto)
                {
                    Image1.ImageUrl = "./img/" + item.URLImg ;
                    Nome.Text = item.Marca + item.Modello;
                    Descrizione.Text = item.Descrizione;
                    Prezzo.Text = item.PrezzoVendita.ToString("c2");
                    if (item.InPromozione) {

                        Label_PrezzoPrecedenteBOX.Visible = true;
                        Label_PrezzoPrecedente.Text = item.PrezzoPrecedente.ToString("c2");
                    } else
                    {
                        Label_PrezzoPrecedenteBOX.Visible = false;
                    }
                }
            }
        }
        protected void AddProduct_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];


            foreach (Prodotto a in Prodotto.ListaProdotti)
            {
                if (a.ID_Prodotto == Convert.ToInt32(id))
                {
                    a.Quantita = Convert.ToInt32(DropDownList1.SelectedValue);
                    a.PrezzoVendita = a.PrezzoVendita * a.Quantita;
                    Prodotto.CarrelloUtente.Add(a);
                    Response.Redirect($"/DettaglioProdotto.aspx?Id={id}");

                }
            }
        }

    }
}