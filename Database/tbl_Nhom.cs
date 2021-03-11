using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_Nhom
    {
        ThuVienTruongEntities db = new ThuVienTruongEntities();

        #region Hiển Thị,Thêm, Xóa, Sửa Dữ Liệu
        //Hiển Thị dữ liệu
        public List<NhomSach> GetAllData()
        {
            return db.NhomSaches.OrderBy(x => x.TenNhom).ToList();
        }

        //Them du lieu 
        public NhomSach Insert(NhomSach obj)
        {

            db.NhomSaches.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(NhomSach obj)
        {
            db.NhomSaches.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //xoa du lieu
        public void Delete(NhomSach obj)
        {

            db.NhomSaches.Attach(obj);
            db.NhomSaches.Remove(obj);
            db.SaveChanges();
        }
        #endregion

        #region Lấy dữ liệu sách
        //Lấy dữ liệu sách qua id
        public NhomSach GetByID(string id)
        {
            return db.NhomSaches.Where(x => x.MaNhom == id).SingleOrDefault();
        }


        //Lấy dữ liệu sách qua Ten
        public NhomSach GetByName(string id)
        {
            return db.NhomSaches.Where(x => x.TenNhom.ToUpper() == id.ToUpper()).SingleOrDefault();
        }

        //Lấy danh sách nhóm
        public List<NhomSach> GetListByName(string id)
        {
            return db.NhomSaches.Where(x => x.TenNhom.ToUpper().IndexOf(id.ToUpper().Trim()) != -1).ToList();
        }
        #endregion
    }
}