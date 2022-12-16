<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="Registrazione.aspx.cs" Inherits="Build_Week_Gruppo_A.Registrazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-2">
        <div class="row justify-content-center">
            <div id="register-container" style="max-width: 80%;" class="d-flex flex-wrap justify-content-between">
                <asp:TextBox ID="TEXTBOX_Nome" CssClass="form-control mt-2" placeholder="Nome" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="Nome_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Nome"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_Cognome" CssClass="form-control mt-2" placeholder="Cognome" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="Cognome_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Cognome"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_Email" CssClass="form-control mt-2" placeholder="Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="Email_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Email"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_Username" CssClass="form-control mt-2" placeholder="Username" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="Username_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Username"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_Password" CssClass="form-control mt-2" placeholder="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="Password_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Password"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_ConfermaPassword" CssClass="form-control mt-2" placeholder="Conferma Password" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator_Password" runat="server" ErrorMessage="La password non corrisponde" 
                    ControlToCompare="TEXTBOX_Password" ControlToValidate="TEXTBOX_ConfermaPassword" Display="Dynamic" EnableClientScript="true"></asp:CompareValidator>
                <asp:TextBox ID="TEXTBOX_Indirizzo" CssClass="form-control mt-2" placeholder="Indirizzo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  Display="Dynamic" ID="Indirizzo_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_Indirizzo"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TEXTBOX_DatadiNascita" TextMode="Date" CssClass="form-control mt-2" placeholder="Data di Nascita" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  Display="Dynamic" ID="Data_Validator" runat="server" ErrorMessage="Campo richiesto" ValidationGroup="Dati_Registrazione" ControlToValidate="TEXTBOX_DatadiNascita"></asp:RequiredFieldValidator>
                <asp:Button ID="Button_Registrazione" CssClass="w-100 btn btn-lg btn-dark mt-2" runat="server" Text="Registrati" OnClick="Button_Registrazione_Click" ValidationGroup="Dati_Registrazione" />
                <asp:Label ID="Label_ErroreRegistrazione" runat="server" Visible="false" Text=""></asp:Label>
            </div>
        </div>
    </div>
    
</asp:Content>
