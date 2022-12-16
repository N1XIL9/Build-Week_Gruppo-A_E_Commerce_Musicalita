<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="DettagliOrdine.aspx.cs" Inherits="Build_Week_Gruppo_A.DettagliOrdine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">

                <asp:GridView ID="GridDettaglioOrdine" CssClass="table table-bordered  table-striped table-light container-tabella " runat="server"
            AutoGenerateColumns="false" ItemType="Build_Week_Gruppo_A.ClasseDettaglio" Visible="true">
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
                        <p><%# Item.Totale.ToString("c2") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantita">
                    <ItemTemplate>
                        <p><%# Item.Quantita %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Data">
                    <ItemTemplate>
                        <p><%# Item.DataOrdine.ToString("d") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
