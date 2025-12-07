using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Matgr.UI.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> DeleteBlob(string blobName, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> UploadBlob(string blobName, IFormFile file, string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            //checking if file exists
            //if the file exists it will be replaced
            //if it doesn't exist it will create a temp space until it is uploaded

            var blobClient = containerClient.GetBlobClient(Guid.NewGuid() + blobName);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };
            await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
