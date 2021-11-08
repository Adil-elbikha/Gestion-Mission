<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tache.aspx.cs" Inherits="GestionDesTaches.Tache" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 210px;
        }

        .auto-style2 {
            width: 105px;
        }

        .auto-style3 {
            width: 216px;
        }

        .auto-style4 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }

        .auto-style5 {
            width: 51px;
        }

        .auto-style6 {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label runat="server" CssClass="form-control border-0" Text="Id Tache :"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="TbIdTache" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:Label runat="server" CssClass="form-control border-0" Text="Description :"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox runat="server" CssClass="auto-style4" ID="TbDescription" Width="185px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label runat="server" CssClass="form-control border-0" Text="Date d'échéance :"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="TbDateDecheance" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GvAfficher" CssClass="table table-hover table-info" runat="server" OnSelectedIndexChanged="GvAfficher_SelectedIndexChanged" Width="965px">
                        <Columns>
                            <asp:ButtonField CommandName="Select" ControlStyle-CssClass="btn btn-info" HeaderText="Action" ShowHeader="True" Text="Afficher" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button runat="server" Text="Ajouter" ID="BtAjouter" OnClick="BtAjouter_Click" CssClass="btn btn-primary" />
                </td>
                <td class="auto-style3">
                    <asp:Button runat="server" Text="Modifier" ID="BtModifier" OnClick="BtModifier_Click" CssClass="btn btn-secondary" />
                </td>
                <td>
                    <asp:Button runat="server" Text="Supprimer" ID="BtSupprimer" OnClick="BtSupprimer_Click" CssClass="btn btn-secondary" />
                </td>
                <td>
                    <asp:Button runat="server" CssClass="btn btn-secondary" Text="Vider" ID="BtVider" OnClick="BtVider_Click" />
                </td>
            </tr>
        </table>
        <h3>
            <asp:Label runat="server" CssClass="form-control border-0" Text="Afficher selon : "></asp:Label></h3>
        <table>
            <tr>
                <td class="auto-style6">
                    <asp:Label runat="server" CssClass="form-control border-0" Text="Date de création : " Width="164px"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList runat="server" CssClass="auto-style4" ID="DdlFiltreDDCreation" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltreDDCreation_SelectedIndexChanged" Width="175px"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label runat="server" CssClass="form-control border-0" Text="Date d'écheance : " Width="173px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="auto-style4" ID="DdlFiltreDDecheance" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltreDDecheance_SelectedIndexChanged" Width="218px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView runat="server" CssClass="table table-hover table-info" ID="GvFiltres" Width="972px"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
