using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach
{
    public class tbl_MuonTra
    {

        ThuVienTruongEntities db = new ThuVienTruongEntities();

        #region Hiển Thị,Thêm, Xóa, Sửa Dữ Liệu
        //Hiển Thị dữ liệu
        public List<DangKyMuon> GetAllData()
        {
            return db.DangKyMuons.ToList();
        }

        //Loc Du Lieu
        public List<DangKyMuon> LocDuLieu(string tinhtrang)
        {
            return db.DangKyMuons.Where(x => x.TinhTrang == tinhtrang).ToList();
        }

        //Them du lieu 
        public DangKyMuon Insert(DangKyMuon obj)
        {

            db.DangKyMuons.Add(obj);
            db.SaveChanges();
            return obj;
        }

        //Cap nhap du lieu
        public void Update(DangKyMuon obj)
        {
            db.DangKyMuons.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //xoa du lieu
        public void Delete(DangKyMuon obj)
        {

            db.DangKyMuons.Attach(obj);
            db.DangKyMuons.Remove(obj);
            db.SaveChanges();
        }
        #endregion

        #region Lấy dữ liệu tài khoản
        //Lấy dữ liệu sách qua Ma Muon
        public DangKyMuon GetByID(string id)
        {
            return db.DangKyMuons.Where(x => x.MaMuon == id.Trim()).SingleOrDefault();
        }

        //Lấy danh sách dữ liệu sách qua Ma The
        public List<DangKyMuon> GetListByIDUser(string id)
        {
            return db.DangKyMuons.Where(x => x.MaThe == id.Trim()).OrderByDescending(x => x.NgayMuon).ToList();
        }

        //Lấy danh sách dữ liệu sách qua Ma sach
        public List<DangKyMuon> GetListByIDBook(string id)
        {
            return db.DangKyMuons.Where(x => x.MaSach == id.Trim()).ToList();
        }

        //Đếm tình trạng
        public int GetByCount()
        {
            List<DangKyMuon> li_mt = db.DangKyMuons.Where(x => x.TinhTrang == "Đang Chờ").ToList();
            return li_mt.Count();
        }

       
        public DangKyMuon KTdulieuSV(string MaSV)
        {
            return db.DangKyMuons.Where(x => x.MaThe == MaSV && x.TinhTrang != "Đã Trả").SingleOrDefault();
        }
        #endregion
    }
}