using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Service
{
    class HoaDonService
    {
        private readonly HoaDonDao hoadon;

        public HoaDonService()
        {
            hoadon = new HoaDonDao();
        }

        public async Task<List<HoaDonModel>> GetAllHoaDon()
        {
            // Validate và fix data consistency trước khi load
            await hoadon.ValidateAndFixDataConsistency();
            return await hoadon.GetAllHoaDon();
        }

		internal async Task<ChiTietHoaDonModel> GetChiTietByMaHD(int maHD)
		{
            return await hoadon.GetChiTietByMaHD(maHD);
		}
	}
}
