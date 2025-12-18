using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using System.Data;

namespace ShoeShop.Service
{
    class DonHangService
    {
        private DonHangDao donhang;
        public DonHangService()
        {
            donhang = new DonHangDao();
        }
		public List<DonHangModel> GetAllDonHang()
		{
			return donhang.GetAllDonHang();
		}

        public async Task<bool> UpdateStatus(int MaDH, string status)
        {
            return donhang.UpdateStatus(MaDH, status);
        }

        public ChiTietDonHangModel GetChiTietByMaDH(int MaDH)
        {
            ChiTietDonHangModel chitiet = donhang.GetChiTietByMaDH(MaDH);
            return chitiet;
        }

        public async Task<bool> ImportXmlToSql()
        {
            return await donhang.SyncXmlToSql();
        }
	}
}
