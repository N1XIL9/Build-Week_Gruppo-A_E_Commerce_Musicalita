using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A
{
    public partial class DettagliUtente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connessioneDB = new SqlConnection();
            connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
            connessioneDB.Open();

            SqlCommand command = new SqlCommand();
            string ID_Utente = Request.Cookies["Utente_Loggato"]["ID_Utente"];
            
            command.Parameters.AddWithValue("@ID_Utente", ID_Utente);
            command.CommandText = "SELECT * FROM Utente WHERE ID_Utente = @ID_Utente";
            command.Connection = connessioneDB;

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read()) { 
                    Label_NomeCognome.Text = reader["Nome"].ToString() + " " + reader["Cognome"].ToString();
                    Label_Username.Text = reader["Username"].ToString();
                    Label_Email.Text = reader["Email"].ToString();

                }
            } else
            {

            }

            connessioneDB.Close();
        }

        protected void LinkButton_Logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpCookie LogoutCookie = new HttpCookie("Utente_Loggato");
            LogoutCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(LogoutCookie);
            Response.Redirect("~/Default.aspx");
        }

        protected void Button_iTuoiOrdini_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ListaOrdini.aspx");
        }

   
        protected void ModificaPwd_Click(object sender, EventArgs e)
        {
            SqlConnection connessioneDB = new SqlConnection();
            connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
            connessioneDB.Open();

            SqlCommand command = new SqlCommand();
            string ID_Utente = Request.Cookies["Utente_Loggato"]["ID_Utente"];

            string oldpsw = oldPassword.Text;
            string newpsw = newPassword.Text;
            if (oldpsw == Request.Cookies["Utente_Loggato"]["Password_Utente"])
            {
                ErroreOldPsw.Visible= false;
                command.Parameters.AddWithValue("@ID_Utente", ID_Utente);
                command.Parameters.AddWithValue("@psw", newpsw);
                command.CommandText = "UPDATE Utente SET Psw = @psw where ID_Utente = @ID_Utente";
                command.Connection= connessioneDB;
                command.ExecuteNonQuery();

                FormsAuthentication.SignOut();
                HttpCookie LogoutCookie = new HttpCookie("Utente_Loggato");
                LogoutCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(LogoutCookie);
                Response.Redirect("~/Login.aspx");

            }
            else
            {
                ErroreOldPsw.Visible= true;
                ErroreOldPsw.Text = "La password non coincide";
            }

            connessioneDB.Close();
        }

        protected void LinkButton_ModificaPassword_Click(object sender, EventArgs e)
        {
            modificapswBox.Visible = true;
        }
    }
}