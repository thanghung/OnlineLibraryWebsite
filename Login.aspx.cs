using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class Login : System.Web.UI.Page
    {
        tbl_TK tbl_tk = new tbl_TK();
        DangNhap tk = new DangNhap();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                Response.Redirect("/QuanLySach");
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (tbl_tk.CheckKey(txtTK.Value.Trim(), txtMK.Value.Trim()) != null)
            {
                HttpCookie ck = new HttpCookie("Login");
                ck["id"] = tk.UserTK;
                ck.Expires = DateTime.Now.AddDays(15d);
                Response.Cookies.Add(ck);

                Response.Redirect("/QuanLySach");
            }
            else
            {
                WebMsgBox.Show("Kiểm tra tài khoản và mật khẩu");
                txtMK.Value = "";
            }
        }
    }
}