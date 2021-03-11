using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class QL_TK : System.Web.UI.UserControl
    {
        tbl_TK tbl_tk = new tbl_TK();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            HttpCookie ck = new HttpCookie("Login");
            ck.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ck);

            Response.Redirect("/QuanLyTaiKhoan/TK");
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            DangNhap tk = tbl_tk.CheckKey("admin", txtMKCu.Text.Trim());

            if (tk == null)
                WebMsgBox.Show("Mật Khẩu cũ không chính xác");
            else
            {
                tk.MK = txtMatKhau.Text.Trim();
                tbl_tk.Update(tk);
                WebMsgBox.Show("Thay Đổi Thành Công");
            }     
        }
    }
}