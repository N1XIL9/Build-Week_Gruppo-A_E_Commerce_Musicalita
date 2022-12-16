<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar_Footer.Master" AutoEventWireup="true" CodeBehind="DettagliUtente.aspx.cs" Inherits="Build_Week_Gruppo_A.DettagliUtente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container mt-3">
    <div class="row d-flex justify-content-center align-items-center ">
      <div class="col-md-12 col-xl-4">

        <div class="card" style="border-radius: 15px;">
          <div class="card-body text-center">
            <div class="mt-3 mb-4">
             <i class="bi bi-person-circle rounded-circle img-fluid" style="font-size: 100px;" ></i>
            </div>
            <h4 class="mb-2"> <asp:Label ID="Label_NomeCognome" runat="server" Text="Nome Cognome"></asp:Label> </h4>
            <p class="text-muted mb-4">@<asp:Label ID="Label_Username" runat="server" Text="Username"></asp:Label> <span class="mx-2">|</span> <a
                href="#"><asp:Label ID="Label_Email" runat="server" Text="email@email.it"></asp:Label> </a></p>
            <%--<div class="mb-4 pb-2">
              <button type="button" class="btn btn-outline-primary btn-floating">
                <i class="fab fa-facebook-f fa-lg"></i>
              </button>
              <button type="button" class="btn btn-outline-primary btn-floating">
                <i class="fab fa-twitter fa-lg"></i>
              </button>
              <button type="button" class="btn btn-outline-primary btn-floating">
                <i class="fab fa-skype fa-lg"></i>
              </button>
            </div>--%>
              <asp:LinkButton CssClass="mb-3" ID="LinkButton_ModificaPassword" PostBackUrl="#" runat="server" OnClick="LinkButton_ModificaPassword_Click" >Modifica Password</asp:LinkButton> <br />
              <div id="modificapswBox" runat="server" class="d-flex flex-column align-items-center mt-1" Visible="false">
                  <asp:TextBox ID="oldPassword" runat="server" CssClass="w-75 mt-1" placeholder="Inserisci la password attuale" ></asp:TextBox>
                  <asp:Label ID="ErroreOldPsw" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                  <asp:TextBox ID="newPassword" runat="server" CssClass="w-75 mt-1" placeholder="Inserisci la nuova password"></asp:TextBox>
                  <asp:Button ID="ModificaPwd" CssClass="w-50 mt-3 bg-black border rounded p-1 text-white" runat="server" OnClick="ModificaPwd_Click" Text="Invia"/>
              </div>



              <asp:Button ID="Button_iTuoiOrdini" CssClass="btn btn-dark btn-rounded btn-lg mt-5 mb-2" OnClick="Button_iTuoiOrdini_Click" runat="server" Text="I tuoi ordini" /> <br />

              <asp:LinkButton OnClick="LinkButton_Logout_Click" CssClass="mt-3 " ID="LinkButton_Logout" PostBackUrl="#" runat="server" >Esci</asp:LinkButton> <br />
              
            <%--<div class="d-flex justify-content-between text-center mt-5 mb-2">
              <div>
                <p class="mb-2 h5">8471</p>
                <p class="text-muted mb-0">Wallets Balance</p>
              </div>
              <div class="px-3">
                <p class="mb-2 h5">8512</p>
                <p class="text-muted mb-0">Income amounts</p>
              </div>
              <div>
                <p class="mb-2 h5">4751</p>
                <p class="text-muted mb-0">Total Transactions</p>
              </div>
            </div>--%>
          </div>
        </div>

      </div>
    </div>
  </div>

</asp:Content>
