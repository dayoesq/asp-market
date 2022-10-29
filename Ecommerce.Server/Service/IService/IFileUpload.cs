using Microsoft.AspNetCore.Components.Forms;

namespace Ecommerce.Server.Service.IService;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);

    bool DeleteFile(string filePath);
}