using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class LoginUser : System.Web.UI.Page
    {
        tbl_User tbl_user = new tbl_User();
        UserDN user = new UserDN();

        int key = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                Response.Redirect("/TrangChinh");
            }
        }

        protected void btnDangNhap_ServerClick(object sender, EventArgs e)
        {
            user = tbl_user.CheckUser(txtUserDN.Value, txtMatKhauDN.Value);

            if (user == null)
                WebMsgBox.Show("Sai Thông tin tài khoản");
            else
            {
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Value = HttpUtility.UrlEncode(user.MaThe.Trim());
                myCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(myCookie);

                Response.Redirect("/TrangChinh");
            }
        }

        protected void btnTimTK_ServerClick(object sender, EventArgs e)
        {
            try
            {
                user = tbl_user.CheckKey(Text1.Value.Trim());

                if (user == null)
                    Label1.Text = "Không tìm thấy tài khoản";
                else
                {
                    key = new Random().Next(111111, 999999);

                    if (key != 0)
                        Session["key"] = key;

                    MailMessage mail = new MailMessage();

                    mail.To.Add(user.Email.Trim());
                    mail.From = new MailAddress("nthung942014@gmail.com");
                    mail.Subject = "Mã xác nhận của bạn là: " + key.ToString();

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    Text1.Value = "";
                    MultiView1.ActiveViewIndex = 2;
                }
            }
            catch (Exception ex)
            {
                WebMsgBox.Show("Email của bạn không hợp lệ hãy đến thư viện kiểm tra lại email");
            }

        }

        #region Di chuyển Trang View
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        #endregion

        protected void btnXacNhan_ServerClick(object sender, EventArgs e)
        {
            if (Text3.Value == Session["key"].ToString())
            {
                user = tbl_user.CheckKey(Text1.Value.Trim());
                MailMessage mail = new MailMessage();

                mail.To.Add(user.Email);
                mail.From = new MailAddress("nthung942014@gmail.com");
                mail.Subject = "Mật Khẩu cũa bạn là: " + user.MK;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("nthung942014@gmail.com", "01692762910hung");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                Text3.Value = "";
                MultiView1.ActiveViewIndex = 0;
                WebMsgBox.Show("Hãy kiểm tra hòm thư của bạn");
            }
            else
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Mã xác nhận không hợp lệ";
            }
        }
    }
}