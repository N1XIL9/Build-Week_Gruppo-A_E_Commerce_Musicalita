<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="BarraDiRicerca.aspx.cs" Inherits="Build_Week_Gruppo_A.BarraDiRicerca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
         sbprodotti-cont div{

         }
     </style>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container w-100 bg-white border rounded">
        <div class="row justify-content-around align-items-center">
            <asp:Repeater ID="REPEATER_Ricerca" ItemType="Build_Week_Gruppo_A.Prodotto" runat="server">
                <ItemTemplate>
                    <div class="sbprodotti-cont align-items-center bg-white my-2 row col-12 col-md-6 col-lg-4 rounded px-0">


                        <div class="col-4">
                            <asp:Image CssClass="widthImg" ImageUrl='<%#"~/img/"  + Item.URLImg %>' runat="server" />
                        </div>
                        
                       
                        <div class="col-8">
                            <h2><%#Item.Marca %></h2>
                            <p><%#Item.Modello %></p>
                            <p>Prezzo: <b><%#Item.PrezzoVendita.ToString("c2") %>  </b></p>

                              <asp:Label  Text='<%# "SCONTATO AL " + Math.Floor((Item.PrezzoPrecedente - Item.PrezzoVendita) * 100 / Item.PrezzoPrecedente) +"%" %>' Font-Bold="true" ForeColor="Green" Visible="<%#Item.InPromozione %>" runat="server" /> <br />
                            <asp:Label  Text='<%# "Risparmio: " + (Item.PrezzoPrecedente - Item.PrezzoVendita).ToString("c2") %>' Visible="<%#Item.InPromozione %>" runat="server" /> <br />


                            <div id="card-button" class="d-flex justify-content-center">
                            <a href="../DettaglioProdotto.aspx?Id=<%# Item.ID_Prodotto %>" class="stile-bottone btn btn-sm btn-dark w-50 px-1 fw-bold">Dettagli </a>
                            <asp:Button ID="Button_AggiungiCarrello" OnClick="Button_AggiungiCarrello_Click1" CommandArgument="<%#Item.ID_Prodotto %>" runat="server" CssClass="stile-bottone-compra btn btn-sm btn-success w-50 px-1 fw-bold ms-1" Text="Compra" /> 
                            </div>

                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:Label ID="Label_ERRORE" runat="server" Text=""></asp:Label>

</asp:Content>
