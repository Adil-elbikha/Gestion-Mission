<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Superviseur.aspx.cs" Inherits="GestionDesTaches.Superviseur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 167px;
        }

        .auto-style2 {
            width: 114px;
        }

        .auto-style3 {
            width: 197px;
        }

        .auto-style4 {
            width: 198px;
        }

        .auto-style5 {
            width: 162px;
        }

        .auto-style6 {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="form-control border-0" runat="server" Text="Id superviseur : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TbIdSuperviseur" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td >
                    <asp:Label ID="Label2" CssClass="form-control border-0" runat="server" Text="Matricule : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TbMatricule" CssClass="form-control " runat="server" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" CssClass="form-control border-0" Text="Nom : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TbNom" CssClass="form-control " runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Label4" CssClass="form-control border-0" runat="server" Text="Prénom :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TbPrenom" CssClass="form-control " runat="server" Width="136px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label5" runat="server" CssClass="form-control border-0" Text="Address : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TbAddress" runat="server" CssClass="form-control " TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GvAfficher" runat="server" CssClass="table table-hover table-info border-0" Width="730px" OnSelectedIndexChanged="GvAfficher_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField CommandName="Select" ControlStyle-CssClass="btn btn-info" Text="Afficher" HeaderText="Action" />
                        </Columns>

                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtAjouter" runat="server" CssClass="btn btn-primary" Text="Ajouter" OnClick="BtAjouter_Click" />
                </td>
                <td>
                    <asp:Button ID="BtModifier" runat="server" CssClass="btn btn-secondary" Text="Modifier" OnClick="BtModifier_Click" />
                </td>
                <td>
                    <asp:Button ID="BtSupprimer" runat="server" CssClass="btn btn-secondary" Text="Supprimer" OnClick="BtSupprimer_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="BtVider" CssClass="btn btn-secondary" Text="Vider" OnClick="BtVider_Click" />
                </td>
            </tr>
        </table>

        <h3>
            <asp:Label runat="server" CssClass="form-control border-0" Text="Afficher :"></asp:Label></h3>

        <table>
            <tr>
                <td >
                    <asp:Label ID="Label6" runat="server" CssClass="form-control border-0" Text="Equipe de Superviseur : " Width="199px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlFiltreEquipe" runat="server" CssClass="form-control " AutoPostBack="True" OnSelectedIndexChanged="DdlFiltreEquipe_SelectedIndexChanged" Width="186px"></asp:DropDownList>
                </td>
                <td >
                    <asp:Label ID="Label7" runat="server" CssClass="form-control border-0" Text="Les superviseur qui s'appele : " Width="240px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlFiltrePrenom" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltrePrenom_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GvFiltre" runat="server" CssClass="table table-hover table-info table-responsive" Width="712px"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
