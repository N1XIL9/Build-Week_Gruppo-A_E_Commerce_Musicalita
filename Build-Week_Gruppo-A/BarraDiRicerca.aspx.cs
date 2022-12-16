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
    public partial class BarraDiRicerca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Marca = Request.QueryString["Marca"];

            if (!IsPostBack)
            {
                try { 
                Prodotto.ListaProdotti.Clear();
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command2 = new SqlCommand();
                command2.CommandText = $"SELECT * FROM Prodotto Where Marca LIKE '%{Marca}%'";
                command2.Connection = connessioneDB;

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Prodotto p = new Prodotto();
                        p.ID_Prodotto = Convert.ToInt32(reader["ID_Prodotto"]);
                        p.Marca = reader["Marca"].ToString();
                        p.Modello = reader["Modello"].ToString();
                        p.PrezzoVendita = Convert.ToDecimal(reader["PrezzoVendita"]);
                            p.PrezzoPrecedente = Convert.ToDecimal(reader["PrezzoPrecedente"]);
                        p.URLImg = reader["URLImg"].ToString();
                        p.Descrizione = reader["Descrizione"].ToString();
                        p.InPromozione = Convert.ToBoolean(reader["InPromozione"]);
                        if (p.InPromozione)
                        {
                            p.PrezzoPrecedente = Convert.ToDecimal(reader["PrezzoPrecedente"]);
                        }
                        p.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                        Prodotto.ListaProdotti.Add(p);
                    }
                }
                REPEATER_Ricerca.DataSource = Prodotto.ListaProdotti;
                REPEATER_Ricerca.DataBind();

                connessioneDB.Close();
                } catch (Exception ex)
                {
                    Label_ERRORE.Text = ex.Message;
                }
            }
        }

        protected void Button_AggiungiCarrello_Click1(object sender, EventArgs e)
        {
            Button AggiungiCarrello = (Button)sender;
            int idProdottoAggiunto = Convert.ToInt32(AggiungiCarrello.CommandArgument);
            string Marca = Request.QueryString["Marca"];

            foreach (Prodotto chitarra in Prodotto.ListaProdotti)
            {
                if (chitarra.ID_Prodotto == Convert.ToInt32(idProdottoAggiunto))
                {
                    Prodotto.CarrelloUtente.Add(chitarra);
                    Response.Redirect($"/BarraDiRicerca.aspx?Marca={Marca}");

                }
            }
        }
    }
}