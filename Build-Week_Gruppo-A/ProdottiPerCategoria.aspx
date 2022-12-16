<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="ProdottiPerCategoria.aspx.cs" Inherits="Build_Week_Gruppo_A.ProdottiPerCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .widthImg{
            width: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="main-container" class="container mt-4 bg-light">
        <div class="row flex-wrap py-4 justify-content-around align-items-center border border-1 shadow ">
            <asp:Repeater ID="REPEATER_SelectAllFromCategoria" ItemType="Build_Week_Gruppo_A.Prodotto" runat="server">
                <ItemTemplate>
                    <div class="bg-white my-4  row col-12 col-md-6 col-lg-4 " style="min-height: 240px;">


                        <div class="col-4 d-flex align-items-center">
                            <a href="DettaglioProdotto.aspx?Id=<%# Item.ID_Prodotto %>"> 
                            <asp:Image CssClass="widthImg" ImageUrl='<%#"~/img/"  + Item.URLImg %>' runat="server" />
                            </a>
                        </div>
                        
                       
                        <div class="col-8 d-flex flex-column justify-content-between align-items-stretch ps-0">
                            <div>
                            <h2><%#Item.Marca %></h2>
                            <p class="fst-italic fs-6"><%#Item.Modello %></p>
                            <p class="fs-5"><b><%#Item.PrezzoVendita.ToString("c2") %> </b></p>

                            <asp:Label CssClass="letter-space"  Text='<%# "SCONTATO AL " + Math.Floor((Item.PrezzoPrecedente - Item.PrezzoVendita) * 100 / Item.PrezzoPrecedente) +"%" %>' Font-Bold="true" ForeColor="Green" Visible="<%#Item.InPromozione %>" runat="server" /> <br />
                            <asp:Label  Text='<%# "Risparmio: " + (Item.PrezzoPrecedente - Item.PrezzoVendita).ToString("c2") %>' Visible="<%#Item.InPromozione %>" runat="server" /> 
                            </div>
                            <div id="card-button" class="d-flex justify-content-center">
                            <a href="../DettaglioProdotto.aspx?Id=<%# Item.ID_Prodotto %>" class="stile-bottone btn btn-sm btn-dark w-50 px-1 fw-bold">Dettagli </a>
                            <asp:Button ID="Button_AggiungiCarrello" OnClick="Button_AggiungiCarrello_Click" CommandArgument="<%#Item.ID_Prodotto %>" runat="server" CssClass="stile-bottone-compra btn btn-sm btn-success w-50 px-1 fw-bold ms-1" Text="Compra" /> 
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

   <%-- <div class="container">
        <div class="row flex-wrap py-4 justify-content-start align-items-center">
            <asp:Repeater ID="REPEATER_SelectAllFromCategoria" ItemType="Build_Week_Gruppo_A.Prodotto" runat="server">
                <ItemTemplate>
                    <div class="bg-white py-5 row col-12 col-md-6 col-lg-4">


                        <div class="col-3">
                            <asp:Image CssClass="widthImg" ImageUrl='<%#"~/img/"  + Item.URLImg %>' runat="server" />
                        </div>
                        
                       
                        <div class="col-9">
                            <h2><%#Item.Marca %></h2>
                            <p><%#Item.Modello %></p>
                            <p>Prezzo: <b><%#Item.PrezzoVendita.ToString("c2") %>  </b></p>

                          
                            <asp:Label  Text='<%# "SCONTATO AL " + Math.Floor((Item.PrezzoPrecedente - Item.PrezzoVendita) * 100 / Item.PrezzoPrecedente) +"%" %>' Font-Bold="true" ForeColor="Green" Visible="<%#Item.InPromozione %>" runat="server" /> <br />
                            <asp:Label  Text='<%# "Risparmio: " + (Item.PrezzoPrecedente - Item.PrezzoVendita).ToString("c2") %>' Visible="<%#Item.InPromozione %>" runat="server" /> <br />

                             <a href="../DettaglioProdotto.aspx?Id=<%# Item.ID_Prodotto %>" class="btn btn-sm btn-dark"> Dettagli </a>
                            <asp:Button ID="Button_AggiungiCarrello" OnClick="Button_AggiungiCarrello_Click" CommandArgument="<%# Item.ID_Prodotto %>" runat="server" CssClass="btn btn-sm btn-success" Text="Aggiungi al carrello" />
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>
</asp:Content>
