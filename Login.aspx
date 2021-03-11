<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ThuVienSach.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Nhập</title>
    <link rel="stylesheet" type="text/css" href="/css/Login.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

      <%--Xóa QC--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-t-85 p-b-20">
                    <form class="login100-form validate-form">
                        <span class="login100-form-title">ĐĂNG NHẬP
                        </span>
                        <span class="login100-form-avatar">
                            <img src="../Images/logoicon.jpg" />
                        </span>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="wrap-input100 validate-input" data-validate="Enter username">
                            <input class="input100" id="txtTK" runat="server" name="username" type="text" autocomplete="off"> <span class="focus-input100" data-placeholder="Tài khoản"></span></input>
                        </div>
                        <div class="wrap-input100 validate-input m-t-50" data-validate="Enter password">
                            <input class="input100" id="txtMK" runat="server" name="pass" type="password"> <span class="focus-input100" data-placeholder="Mật khẩu"></span></input>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button ID="btnDangNhap" CssClass="login100-form-btn" runat="server" Text="Đăng Nhập" OnClick="btnDangNhap_Click" />
                        </div>
                    </form>
                </div>
            </div>

            <script src="../js/main.js"></script>
            <script src="../js/jquery-3.2.1.min.js"></script>

            <script>
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
        </div>

    </form>
</body>
</html>
