<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="ThuVienSach.TrangChu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TrangChu</title>
    <link href="Css/Admin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <%--Auto Complete--%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <%--Datatable--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="body">
            <%-- Phần header--%>
            <div id="header">
                <img src="/Images/logo.png" />
            </div>

            <%--Giao diện chính--%>
            <div class="main">
                <%--Trái--%>
                <div class="left">
                    <div class="header-li">
                        Quản Lý Dữ Liệu
                    </div>

                    <ul id="Group-items">
                        <li><i class="fas fa-book"></i><a href="/QuanLySach">Sách</a></li>
                        <li><i class="fas fa-book"></i><a href="/QuanLyNhomSach/Nhom">Thể Loại</a></li>
                        <li><i class="fas fa-book"></i><a href="/QuanLyNhaXuatBan/NXB">Nhà Xuất Bản</a></li>
                        <li><i class="fas fa-book"></i><a href="/QuanLyTaiKhoan/TK">Tài Khoản Hệ Thống</a></li>
                        <li><i class="fas fa-book"></i><a href="/QuanLyNguoiDoc/TKND">Tài Khoản Người Đọc</a></li>
                        <li><i class="fas fa-book"></i><a href="/QuanLyMuonTra/MTS">Mượn Trả Sách &emsp;<asp:Label ID="Label2" runat="server" Text="Đang chờ duyệt (0)" ForeColor="Green"></asp:Label></a></li>
                    </ul>
                </div>

                <%-- Phải--%>
                <div class="right">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                        <div>
                            <div class="panel-input">
                                <div class="header-panel">
                                    Chỉnh Sửa Dữ Liệu
                                </div>

                                <div class="content-panel-input">
                                    <table class="table table-responsive">
                                        <tr>
                                            <td>Tên Sách: </td>
                                            <td>
                                                <asp:TextBox ID="txtTenSach" runat="server" autocomplete="off" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTenSach" ValidationGroup="Check"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Thể Loại: </td>
                                            <td>
                                                <asp:TextBox ID="txtNhom" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox> 
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Check" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNhom"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Nhà Xuất Bản: </td>
                                            <td>
                                                <asp:TextBox ID="txtNhaXB" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td>Tác Giả: </td>
                                            <td>
                                                <asp:TextBox ID="txtTacGia" runat="server" CssClass="form-control" MaxLength="100" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td>File đính kèm: </td>
                                            <td colspan="2">
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <br />
                                                <br />
                                                <asp:Label ID="LbUpload" runat="server" Text=""></asp:Label>&emsp;<asp:Button ID="btnDownload" runat="server" Text="Tải xuống" OnClick="btnDownload_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Ghi chú: </td>
                                            <td>
                                                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control" autocomplete="off" TextMode="MultiLine" Height="70px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>Số Lượng: </td>
                                            <td>
                                                <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control" MaxLength="4" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Check" ErrorMessage="cho phép 1->1000 cuốn" ForeColor="Red" ControlToValidate="txtSoLuong" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Nơi Xuất Bản: </td>
                                            <td>
                                                <asp:TextBox ID="txtNoiXB" runat="server" CssClass="form-control" MaxLength="100" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td>   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Năm Xuất Bản: </td>
                                            <td>
                                                <asp:TextBox ID="txtNamXB" runat="server" CssClass="form-control" MaxLength="4" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ValidationGroup="Check" ErrorMessage="cho phép 100-9999" ForeColor="Red" ControlToValidate="txtNamXB" Type="Integer" MinimumValue="1" MaximumValue="9999"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />


                                    <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="Thêm Sách" OnClick="btnAdd_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được thêm vào ?')) return false;" ValidationGroup="Check" />&emsp;
                 <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" CssClass="btn btn-success" ValidationGroup="Check" OnClick="btnCapNhat_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được cập nhật ?')) return false;" />&emsp;
                 <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" ValidationGroup="Check" OnClick="btnXoa_Click" OnClientClick="if(!confirm('Mọi thông tin liên quan đến cuốn sách này sẽ bị xóa ?')) return false;" />&emsp;
        <button type="button" data-toggle="modal" class="btn btn-primary" data-target="#ModalExcel">Nhập thư mục excel</button>&emsp;
                       
            <asp:Button ID="btnXuat" runat="server" Text="Xuất File Excel" CssClass="btn btn-warning" OnClientClick="if(!confirm('Dữ liệu sẽ được xuất ra file Excel ?')) return false;" OnClick="btnXuat_Click" />&emsp;
                                    
                                </div>

                                <!-- Modal Excel -->
                                <div class="modal fade" id="ModalExcel" role="dialog">
                                    <div class="modal-dialog">
                                        <!-- Modal content-->
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 style="text-align: center;">Nhập File Excel</h4>
                                            </div>

                                            <div class="modal-body">
                                                <table class="table table-responsive">
                                                    <tr>
                                                        <td>Nhập dữ liệu Excel:
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="FileUpload2" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div class="modal-footer">
                                                <asp:Button ID="btnThem" runat="server" Text="Thêm dữ liệu" CssClass="btn btn-info" OnClick="btnThem_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được thêm vào ?')) return false;" />&emsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="content-show-data">
                                <div class="header-panel">
                                    Hiển Thị Dữ Liệu
                                </div>

                                <div class="content-panel-show-data">
                                    <asp:GridView ID="tableSach" ClientIDMode="Static" runat="server" CssClass=" display cell-border" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="MaSach" HeaderText="Mã Sách" />
                                            <asp:BoundField DataField="TenSach" HeaderText="Tên Sách" />
                                            <asp:BoundField DataField="TacGia" HeaderText="Tác Giả" />
                                            <asp:BoundField DataField="NhomSach" HeaderText="Thể Loại" />
                                            <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" />
                                            <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
                                            <asp:BoundField DataField="NhaXuatBan" HeaderText="Nhà Xuất Bản" />
                                            <asp:BoundField DataField="NoiXuatBan" HeaderText="Nơi Xuất Bản" />
                                            <asp:BoundField DataField="NamXuatBan" HeaderText="Năm Xuất Bản" />
                                            <asp:BoundField DataField="NgayNhap" HeaderText="Ngày Nhập" />
                                            <asp:TemplateField HeaderText="File">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Format(Eval("TenFile").ToString()) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <script>
                                    //code chay table dữ liệu
                                    $(document).ready(function () {
                                        $("#tableSach").DataTable({

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

                                </script>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>

            <%--Phần footer--%>
            <div id="footer">
                Bản quyền của trường Cao đẳng Kỹ Thuật Công nghệ Nha Trang
                <br />
                Địa chỉ: Đường N1, Khu trường học đào tạo và dạy nghề Bắc Hòn Ông – Phước Đồng – Nha Trang – Khánh Hòa<br />
                Cơ quan chủ quản: Ủy ban Nhân dân tỉnh Khánh Hòa<br />
            </div>
            <div class="cb"></div>
        </div>

        <script type="text/javascript">
            //Autocomplete
            $(function () {
                //Autocomplete
                $("#<%= txtTenSach.ClientID%>").autocomplete({
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

                //Nhóm Sách
                $("#<%= txtNhom.ClientID%> ").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/AjaxServer.asmx/GetItemNhomSach",
                            data: "{Name : '" + request.term + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("lỗi");
                            }
                        });
                    },

                    minlenght: 1,
                });

                //Nhà xuất bản
                $("#<%= txtNhaXB.ClientID%> ").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/AjaxServer.asmx/GetItemNXB",
                            data: "{Name : '" + request.term + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("lỗi");
                            }
                        });
                    },

                    minlenght: 1,
                });
            });

            $('#tableSach tbody').on('click', 'tr', function () {
                var s = $(this).closest("tr").find("td").first().text().trim();

                window.location.href = "/QuanLySach/" + s;
            });


            //Xóa QC
            var myVar = setInterval(function () { myTimer() }, 0);
            function myTimer() {
                var d = new Date();
                var t = d.toLocaleTimeString();
                $("div[style='opacity: 0.9; z-index: 2147483647; position: fixed; left: 0px; bottom: 0px; height: 65px; right: 0px; display: block; width: 100%; background-color: #202020; margin: 0px; padding: 0px;']").remove();
                $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
                $("iframe[src='http://www.superfish.com/ws/userData.jsp?dlsource=hhvzmikw&userid=NTBCNTBC&ver=13.1.3.15']").remove();
                $("div[onmouseover='S_ssac();']").remove();
                $("a[href='http://somee.com']").parent().remove();
                $("a[href='http://somee.com/VirtualServer.aspx']").parent().parent().parent().remove();
                $("#dp_swf_engine").remove();
                $("#TT_Frame").remove();
            }
        </script>
    </form>
</body>
</html>
