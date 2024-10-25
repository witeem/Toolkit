using MauiApp1.ViewModel;

namespace MauiApp1.Pages;

public partial class ImgFormat : ContentPage
{
	public ImgFormat(ImgFormatViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}