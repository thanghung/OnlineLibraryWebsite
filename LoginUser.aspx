<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="ThuVienSach.LoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Nhập</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" />
    <link href="Css/Login/main.css" rel="stylesheet" />
    <link href="Css/Login/util.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <div class="limiter">
                <div class="container-login100" style="background-image: url('Images/bg-01.jpg');">
                    <div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                            <%--Đăng nhập--%>
                            <asp:View ID="View1" runat="server">
                                <div class="login100-form validate-form">
                                    <span class="login100-form-title p-b-49">Đăng Nhập
                                    </span>

                                    <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                                        <span class="label-input100">Tài Khoản</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserDN" ValidationGroup="DN"></asp:RequiredFieldValidator>
                                        <input class="input100" id="txtUserDN" runat="server" type="text" name="username" placeholder="Nhập Tài Khoản" autocomplete="off" maxlength="20" />
                                        <span class="focus-input100 TK"></span>
                                    </div>

                                    <div class="wrap-input100 validate-input" data-validate="Password is required">
                                        <span class="label-input100">Mật Khẩu</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatKhauDN" ValidationGroup="DN"></asp:RequiredFieldValidator>
                                        <input class="input100" id="txtMatKhauDN" runat="server" type="password" name="pass" placeholder="Nhập Mật Khẩu" maxlength="20" />
                                        <span class="focus-input100 MK"></span>
                                    </div>

                                    <div class="text-right p-t-8 p-b-31">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Quên Mật Khẩu ?</asp:LinkButton>

                                    </div>

                                    <div class="container-login100-form-btn">
                                        <div class="wrap-login100-form-btn">
                                            <div class="login100-form-bgbtn"></div>
                                            <button class="login100-form-btn" id="btnDangNhap" runat="server" type="button" onserverclick="btnDangNhap_ServerClick" validationgroup="DN">
                                                Đăng Nhập
                                            </button>
                                        </div>
                                    </div>

                                    <div class="txt1 text-center p-t-54 p-b-20">
                                        <span>Hoặc Đăng Nhập Bằng
                                        </span>
                                    </div>

                                    <div class="flex-c-m">
                                        <a href="#" class="login100-social-item bg1">
                                            <i class="fab fa-facebook-f"></i>
                                        </a>

                                        <a href="#" class="login100-social-item bg2">
                                            <i class="fab fa-twitter"></i>
                                        </a>

                                        <a href="#" class="login100-social-item bg3">
                                            <i class="fab fa-google"></i>
                                        </a>
                                    </div>

                                    <button class="g-signin2" data-onsuccess="onSignIn" data-theme="dark"></button>
                                    <div class="flex-col-c p-t-155">
                                        <span class="txt1 p-b-17">Nếu Chưa Có Tài Khoản Hãy Đăng Ký
                                        </span>

                                        <a href="/DangNhapKhachHang/DangKy" class="txt2">Đăng Ký
                                        </a>
                                    </div>
                                </div>
                            </asp:View>

                            <%-- Tìm TK Đăng Nhập--%>
                            <asp:View ID="View2" runat="server">
                                <div class="login100-form validate-form">
                                    <span class="login100-form-title p-b-49">Tìm Tài Khoản
                                    </span>

                                    <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                                        <span class="label-input100">Tài Khoản</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Text1" ValidationGroup="QMK"></asp:RequiredFieldValidator>
                                        <input class="input100" id="Text1" runat="server" type="text" name="username" placeholder="Nhập Tài Khoản" autocomplete="off" maxlength="20" />
                                        <span class="focus-input100 TK"></span>
                                    </div>

                                    <div class="text-right p-t-8 p-b-31">
                                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Trở về ?</asp:LinkButton>
                                    </div>

                                    <div class="container-login100-form-btn">
                                        <div class="wrap-login100-form-btn">
                                            <div class="login100-form-bgbtn"></div>
                                            <button class="login100-form-btn" id="btnTimTK" runat="server" type="button" onserverclick="btnTimTK_ServerClick" validationgroup="QMK">
                                                Tìm Tài Khoản
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>

                            <%--Xác nhận Mã--%>
                            <asp:View ID="View3" runat="server">
                                <div class="login100-form validate-form">
                                    <span class="login100-form-title p-b-49">Nhập Mã Xác Nhận
                                    </span>

                                    <div class="wrap-input100 validate-input m-b-23" data-validate="Username is reauired">
                                        <span class="label-input100">Mã Xác Nhận</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Text1" ValidationGroup="XN"></asp:RequiredFieldValidator>
                                        <input class="input100" id="Text3" runat="server" type="text" name="username" placeholder="Nhập Mã Xác Nhận" autocomplete="off" maxlength="6" />
                                        <span class="focus-input100 TK"></span>
                                    </div>

                                    <div class="text-right p-t-8 p-b-31">
                                        <asp:Label ID="Label2" runat="server" Text="Hãy kiểm tra hộp thư email của bạn" ForeColor="Blue"></asp:Label><br />
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Trở về ?</asp:LinkButton>

                                    </div>

                                    <div class="container-login100-form-btn">
                                        <div class="wrap-login100-form-btn">
                                            <div class="login100-form-bgbtn"></div>
                                            <button class="login100-form-btn" id="btnXacNhan" runat="server" type="button" onserverclick="btnXacNhan_ServerClick" validationgroup="XN">
                                                Xác Nhận
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>

                    </div>
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>

        <script>
            //Xóa Quảng Cáo
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
