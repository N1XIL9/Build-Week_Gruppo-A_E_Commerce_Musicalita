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
    public partial class DettagliOrdine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClasseDettaglio.ListaDettagli.Clear();
                int IdOrdine = Convert.ToInt32(Request.QueryString["IdOrdine"]);
                SqlConnection connectionDB = new SqlConnection();
                connectionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connectionDB.Open();

                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@ID_Ordine", IdOrdine);
                comand.CommandText = "Select Quantita, Marca, Modello, TotaleOrdine, DataOrdine FROM DettagliOrdine INNER JOIN Ordine ON DettagliOrdine.ID_Ordine = Ordine.ID_Ordine INNER JOIN Prodotto ON DettagliOrdine.ID_Prodotto = Prodotto.ID_Prodotto WHERE DettagliOrdine.ID_Ordine = @ID_Ordine";
                comand.Connection = connectionDB;

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClasseDettaglio dettaglio = new ClasseDettaglio();
                        dettaglio.Marca = reader["Marca"].ToString();
                        dettaglio.Quantita = Convert.ToInt32(reader["Quantita"].ToString());
                        dettaglio.Totale = Convert.ToDecimal(reader["TotaleOrdine"].ToString());
                        dettaglio.Modello = reader["Modello"].ToString();
                        dettaglio.DataOrdine = Convert.ToDateTime(reader["DataOrdine"].ToString());
                        ClasseDettaglio.ListaDettagli.Add(dettaglio);
                    }
                }


                GridDettaglioOrdine.DataSource = ClasseDettaglio.ListaDettagli;
                GridDettaglioOrdine.DataBind();


                connectionDB.Close();
            }
        }
    }
}