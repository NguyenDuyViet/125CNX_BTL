using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Service
{
    class ProductService
    {
        private ProductDao product;

        public ProductService()
        {
            product = new ProductDao();
        }
        //Hàm lấy tất cả các sản phẩm
        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await product.GetAllProduct();
        }
        
        //Update Product
        public async Task<Boolean> UpdateProduct(ProductModel pdm)
        {
           return await product.UpdateProduct(pdm);
        }

        //Add Product
        public async Task<Boolean> AddProduct(ProductModel pdm)
        {
           return await product.AddProduct(pdm);
        }

        //Delete Product
        public async Task<Boolean> DeleteProduct(int MaSP)
        {
            return await product.DeleteProduct(MaSP);
        }

        //Lấy danh mục sản phẩm
        public async Task<List<CategoriesModel>> GetAllCategories()
        {
            return await product.GetAllCategories();
        }

        //Import XML to SQL
        public async Task<bool> ImportXmlToSql()
        {
            return await product.SyncXmlToSql();
        }
    }
}
