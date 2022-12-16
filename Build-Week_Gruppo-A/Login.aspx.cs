using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Build_Week_Gruppo_A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.Cookies["Utente_Loggato"] != null)
            {
                Response.Redirect("/DettagliUtente.aspx");
            }
        }

        protected void Button_Accedi_Click(object sender, EventArgs e)
        {
            string password = TextBox_Password.Text;
            string username = TextBox_Username.Text;


            try { 
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("Username", username);
                command.Parameters.AddWithValue("Psw", password);
                command.CommandText = "SELECT * FROM Utente WHERE Username = @Username AND Psw = @Psw";
                command.Connection = connessioneDB;

                SqlDataReader record = command.ExecuteReader();


                if (record.Read())
                {
                    HttpCookie LogoutCookie = new HttpCookie("Utente_Loggato");
                    LogoutCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(LogoutCookie);
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(username, CheckBox_RicordamiAccedi.Checked);
                    HttpCookie UtenteLoggato = new HttpCookie("Utente_Loggato");
                    UtenteLoggato.Values["Nome"] = record["Nome"].ToString();
                    UtenteLoggato.Values["Ruolo"] = record["Ruolo"].ToString();
                    UtenteLoggato.Values["ID_Utente"] = record["ID_Utente"].ToString();
                    UtenteLoggato.Values["Password_Utente"] = record["Psw"].ToString();
                    Response.Cookies.Add(UtenteLoggato);
                    connessioneDB.Close();
                    Response.Redirect("/Default.aspx");
                } else
                {
                    Label_ERROR.Text = "Username e Password non coincidono.";
                }
                connessioneDB.Close();
            } catch (Exception ex)
            {
                Label_ERROR.Text = ex.Message;
            }
        }
    }
}