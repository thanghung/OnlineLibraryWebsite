using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class TrangChu : System.Web.UI.Page
    {
        tbl_Sach tbl_sach = new tbl_Sach();
        tbl_MuonTra tbl_mt = new tbl_MuonTra();
        static tbl_Nhom tbl_nhomsach = new tbl_Nhom();
        static tbl_NXB tbl_nxb = new tbl_NXB();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Login"] == null)
                Response.Redirect("/DangNhap");
            else
            {
                //chuyển đổi qua lại các user control
                if (Page.RouteData.Values["Modul"] != null)
                {
                    string modul = Page.RouteData.Values["Modul"].ToString().Trim();
                    PlaceHolder2.Visible = false;
                    switch (modul)
                    {
                        case "Nhom":
                            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/QL_Nhom.ascx"));
                            break;
                        case "NXB":
                            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/QL_NXB.ascx"));
                            break;
                        case "TK":
                            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/QL_TK.ascx"));
                            break;
                        case "TKND":
                            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/QL_User.ascx"));
                            break;
                        case "MTS":
                            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/QL_MuonTra.ascx"));
                            break;

                    }
                }
                else
                {
                    PlaceHolder2.Visible = true;
                    ShowData();

                    if (!IsPostBack)
                        ShowFormInput();
                }
            }

            LoadDuLieu();
        }


        public void LoadDuLieu()
        {

            List<DangKyMuon> muon = tbl_mt.GetAllData();

            if (muon.Count > 0 && muon != null)
                Label2.Text = "Đang chờ (" + tbl_mt.GetByCount().ToString() + ")";

        }

        //Hiển thị bảng dữ liệu
        private void ShowData()
        {
            tableSach.DataSource = tbl_sach.GetAllData();
            tableSach.DataBind();

            if (tableSach.Rows.Count > 0)
                tableSach.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //Hiển Thị Form Input
        private void ShowFormInput()
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                btnAdd.Visible = false;
                btnCapNhat.Visible = true;
                btnXoa.Visible = true;

                string id = Page.RouteData.Values["ID"].ToString().Trim();
                Sach sach = tbl_sach.GetByID(id);

                txtTenSach.Text = sach.TenSach;
                txtTacGia.Text = sach.TacGia;
                txtNhom.Text = sach.NhomSach;
                txtGhiChu.Text = sach.GhiChu;
                txtSoLuong.Text = sach.SoLuong.ToString();
                txtNhaXB.Text = sach.NhaXuatBan;
                txtNoiXB.Text = sach.NoiXuatBan;
                txtNamXB.Text = sach.NamXuatBan;
                LbUpload.Text = Format(sach.TenFile.Trim());

                if (LbUpload.Text.Trim() != "")
                {
                    ViewState["Url"] = sach.TenFile.Trim();
                    ViewState["FileName"] = sach.TenFile.Trim();
                    btnDownload.Visible = true;
                }
                else
                    btnDownload.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
                btnCapNhat.Visible = false;
                btnXoa.Visible = false;
                btnDownload.Visible = false;
            }
        }

        #region Thêm Sách
        //Thêm Thủ Công
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Input();

            //reset
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhom.Text = "";
            txtSoLuong.Text = "";
            txtNhaXB.Text = "";
            txtNamXB.Text = "";
            txtNoiXB.Text = "";
            txtGhiChu.Text = "";
            ShowData();
            WebMsgBox.Show("Thêm Vào Thành Công");
        }

        //Thêm File Excel
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                if (Path.GetExtension(FileUpload2.FileName) == ".xlsx")
                {
                    try
                    {
                        using (var excel = new ExcelPackage(FileUpload2.PostedFile.InputStream))
                        {
                            //gọi bảng chứa dữ liệu excel
                            ExcelPackage.LicenseContext = LicenseContext.Commercial;
                            var ws = excel.Workbook.Worksheets.First();
                            int rowCount = ws.Dimension.End.Row;     //get row count
                            for (int row = 5; row <= rowCount; row++)
                            {
                                if (ws.Cells[row, 3].Text.Trim() == "")
                                    break;

                                Sach sach = tbl_sach.GetByName(ws.Cells[row, 3].Text.Trim());

                                if (sach == null)
                                {
                                    ThemNhomSach(ws.Cells[row, 5].Text.Trim());
                                    ThemNhaXuatBan(ws.Cells[row, 8].Text.Trim());

                                    sach = new Sach();
                                    sach.MaSach = CreateKey();
                                    sach.TenSach = ws.Cells[row, 3].Text.Trim();
                                    sach.TacGia = ws.Cells[row, 4].Text.Trim();
                                    sach.NhomSach = ws.Cells[row, 5].Text.Trim();
                                    sach.GhiChu = ws.Cells[row, 6].Text.Trim();
                                    sach.SoLuong = Int32.Parse(ws.Cells[row, 7].Text.Trim());
                                    sach.NhaXuatBan = ws.Cells[row, 8].Text.Trim();
                                    sach.NoiXuatBan = ws.Cells[row, 9].Text.Trim();
                                    sach.NamXuatBan = ws.Cells[row, 10].Text.Trim();

                                    if (ws.Cells[row, 11].Text.Trim() != "")
                                        sach.NgayNhap = ws.Cells[row, 11].Text.Trim();
                                    else
                                        sach.NgayNhap = DateTime.Now.ToString("dd/MM/yyyy");

                                    sach.TenFile = "";

                                    tbl_sach.Insert(sach);
                                }
                                else
                                {
                                    ThemNhomSach(sach.NhomSach);
                                    ThemNhaXuatBan(sach.NhaXuatBan);

                                    sach.TenSach = ws.Cells[row, 3].Text.Trim();
                                    sach.TacGia = ws.Cells[row, 4].Text.Trim();
                                    sach.NhomSach = ws.Cells[row, 5].Text.Trim();
                                    sach.GhiChu = ws.Cells[row, 6].Text.Trim();
                                    sach.SoLuong = Int32.Parse(ws.Cells[row, 7].Text.Trim());
                                    sach.NhaXuatBan = ws.Cells[row, 8].Text.Trim();
                                    sach.NoiXuatBan = ws.Cells[row, 9].Text.Trim();
                                    sach.NamXuatBan = ws.Cells[row, 10].Text.Trim();
                                    sach.NgayNhap = ws.Cells[row, 11].Text.Trim();

                                    tbl_sach.Update(sach);
                                }
                            }

                        }

                        WebMsgBox.Show("Thêm Vào Thành Công");
                    }
                    catch (Exception ex)
                    {
                        WebMsgBox.Show("Lỗi nhập file, hãy kiểm tra lại file của bạn");
                    }
                }
                else
                    WebMsgBox.Show("Lỗi Hệ thống: chỉ nhận file Excel");
            }
            else
            {
                WebMsgBox.Show("Hãy chọn tệp");
            }

            ShowData();
        }

        //Thêm dữ liệu sách nhập thủ công
        private void Input()
        {
            Sach sach = new Sach();

            ThemNhomSach(txtNhom.Text.Trim());
            ThemNhaXuatBan(txtNhaXB.Text.Trim());

            sach.MaSach = CreateKey();
            sach.TenSach = txtTenSach.Text.Trim();
            sach.TacGia = txtTacGia.Text.Trim();
            sach.NhomSach = txtNhom.Text.Trim();
            sach.GhiChu = txtGhiChu.Text.Trim();
            sach.SoLuong = Int32.Parse(txtSoLuong.Text.Trim());
            sach.NhaXuatBan = txtNhaXB.Text.Trim();
            sach.NoiXuatBan = txtNoiXB.Text.Trim();
            sach.NamXuatBan = txtNamXB.Text.Trim();
            sach.NgayNhap = DateTime.Now.ToString("dd/MM/yyyy");
            sach.TenFile = "";
            LuuFile(sach);

            //gọi hàm database và truyền dữ liệu sách vào
            tbl_sach.Insert(sach);
        }

        private void ThemNhomSach(string ten)
        {
            NhomSach _ns = tbl_nhomsach.GetByName(ten);
            if (_ns == null)
            {
                if (ten.Trim() != "")
                {
                    _ns = new NhomSach();
                    _ns.MaNhom = QL_Nhom.CreateKey();
                    _ns.TenNhom = ten;
                    tbl_nhomsach.Insert(_ns);
                }

            }
        }

        private void ThemNhaXuatBan(string ten)
        {
            NhaXuatBan _nxb = tbl_nxb.GetByName(ten);
            if (_nxb == null)
            {
                if (ten.Trim() != "")
                {
                    _nxb = new NhaXuatBan();
                    _nxb.MaNXB = QL_NXB.CreateKey();
                    _nxb.TenNXB = ten;

                    tbl_nxb.Insert(_nxb);
                }
            }
        }
        #endregion

        #region Xóa dữ liệu
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            Sach sach = tbl_sach.GetByID(id);

            if (sach.TenFile.Trim() != "")
            {
                XoaFile(sach);
            }

            List<DangKyMuon> li_muon = tbl_mt.GetListByIDBook(sach.MaSach);
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
                        tbl_mt.Delete(item);
            }

            if (flag == true)
            {
                tbl_sach.Delete(sach);
                Response.Redirect("/QuanLySach");
            }
            else
                WebMsgBox.Show("Sách " + sach.TenSach + " còn đang mượn sách nên chưa xóa được");
        }
        #endregion

        #region Cập nhật dữ liệu
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = Page.RouteData.Values["ID"].ToString().Trim();
            Sach sach = tbl_sach.GetByID(id);

            ThemNhomSach(sach.NhomSach);
            ThemNhaXuatBan(sach.NhaXuatBan);

            sach.TenSach = txtTenSach.Text.Trim();
            sach.TacGia = txtTacGia.Text.Trim();
            sach.NhomSach = txtNhom.Text.Trim();
            sach.GhiChu = txtGhiChu.Text.Trim();
            sach.SoLuong = Int32.Parse(txtSoLuong.Text.Trim());
            sach.NhaXuatBan = txtNhaXB.Text.Trim();
            sach.NoiXuatBan = txtNoiXB.Text.Trim();
            sach.NamXuatBan = txtNamXB.Text.Trim();

            if (sach.TenFile == null)
                sach.TenFile = "";

            LuuFile(sach);

            tbl_sach.Update(sach);
            Response.Redirect("/QuanLySach");
        }
        #endregion

        #region Tương tác file excel
        //Xuất File Excel
        protected void btnXuat_Click(object sender, EventArgs e)
        {
            List<Sach> list = tbl_sach.GetAllData();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage pxk = new ExcelPackage();
            ExcelWorksheet ws = pxk.Workbook.Worksheets.Add("Report");

            ws.Cells["B4"].Value = "Mã Sách";
            ws.Cells["C4"].Value = "Tên Sách";
            ws.Cells["D4"].Value = "Tác Giả";
            ws.Cells["E4"].Value = "Nhóm Sách";
            ws.Cells["F4"].Value = "Ghi Chú";
            ws.Cells["G4"].Value = "Số Lượng";
            ws.Cells["H4"].Value = "Nhà Xuất Bản";
            ws.Cells["I4"].Value = "Nơi Xuất Bản";
            ws.Cells["J4"].Value = "Năm Xuất Bản";
            ws.Cells["K4"].Value = "Ngày Nhập";

            //Chỉnh style excel
            ws.Cells["B4:K4"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["B4:K4"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells["B4:K4"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["B4:K4"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells["B4:K4"].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells["B4:K4"].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells["B4:K4"].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells["B4:K4"].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);

            int row = 5;
            foreach (Sach sach in list)
            {
                ws.Cells[string.Format("B{0}", row)].Value = sach.MaSach;
                ws.Cells[string.Format("C{0}", row)].Value = sach.TenSach;
                ws.Cells[string.Format("D{0}", row)].Value = sach.TacGia;
                ws.Cells[string.Format("E{0}", row)].Value = sach.NhomSach;
                ws.Cells[string.Format("F{0}", row)].Value = sach.GhiChu;
                ws.Cells[string.Format("G{0}", row)].Value = sach.SoLuong;
                ws.Cells[string.Format("H{0}", row)].Value = sach.NhaXuatBan;
                ws.Cells[string.Format("I{0}", row)].Value = sach.NoiXuatBan;
                ws.Cells[string.Format("J{0}", row)].Value = sach.NamXuatBan;
                ws.Cells[string.Format("K{0}", row)].Value = sach.NgayNhap;

                //Chỉnh style excel
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                ws.Cells[string.Format("B{0}:K{0}", row)].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                row++;
            }


            ws.Cells["B:K"].AutoFitColumns();

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + "ThuVien.xlsx");
                pxk.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            };
        }
        #endregion

        #region Lưu, Xóa File Đính Kèm

        public void LuuFile(Sach sach)
        {
            string ten = FileUpload1.FileName.Trim();

            if (ten != "")
            {
                if (sach.TenFile.Trim() == "")
                {
                    //Thực hiện chép tập tin lên thư mục Upload
                    FileUpload1.SaveAs(Server.MapPath("~/Files/") + ten);
                    sach.TenFile = "~/Files/" + ten;
                }
                else
                {
                    if (sach.TenFile.Contains(ten.Trim()) == false)
                    {
                        XoaFile(sach);
                        //Thực hiện chép tập tin lên thư mục Upload
                        FileUpload1.SaveAs(Server.MapPath("~/Files/") + ten);
                        sach.TenFile = "~/Files/" + ten;
                    }
                }
            }
        }

        //Xóa File
        protected void XoaFile(Sach sach)
        {
            if (sach.TenFile.Trim() != "")
            {
                string ten = Server.MapPath(sach.TenFile.Trim());

                if (System.IO.File.Exists(ten))
                    System.IO.File.Delete(ten);
            }
        }
        #endregion

        #region Random Mã Sách
        private string CreateKey()
        {
            string Key = RanDomKey();
            while (tbl_sach.GetByID(Key) != null)
            {
                Key = RanDomKey();
            }

            return Key;
        }

        private string RanDomKey()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 99999);
            string Key;
            if (number < 10)
                Key = "MS0000" + number.ToString();
            else
                if (number >= 10 && number < 100)
                Key = "MS000" + number.ToString();
            else
                if (number >= 100 && number < 1000)
                Key = "MS00" + number.ToString();
            else
                if (number >= 1000 && number < 10000)
                Key = "MS0" + number.ToString();
            else
                Key = "MS" + number.ToString();

            return Key;
        }
        #endregion

        //Format String tenFile
        public static string Format(string ten)
        {
            string s = "";

            for (int i = 8; i < ten.Length; i++)
                s += ten[i];

            return s;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            //string ten = ViewState["FileName"].ToString().Trim();
            string filePath = Format(ViewState["FileName"].ToString().Trim());

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = ContentType;
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + filePath + ";");
            response.TransmitFile(Server.MapPath("~/Files/" + filePath));
            response.Flush();
            response.End();
        }


    }
}