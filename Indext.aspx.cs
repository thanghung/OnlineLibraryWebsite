using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienSach
{
    public partial class Indext2 : System.Web.UI.Page
    {
        tbl_Sach tbl_sach = new tbl_Sach();

        int CurrentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["ID"] != null)
            {
                Panel1.Visible = false;
                PlaceHolder1.Controls.Add(LoadControl("~/PagesShow/FormItems.ascx"));
            }
            if(Page.RouteData.Values["modul"] != null)
            {
                string id = Page.RouteData.Values["modul"].ToString().Trim();
                Panel1.Visible = false;

                switch(id)
                {
                    case "ttsv":
                        PlaceHolder1.Controls.Add(LoadControl("~/PagesShow/HoSo.ascx"));
                        break;
                    case "gs":
                        PlaceHolder1.Controls.Add(LoadControl("~/PagesShow/GioSach.ascx"));
                        break;
                    default:
                        PlaceHolder1.Controls.Add(LoadControl("~/PagesShow/NhomSach.ascx"));
                        break;
                }    
               
            }
            else
            {
                if (!IsPostBack)
                {
                    ViewState["vs"] = 0;
                    CurrentPage = (int)ViewState["vs"];

                    DatalistPaging();
                }
            }
           
        }

        public void DatalistPaging()
        {
            PagedDataSource PD = new PagedDataSource();
            PD.DataSource = tbl_sach.GetAllData();

            PD.PageSize = 21;
            PD.AllowPaging = true;
            PD.CurrentPageIndex = CurrentPage;
            
            if (PD.PageCount > 1)
            {
                Repeater1.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();

                    int cout = 0;
                    for (int i = CurrentPage - 5; i <= CurrentPage + 10; i++)
                    {
                        if (i > PD.PageCount)
                            break;

                        if (i > 0)
                        {
                            if (cout < 10)
                            {
                                cout++;
                                pages.Add(i.ToString());
                            }
                            else
                                break;
                        }
                    }

                
                Repeater1.DataSource = pages;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }

            DataList1.DataSource = PD;
            DataList1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CurrentPage = (int)ViewState["vs"];
            CurrentPage = Convert.ToInt32(e.CommandArgument) - 1;
            ViewState["vs"] = CurrentPage;
            DatalistPaging();
        }

        protected void btnID_Command(object sender, CommandEventArgs e)
        {
            string Url;
            Url = "/ThongTinSach/" + e.CommandArgument.ToString().Trim();
            Response.Redirect(Url);
        }
    }
}