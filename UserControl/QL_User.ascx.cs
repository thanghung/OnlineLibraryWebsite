using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class QL_User : System.Web.UI.UserControl
    {
        tbl_User tbl_user = new tbl_User();
        tbl_MuonTra tbl_muon = new tbl_MuonTra();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();


            if (!IsPostBack)
            {
                ShowFormInput();
            }

        }

        //Hiển thị bảng dữ liệu
        private void ShowData()
        {
            tableUser.DataSource = tbl_user.GetAllData();
            tableUser.DataBind();

            if (tableUser.Rows.Count > 0)
                tableUser.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //Hiển Thị Form Input
        private void ShowFormInput()
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                btnThem.Visible = false;
                btnCapNhat.Visible = true;
                btnCapNhat.Visible = true;
                btnXoa.Visible = true;
                txtTaiKhoan.Enabled = false;
                txtNam.Enabled = false;

                string id = Page.RouteData.Values["ID"].ToString().Trim();
                UserDN user = tbl_user.GetByID(id);

                txtTenSV.Text = user.TenSV;
                txtMaSV.Text = user.MSSV;
                txtEmail.Text = user.Email;
                txtLop.Text = user.Lop;
                txtNam.Text = user.nam.ToString();
                txtTaiKhoan.Text = user.UserTK;
                txtMatKhau.Text = user.MK;
            }
            else
            {
                btnThem.Visible = true;
                btnCapNhat.Visible = false;
                btnXoa.Visible = false;
                txtTaiKhoan.Enabled = true;
                txtNam.Enabled = true;
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            UserDN user = new UserDN();

            if (txtMaSV.Text.Trim() != "")
                user.MaThe = utf8Convert1(txtMaSV.Text.Trim());
            else
                user.MaThe = CreateKey();

            user.TenSV = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(txtTenSV.Text.ToLower().Trim());
            user.MSSV = txtMaSV.Text.Trim();
            user.Lop = txtLop.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.MK = txtMatKhau.Text.Trim();
            user.nam = Int32.Parse(txtNam.Text.Trim());
            user.ThoiHan = DateTime.Now.AddYears(Int32.Parse(txtNam.Text.Trim())).ToString("dd/MM/yyyy");

            if (tbl_user.CheckKey(txtTaiKhoan.Text.Trim()) == null)
            {
                user.UserTK = txtTaiKhoan.Text.Trim();

                tbl_user.Insert(user);

                //Reset
                txtTenSV.Text = "";
                txtMaSV.Text = "";
                txtLop.Text = "";
                txtEmail.Text = "";
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtNam.Text = "";

                ShowData();
                WebMsgBox.Show("Thêm Vào Thành Công");
            }
            else
                WebMsgBox.Show("Tên tài khoản đã tồn tại");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            UserDN user = tbl_user.GetByID(id);

            user.TenSV = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(txtTenSV.Text.ToLower().Trim());
            user.MSSV = txtMaSV.Text.Trim();
            user.Lop = txtLop.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.MK = txtMatKhau.Text.Trim();

            tbl_user.Update(user);
            Response.Redirect("/QuanLyNguoiDoc/TKND");
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            UserDN user = tbl_user.GetByID(id);

            XoaDuLieu(user, true);      
        }

        private void XoaDuLieu(UserDN user, bool point)
        {
            List<DangKyMuon> li_muon = tbl_muon.GetListByIDUser(user.MaThe);
            bool flag = true;

            //Xóa danh sách mượn của sinh viên
            if (li_muon.Count > 0)
            {
                foreach (DangKyMuon item in li_muon)
                    if (item.TinhTrang == "Đang Mượn" || item.TinhTrang == "Chưa Trả")
                    {
                        flag = false;
                        break;
                    }
                    else
                        tbl_muon.Delete(item);
            }

            if (flag == true)
            {
                tbl_user.Delete(user);

                if(point)
                    Response.Redirect("/QuanLyNguoiDoc/TKND");
            }
            else
                WebMsgBox.Show("Tài khoản của mã thẻ " + user.MaThe + " còn đang mượn sách nên chưa xóa được");
        }

        #region Random Mã Nhóm
        public string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_user.GetByID(Key) != null)
            {
                Key = RanDomKey();
            }

            return Key;
        }

        public static string RanDomKey()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "US0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "US000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "US00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "US0" + number.ToString();
            else
                Key = "US" + number.ToString();

            return Key;
        }
        #endregion

        protected void btnXoaAll_Click(object sender, EventArgs e)
        {
            List<UserDN> li_user = tbl_user.GetAllData();
            bool expired = false;

            foreach (UserDN user in li_user)
            {
                //Code chạy đc
                TimeSpan total = DateTime.Parse(user.ThoiHan.Trim()).Date - DateTime.Now.Date;
                int days = total.Days;

                if (days < 1)
                {
                    XoaDuLieu(user, false);
                    expired = true;
                }
            }

            if (expired == false)
                WebMsgBox.Show("không có tài khoản nào hết hạn");
            else
            {
                WebMsgBox.Show("Đã Xóa Thành Công");
                ShowData();
            }

        }

        #region chuyển dấu c#

        private static readonly string[] VietNamChar = new string[]
{
    "aAeEoOuUiIdDyY",
    "áàạảãâấầậẩẫăắằặẳẵ",
    "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
    "éèẹẻẽêếềệểễ",
    "ÉÈẸẺẼÊẾỀỆỂỄ",
    "óòọỏõôốồộổỗơớờợởỡ",
    "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
    "úùụủũưứừựửữ",
    "ÚÙỤỦŨƯỨỪỰỬỮ",
    "íìịỉĩ",
    "ÍÌỊỈĨ",
    "đ",
    "Đ",
    "ýỳỵỷỹ",
    "ÝỲỴỶỸ"
};
        public static string utf8Convert1(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        #endregion
    }
}