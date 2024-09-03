using MauiLib1.Model.Dto;

namespace MauiLib1.IService.Image
{
    public interface IImageService
    {
        Task<OriginalFileDto> ImportProcessAsync(FileResult file);

        Task<(int Height, int Width)> GetProcessImgWH(Stream imageStream);
    }
}
