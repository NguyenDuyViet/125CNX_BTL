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
		public async Task<List<DonHangModel>> GetAllDonHang()
		{
			return await donhang.GetAllDonHang();
		}

        public async Task<bool> UpdateStatus(int MaDH, string status)
        {
            return donhang.UpdateStatus(MaDH, status);
        }

        public async Task<ChiTietDonHangModel> GetChiTietByMaDH(int MaDH)
        {
            ChiTietDonHangModel chitiet = await donhang.GetChiTietByMaDH(MaDH);
            return chitiet;
        }
	}
}
