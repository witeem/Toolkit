namespace MauiLib1.Model.Dto
{
    public class OriginalFileDto
    {
        public string FileName { get; set; }

        public string FullPath { get; set; }

        public string FileSize { get; set; } = "0 KB";

        public string FileType { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public byte[] Source { get; set; }

        public ImageSource ImageSource { get; set; }
    }
}
