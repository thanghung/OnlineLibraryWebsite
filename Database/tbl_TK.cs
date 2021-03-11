using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_TK
    {
        ThuVienTruongEntities db = new ThuVienTruongEntities();

        //Thay đổi tài khoản
        public void Update(DangNhap obj)
        {
            db.DangNhaps.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //Kiểm tra đăng nhập
        public DangNhap CheckKey(string user, string mk)
        {
            return db.DangNhaps.Where(x => x.UserTK == user && x.MK == mk).SingleOrDefault();
        }

       
    }
}