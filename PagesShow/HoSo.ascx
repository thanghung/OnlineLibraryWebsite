<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoSo.ascx.cs" Inherits="ThuVienSach.HoSo" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

<style>
    .form-control {
        width: 255px;
        height: 30px;
    }

    a:hover {
        text-decoration: none;
    }
</style>

<div class="col-lg-12">
    <table class="table table-responsive">
        <tr>
            <td>Mã Thẻ</td>
            <td>
                <asp:TextBox ID="txtMaThe" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tên</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Lớp</td>
            <td>
                <asp:TextBox ID="txtLop" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="30" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tài Khoản Đăng Nhập</td>
            <td>
                <asp:TextBox ID="txtTK" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>Hạn sử dụng tài khoản</td>
            <td>
                <asp:TextBox ID="txtThoiHan" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
             <td></td>
        </tr>
        <tr>
            <td colspan="2">&emsp;
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">Đổi Mật Khẩu</button>&emsp;
                <asp:Button ID="txtUpdate" runat="server" Text="Cập Nhật Thông Tin" CssClass="btn btn-info" OnClick="txtUpdate_Click"/>&emsp;
                <asp:Button ID="txtDangXuat" runat="server" Text="Đăng Xuất" CssClass="btn btn-danger" OnClick="txtDangXuat_Click" />
            </td>
        </tr>
    </table>
</div>

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog modal-lg">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" style="text-align: center;">Đổi Mật Khẩu</h4>
            </div>
            <div class="modal-body">
                <table class="table table-responsive">
                    <tr>
                        <td>Nhập Mật Khẩu Cũ: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtMKCu" runat="server" TextMode="Password" CssClass="form-control" MaxLength="12"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCu" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMKCu" ValidationGroup="DoiMK"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Nhập Mật Khẩu Mới: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" CssClass="form-control" MaxLength="12"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMatKhau" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatKhau" ValidationGroup="DoiMK"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Nhập Lại Mật Khẩu : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtRepeat" runat="server" TextMode="Password" CssClass="form-control" MaxLength="12"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeat" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepeat" ValidationGroup="DoiMK"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorRepeat" runat="server" ForeColor="Red" ErrorMessage="Mật Khẩu không trùng khớp" ControlToValidate="txtRepeat" ValidationGroup="DoiMK" ControlToCompare="txtMatKhau" Operator="Equal"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnDoiMK" ValidationGroup="DoiMK" runat="server" Text="Đổi mật khẩu" CssClass="btn btn-success" OnClick="btnDoiMK_Click" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
            </div>
        </div>

    </div>
</div>
