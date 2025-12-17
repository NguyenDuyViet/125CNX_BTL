using Microsoft.Data.SqlClient;
using System.Xml.Linq;
using System.Text;

namespace _125CNX_ECommerce.Service
{
    public class SqlToXmlService
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

        public async Task<string> ExportTableToXmlAsync(string tableName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM {tableName}";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    await conn.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    XDocument doc = new XDocument();
                    XElement root = new XElement(tableName + "s");
                    doc.Add(root);

                    while (await reader.ReadAsync())
                    {
                        XElement row = new XElement(tableName);
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            object value = reader.GetValue(i);
                            
                            XElement column = new XElement(columnName, 
                                value == DBNull.Value ? "" : value.ToString());
                            row.Add(column);
                        }
                        
                        root.Add(row);
                    }

                    return doc.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi export bảng {tableName}: {ex.Message}");
            }
        }

        public async Task<bool> ExportAllTablesToXmlFilesAsync(string outputDirectory)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(outputDirectory))
                    Directory.CreateDirectory(outputDirectory);

                // Danh sách các bảng cần export
                string[] tables = {
                    "Categories", "Products", "Users", "Roles",
                    "GioHang", "Wishlist", "DonHang", "ChiTietDonHang",
                    "HoaDon", "ChiTietHoaDon", "ThanhToan"
                };

                foreach (string table in tables)
                {
                    try
                    {
                        string xmlContent = await ExportTableToXmlAsync(table);
                        string filePath = Path.Combine(outputDirectory, $"{table}.xml");
                        
                        await File.WriteAllTextAsync(filePath, xmlContent, Encoding.UTF8);
                        Console.WriteLine($"Exported {table} to {filePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi export bảng {table}: {ex.Message}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tổng quát: {ex.Message}");
                return false;
            }
        }

        public async Task<Dictionary<string, int>> GetTableStatsAsync()
        {
            var stats = new Dictionary<string, int>();
            
            string[] tables = {
                "Categories", "Products", "Users", "Roles",
                "GioHang", "Wishlist", "DonHang", "ChiTietDonHang",
                "HoaDon", "ChiTietHoaDon", "ThanhToan"
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                
                foreach (string table in tables)
                {
                    try
                    {
                        string query = $"SELECT COUNT(*) FROM {table}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        stats[table] = count;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi đếm bảng {table}: {ex.Message}");
                        stats[table] = 0;
                    }
                }
            }

            return stats;
        }
    }
}