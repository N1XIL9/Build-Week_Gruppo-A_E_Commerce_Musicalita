<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="Build_Week_Gruppo_A.Carrello" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .container-tabella {
           overflow:hidden;
           border-radius: 1em!important;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container ">
        <a href="../Default.aspx"><asp:Label ID="lblEmptyCart" runat="server" Text="Il tuo carrello è vuoto... Torna alla pagina prodotti"></asp:Label></a><hr />
        <asp:GridView ID="GridCarrello" CssClass="table table-bordered  table-striped table-light container-tabella " runat="server"
            AutoGenerateColumns="false" ItemType="Build_Week_Gruppo_A.Prodotto" Visible="true">
            <Columns>
                <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate>
                        <p class="ps-2"><%# Item.Marca %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Modello">
                    <ItemTemplate>
                        <p><%# Item.Modello %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prezzo">
                    <ItemTemplate>
                        <p><%# Item.PrezzoVendita.ToString("c2") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantita">
                    <ItemTemplate>
                        <p><%# Item.Quantita %></p>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

         <asp:Label ID="Label_RigheInteressate" runat="server" Visible="false" Text=""></asp:Label>

    </div>
    <div class="container">
        <div>
            <p class="float-end bg-light rounded ps-2">Totale:
                <asp:Label ID="lblTotCarrello" runat="server" Text="" Font-Bold="true"></asp:Label>
                <asp:Button OnClick="Button_EffettuaOrdine_Click" CssClass="btn btn-success" ID="Button_EffettuaOrdine" runat="server" Text="Effettua Ordine" />
            </p>
            
        </div>
        <div>
            <asp:Button ID="Delete" runat="server" Text="Svuota Carrello" OnClick="Delete_Click" CssClass="border btn btn-dark " Visible="true" />
        </div>
    </div>
</asp:Content>
