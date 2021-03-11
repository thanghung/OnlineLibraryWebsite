using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class GioSach : System.Web.UI.UserControl
    {
        tbl_MuonTra tbl_muon = new tbl_MuonTra();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] == null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }    
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;

                ShowData();
            }    
        }

        public void ShowData()
        {
            HttpCookie ck = Request.Cookies["User"];
            DataList1.DataSource = tbl_muon.GetListByIDUser(HttpUtility.UrlDecode(ck.Value.Trim()));
            DataList1.DataBind();
        }

        protected void btnHuy_Command(object sender, CommandEventArgs e)
        {
            DangKyMuon muon = tbl_muon.GetByID(e.CommandArgument.ToString().Trim());

            if (muon.TinhTrang == "Đang Mượn" || muon.TinhTrang == "Chưa Trả")
                WebMsgBox.Show("Bạn không thể hủy khi bạn còn đang mượn sách");
            else
            {
                tbl_muon.Delete(muon);
                Response.Redirect("/LichSuMuonSach/gs");
            }        
        }
    }
}