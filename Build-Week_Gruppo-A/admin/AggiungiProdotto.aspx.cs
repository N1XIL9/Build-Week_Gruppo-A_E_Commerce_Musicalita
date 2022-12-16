using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A.admin
{
    public partial class AggiungiProdotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {


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
                        ListItem listitem_categoria = new ListItem();
                        string c = reader["Tipologia"].ToString();
                        string id = reader["ID_Categoria"].ToString();
                        listitem_categoria.Text = c;
                        listitem_categoria.Value = id;
                        DropDownList_Categoria.Items.Add(listitem_categoria);
                        DropDownList_EliminaCategoria.Items.Add(listitem_categoria);

                    }
                }

                connessioneDB.Close();

                if (Request.QueryString["IdProdotto"] != null)
                {   string idQuery = Request.QueryString["IdProdotto"];


                    SqlConnection connessioneDBModifica = new SqlConnection();
                    connessioneDBModifica.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                    connessioneDBModifica.Open();

                    SqlCommand commandModifica = new SqlCommand();
                    commandModifica.CommandText = $"SELECT * FROM Categoria INNER JOIN Prodotto ON Prodotto.ID_Categoria = Categoria.ID_Categoria" +
                                                  $" WHERE Prodotto.ID_Prodotto = {idQuery} ";
                    commandModifica.Connection = connessioneDBModifica;

                    SqlDataReader readerModifica = commandModifica.ExecuteReader();

                    if (readerModifica.HasRows)
                    {
                        while (readerModifica.Read())
                        {
                            TEXTBOX_Marca.Text = readerModifica["Marca"].ToString();
                            TEXTBOX_Modello.Text = readerModifica["Modello"].ToString();
                            TEXTBOX_Descrizione.Text = readerModifica["Descrizione"].ToString();
                            TEXTBOX_PrezzoVendita.Text = Convert.ToDouble(readerModifica["PrezzoVendita"]).ToString();
                            CheckBox_InPromozione.Checked = Convert.ToBoolean(readerModifica["InPromozione"]);
                            DropDownList_Categoria.SelectedValue = readerModifica["ID_Categoria"].ToString();
                            TEXTBOX_PrezzoPrecedente.Text = readerModifica["PrezzoPrecedente"].ToString();
                            Label_Immagine.Text = readerModifica["URLIMG"].ToString();

                            
                            
                        }
                    }

                    if (CheckBox_InPromozione.Checked)
                    {
                        TEXTBOX_PrezzoPrecedente.Visible = true;
                    } else
                    {
                        TEXTBOX_PrezzoPrecedente.Visible = false;
                    }

                    if (CheckBox_AggiungiCategoria.Checked)
                    {
                        TEXTBOX_AggiungiCategoria.Visible = true;
                    } else
                    {
                        TEXTBOX_AggiungiCategoria.Visible = false;
                    }


                    Button_AggiungiProdotto.Visible = false;
                    Button_ModificaProdotto.Visible = true;



                }

                connessioneDB.Close();
            }

        }

        protected void CheckBox_InPromozione_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox_InPromozione.Checked) {

                TEXTBOX_PrezzoPrecedente.Visible = true;
            } else
            {
                TEXTBOX_PrezzoPrecedente.Visible = false;
            }
        }

        protected void Button_AggiungiProdotto_Click(object sender, EventArgs e)
        {

            if (TEXTBOX_AggiungiCategoria.Text != "")
            {
                try
                {

                    SqlConnection connessioneDB = new SqlConnection();
                    connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                    connessioneDB.Open();

                    SqlCommand command = new SqlCommand();

                    command.Parameters.AddWithValue("@Tipologia", TEXTBOX_AggiungiCategoria.Text);
                    command.CommandText = "INSERT INTO Categoria VALUES (@Tipologia)";
                    command.Connection = connessioneDB;

                    int righeInteressate = command.ExecuteNonQuery();

                    if (righeInteressate > 0)
                    {
                        Label_RigheInteressate.Text = "Inserimento effettuato con successo.";
                    }
                    else
                    {
                        Label_RigheInteressate.Text = "inserimento non effettuato.";
                    }

                    connessioneDB.Close();

                }
                catch (Exception ex)
                {
                    Label_RigheInteressate.Text = ex.Message;
                    Label_RigheInteressate.ForeColor = Color.Red;
                }
            } else if (CheckBox_EliminaCategoriaByName.Checked){
                try
                {

                    SqlConnection connessioneDB = new SqlConnection();
                    connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                    connessioneDB.Open();

                    SqlCommand command = new SqlCommand();

                    command.Parameters.AddWithValue("@ID_Categoria", DropDownList_EliminaCategoria.SelectedItem.Value);
                    command.CommandText = "DELETE FROM Categoria WHERE ID_Categoria = @ID_Categoria";
                    command.Connection = connessioneDB;

                    int righeInteressate = command.ExecuteNonQuery();

                    if (righeInteressate > 0)
                    {
                        Label_RigheInteressate.Text = "Inserimento effettuato sul cesso.";
                        Response.Redirect("~/admin/AggiungiProdotto.aspx");
                    }
                    else
                    {
                        Label_RigheInteressate.Text = "Hai cagato fuori dal vaso.";
                    }

                    connessioneDB.Close();

                }
                catch (Exception ex)
                {
                    Label_RigheInteressate.Text = ex.Message;
                    Label_RigheInteressate.ForeColor = Color.Red;
                }



            } else { 
            try { 

                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();

                command.Parameters.AddWithValue("@Marca", TEXTBOX_Marca.Text);
                command.Parameters.AddWithValue("@Modello", TEXTBOX_Modello.Text);
                command.Parameters.AddWithValue("@Descrizione", TEXTBOX_Descrizione.Text);

                if (FileUpload_Image.HasFile)
                {
                    FileUpload_Image.SaveAs(Server.MapPath($"/img/{FileUpload_Image.FileName}"));
                    
                }
                command.Parameters.AddWithValue("@URLImg", FileUpload_Image.FileName);

                command.Parameters.AddWithValue("@PrezzoVendita", TEXTBOX_PrezzoVendita.Text);
                
                command.Parameters.AddWithValue("@PrezzoPrecedente", TEXTBOX_PrezzoPrecedente.Text);

                command.Parameters.AddWithValue("@InPromozione", CheckBox_InPromozione.Checked);

                command.Parameters.AddWithValue("@ID_Categoria", DropDownList_Categoria.SelectedItem.Value);

                command.CommandText = $"INSERT INTO Prodotto VALUES (@Marca, @Descrizione, @Modello, @URLImg, @PrezzoVendita, @PrezzoPrecedente, @InPromozione, @ID_Categoria)";
                command.Connection = connessioneDB;

                int righeInteressate = command.ExecuteNonQuery();

                if (righeInteressate > 0)
                {
                    Label_RigheInteressate.Text = "Inserimento effettuato sul cesso.";
                } else
                {
                    Label_RigheInteressate.Text = "Hai cagato fuori dal vaso.";
                }

                connessioneDB.Close();

            } catch(Exception ex)
            {
                Label_RigheInteressate.Text = ex.Message;
                Label_RigheInteressate.ForeColor = Color.Red;
            }
        }
        }


        protected void Button_ModificaProdotto_Click (object sender, EventArgs e)
        {
            
            string idQueryModifica = Request.QueryString["IdProdotto"];
            if (FileUpload_Image.HasFile)
            {

            try
            {


                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();


                command.Parameters.AddWithValue("@Marca", TEXTBOX_Marca.Text);
                command.Parameters.AddWithValue("@Modello", TEXTBOX_Modello.Text);
                command.Parameters.AddWithValue("@Descrizione", TEXTBOX_Descrizione.Text);


                    FileUpload_Image.SaveAs(Server.MapPath($"~/img/{FileUpload_Image.FileName}"));
                    command.Parameters.AddWithValue("@URLImg", FileUpload_Image.FileName);
                              

                command.Parameters.AddWithValue("@PrezzoVendita", TEXTBOX_PrezzoVendita.Text);

                command.Parameters.AddWithValue("@PrezzoPrecedente", TEXTBOX_PrezzoPrecedente.Text);

                command.Parameters.AddWithValue("@InPromozione", CheckBox_InPromozione.Checked);

                command.Parameters.AddWithValue("@ID_Categoria", DropDownList_Categoria.SelectedItem.Value);

                command.CommandText = $"UPDATE Prodotto SET Marca = @Marca, Descrizione = @Descrizione, Modello = @Modello, URLImg = @URLImg, PrezzoVendita = @PrezzoVendita, PrezzoPrecedente = @PrezzoPrecedente, InPromozione = @InPromozione, ID_Categoria = @ID_Categoria WHERE ID_Prodotto = {idQueryModifica}";
                command.Connection = connessioneDB;
                command.ExecuteNonQuery();
                connessioneDB.Close();

            } catch(Exception ex)
            {
                Label_RigheInteressate.Text = ex.Message;
            }
            }
            else
            {

            try
            {


                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();


                command.Parameters.AddWithValue("@Marca", TEXTBOX_Marca.Text);
                command.Parameters.AddWithValue("@Modello", TEXTBOX_Modello.Text);
                command.Parameters.AddWithValue("@Descrizione", TEXTBOX_Descrizione.Text);



                command.Parameters.AddWithValue("@PrezzoVendita", TEXTBOX_PrezzoVendita.Text);

                command.Parameters.AddWithValue("@PrezzoPrecedente", TEXTBOX_PrezzoPrecedente.Text);

                command.Parameters.AddWithValue("@InPromozione", CheckBox_InPromozione.Checked);

                command.Parameters.AddWithValue("@ID_Categoria", DropDownList_Categoria.SelectedItem.Value);

                command.CommandText = $"UPDATE Prodotto SET Marca = @Marca, Descrizione = @Descrizione, Modello = @Modello," +
                    $" PrezzoVendita = @PrezzoVendita, PrezzoPrecedente = @PrezzoPrecedente, InPromozione = @InPromozione, ID_Categoria = @ID_Categoria WHERE ID_Prodotto = {idQueryModifica}";
                command.Connection = connessioneDB;
                command.ExecuteNonQuery();
                connessioneDB.Close();

            }
            catch (Exception ex)
            {
                Label_RigheInteressate.Text = ex.Message;
            }

                Response.Redirect("ListaProdotti.aspx");

            }
        }

        protected void CheckBox_AggiungiCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_AggiungiCategoria.Checked)
            {
                DropDownList_Categoria.Visible = false;
                TEXTBOX_AggiungiCategoria.Visible = true;
                TEXTBOX_Marca.Visible = false;
                TEXTBOX_Descrizione.Visible = false;
                TEXTBOX_Modello.Visible = false;
                TEXTBOX_PrezzoVendita.Visible = false;
                CheckBox_InPromozione.Visible = false;
                FileUpload_Image.Visible = false;
                Label_Immagine.Visible = false;
                TEXTBOX_PrezzoPrecedente.Visible = false;
                CheckBox_EliminaCategoriaByName.Visible = false;

                Button_AggiungiProdotto.Text = "Crea Categoria";
                Button_ModificaProdotto.Text = "Crea Categoria";
            }
            else
            {
                DropDownList_Categoria.Visible = true;
                TEXTBOX_AggiungiCategoria.Visible = false;
                TEXTBOX_Marca.Visible = true;
                TEXTBOX_Descrizione.Visible=true;
                TEXTBOX_Modello.Visible=true;
                TEXTBOX_PrezzoVendita.Visible=true;
                CheckBox_InPromozione.Visible = true;
                FileUpload_Image.Visible = true;
                CheckBox_EliminaCategoriaByName.Visible = true;

                Button_AggiungiProdotto.Text = "Aggiungi Prodotto";
                Button_ModificaProdotto.Text = "Modifica Prodotto";
            }
        }

        protected void CheckBox_EliminaCategoriaByName_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_EliminaCategoriaByName.Checked)
            {
                
                DropDownList_Categoria.Visible = false;
                TEXTBOX_AggiungiCategoria.Visible = false;
                TEXTBOX_Marca.Visible = false;
                TEXTBOX_Descrizione.Visible = false;
                TEXTBOX_Modello.Visible = false;
                TEXTBOX_PrezzoVendita.Visible = false;
                CheckBox_InPromozione.Visible = false;
                FileUpload_Image.Visible = false;
                DropDownList_EliminaCategoria.Visible = true;
                Label_Immagine.Visible = false;
                TEXTBOX_PrezzoPrecedente.Visible = false;
                CheckBox_AggiungiCategoria.Visible = false;

                Button_AggiungiProdotto.Text = "Elimina";
                Button_ModificaProdotto.Text = "Elimina";
            }
            else
            {
                DropDownList_Categoria.Visible = true;
                TEXTBOX_AggiungiCategoria.Visible = true;
                TEXTBOX_Marca.Visible = true;
                TEXTBOX_Descrizione.Visible = true;
                TEXTBOX_Modello.Visible = true;
                TEXTBOX_PrezzoVendita.Visible = true;
                CheckBox_InPromozione.Visible = true;
                FileUpload_Image.Visible = true;
                DropDownList_EliminaCategoria.Visible = false;
                CheckBox_AggiungiCategoria.Visible = true;

                Button_AggiungiProdotto.Text = "Aggiungi Prodotto";
                Button_ModificaProdotto.Text = "Modifica Prodotto";

            }
        }
    }
}
