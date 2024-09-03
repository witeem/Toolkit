using MauiLib1.IService.Image;
using MauiLib1.Model.Dto;
using SkiaSharp;

namespace MauiLib1.Service.Image
{
    public class ImageService : IImageService
    {
        public async Task<OriginalFileDto> ImportProcessAsync(FileResult file)
        {
            if (file != null)
            {
                if (file.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    file.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await file.OpenReadAsync();
                    var OriFile = new OriginalFileDto
                    {
                        FileName = file.FileName,
                        FullPath = file.FullPath,
                        FileType = file.ContentType,
                        FileSize = (stream.Length / 1024m).ToString("F2") + " KB",
                    };

                   await StreamProcess(stream, OriFile);
                    OriFile.ImageSource = ImageSource.FromStream(() => new MemoryStream(OriFile.Source));
                    return OriFile;
                }
            }

            return null;
        }

        public async Task<(int Height, int Width)> GetProcessImgWH(Stream imageStream)
        {
            using var skBitmap = SKBitmap.Decode(imageStream);
            var wh = (skBitmap.Height, skBitmap.Width);
            return await Task.FromResult(wh);
        }

        #region private

        private async Task StreamProcess(Stream stream, OriginalFileDto file)
        {
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var result = memoryStream.ToArray();
            memoryStream.Position = 0;

            using var skBitmap = SKBitmap.Decode(memoryStream);
            var wh = (skBitmap.Height, skBitmap.Width);

            file.Width = wh.Width;
            file.Height = wh.Height;
            file.Source = result;
        }
        #endregion
    }
}
