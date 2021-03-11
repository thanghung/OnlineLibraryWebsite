<%@ Page Title="" Language="C#" MasterPageFile="~/Indext.Master" AutoEventWireup="true" CodeBehind="Indext.aspx.cs" Inherits="ThuVienSach.Indext2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
        <div style="margin-top: 5px;">
            <div style="padding: 10px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="panel-body">
                                        <div style="border: solid 1px #808080; color: #000000;background-image: linear-gradient(to top, #a8edea 0%, #fed6e3 100%); font-weight: bold;">
                                            <table class="table table-responsive">
                                                <tr>
                                                    <td>Tên sách :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("TenSach")%>'></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>Số lượng :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("SoLuong")%>'></asp:Label>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td>Xuất bản năm :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("NamXuatBan")%>'></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnID" OnCommand="btnID_Command" CommandArgument='<%# Eval("MaSach") %>' runat="server" Text="Chi Tiết" CssClass="btn btn-success" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>

                        <div style="overflow: hidden; text-align: center; margin-bottom: 10px; margin-top: 10px;">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <asp:Button ID="Button3" CssClass="btnpaging" runat="server" Text='<%# Container.DataItem%>' CommandArgument='<%# Container.DataItem%>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <style>
            .btnpaging {
                background: #ff6a00;
                border: solid 1px #000000;
            }

                .btnpaging:active {
                    background: #ffd800;
                }

                .btnpaging:focus {
                    background: #ffd800;
                }

                .btnpaging:hover {
                    background: #ffd800;
                }
        </style>
    </asp:Panel>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>
