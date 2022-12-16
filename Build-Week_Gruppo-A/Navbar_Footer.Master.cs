using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Build_Week_Gruppo_A
{
    public partial class Navbar_Footer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                if (Prodotto.CarrelloUtente.Count > 0)
            {
                Label_BadgeCarrello.Visible = true;
            } else
            {
                Label_BadgeCarrello.Visible = false;
            }
            int quantitaProdotti = 0;    
            foreach(Prodotto item in Prodotto.CarrelloUtente)
            {
                quantitaProdotti += item.Quantita;
            }
            
                Label_CounterCarrello.Text = quantitaProdotti.ToString();
                Label_CounterCarrello.DataBind();

            if (!IsPostBack)
            {
                
                if (Request.Cookies["Utente_Loggato"] != null && (Request.Cookies["Utente_Loggato"]["Ruolo"] == "admin"))
                {
                    LinkButton_Admin.Visible = true;
                    LinkButton_Logout.Visible = true;
                    Label_NomeCookie.Text = Request.Cookies["Utente_Loggato"]["Nome"];
                }
                if (Request.Cookies["Utente_Loggato"] != null)
                {
                    LinkButton_Logout.Visible = true;
                    Label_NomeCookie.Text = Request.Cookies["Utente_Loggato"]["Nome"];
                }



                Categoria.Categorie.Clear();
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Categoria";
                command.Connection = connessioneDB;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                        
                        Categoria cat = new Categoria();
                        cat.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"].ToString());
                        cat.Tipologia = reader["Tipologia"].ToString();
                        Categoria.Categorie.Add(cat);

                    }
                }

                Repeater_NavbarCategorie.DataSource = Categoria.Categorie;
                Repeater_NavbarCategorie.DataBind();
                
                connessioneDB.Close();
            }
        }

        protected void Button_CercaChitarra_Click(object sender, EventArgs e)
        {
            string url = $"/BarraDiRicerca.aspx?Marca={TextBox_CercaChitarra.Text}";
            Response.Redirect(url);
        }

        protected void Button_LogoutCookie_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpCookie LogoutCookie = new HttpCookie("Utente_Loggato");
            LogoutCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(LogoutCookie);
            Response.Redirect("~/Default.aspx");
        }
    }
}