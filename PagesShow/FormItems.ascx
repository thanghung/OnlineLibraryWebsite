<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormItems.ascx.cs" Inherits="ThuVienSach.FormItems" %>

<style>
    a:hover {
        text-decoration: none;
    }
</style>

<asp:Panel ID="Panel1" runat="server">
    <asp:FormView ID="FormView1" runat="server" CssClass="row" RepeatLayout="Flow">
        <ItemTemplate>
            <div class="panel-body" style="color: #000000; font-weight: bold;">
                <div class="col-md-4">Tên Sách: &emsp;<asp:Label ID="Label4" runat="server" Text='<%# Eval("TenSach")%>'></asp:Label></div>
                <div class="col-md-4">Nhóm Sách: &emsp;<asp:Label ID="Label5" runat="server" Text='<%# Eval("NhomSach")%>'></asp:Label></div>
                <div class="col-md-4">Tác Giả: &emsp;<asp:Label ID="Label6" runat="server" Text='<%# Eval("TacGia")%>'></asp:Label></div>
                <div class="col-md-4">Nhà Xuất Bản: &emsp;<asp:Label ID="Label7" runat="server" Text='<%# Eval("NhaXuatBan")%>'></asp:Label></div>
                <div class="col-md-4">Nơi Xuất Bản: &emsp;<asp:Label ID="Label8" runat="server" Text='<%# Eval("NoiXuatBan")%>'></asp:Label></div>
                <div class="col-md-4">Năm Xuất Bản: &emsp;<asp:Label ID="Label9" runat="server" Text='<%# Eval("NamXuatBan")%>'></asp:Label></div>
                <div class="col-md-4">Số Lượng Còn Lại: &emsp;<asp:Label ID="Label10" runat="server" Text='<%# Eval("SoLuong")%>'></asp:Label></div>
                <div class="col-md-4">Ghi Chú: &emsp;<asp:Label ID="Label11" runat="server" Text='<%# Eval("GhiChu")%>'></asp:Label></div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    &emsp;&emsp;<asp:Button ID="btnTai" CssClass="btn btn-warning" OnClick="btnTai_Click" runat="server" Text="Tải File đính kèm" />
    &emsp;&emsp;
    <button type="button" id="btnShowPopup" class="btn btn-success" data-toggle="modal" data-target="#myModal">Đăng Ký Mượn Sách</button>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title" style="text-align: center; font-weight: bold;">Đăng Ký Ngay</h3>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel3" runat="server">
                        <div style="text-align: center;">
                            <h4>Bạn chưa đăng nhập </h4>
                            <button class="btn btn-warning"><a href="/DangNhapThanhVien">Đăng Nhập</a></button>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panel4" runat="server">
                        <div style="text-align: center;">
                            <h4>Thông tin mượn sách của bạn sẽ được duyệt sau 1 ngày</h4>
                            <table class="table">
                                <tr>
                                    <td>Ghi Chú : 
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtGhiChuSV" runat="server" TextMode="MultiLine" Width="200px" Height="100px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Mượn trong bao nhiêu ngày : 
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtSoLuong" runat="server" MaxLength="3" autocomplete="off"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="chỉ được từ 1-200 ngày" ValidationGroup="DK" ForeColor="Red" ControlToValidate="txtSoLuong" MinimumValue="1" MaximumValue="200" Type="Integer"></asp:RangeValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnDangKy" ValidationGroup="DK" runat="server" Text="Đăng ký mượn" CssClass="btn btn-success" OnClick="btnDangKy_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="panel-body">
                            <div style="border: solid 1px #808080; color: #000000; background-image: linear-gradient(to top, #a8edea 0%, #fed6e3 100%); font-weight: bold;">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

