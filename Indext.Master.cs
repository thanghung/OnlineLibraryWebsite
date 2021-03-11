using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class Indext : System.Web.UI.MasterPage
    {
        public static string key = "";
        tbl_Sach tbl_sach = new tbl_Sach();

        protected void Page_Load(object sender, EventArgs e)
        {        
            tbl_Nhom tbl_ns = new tbl_Nhom();

            form1.Action = Request.RawUrl;
            if(!IsPostBack)
            {
                Repeater1.DataSource = tbl_ns.GetAllData();
                Repeater1.DataBind();
            }    
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (txtSearch.Value.Trim() != "")
            {
                string Url;
                Sach sach = tbl_sach.GetByName(txtSearch.Value.Trim());

                if (sach != null)
                    Url = "/ThongTinSach/" + sach.MaSach.ToString().Trim();
                else
                    Url = "/ThongTinSach/" + "TimKiem";

                key = txtSearch.Value.Trim();
                Response.Redirect(Url);
            }
        }
    }
}