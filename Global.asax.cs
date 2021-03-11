using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ThuVienSach
{
    public class Global : System.Web.HttpApplication
    {

        public void Rewrite(RouteCollection routecolection)
        {
           //trang hệ thống
            routecolection.MapPageRoute("DangNhap", "DangNhap", "~/Login.aspx");
            routecolection.MapPageRoute("QuanLySach", "QuanLySach", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLySach_id", "QuanLySach/{ID}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNhomSach", "QuanLyNhomSach/{Modul}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNhomSach_id", "QuanLyNhomSach/{Modul}/{ID}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNXB", "QuanLyNhaXuatBan/{Modul}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNXB_id", "QuanLyNhaXuatBan/{Modul}/{ID}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyTaiKhoan", "QuanLyTaiKhoan/{Modul}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNguoiDoc", "QuanLyNguoiDoc/{Modul}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyNguoiDoc_id", "QuanLyNguoiDoc/{Modul}/{ID}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyMuonTra", "QuanLyMuonTra/{Modul}", "~/TrangChu.aspx");
            routecolection.MapPageRoute("QuanLyMuonTra_id", "QuanLyMuonTra/{Modul}/{ID}", "~/TrangChu.aspx");

            //giao diện
            routecolection.MapPageRoute("Indext", "TrangChinh", "~/Indext.aspx");
            routecolection.MapPageRoute("Indext_id", "ThongTinSach/{ID}", "~/Indext.aspx");
            routecolection.MapPageRoute("NhomSach", "NhomSach/{modul}", "~/Indext.aspx");
            routecolection.MapPageRoute("ThongTinSinhVien", "ThongTinSinhVien/{modul}", "~/Indext.aspx");
            routecolection.MapPageRoute("LichSuMuonSach", "LichSuMuonSach/{modul}", "~/Indext.aspx");
            routecolection.MapPageRoute("DangNhapThanhVien", "DangNhapThanhVien", "~/LoginUser.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Rewrite(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}