using MauiApp1.ViewModel;

namespace MauiApp1.Pages;

public partial class CatsPage : ContentPage
{
	public CatsPage(CatsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}