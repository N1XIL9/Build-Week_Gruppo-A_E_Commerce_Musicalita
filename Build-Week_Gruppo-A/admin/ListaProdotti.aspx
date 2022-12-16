<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="ListaProdotti.aspx.cs" Inherits="Build_Week_Gruppo_A.admin.ListaProdotti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container justify-content-center">     
        
        <a class="text-center" href="AggiungiProdotto.aspx">Aggiungi un nuovo Prodotto</a>
    <asp:GridView ItemType="Build_Week_Gruppo_A.Prodotto" AutoGenerateColumns="false" CssClass="table table-secondary table-striped border-0" ID="GridView_ListaProdotti" runat="server">
        <Columns>
            <asp:BoundField DataField="Marca" HeaderText="Marca"  />
            <asp:BoundField DataField="Modello" HeaderText="Modello" />
            <asp:BoundField DataField="PrezzoVendita" HeaderText="Prezzo al pubblico" DataFormatString="{0:C}" />
            <asp:BoundField DataField="PrezzoPrecedente" HeaderText="Prezzo precedente" DataFormatString="{0:C}" />
            <asp:CheckBoxField runat="server" DataField="InPromozione" HeaderText="In Promozione"></asp:CheckBoxField>
            <asp:BoundField DataField="Tipologia" HeaderText="Categoria"/>
            <asp:TemplateField>
                
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Modifica" CssClass="bg-light" OnClick="Button1_Click" CommandArgument="<%#Item.ID_Prodotto %>" />
                    <asp:Button ID="Button2" runat="server" Text="X" CssClass="bg-danger" OnClick="Button2_Click" CommandArgument="<%#Item.ID_Prodotto %>" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
        </div>

</asp:Content>