using System.Threading.Tasks;
using CloudinaryDotNet.Actions;


namespace WebAPI.Interface
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
