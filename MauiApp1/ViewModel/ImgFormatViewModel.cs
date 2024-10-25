using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib1.IService.Image;
using MauiLib1.Model.Dto;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    public partial class ImgFormatViewModel : ObservableObject
    {
        private readonly IImageService _imageService;
        readonly IConnectivity connectivity;

        public ImgFormatViewModel(IConnectivity connectivity, IImageService imageService)
        {
            this.connectivity = connectivity;
            _imageService = imageService;
            ImportImageCommand = new AsyncRelayCommand(ImportImageAsync);

            if (ImportedImage == null) ImportedImage = ImageSource.FromFile("img_bg.png");
        }

        [ObservableProperty]
        public ImageSource importedImage;

        [ObservableProperty]
        public OriginalFileDto oriFile;

        [ObservableProperty]
        public OutputFileDto outputFile;

        [ObservableProperty]
        public string outPutPath;

        public ICommand ImportImageCommand { get; }

        public async Task ImportImageAsync()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions { 
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Please select an image"
                });

                var imageSource = await _imageService.ImportProcessAsync(result);
                if (imageSource != null) OriFile = imageSource;

                if (OriFile != null)
                {
                    ImportedImage = OriFile.ImageSource;
                    OutputFile = new OutputFileDto
                    {
                        FileName = OriFile.FileName,
                        FullPath = OriFile.FullPath,
                        FileType = OriFile.FileType,
                        FileSize = OriFile.FileSize,
                        Width = OriFile.Width,
                        Height = OriFile.Height,
                        Source = OriFile.Source,
                        ImageSource = OriFile.ImageSource
                    };
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }
    }
}
