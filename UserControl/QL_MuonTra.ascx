<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QL_MuonTra.ascx.cs" Inherits="ThuVienSach.QL_MuonTra" %>

<div class="panel-input">
    <div class="header-panel">
        Chỉnh Sửa Dữ Liệu
    </div>

    <div class="content-panel-input">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table class="table table-responsive">
                    <tr>
                        <td>Tên Sách: </td>
                        <td>
                            <asp:TextBox ID="txtTenSach" ClientIDMode="Static" autocomplete="off" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTenSach"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Mã Thẻ: </td>
                        <td>
                            <asp:TextBox ID="txtMaThe" ClientIDMode="Static" autocomplete="off" AutoPostBack="true" runat="server" OnTextChanged="txtMaThe_TextChanged" CssClass="form-control" MaxLength="12"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="KTSV" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMaThe"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Tên SV: </td>
                        <td>
                            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" MaxLength="100" Enabled="false"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Ngày Mượn: </td>
                        <td>
                            <asp:TextBox ID="txtNgayMuon" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Số Ngày Mượn: </td>
                        <td>
                            <asp:TextBox ID="txtMuon" runat="server" AutoPostBack="true" OnTextChanged="txtMuon_TextChanged" autocomplete="off" CssClass="form-control" MaxLength="3"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMuon"></asp:RequiredFieldValidator>
                            <asp:Label ID="lbMuon" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày Trả: </td>
                        <td>
                            <asp:TextBox ID="txtNgayTra" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Tình Trạng: </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True">Đang Chờ</asp:ListItem>
                                <asp:ListItem>Đã Duyệt</asp:ListItem>
                                <asp:ListItem>Đang Mượn</asp:ListItem>
                                <asp:ListItem>Đã Trả</asp:ListItem>
                                <asp:ListItem>Chưa Trả</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Ghi Chú Thư Viện: </td>
                        <td>
                            <asp:TextBox ID="txtGhiChuNV" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="87px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>Ghi Chú Sinh Viên: </td>
                        <td>
                            <asp:TextBox ID="txtGhiChuSV" autocomplete="off" runat="server" CssClass="form-control" TextMode="MultiLine" Height="87px" Enabled="false"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtMaThe" />
                <asp:AsyncPostBackTrigger ControlID="txtMuon" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="Event-Click">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-info" ValidationGroup="Check" OnClick="btnThem_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được thêm vào ?')) return false;" />&emsp;
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" CssClass="btn btn-success" ValidationGroup="Check" OnClick="btnCapNhat_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được cập nhật ?')) return false;" />&emsp;
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnXoa_Click" OnClientClick="if(!confirm('Dữ liệu sẽ bị xóa ?')) return false;" />&emsp;
        <asp:Button ID="btnChuaTra" runat="server" Text="Lọc dữ liệu chưa trả" CssClass="btn btn-warning" OnClick="btnChuaTra_Click" />
        </div>
    </div>
</div>

<div class="content-show-data">
    <div class="header-panel">
        Hiển Thị Dữ Liệu
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="padding: 10px 20px;">
                Lọc Dữ Liệu: &emsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Đầy Đủ</asp:ListItem>
                    <asp:ListItem>Đang Chờ</asp:ListItem>
                    <asp:ListItem>Đã Duyệt</asp:ListItem>
                    <asp:ListItem>Đang Mượn</asp:ListItem>
                    <asp:ListItem>Đã Trả</asp:ListItem>
                    <asp:ListItem>Chưa Trả</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="content-panel-show-data">
                <asp:GridView ID="tableMuonTra" ClientIDMode="Static" runat="server" CssClass="display cell-border" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="MaMuon" HeaderText="Mã Mượn" />
                        <asp:BoundField DataField="MaThe" HeaderText="Mã Thẻ" />
                        <asp:BoundField DataField="TenSV" HeaderText="Tên Sinh Viên" />
                        <asp:BoundField DataField="TenSach" HeaderText="Tên Sách" />
                        <asp:BoundField DataField="SoLuong" HeaderText="Tên Sách" />
                        <asp:BoundField DataField="NgayMuon" HeaderText="Ngày Mượn" />
                        <asp:BoundField DataField="NgayTra" HeaderText="Ngày Trả" />
                        <asp:BoundField DataField="TinhTrang" HeaderText="Tình Trạng" />
                        <asp:BoundField DataField="GhiChuSV" HeaderText="Ghi Chú SV" />
                    </Columns>
                </asp:GridView>
            </div>

            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    //code chay table
                    $(document).ready(function () {
                        $('#tableMuonTra').DataTable({
                            retrieve: true,

                            language: {
                                "sProcessing": "Đang xử lý...",
                                "sLengthMenu": "Xem _MENU_ mục",
                                "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                                "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                                "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                                "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                                "sInfoPostFix": "",
                                "sSearch": "Tìm Kiếm:",
                                "sUrl": "",
                                "oPaginate": {
                                    "sFirst": "Đầu",
                                    "sPrevious": "Trước",
                                    "sNext": "Tiếp",
                                    "sLast": "Cuối"
                                }
                            },
                        });
                    });
                });

                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    $('#tableMuonTra tbody').on('click', 'tr', function () {
                        var s = $(this).closest("tr").find("td").first().text().trim();

                        window.location.href = "/QuanLyMuonTra/MTS/" + s;
                    });
                });
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" />
        </Triggers>
    </asp:UpdatePanel>
</div>

<script type="text/javascript">
    //Autocomplete
    $(function () {
        $("#txtMaThe").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/AjaxServer.asmx/GetItemUser",
                    data: "{Name : '" + request.term + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },

                });
            },

            minlenght: 1,
        });

        $("#txtTenSach").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/AjaxServer.asmx/GetItemsach",
                    data: "{Name : '" + request.term + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },

                });
            },

            minlenght: 1,
        });
    });

    //code chay table
    $(document).ready(function () {
        $('#tableMuonTra').DataTable({
            retrieve: true,

            language: {
                "sProcessing": "Đang xử lý...",
                "sLengthMenu": "Xem _MENU_ mục",
                "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                "sInfoPostFix": "",
                "sSearch": "Tìm Kiếm:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Đầu",
                    "sPrevious": "Trước",
                    "sNext": "Tiếp",
                    "sLast": "Cuối"
                }
            },
        });
    });

    $('#tableMuonTra tbody').on('click', 'tr', function () {
        var s = $(this).closest("tr").find("td").first().text().trim();

        window.location.href = "/QuanLyMuonTra/MTS/" + s;
    });

</script>
