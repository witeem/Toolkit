using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    public partial class DogsViewModel : ObservableObject
    {
        readonly IConnectivity connectivity;

        public DogsViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;
            ImportImageCommand = new AsyncRelayCommand(ImportImageAsync);

            if (ImportedImage == null) ImportedImage = ImageSource.FromFile("img_bg.png");
        }

        [ObservableProperty]
        public ImageSource importedImage;

        [ObservableProperty]
        public string imageName;

        [ObservableProperty]
        public string imagePath;

        public ICommand ImportImageCommand { get; }

        public async Task ImportImageAsync()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions { 
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Please select an image"
                });

                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        ImageName = result.FileName;
                        ImagePath = result.FullPath;
                        using var stream = await result.OpenReadAsync();
                        byte[] imageData = await ConvertStreamToByteArrayAsync(stream);

                        ImportedImage = ImageSource.FromStream(() => new MemoryStream(imageData));
                    }
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }

        private async Task<byte[]> ConvertStreamToByteArrayAsync(Stream stream)
        {
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
