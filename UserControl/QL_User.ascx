<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QL_User.ascx.cs" Inherits="ThuVienSach.QL_User" %>

<div class="panel-input">
    <div class="header-panel">
        Chỉnh Sửa Dữ Liệu
    </div>

    <div class="content-panel-input">
        <table class="table table-responsive">
            <tr>
                <td>Tên Sinh Viên: </td>
                <td>
                    <asp:TextBox ID="txtTenSV" runat="server" autocomplete="off" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </td>
                <td>
<asp:RequiredFieldValidator ID="KTSV" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTenSV"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Mã Sinh Viên: </td>
                <td>
                    <asp:TextBox ID="txtMaSV" runat="server" autocomplete="off" CssClass="form-control" MaxLength="12"></asp:TextBox>  
                </td>
                <td></td>
            </tr>
             <tr>
                <td>Lớp: </td>
                <td>
                    <asp:TextBox ID="txtLop" runat="server" autocomplete="off" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLop"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>Email: </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="form-control" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Check" ErrorMessage="Email không hợp lệ" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Tên Tài Khoản: </td>
                <td>
                    <asp:TextBox ID="txtTaiKhoan" runat="server" autocomplete="off" CssClass="form-control" MaxLength="12"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTaiKhoan"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Mật Khẩu: </td>
                <td>
                    <asp:TextBox ID="txtMatKhau" runat="server" autocomplete="off" CssClass="form-control" MaxLength="12"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatKhau"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>số năm kích hoạt: </td>
                <td>
                    <asp:TextBox ID="txtNam" Text="1" runat="server" autocomplete="off" CssClass="form-control" MaxLength="1"></asp:TextBox>
                </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNam"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="chỉ cho phép 1-> 5 năm" ControlToValidate="txtNam" ForeColor="Red" ValidationGroup="Check" MinimumValue="1" MaximumValue="5"></asp:RangeValidator>
                 </td>
            </tr>
        </table>
        <div class="Event-Click">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-info" ValidationGroup="Check" OnClick="btnThem_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được thêm vào ?')) return false;" />&emsp;
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" CssClass="btn btn-success" ValidationGroup="Check" OnClick="btnCapNhat_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được cập nhật ?')) return false;" />&emsp;
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnXoa_Click" OnClientClick="if(!confirm('Mọi thông tin liên quan đến sinh viên này sẽ bị xóa ?')) return false;" />&emsp;
             <asp:Button ID="btnXoaAll" runat="server" Text="Xóa dữ liệu tài khoản hết hạn" CssClass="btn btn-danger" OnClick="btnXoaAll_Click" OnClientClick="if(!confirm('Mọi thông tin liên quan đến những sinh viên này sẽ bị xóa ?')) return false;" />
        </div>
    </div>
</div>

<div class="content-show-data">
    <div class="header-panel">
        Hiển Thị Dữ Liệu
    </div>

    <div class="content-panel-show-data">
        <asp:GridView ID="tableUser" ClientIDMode="Static" runat="server" CssClass="display cell-border" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaThe" HeaderText="Mã Thẻ" />
                <asp:BoundField DataField="TenSV" HeaderText="Tên Sinh Viên" />
                <asp:BoundField DataField="MSSV" HeaderText="Mã Sinh Viên" />
                <asp:BoundField DataField="Lop" HeaderText="Lớp" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="UserTK" HeaderText="Tên Tài Khoản" />
                 <asp:BoundField DataField="ThoiHan" HeaderText="Thời Hạn" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<script type="text/javascript">
    //code chay table
    $(document).ready(function () {
        $("#tableUser").DataTable({

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

    $('#tableUser tbody').on('click', 'tr', function () {
        var s = $(this).closest("tr").find("td").first().text().trim();

        window.location.href = "/QuanLyNguoiDoc/TKND/" + s;
    });

</script>
