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
    public partial class ListaOrdini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Ordine.listaOrdini.Clear();

                SqlConnection connectionDB = new SqlConnection();
                connectionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connectionDB.Open();

                SqlCommand comand = new SqlCommand();
                string ID_Utente = Request.Cookies["Utente_Loggato"]["ID_Utente"];
                comand.Parameters.AddWithValue("@ID_Utente", ID_Utente);
                comand.CommandText = "Select * FROM Ordine WHERE ID_Utente = @ID_Utente";
                comand.Connection = connectionDB;

                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ordine ordine = new Ordine();
                        ordine.ID_Ordine = Convert.ToInt32(reader["ID_Ordine"]);
                        ordine.ID_Utente = Convert.ToInt32(reader["ID_Utente"]);
                        ordine.DataOrdine = Convert.ToDateTime(reader["DataOrdine"].ToString());
                        ordine.TotaleOrdine = Convert.ToDecimal(reader["TotaleOrdine"]);
                        Ordine.listaOrdini.Add(ordine);
                    }
                }

                GridCarrello.DataSource = Ordine.listaOrdini;
                GridCarrello.DataBind();

                connectionDB.Close();
            }
        }

        protected void Button_Dettaglio_Click(object sender, EventArgs e)
        {
            Button DettaglioOrdine = (Button)sender;
            int IdOrdine = Convert.ToInt32(DettaglioOrdine.CommandArgument);
            Response.Redirect($"DettagliOrdine.aspx?IdOrdine={IdOrdine}");
        }
    }
}