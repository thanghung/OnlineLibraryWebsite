using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class FormItems : System.Web.UI.UserControl
    {
        tbl_Sach tbl_sach = new tbl_Sach();
        tbl_User tbl_user = new tbl_User();
        tbl_MuonTra tbl_muon = new tbl_MuonTra();
        Sach sach = new Sach();
        string ten;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] == null)
            {
                Panel3.Visible = true;
                Panel4.Visible = false;
            }
            else
            {
                Panel3.Visible = false;
                Panel4.Visible = true;
            }

            if (Page.RouteData.Values["ID"] != null)
            {
                string id = Page.RouteData.Values["ID"].ToString().Trim();
                List<Sach> li_sach = new List<Sach>();
                sach = tbl_sach.GetByID(id);

                if (sach != null)
                {
                    ten = sach.TenFile;
                    li_sach.Add(sach);

                    if (sach.TenFile.Trim() == "")
                        btnTai.Visible = false;
                    else
                        btnTai.Visible = true;
                }

                else
                    li_sach = tbl_sach.SearchSachObj(Indext.key);

                if (li_sach.Count > 1)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    DataList1.DataSource = li_sach;
                    DataList1.DataBind();
                }
                else
                if (li_sach.Count == 0)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    WebMsgBox.Show("Không tìm thấy sách");
                }
                else
                    if (li_sach.Count == 1)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    FormView1.DataSource = li_sach;
                    FormView1.DataBind();
                }
            }
        }


        protected void btnID_Command(object sender, CommandEventArgs e)
        {
            string Url;
            Url = "/ThongTinSach/" + e.CommandArgument.ToString().Trim();
            Response.Redirect(Url);
        }

        protected void btnTai_Click(object sender, EventArgs e)
        {
            string filePath = TrangChu.Format(ten);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + filePath + ";");
            response.TransmitFile(Server.MapPath("~/Files/" + filePath));
            response.Flush();
            response.End();
        }

        //Đăng ký mượn sách
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (sach.SoLuong > 0)
            {
                HttpCookie ck = Request.Cookies["User"];
                DangKyMuon muon = new DangKyMuon();
                UserDN user = tbl_user.GetByID(HttpUtility.UrlDecode(ck.Value.Trim()));

                //Tính thời hạn cảu tài khoản
                TimeSpan total = DateTime.Parse(user.ThoiHan).Date - DateTime.Now.Date;
                int days = total.Days;

                if (days > 0)
                {
                    //KT xem sinh viên đó có đang mượn cuốn sách nào không
                    //Nếu có thì không cho mượn sách
                    if (tbl_muon.KTdulieuSV(user.MaThe) != null)
                    {
                        WebMsgBox.Show("Hiện tại bạn đang mượn 1 cuốn sách của thư viện nên bạn chưa được phép mượn sách khác");
                    }
                    else
                    {
                        muon.MaMuon = QL_MuonTra.CreateKey();
                        muon.MaThe = user.MaThe;
                        muon.TenSV = user.TenSV;
                        muon.MaSach = sach.MaSach;
                        muon.TenSach = sach.TenSach;
                        muon.GhiChuSV = txtGhiChuSV.Text;
                        muon.GhiChuNV = "Thông tin mượn sách của bạn sẽ được duyệt sau 1 ngày";
                        muon.SoLuong = 1;
                        muon.NgayMuon = DateTime.Now.ToString("dd/MM/yyyy");
                        muon.NgayTra = DateTime.Now.AddDays(Int32.Parse(txtSoLuong.Text.Trim())).ToString("dd/MM/yyyy");
                        muon.TinhTrang = "Đang Chờ";


                        tbl_muon.Insert(muon);
                        Response.Redirect("/LichSuMuonSach/gs");
                    }
                }
                else
                    WebMsgBox.Show("Tài khoản của bạn đã hết hạn, hãy đến thư viện đăng ký 1 tài khoản mới");
            }
            else
                WebMsgBox.Show("Số lượng sách đã hết, bạn hãy mượn vào lần sau");
        }
    }
}