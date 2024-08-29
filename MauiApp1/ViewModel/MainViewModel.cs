using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib1.Model.Dto;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        readonly IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<MainItemDto> { 
                new MainItemDto { Key="1", Title = "DogsPage", Description = "Description 1", ImageUrl = "dog.png", Detail = "Detail 1" },
                new MainItemDto { Key="2", Title = "CatsPage", Description = "Description 2", ImageUrl = "cat.png", Detail = "Detail 2" }
            };
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<MainItemDto> items;

        [RelayCommand]
        async Task Add()
        {
            await Task.CompletedTask;
        }

        [RelayCommand]
        void OnPanUpdated(PanUpdatedEventArgs e)
        {
            switch (e.StatusType) 
            {
                case GestureStatus.Started:
                    break;

                case GestureStatus.Running:
                    break;

                case GestureStatus.Completed:
                    break;
            }
        }
    }
}
