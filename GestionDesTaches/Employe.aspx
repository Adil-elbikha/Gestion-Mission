<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employe.aspx.cs" Inherits="GestionDesTaches.Employe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .auto-style1 {
            width: 84px;
        }
        .auto-style3 {
            width: 205px;
        }
        .auto-style5 {
            width: 129px;
        }
        .auto-style6 {
            width: 203px;
        }
        .auto-style7 {
            width: 92px;
        }
        .auto-style8 {
            width: 590px;
        }
        .auto-style9 {
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
        .auto-style10 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            margin-left: 22;
            background-color: #fff;
        }
        .auto-style12 {
            width: 114px;
        }
        .auto-style13 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            margin-left: 17;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-md">
    <table>
        <tr>
            <td colspan="2">
                <table >
                    <tr>
                        <td class="auto-style3">
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Id Employe :"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox runat="server" CssClass="form-control" ID="TbIdEmploye" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Matricule :"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:TextBox runat="server" CssClass="auto-style9" ID="TbMatricule" Width="176px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Nom :"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox runat="server" CssClass="form-control" ID="TbNom"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Prénom :"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:TextBox runat="server" CssClass="auto-style9" ID="TbPrenom" Width="172px" ></asp:TextBox>
                        </td>
                   </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Address :"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox runat="server" CssClass="form-control" ID="TbAddress" TextMode="MultiLine" Height="44px" Width="175px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label runat="server" CssClass="form-control border-0" Text="Superviseur :"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:DropDownList runat="server" CssClass="auto-style9" ID="DdlSuperviseur" Width="184px" ></asp:DropDownList>
                        </td>
                   </tr>
                    <tr>
                        <td colspan="4">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="GvAfficher" Width="1001px" CssClass="table table-hover table-info" OnSelectedIndexChanged="GvAfficher_SelectedIndexChanged">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" ControlStyle-CssClass="btn btn-info" HeaderText="Action" Text="Afficher" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Ajouter" ID="BtAjouter" OnClick="BtAjouter_Click" />
                        </td>
                        <td class="auto-style6">
                            <asp:Button runat="server" CssClass="btn btn-secondary" Text="Modifier" ID="BtModifier" OnClick="BtModifier_Click" />
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="btn btn-secondary" Text="Supprimer" ID="BtSupprimer" OnClick="BtSupprimer_Click" />
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="btn btn-secondary" Text="Vider" ID="BtVider" OnClick="BtVider_Click" />
                        </td>
                    </tr>
            </table>
        </td>
        </tr>
        <tr>
            <td class="auto-style8">
             <h3> <asp:Label runat="server" CssClass="form-control border-0" Text="Afficher selon : "></asp:Label></h3>  
          <table>
        <tr>
            <td>
                <asp:Label runat="server" CssClass="form-control border-0" Text="Taches : " Width="86px"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="auto-style10" ID="DdlFiltreTaches" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltreTaches_SelectedIndexChanged" Width="168px"></asp:DropDownList>
            </td>
            <td class="auto-style1">
                <asp:Label runat="server" CssClass="form-control border-0" Text="Address : " Width="96px"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="DdlFiltreAddress" CssClass="auto-style9" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltreAddress_SelectedIndexChanged" Width="189px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="GvFiltres" CssClass="table table-hover table-info" Width="647px"></asp:GridView>
                </div>
            </td>
        </tr>
    </table> 
            </td>
            <td>
                <h3><asp:Label runat="server" CssClass="form-control border-0" Text="Affectation des taches"></asp:Label></h3>
                <table>
                    <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label1" runat="server" CssClass="form-control border-0" Text="Employe " Width="84px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlAffectationEmploye" CssClass="auto-style9" runat="server" Width="177px"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="form-control border-0" Text="Tache " Width="55px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlAffectationTache" CssClass="auto-style13" runat="server" Width="158px"></asp:DropDownList>
                    </td>
                        </tr>
                    <tr>
                        <td colspan="4">
                                <asp:Button ID="BtAffecter" runat="server" CssClass="btn btn-primary btn-block" Text="Affecter" OnClick="BtAffecter_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary btn-block" Text="Desaffecter" OnClick="BtDesaffecter_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
        </div>
</asp:Content>
