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
    public partial class Registrazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Registrazione_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();

                command.Parameters.AddWithValue("@Nome", TEXTBOX_Nome.Text);
                command.Parameters.AddWithValue("@Cognome", TEXTBOX_Cognome.Text);
                command.Parameters.AddWithValue("@Username", TEXTBOX_Username.Text);
                command.Parameters.AddWithValue("@Psw", TEXTBOX_Password.Text);
                command.Parameters.AddWithValue("@Email", TEXTBOX_Email.Text);
                command.Parameters.AddWithValue("@Indirizzo", TEXTBOX_Indirizzo.Text);
                command.Parameters.AddWithValue("@AnnoNascita", TEXTBOX_DatadiNascita.Text);
                command.Parameters.AddWithValue("@Ruolo", "utente");

                command.CommandText = "INSERT INTO Utente (Nome, Cognome, Username, Psw, Email, Indirizzo, AnnoNascita, Ruolo) VALUES (@Nome, @Cognome, @Username, @Psw, @Email, @Indirizzo, @AnnoNascita, @Ruolo)";
                command.Connection = connessioneDB;
                int righe = command.ExecuteNonQuery();

                if (righe > 0)
                {
                    Label_ErroreRegistrazione.Visible = true;
                    Label_ErroreRegistrazione.Text = "Registrazione effettuata";
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label_ErroreRegistrazione.Visible = true;
                    Label_ErroreRegistrazione.Text = "Errore durante la registrazione";
                }

                connessioneDB.Close();
            }
            catch(Exception err)
            {
                Label_ErroreRegistrazione.Visible= false;
                Label_ErroreRegistrazione.Text = err.Message;
            }
            
        }
    }
}