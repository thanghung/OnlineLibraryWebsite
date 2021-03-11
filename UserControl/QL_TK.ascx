<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QL_TK.ascx.cs" Inherits="ThuVienSach.QL_TK" %>

<div style="border: solid 2px #0e75bf;">
    <h1 style="text-align: center;">Quản Lý Tài Khoản</h1>
    <div style="padding: 1em; margin: 0 100px;">
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
            <tr>
                <td colspan="3">
                    &emsp;&emsp;&emsp;&emsp;<asp:Button ID="btnChangePass" runat="server" Text="Đổi mật khẩu" ValidationGroup="DoiMK" CssClass="btn btn-success" OnClick="btnChangePass_Click"/>&emsp;&emsp;
                      <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger" Text="Đăng xuất" OnClick="btnLogout_Click" />
                </td>
            </tr>
        </table>
    </div>

</div>
