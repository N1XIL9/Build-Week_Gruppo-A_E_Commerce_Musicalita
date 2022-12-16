using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


            if(!IsPostBack)
            {


                if (Prodotto.CarrelloUtente.Count() == 0) 
                {
                    Delete.Visible = false;
                    lblEmptyCart.Visible = true;
                    Button_EffettuaOrdine.Visible = false;
                    lblTotCarrello.Text = 0.ToString("c2");
                } 
                else { 
                   
                    Delete.Visible = true; 
                    lblEmptyCart.Visible = false; 

                    decimal Tot = 0;


                    foreach (Prodotto item in Prodotto.CarrelloUtente)
                    {
                        Tot += item.PrezzoVendita;
                    }


                    lblTotCarrello.Text = Tot.ToString("c2");


                }
                GridCarrello.DataSource = Prodotto.CarrelloUtente;
                GridCarrello.DataBind();
                
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            
            Prodotto.CarrelloUtente.Clear();
            Response.Redirect("~/Carrello.aspx");
       
        }

        protected void Button_EffettuaOrdine_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["Utente_Loggato"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();

                decimal Tot = 0;


                foreach (Prodotto item in Prodotto.CarrelloUtente)
                {
                    Tot += item.PrezzoVendita;
                }




                command.Parameters.AddWithValue("@ID_Utente", Request.Cookies["Utente_Loggato"]["ID_Utente"]);
                command.Parameters.AddWithValue("@DataOrdine", DateTime.Now.Date);

                command.Parameters.AddWithValue("@TotaleOrdine", Tot);
                command.CommandText = "INSERT INTO Ordine VALUES (@ID_Utente, @DataOrdine, @TotaleOrdine)";
                command.Connection = connessioneDB;

                int righeInteressate = command.ExecuteNonQuery();

                SqlCommand commandSelectDettaglio = new SqlCommand();
                commandSelectDettaglio.CommandText = "SELECT MAX(ID_Ordine) AS OrdineCreato FROM Ordine";
                commandSelectDettaglio.Connection = connessioneDB;
                SqlDataReader reader = commandSelectDettaglio.ExecuteReader();
                int IdOrdine = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IdOrdine = Convert.ToInt32(reader["OrdineCreato"]);
                    }
                }

                SqlCommand commandInsertDettaglio = new SqlCommand();
                commandInsertDettaglio.Connection= connessioneDB;
                foreach (Prodotto item in Prodotto.CarrelloUtente)
                {
                    commandInsertDettaglio.Parameters.Clear();
                    commandInsertDettaglio.Parameters.AddWithValue("@ID_Ordine", IdOrdine);
                    commandInsertDettaglio.Parameters.AddWithValue("@ID_Prodotto", item.ID_Prodotto);
                    commandInsertDettaglio.Parameters.AddWithValue("@Quantita", item.Quantita);
                    commandInsertDettaglio.CommandText = "INSERT INTO DettagliOrdine VALUES (@ID_Ordine, @ID_Prodotto, @Quantita)";
                    commandInsertDettaglio.ExecuteNonQuery();
                }


                


                if (righeInteressate > 0)
                {
                    Prodotto.CarrelloUtente.Clear();
                    GridCarrello.DataSource = Prodotto.CarrelloUtente;
                    GridCarrello.DataBind();
                    Label_RigheInteressate.Visible = true;
                    Label_RigheInteressate.Text = "Ordine Effettuato.";
                }
                else
                {
                    Label_RigheInteressate.Visible = true;
                    Label_RigheInteressate.Text = "Si è verificato un problema.";
                }

                connessioneDB.Close();


            }
        }
    }
}