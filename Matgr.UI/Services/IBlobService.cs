namespace Matgr.UI.Services
{
    public interface IBlobService
    {
        Task<string> UploadBlob(string blobName, IFormFile file, string containerName);
        Task<bool> DeleteBlob(string blobName, string containerName);
    }
}
