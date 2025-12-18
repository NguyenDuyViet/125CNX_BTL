using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Service;

namespace _125CNX_ECommerce.Controllers
{
    public class XmlExportController : Controller
    {
        private readonly SqlToXmlService _xmlService;

        public XmlExportController()
        {
            _xmlService = new SqlToXmlService();
        }

        // GET: /XmlExport
        public async Task<IActionResult> Index()
        {
            try
            {
                var stats = await _xmlService.GetTableStatsAsync();
                return View(stats);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi tải thống kê: {ex.Message}";
                return View(new Dictionary<string, int>());
            }
        }

        // POST: /XmlExport/ExportTable
        [HttpPost]
        public async Task<IActionResult> ExportTable(string tableName)
        {
            try
            {
                string xmlContent = await _xmlService.ExportTableToXmlAsync(tableName);
                
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xmlContent);
                return File(bytes, "application/xml", $"{tableName}.xml");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi export bảng {tableName}: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // POST: /XmlExport/ExportAll
        [HttpPost]
        public async Task<IActionResult> ExportAll()
        {
            try
            {
                string tempDir = Path.Combine(Path.GetTempPath(), "XmlExport_" + DateTime.Now.Ticks);
                
                bool success = await _xmlService.ExportAllTablesToXmlFilesAsync(tempDir);
                
                if (success)
                {
                    // Tạo file ZIP chứa tất cả XML
                    string zipPath = Path.Combine(Path.GetTempPath(), $"DatabaseExport_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
                    System.IO.Compression.ZipFile.CreateFromDirectory(tempDir, zipPath);
                    
                    // Xóa thư mục tạm
                    Directory.Delete(tempDir, true);
                    
                    // Trả về file ZIP
                    byte[] zipBytes = await System.IO.File.ReadAllBytesAsync(zipPath);
                    System.IO.File.Delete(zipPath);
                    
                    return File(zipBytes, "application/zip", $"DatabaseExport_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
                }
                else
                {
                    TempData["Error"] = "Có lỗi xảy ra khi export dữ liệu";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi export tất cả: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: /XmlExport/Preview/{tableName}
        public async Task<IActionResult> Preview(string tableName)
        {
            try
            {
                string xmlContent = await _xmlService.ExportTableToXmlAsync(tableName);
                ViewBag.TableName = tableName;
                ViewBag.XmlContent = xmlContent;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi preview bảng {tableName}: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}