<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="DettaglioProdotto.aspx.cs" Inherits="Build_Week_Gruppo_A.DettaglioProdotto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class=" container mt-5">
            <div class="details-cont d-block card mb-3">
                <div class="row g-0 p-4">
                    
                    <div class="col-9">
                        <div class="card-body mt-5 d-flex flex-column justify-content-between h-75">
                            <div>
                                <h2 class="card-title">
                                    <asp:Label ID="Nome" runat="server" Text="" Font-Bold="true" Font-Size="40px"></asp:Label></h2>
                                <p class="card-text">
                                    <asp:Label ID="Descrizione" runat="server" Text=""></asp:Label></p>
                            </div>
                            <div class="border-0 rounded-0">
                                <p class="card-text fs-3">Prezzo di Vendita:
                                    <asp:Label ID="Prezzo" ForeColor="Green" runat="server" Text="" Font-Bold="true"></asp:Label></p>
                                <asp:Label ID="Label_PrezzoPrecedenteBOX" Visible="false" runat="server" Text="Label">
                                    <p class="card-text">Prezzo Precedente:
                                        <asp:Label ID="Label_PrezzoPrecedente" runat="server" Text="" Font-Bold="true"></asp:Label></p>
                                </asp:Label>
                                <br />
                                <asp:DropDownList ID="DropDownList1" CssClass="mb-2"  runat="server"  MaxLength="5">
                                    <asp:ListItem Enabled="true"  Text="" Value=""></asp:ListItem>
                                    <%--<asp:ListItem Enabled="true" Text="" Value="" ></asp:ListItem>--%>
                                    <asp:ListItem Enabled="true" Selected="True"  Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Enabled="true" Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Enabled="true" Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Enabled="true" Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Enabled="true" Text="5"  Value="5"></asp:ListItem>
                                </asp:DropDownList><br />
                                <asp:Button ID="AddProduct" CssClass="btn btn-success dettaglio-bottone-compra " runat="server" Text="Aggiungi al Carrello" OnClick="AddProduct_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="img-box col-3 text-left">
                        
                        <asp:Image ID="Image1" CssClass="ms-5 py-5" runat="server" Width="200" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
