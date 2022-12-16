<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="AggiungiProdotto.aspx.cs" Inherits="Build_Week_Gruppo_A.admin.AggiungiProdotto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <div>
            <a href="ListaProdotti.aspx">Torna a Lista Prodotti</a>
            <asp:TextBox ID="TEXTBOX_Marca" CssClass="form-control mt-1" placeholder="Marca" runat="server"></asp:TextBox>
            <asp:TextBox ID="TEXTBOX_Modello" CssClass="form-control mt-1" placeholder="Modello" runat="server"></asp:TextBox>
            <asp:TextBox ID="TEXTBOX_Descrizione" CssClass="form-control mt-1" placeholder="Descrizione" runat="server"></asp:TextBox>
            <asp:TextBox ID="TEXTBOX_PrezzoVendita" CssClass="form-control mt-1" placeholder="Prezzo Vendita" runat="server"></asp:TextBox>
            <div class="my-2">
                <asp:CheckBox ID="CheckBox_InPromozione" CssClass="mt-2" OnCheckedChanged="CheckBox_InPromozione_CheckedChanged" AutoPostBack="true" Checked="false" Text="In promozione?" runat="server" />
                <br />
                <asp:TextBox ID="TEXTBOX_PrezzoPrecedente" Visible="false" CssClass="form-control my-1" placeholder="Prezzo Precedente" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload_Image" runat="server" CssClass="mt-2" />
                <asp:Label ID="Label_Immagine" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="DropDownList_Categoria" runat="server" CssClass="ms-4"></asp:DropDownList>
                <br />
            </div>
            <asp:CheckBox ID="CheckBox_AggiungiCategoria"  OnCheckedChanged="CheckBox_AggiungiCategoria_CheckedChanged" AutoPostBack="true" Checked="false" Text="Creare nuova categoria?" runat="server" />
            <asp:TextBox ID="TEXTBOX_AggiungiCategoria" Visible="false" CssClass="form-control" placeholder="Nome della nuova categoria" runat="server"></asp:TextBox> <br />

            <asp:CheckBox ID="CheckBox_EliminaCategoriaByName"  OnCheckedChanged="CheckBox_EliminaCategoriaByName_CheckedChanged" AutoPostBack="true" Checked="false" Text="Eliminare una categoria?" runat="server" />
            <asp:DropDownList ID="DropDownList_EliminaCategoria" Visible="false" runat="server"></asp:DropDownList> <br />

            <asp:Button ID="Button_AggiungiProdotto" CssClass="btn btn-warning border-0 rounded-2 mt-3" OnClick="Button_AggiungiProdotto_Click" runat="server" Text="Aggiungi prodotto" />
            <asp:Button ID="Button_ModificaProdotto" Visible="false" CssClass="btn btn-warning border-0 rounded-2 mt-3" OnClick="Button_ModificaProdotto_Click" runat="server" Text="Modifica prodotto" />
            <asp:Label ID="Label_RigheInteressate" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
