using MauiApp1.ViewModel;

namespace MauiApp1.Pages;

public partial class DogsPage : ContentPage
{
	public DogsPage(DogsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}