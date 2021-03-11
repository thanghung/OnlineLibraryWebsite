using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_NXB
    {
        ThuVienTruongEntities db = new ThuVienTruongEntities();

        #region Hiển Thị,Thêm, Xóa, Sửa Dữ Liệu
        //Hiển Thị dữ liệu
        public List<NhaXuatBan> GetAllData()
        {
            return db.NhaXuatBans.OrderBy(x => x.TenNXB).ToList();
        }

        //Them du lieu 
        public NhaXuatBan Insert(NhaXuatBan obj)
        {

            db.NhaXuatBans.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(NhaXuatBan obj)
        {
            db.NhaXuatBans.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //xoa du lieu
        public void Delete(NhaXuatBan obj)
        {

            db.NhaXuatBans.Attach(obj);
            db.NhaXuatBans.Remove(obj);
            db.SaveChanges();
        }
        #endregion

        #region Lấy dữ liệu sách
        //Lấy dữ liệu sách qua id
        public NhaXuatBan GetByID(string id)
        {
            return db.NhaXuatBans.Where(x => x.MaNXB == id).SingleOrDefault();
        }


        //Lấy dữ liệu sách qua Ten
        public NhaXuatBan GetByName(string id)
        {
            return db.NhaXuatBans.Where(x => x.TenNXB.ToUpper() == id.ToUpper()).SingleOrDefault();
        }

        //Lấy danh sách nhóm
        public List<NhaXuatBan> GetListByName(string id)
        {
            return db.NhaXuatBans.Where(x => x.TenNXB.ToUpper().IndexOf(id.ToUpper().Trim()) != -1).ToList();
        }
        #endregion
    }
}