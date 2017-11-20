<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kefron._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:TextBox ID="txtName" runat="server" MaxLength="50" placeholder="Name"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" placeholder="Address"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtDateOfBirth" runat="server" MaxLength="50" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" placeholder="Email" TextMode="Email"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:ListBox ID="listMenu" runat="server" SelectionMode="Multiple"></asp:ListBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
    </div>

</asp:Content>
