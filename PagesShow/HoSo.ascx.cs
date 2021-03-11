using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class HoSo : System.Web.UI.UserControl
    {
        tbl_User tbl_user = new tbl_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["User"] != null)
                {
                    HttpCookie ck = Request.Cookies["User"];
                    UserDN user = tbl_user.GetByID(HttpUtility.UrlDecode(ck.Value.Trim()));

                    if (user == null)
                        XoaCookie();
                    else
                    {
                        txtMaThe.Text = user.MaThe;
                        txtTen.Text = user.TenSV;
                        txtLop.Text = user.Lop;
                        txtEmail.Text = user.Email;
                        txtTK.Text = user.UserTK;
                        txtThoiHan.Text = user.ThoiHan;
                    }         
                }
            }
        }

        protected void txtDangXuat_Click(object sender, EventArgs e)
        {
            XoaCookie();
        }

        protected void txtUpdate_Click(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["User"];
            UserDN user = tbl_user.GetByID(HttpUtility.UrlDecode(ck.Value.Trim()));

            user.TenSV = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(txtTen.Text.ToLower().Trim());
            user.Lop = txtLop.Text.Trim();
            user.Email = txtEmail.Text.Trim();

            tbl_user.Update(user);
        }

        protected void btnDoiMK_Click(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["User"];
            UserDN user = tbl_user.GetByID(HttpUtility.UrlDecode(ck.Value.Trim()));

            if (txtMKCu.Text == user.MK)
            {
                user.MK = txtMatKhau.Text;

                tbl_user.Update(user);

                WebMsgBox.Show("Cập nhật thành công");
            }
            else
                WebMsgBox.Show("Mật khẩu cũ của bạn không trùng khớp");
        }

        private void XoaCookie()
        {
            HttpCookie ck = new HttpCookie("User");
            ck.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ck);

            Response.Redirect("/TrangChinh");
        }
    }
}