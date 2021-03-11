<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioSach.ascx.cs" Inherits="ThuVienSach.GioSach" %>

<div class="col-lg-12">
    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align: center;">
            <h4>Bạn chưa đăng nhập</h4>
            <br />
            <a href="/DangNhapThanhVien" class="btn btn-info">Đăng Nhập</a>
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
            <ItemTemplate>
                <div class="col-md-12">
                    <div class="panel-body">
                        <div style="border: solid 1px #808080; color: #000000; background-image: linear-gradient(to top, #a8edea 0%, #fed6e3 100%); font-weight: bold;">
                            <table class="table table-responsive">
                                <tr>
                                    <td>Tên sách:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("TenSach")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Số lượng:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("SoLuong")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Ghi Chú Sinh Viên:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("GhiChuSV")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Ghi Chú Thư Viện:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("GhiChuNV")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Ngày Mượn:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("NgayMuon")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Ngày Trả:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("NgayTra")%>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Tình Trạng:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TinhTrang")%>' ForeColor="Green"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnHuy" OnCommand="btnHuy_Command" CommandArgument='<%# Eval("MaMuon") %>' runat="server" Text="Hủy" CssClass="btn btn-danger" OnClientClick="if(!confirm('Bạn muốn hủy mượn sách ?')) return false;" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
</div>
