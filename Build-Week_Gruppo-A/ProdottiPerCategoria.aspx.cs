﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Build_Week_Gruppo_A
{
    public partial class ProdottiPerCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IdCategoria = Request.QueryString["IdCategoria"];

            if (!IsPostBack)
            {
                Prodotto.ListaProdotti.Clear();
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Musicalita"].ToString();
                connessioneDB.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM Prodotto Where ID_Categoria = {IdCategoria}";
                command.Connection = connessioneDB;

                SqlDataReader reader = command.ExecuteReader();

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
                REPEATER_SelectAllFromCategoria.DataSource = Prodotto.ListaProdotti;
                REPEATER_SelectAllFromCategoria.DataBind();

                connessioneDB.Close();
            }
        }


        protected void Button_AggiungiCarrello_Click(object sender, EventArgs e)
        {
            Button AggiungiCarrello = (Button)sender;
            int idProdottoAggiunto = Convert.ToInt32(AggiungiCarrello.CommandArgument);
            string IdCategoria = Request.QueryString["IdCategoria"];

            foreach (Prodotto chitarra in Prodotto.ListaProdotti)
            {
                if (chitarra.ID_Prodotto == Convert.ToInt32(idProdottoAggiunto))
                {
                    Prodotto.CarrelloUtente.Add(chitarra);
                    Response.Redirect($"/ProdottiPerCategoria.aspx?IdCategoria={IdCategoria}");

                }
            }
        }
    }
    }
