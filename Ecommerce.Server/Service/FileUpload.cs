using Ecommerce.Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace Ecommerce.Server.Service;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public bool DeleteFile(string? filePath)
    {
        if (!File.Exists(_webHostEnvironment.WebRootPath + filePath)) return false;
        File.Delete(_webHostEnvironment.WebRootPath + filePath);
        return true;
    }

    public async Task<string> UploadFile(IBrowserFile file)
    {
        FileInfo fileInfo = new(file.Name);
        var fileName = Guid.NewGuid() + fileInfo.Extension;
        var folderDirectory = $"{_webHostEnvironment.WebRootPath}/images/product";
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }
        var filePath = Path.Combine(folderDirectory, fileName);

        await using FileStream fs = new(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);

        return $"/images/product/{fileName}";
        
    }
} 