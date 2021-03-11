using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class QL_NXB : System.Web.UI.UserControl
    {
        static tbl_NXB tbl_nxb = new tbl_NXB();

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
            tableNXB.DataSource = tbl_nxb.GetAllData();
            tableNXB.DataBind();

            if (tableNXB.Rows.Count > 0)
                tableNXB.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //Hiển Thị Form Input
        private void ShowFormInput()
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                btnThem.Visible = false;
                btnCapNhat.Visible = true;
                btnXoa.Visible = true;

                string id = Page.RouteData.Values["ID"].ToString().Trim();
                NhaXuatBan _nxb = tbl_nxb.GetByID(id);

                txtTenNXB.Text = _nxb.TenNXB;
            }
            else
            {
                btnThem.Visible = true;
                btnCapNhat.Visible = false;
                btnXoa.Visible = false;
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            NhaXuatBan _nxb = new NhaXuatBan();

            _nxb.MaNXB = CreateKey();
            _nxb.TenNXB = txtTenNXB.Text.Trim();
            tbl_nxb.Insert(_nxb);

            Response.Redirect("/QuanLyNhaXuatBan/NXB");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            NhaXuatBan _nxb = tbl_nxb.GetByID(id);

            _nxb.TenNXB = txtTenNXB.Text.Trim();
            tbl_nxb.Update(_nxb);
            Response.Redirect("/QuanLyNhaXuatBan/NXB");
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            NhaXuatBan _nxb = tbl_nxb.GetByID(id);

            tbl_nxb.Delete(_nxb);
            Response.Redirect("/QuanLyNhaXuatBan/NXB");
        }

        #region Random Mã Nhà Xuất Bản
        public static string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_nxb.GetByID(Key) != null)
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
                Key = "NXB000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "NXB00" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "NXB0" + number.ToString();
            else
                Key = "NXB" + number.ToString();

            return Key;
        }
        #endregion

        public static List<string> GetItem(string Name)
        {
            List<NhaXuatBan> li_nxb = tbl_nxb.GetListByName(Name);
            List<string> li_ten = new List<string>();

            foreach (NhaXuatBan _nxb in li_nxb)
                li_ten.Add(_nxb.TenNXB);

            return li_ten;
        }
    }
}