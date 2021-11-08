<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GestionDesTaches.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container  container-fluid align-content-center">
        <table class="table-borderless">
            <tr>
                <td>

                    <h2 class="">Bienvenu c'est la page d'acceuil
                    </h2>
                    <ul class="nav navbar-nav">
                        <li><a href="Superviseur.aspx" class="nav-link text-primary">Interface des superviseurs</a></li>
                        <li><a href="Tache.aspx" class="nav-link text-primary">Interface des tâches</a></li>
                        <li><a href="Employe.aspx" class="nav-link text-primary">Interface des employes</a></li>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
