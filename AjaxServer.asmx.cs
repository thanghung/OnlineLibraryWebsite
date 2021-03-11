using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ThuVienSach
{
    /// <summary>
    /// Summary description for AjaxServer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AjaxServer : System.Web.Services.WebService
    {
        tbl_Sach tbl_sach = new tbl_Sach();
        tbl_User tbl_user = new tbl_User();

        [WebMethod]
        public List<string> GetItemNhomSach(string Name)
        {
            return QL_Nhom.GetItem(Name);
        }

        [WebMethod]
        public List<string> GetItemNXB(string Name)
        {
            return QL_NXB.GetItem(Name);
        }

        [WebMethod]
        public List<string> GetItemsach(string Name)
        {
            return tbl_sach.SearchSach(Name);
        }

        [WebMethod]
        public List<string> GetItemUser(string Name)
        {
            return tbl_user.GetListByID(Name);
        }
    }
}
