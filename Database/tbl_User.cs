using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_User
    {
        ThuVienTruongEntities db = new ThuVienTruongEntities();

        #region Hiển Thị,Thêm, Xóa, Sửa Dữ Liệu
        //Hiển Thị dữ liệu
        public List<UserDN> GetAllData()
        {
            return db.UserDNs.OrderBy(x => x.TenSV).ToList();
        }

        //Them du lieu 
        public UserDN Insert(UserDN obj)
        {

            db.UserDNs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(UserDN obj)
        {
            db.UserDNs.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //xoa du lieu
        public void Delete(UserDN obj)
        {

            db.UserDNs.Attach(obj);
            db.UserDNs.Remove(obj);
            db.SaveChanges();
        }
        #endregion

        #region Lấy dữ liệu tài khoản
        //Lấy dữ liệu sách qua Ma The
        public UserDN GetByID(string id)
        {
            return db.UserDNs.Where(x => x.MaThe == id.Trim()).SingleOrDefault();
        }

        //Lấy danh sách dữ liệu sách qua Ma The
        public List<string> GetListByID(string id)
        {
            List<UserDN> li_user =  db.UserDNs.Where(x => x.MaThe.ToUpper().Trim().IndexOf(id.Trim().ToUpper()) != -1).ToList();
            List<string> li_Ma = new List<string>();

            foreach (UserDN items in li_user)
                li_Ma.Add(items.MaThe);

            return li_Ma;
        }

        //Kiểm tra đăng nhập
        public UserDN CheckUser(string user, string mk)
        {
            return db.UserDNs.Where(x => x.UserTK == user && x.MK == mk).SingleOrDefault();
        }

        //Kiểm tra đăng nhập
        public UserDN CheckKey(string user)
        {
            return db.UserDNs.Where(x => x.UserTK == user).SingleOrDefault();
        }
        #endregion
    }
}