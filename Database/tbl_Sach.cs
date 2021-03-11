using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_Sach
    {
        ThuVienTruongEntities db = new ThuVienTruongEntities();

        #region Hiển Thị,Thêm, Xóa, Sửa Dữ Liệu

        //Hiển Thị dữ liệu
        public List<Sach> GetAllData()
        {
            return db.Saches.OrderBy(x => x.TenSach).ToList();
        }

        //Them du lieu 
        public Sach Insert(Sach obj)
        {

            db.Saches.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(Sach obj)
        {
            db.Saches.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //xoa du lieu
        public void Delete(Sach obj)
        {

            db.Saches.Attach(obj);
            db.Saches.Remove(obj);
            db.SaveChanges();
        }
        #endregion

        //Lấy dữ liệu sách qua Mã
        public Sach GetByID(string id)
        {
            return db.Saches.Where(x => x.MaSach == id).SingleOrDefault();
        }

        //Lấy dữ liệu sách qua Tên
        public Sach GetByName(string name)
        {
            return db.Saches.Where(x => x.TenSach == name.Trim()).SingleOrDefault();
        }

        //Trả về tên sách
        public List<string> SearchSach(string name)
        {
            List<Sach> li_sach = db.Saches.Where(x => x.TenSach.ToUpper().Trim().IndexOf(name.ToUpper().Trim()) != -1).ToList();

            List<string> li_ten = new List<string>();
            foreach (Sach sach in li_sach)
                li_ten.Add(sach.TenSach);

            return li_ten;
        }

        //trả về đối tượng sách
        public List<Sach> SearchSachObj(string name)
        {
            return db.Saches.Where(x => x.TenSach.ToUpper().Trim().IndexOf(name.ToUpper().Trim()) != -1).ToList();
        }

        //trả về đối tượng sách theo nhóm
        public List<Sach> GroupBook(string name)
        {
            return db.Saches.Where(x => x.NhomSach == name.Trim()).ToList();
        }
    }
}