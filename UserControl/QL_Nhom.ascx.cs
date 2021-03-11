using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class QL_Nhom : System.Web.UI.UserControl
    {
        static tbl_Nhom tbl_ns = new tbl_Nhom();

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
            tableNhomSach.DataSource = tbl_ns.GetAllData();
            tableNhomSach.DataBind();

            if (tableNhomSach.Rows.Count > 0)
                tableNhomSach.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                NhomSach _ns = tbl_ns.GetByID(id);

                txtTenNhom.Text = _ns.TenNhom;
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
            NhomSach _ns = new NhomSach();

            _ns.MaNhom = CreateKey();
            _ns.TenNhom = txtTenNhom.Text.Trim();
            tbl_ns.Insert(_ns);

            Response.Redirect("/QuanLyNhomSach/Nhom");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            NhomSach _ns = tbl_ns.GetByID(id);

            _ns.TenNhom = txtTenNhom.Text.Trim();
            tbl_ns.Update(_ns);
            Response.Redirect("/QuanLyNhomSach/Nhom");
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            NhomSach _ns = tbl_ns.GetByID(id);
           
            tbl_ns.Delete(_ns);
            Response.Redirect("/QuanLyNhomSach/Nhom");
        }

        #region Random Mã Nhóm
        public static string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_ns.GetByID(Key) != null)
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
                Key = "NS0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "NS000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "NS00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "NS0" + number.ToString();
            else
                Key = "NS" + number.ToString();

            return Key;
        }
        #endregion

        public static List<string> GetItem(string Name)
        {
            List<NhomSach> li_ns= tbl_ns.GetListByName(Name);
            List<string> li_ten = new List<string>();

            foreach (NhomSach _ns in li_ns)
                li_ten.Add(_ns.TenNhom);

            return li_ten;
        }
    }
}