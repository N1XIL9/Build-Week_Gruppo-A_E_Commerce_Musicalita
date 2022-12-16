<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Build_Week_Gruppo_A.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div style="max-width: 300px">
                <h1 class="text-center">Accedi</h1>
                <asp:TextBox ID="TextBox_Username" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox_Password" CssClass="form-control mt-1" placeholder="Password" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CheckBox_RicordamiAccedi" runat="server" /> <span style="font-size:12px">Ricordami</span>
                <asp:Button ID="Button_Accedi" CssClass="w-100 btn btn-lg btn-dark" Text="Accedi" OnClick="Button_Accedi_Click" runat="server" />
                <p class="text-center bg-white rounded">Non sei registrato? <a href="/Registrazione.aspx">Registrati</a></p>
                <asp:Label ID="Label_ERROR" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
