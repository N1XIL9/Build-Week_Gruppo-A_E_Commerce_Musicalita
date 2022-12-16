using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A.admin
{
    public partial class ListaProdotti : System.Web.UI.Page
    {
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Prodotto.ListaProdotti.Clear();
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                try
                {
                    connessioneDB.Open();
                    SqlCommand commandGrid = new SqlCommand(@"SELECT *  FROM Prodotto
                                                                INNER JOIN
                                                                Categoria ON
                                                                Prodotto.ID_Categoria = Categoria.ID_Categoria", connessioneDB);



                    SqlDataReader prodottiTable = commandGrid.ExecuteReader();

                    if (prodottiTable.HasRows)
                    {
                        while (prodottiTable.Read())
                        {
                            Prodotto prodottoAdmin = new Prodotto();
                            prodottoAdmin.ID_Prodotto = Convert.ToInt32(prodottiTable["ID_Prodotto"]);
                            prodottoAdmin.Marca = prodottiTable["Marca"].ToString();
                            prodottoAdmin.Modello = prodottiTable["Modello"].ToString();
                            prodottoAdmin.PrezzoVendita = Convert.ToDecimal(prodottiTable["PrezzoVendita"]);
                            prodottoAdmin.PrezzoPrecedente = Convert.ToDecimal(prodottiTable["PrezzoPrecedente"]);
                            prodottoAdmin.InPromozione = Convert.ToBoolean(prodottiTable["InPromozione"]);
                            prodottoAdmin.Tipologia = prodottiTable["Tipologia"].ToString();
                            


                            Prodotto.ListaProdotti.Add(prodottoAdmin);
                            
                        }
                    }





                    GridView_ListaProdotti.DataSource = Prodotto.ListaProdotti;
                    GridView_ListaProdotti.DataBind();
                }
                catch { }



                connessioneDB.Close();
            }

    


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button ModificaProdotto = (Button)sender;
            int idProdotto = Convert.ToInt32(ModificaProdotto.CommandArgument);

            Response.Redirect($"./AggiungiProdotto.aspx?IdProdotto={idProdotto}");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button EliminaProdotto = (Button)sender;
            int idProdotto = Convert.ToInt32(EliminaProdotto.CommandArgument);

            
            SqlConnection connessioneDB = new SqlConnection();
            connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
            connessioneDB.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"DELETE  FROM Prodotto WHERE ID_Prodotto = {idProdotto}";
            command.Connection = connessioneDB;

            command.ExecuteNonQuery();

            GridView_ListaProdotti.DataSource = Prodotto.ListaProdotti;
            GridView_ListaProdotti.DataBind();

            connessioneDB.Close();

            Response.Redirect("ListaProdotti.aspx");


        }
    }
}