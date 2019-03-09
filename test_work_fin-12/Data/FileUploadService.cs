using System.IO;
using Microsoft.AspNetCore.Http;

namespace test_work_fin_12.Data {
    public class FileUploadService {

        public async void Upload (string path, string fileName, IFormFile file) {
            Directory.CreateDirectory (path);
            using (var stream = new FileStream (Path.Combine (path, fileName), FileMode.Create)) {
                await file.CopyToAsync (stream);
            }
        }
    }
}