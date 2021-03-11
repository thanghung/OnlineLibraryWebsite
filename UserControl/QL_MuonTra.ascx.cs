using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class QL_MuonTra : System.Web.UI.UserControl
    {
        static tbl_MuonTra tbl_muontra = new tbl_MuonTra();
        tbl_Sach tbl_sach = new tbl_Sach();
        tbl_User tbl_user = new tbl_User();
        string _tt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNgayMuon.Text = DateTime.Now.ToString("dd/MM/yyyy").Trim();

            ShowData();
            ShowFormInput();
        }

        //Hiển thị bảng dữ liệu
        private void ShowData()
        {
            tableMuonTra.DataSource = tbl_muontra.GetAllData();
            tableMuonTra.DataBind();

            if (tableMuonTra.Rows.Count > 0)
                tableMuonTra.HeaderRow.TableSection = TableRowSection.TableHeader;
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

                string id = Page.RouteData.Values["ID"].ToString().Trim();
                DangKyMuon muontra = tbl_muontra.GetByID(id);

                txtMaThe.Text = muontra.MaThe;
                txtTen.Text = muontra.TenSV;
                txtTenSach.Text = muontra.TenSach;
                txtNgayMuon.Text = muontra.NgayMuon;
                txtNgayTra.Text = muontra.NgayTra;
                //Ko đc luôn
                txtMuon.Text = (DateTime.ParseExact(muontra.NgayTra.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Date - DateTime.ParseExact(muontra.NgayMuon.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Date).TotalDays.ToString();
                DropDownList1.SelectedValue = muontra.TinhTrang.Trim();
                txtGhiChuNV.Text = muontra.GhiChuNV;
                txtGhiChuSV.Text = muontra.GhiChuSV;

                _tt = muontra.TinhTrang.Trim();
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
            DangKyMuon muon = new DangKyMuon();

            muon.MaMuon = CreateKey();
            muon.MaThe = txtMaThe.Text.Trim();
            muon.TenSV = txtTen.Text.Trim();
            muon.SoLuong = 1;
            muon.NgayMuon = txtNgayMuon.Text.Trim();
            muon.NgayTra = txtNgayTra.Text.Trim();
            muon.TinhTrang = DropDownList1.SelectedValue.Trim();
            muon.GhiChuNV = txtGhiChuNV.Text;
            muon.GhiChuSV = "";

            if (lbMuon.Text.Trim() == "")
            {
                //xử lý dữ liệu sách
                Sach sach = tbl_sach.GetByName(txtTenSach.Text.Trim());

                if (sach != null)
                {
                    muon.MaSach = sach.MaSach;
                    muon.TenSach = sach.TenSach;
                    LogicSach(_tt, muon.TinhTrang, sach);

                    tbl_muontra.Insert(muon);
                    Response.Redirect("/QuanLyMuonTra/MTS");
                }
                else
                    WebMsgBox.Show("Tên sách không tồn tại");
            }
            else
                WebMsgBox.Show("Hãy nhập số ngày mượn");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            DangKyMuon muon = tbl_muontra.GetByID(id);

            muon.MaThe = txtMaThe.Text.Trim();
            muon.TenSV = txtTen.Text.Trim();
            muon.SoLuong = 1;
            muon.NgayMuon = txtNgayMuon.Text.Trim();
            muon.NgayTra = txtNgayTra.Text.Trim();
            muon.TinhTrang = DropDownList1.SelectedValue.Trim();
            muon.GhiChuNV = txtGhiChuNV.Text;
            muon.GhiChuSV += "";

            if (lbMuon.Text.Trim() == "")
            {
                //xử lý dữ liệu sách
                Sach sach = tbl_sach.GetByName(txtTenSach.Text.Trim());

                if (sach != null)
                {
                    muon.MaSach = sach.MaSach;
                    muon.TenSach = sach.TenSach;
                    LogicSach(_tt, muon.TinhTrang, sach);

                    tbl_muontra.Update(muon);
                    Response.Redirect("/QuanLyMuonTra/MTS");
                }
                else
                    WebMsgBox.Show("Tên sách không tồn tại");
            }
            else
                WebMsgBox.Show("Hãy nhập số ngày mượn");
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            DangKyMuon muon = tbl_muontra.GetByID(id);

            if (muon.TinhTrang == "Đang Mượn" || muon.TinhTrang == "Chưa Trả")
                WebMsgBox.Show("Bạn không thể hủy khi bạn còn đang mượn sách");
            else
            {
                tbl_muontra.Delete(muon);
                Response.Redirect("/QuanLyMuonTra/MTS");
            }    
        }

        #region Random Mã Muon Tra
        public static string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_muontra.GetByID(Key) != null)
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
                Key = "MT0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "MT000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "MT00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "MT0" + number.ToString();
            else
                Key = "MT" + number.ToString();

            return Key;
        }
        #endregion

        //Mã Thẻ
        protected void txtMaThe_TextChanged(object sender, EventArgs e)
        {
            UserDN user = tbl_user.GetByID(txtMaThe.Text.Trim());

            if (user != null)
            {
                txtTen.Text = user.TenSV;
            }
            else
                WebMsgBox.Show("Mã thẻ không tồn tại");
        }

        //số ngày mượn
        protected void txtMuon_TextChanged(object sender, EventArgs e)
        {
            bool flag = true;


            foreach (Char item in txtMuon.Text.Trim())
                if (!Char.IsDigit(item))
                {
                    flag = false;
                    break;
                }


            if (flag)
            {
                int number = Int32.Parse(txtMuon.Text.Trim());

                if (number <= 200 && number > 0)
                {
                    lbMuon.Text = "";
                    txtNgayTra.Text = DateTime.Now.AddDays(Int32.Parse(txtMuon.Text.Trim())).ToString("dd/MM/yyyy");
                }
                else
                    lbMuon.Text = "chỉ cho phép từ 1->200 ngày";
            }
            else
                lbMuon.Text = "Hãy nhập số dương";
        }

        //Load dữ liệu chưa trả
        protected void btnChuaTra_Click(object sender, EventArgs e)
        {
            List<DangKyMuon> li_muon = tbl_muontra.GetAllData();
            int dem = 0;

            foreach (DangKyMuon item in li_muon)
            {
                //Chạy đểu
                TimeSpan total = DateTime.Parse(item.NgayTra.Trim()).Date - DateTime.Now.Date;
                int days = total.Days;

                if (days < 1)
                {
                    dem++;
                    item.TinhTrang = "Chưa Trả";
                    tbl_muontra.Update(item);
                }

            }

            WebMsgBox.Show("Đã kiểm tra xong, Hiên đang có " + dem + " sinh viên chưa trả sách");
        }

        //hiển thị dữ liệu mượn, trả
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = DropDownList2.SelectedIndex;

            switch (s)
            {
                case 0:
                    tableMuonTra.DataSource = tbl_muontra.GetAllData();
                    break;
                default:
                    tableMuonTra.DataSource = tbl_muontra.LocDuLieu(DropDownList2.SelectedValue.Trim());
                    break;
            }

            tableMuonTra.DataBind();
            if (tableMuonTra.Rows.Count > 0)
                tableMuonTra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void LogicSach(string ttdau, string ttsau, Sach sach)
        {
            
            if (ttdau == "Đã Duyệt" || ttdau == "Đang Chờ" || ttdau == "")
            {
                if (ttsau == "Đang Mượn")
                    sach.SoLuong -= 1;
            }
            else
                if (ttdau == "Đang Mượn")
            {
                if (ttsau == "Đã Trả")
                    sach.SoLuong += 1;
            }
            else
                if (ttdau == "Chưa Trả")
            {
                if (ttsau == "Đã Trả")
                    sach.SoLuong += 1;
            }

            tbl_sach.Update(sach);
        }
    }
}